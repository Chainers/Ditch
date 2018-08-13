using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using Ditch.Core;
using Ditch.Core.JsonRpc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.BitShares.Tests
{
    public class BaseTest
    {
        protected static UserInfo User;
        protected static OperationManager Api;
        protected HttpManager HttpManager;
        protected HttpClient HttpClient;
        protected string SbdSymbol = "BTS";

        [OneTimeSetUp]
        protected virtual void OneTimeSetUp()
        {
            if (User == null)
            {
                User = new UserInfo
                {
                    Login = ConfigurationManager.AppSettings["Login"],
                    ActiveWif = ConfigurationManager.AppSettings["ActiveWif"],
                    OwnerWif = ConfigurationManager.AppSettings["OwnerWif"]
                };
                Assert.IsFalse(string.IsNullOrEmpty(User.ActiveWif), "empty ActiveWif");
            }

            if (Api == null)
            {
                HttpManager = new HttpManager();
                Api = new OperationManager(HttpManager);

                var url = ConfigurationManager.AppSettings["Url"];
                Assert.IsTrue(Api.ConnectTo(url, CancellationToken.None).Result, "Enable connect to node");

                var acc = Api.GetAccountByName(User.Login, CancellationToken.None).Result;
                Assert.IsFalse(acc.IsError);
                User.Account = acc.Result;
            }

            Assert.IsTrue(Api.IsConnected, "Enable connect to node");
        }

        protected void TestPropetries<T>(JsonRpcResponse<T> resp)
        {
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            if (resp.RawResponse.Contains("\"result\":{"))
            {
                var jResult = JsonConvert.DeserializeObject<JsonRpcResponse<JObject>>(resp.RawResponse).Result;
                Compare(typeof(T), jResult);
            }
            else
            {
                var jResult = JsonConvert.DeserializeObject<JsonRpcResponse<JArray>>(resp.RawResponse).Result;

                if (jResult == null)
                    throw new NullReferenceException("obj.Result");

                var type = typeof(T);
                if (type.IsArray) //list
                {
                    type = type.GetElementType();
                    var jObj = jResult.First.Value<JObject>();
                    Compare(type, jObj);
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
                        Compare(t, jResult[i].Value<JObject>());
                    }
                }
            }
        }

        private void Compare(Type type, JObject jObj)
        {
            var propNames = GetPropertyNames(type);
            var jNames = jObj.Properties().Select(p => p.Name);

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
                    Console.WriteLine(JsonConvert.SerializeObject(r.ResponseError, Formatting.Indented));
                if (r.Exception != null)
                    Console.WriteLine(r.Exception.ToString());
            }
            else
            {
                Console.WriteLine("Result:");
                Console.WriteLine(JsonConvert.SerializeObject(r.Result, Formatting.Indented));
            }

            Console.WriteLine("Request:");
            Console.WriteLine(JsonBeautify(r.RawRequest));
            Console.WriteLine("Response:");
            Console.WriteLine(JsonBeautify(r.RawResponse));
        }

        private string JsonBeautify(string json)
        {
            if (string.IsNullOrEmpty(json))
                return json;
            var obj = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}