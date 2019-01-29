using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Cryptography.ECDSA;
using Ditch.Core;
using Ditch.Core.Interfaces;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Models;
using Ditch.Steem.Operations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Steem.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected const string AppVersion = "ditch / 4.0.0-alpha";

        protected static UserInfo User;
        protected static OperationManager Api;
        protected HttpManager HttpManager;
        protected IHttpClient HttpClient;
        protected JsonSerializerSettings JsonSerializerSettings;

        [OneTimeSetUp]
        protected virtual void OneTimeSetUp()
        {
            // Used https://testnet.steem.vc for test

            if (User == null)
            {
                User = new UserInfo
                {
                    Login = ConfigurationManager.AppSettings["Login"] ?? "ditch.test",
                    PostingWif = ConfigurationManager.AppSettings["PostingWif"] ?? "5KX6QUwtxn2TvjxT7R6GXyjmHZpBFacCY9TV3T7Bg5YQ64V8bhy",
                    ActiveWif = ConfigurationManager.AppSettings["ActiveWif"] ?? "5JTQgtzuRTfDniVP24WnFro8ucGD3cFbgfp1Q9qX47gEywp9BU3"
                };
            }
            Assert.IsFalse(string.IsNullOrEmpty(User.PostingWif), "empty PostingWif");

            if (Api == null)
            {
                HttpClient = new RepeatHttpClient();
                HttpManager = new HttpManager(HttpClient);
                Api = new OperationManager(HttpManager);
                JsonSerializerSettings = Api.NewJsonSerializerSettings;

                Config.ChainId = Hex.HexToBytes(ConfigurationManager.AppSettings["ChainId"] ?? "79276aea5d4877d9a25892eaa01b0adf019d3e5cb12a97478df3298ccdd01673");
                Config.KeyPrefix = ConfigurationManager.AppSettings["KeyPrefix"] ?? "STX";
                var url = ConfigurationManager.AppSettings["Url"] ?? "https://testnet.steem.vc";
                Assert.IsTrue(Api.ConnectToAsync(url, CancellationToken.None).Result, "Enable connect to node");
            }

            Assert.IsTrue(Api.IsConnected, "Enable connect to node");
        }

        protected void TestPropetries<T>(JsonRpcResponse<T> resp, bool isCondenser = false)
        {
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            if (resp.RawResponse.Contains("\"result\":{"))
            {
                var jResult = JsonConvert.DeserializeObject<JsonRpcResponse<JObject>>(resp.RawResponse).Result;
                Compare(typeof(T), jResult, isCondenser);
            }
            else
            {
                var jResult = JsonConvert.DeserializeObject<JsonRpcResponse<JArray>>(resp.RawResponse).Result;

                if (jResult == null)
                    throw new NullReferenceException("obj.Result");

                if (jResult.Type == JTokenType.Array && jResult.First.Type == JTokenType.String)
                    return; // skeep string array

                var type = typeof(T);
                if (isCondenser)
                {
                    var props = type.GetRuntimeProperties().ToArray();
                    if (props.Length == 1)
                        type = props[0].PropertyType;
                }

                if (type.IsArray) //list
                {
                    type = type.GetElementType();
                    var jObj = jResult.First.Value<JObject>();
                    Compare(type, jObj, isCondenser);
                }
                else //dictionary
                {
                    jResult = jResult.First().Value<JArray>();
                    if (jResult == null)
                        throw new InvalidCastException(nameof(jResult));

                    while (type != null && !type.IsGenericType)
                    {
                        type = type.BaseType;
                    }

                    if (type == null)
                        throw new InvalidCastException(nameof(jResult));

                    var types = type.GenericTypeArguments;

                    if (types.Length != jResult.Count)
                    {
                        throw new InvalidCastException(nameof(jResult));
                    }

                    for (var i = 0; i < types.Length; i++)
                    {
                        var t = types[i];
                        if (t.IsPrimitive)
                            continue;
                        Compare(t, jResult[i].Value<JObject>(), isCondenser);
                    }
                }
            }
        }

        private void Compare(Type type, JObject jObj, bool isCondenser)
        {
            var propNames = GetPropertyNames(type);
            var jNames = jObj.Properties().Select(p => p.Name);

            if (isCondenser)
            {
                var props = type.GetRuntimeProperties().ToArray();
                if (props.Length == 1)
                {
                    Compare(props[0].PropertyType, jObj, false);
                    return;
                }
            }


            var msg = new List<string>();
            foreach (var name in jNames)
            {
                if (!propNames.Contains(name))
                {
                    msg.Add($"Missing {name}");
                }
            }

            if (msg.Any())
            {
                Assert.Fail($"Some properties ({msg.Count}) was missed! {Environment.NewLine} {string.Join(Environment.NewLine, msg)}");
            }
        }

        protected HashSet<string> GetPropertyNames(Type type)
        {
            var props = type.GetRuntimeProperties();
            var resp = new HashSet<string>();
            foreach (var prop in props)
            {
                var order = prop.GetCustomAttribute<JsonPropertyAttribute>();
                if (order != null)
                {
                    resp.Add(order.PropertyName);
                }
            }
            return resp;
        }

        protected string GetMeta(string[] tags)
        {
            var tagsm = tags == null || !tags.Any() ? string.Empty : $"\"{string.Join("\",\"", tags)}\"";
            return $"{{\"app\": \"{AppVersion}\", \"tags\": [{tagsm}]}}";
        }


        protected async Task<SignedTransaction> GetSignedTransaction()
        {
            var user = User;
            const string autor = "steepshot";

            var op = new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            var prop = await Api.GetDynamicGlobalPropertiesAsync(CancellationToken.None).ConfigureAwait(false);
            var transaction = await Api.CreateTransactionAsync(prop.Result, user.PostingKeys, op, CancellationToken.None).ConfigureAwait(false);
            return transaction;
        }

        protected void WriteLine(string s)
        {
            Console.WriteLine("---------------");
            Console.WriteLine(s);
        }

        protected void WriteLine(JsonRpcResponse r)
        {
            Console.WriteLine("---------------");
            if (r.IsError)
            {
                Console.WriteLine("Error:");
                if (r.ResponseError != null)
                    Console.WriteLine(JsonConvert.SerializeObject(r.ResponseError, Formatting.Indented, JsonSerializerSettings));
                if (r.Exception != null)
                    Console.WriteLine(r.Exception.ToString());
            }
            else
            {
                Console.WriteLine("Result:");
                Console.WriteLine(JsonConvert.SerializeObject(r.Result, Formatting.Indented, JsonSerializerSettings));
            }

            Console.WriteLine("Request:");
            Console.WriteLine(JsonBeautify(r.RawRequest));
            Console.WriteLine("Response:");
            Console.WriteLine(JsonBeautify(r.RawResponse));
        }

        protected string JsonBeautify(string json)
        {
            if (string.IsNullOrEmpty(json))
                return json;
            var obj = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}