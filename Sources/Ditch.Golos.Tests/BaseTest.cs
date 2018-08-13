using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading;
using Ditch.Core;
using Ditch.Core.JsonRpc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Golos.Tests
{
    public class BaseTest
    {
        protected const string AppVersion = "ditch / 4.0.0-alpha";
        protected static UserInfo User;
        protected static OperationManager Api;
        protected WebSocketManager WebSocketManager;


        [OneTimeSetUp]
        protected virtual void OneTimeSetUp()
        {
            if (User == null)
            {
                User = new UserInfo
                {
                    Login = ConfigurationManager.AppSettings["Login"],
                    PostingWif = ConfigurationManager.AppSettings["PostingWif"],
                    ActiveWif = ConfigurationManager.AppSettings["ActiveWif"]
                };
            }

            Assert.IsFalse(string.IsNullOrEmpty(User.PostingWif), "empty PostingWif");

            if (Api == null)
            {
                WebSocketManager = new WebSocketManager();
                Api = new OperationManager(WebSocketManager);

                var url = ConfigurationManager.AppSettings["Url"];
                Assert.IsTrue(Api.ConnectTo(url, CancellationToken.None).Result, "Сan`t connect to the node");
            }

            Assert.IsTrue(Api.IsConnected, "Сan`t connect to the node");
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
                Assert.Fail(
                    $"Some properties ({msg.Count}) was missed! {Environment.NewLine} {string.Join(Environment.NewLine, msg)}");
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