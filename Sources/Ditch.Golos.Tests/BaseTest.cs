using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
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
        protected const string AppVersion = "ditch / 3.2.0-alpha";

        private const bool IgnoreRequestWithBadData = true;
        protected static UserInfo User;
        protected static OperationManager Api;


        [OneTimeSetUp]
        protected virtual void OneTimeSetUp()
        {
            if (User == null)
            {
                User = new UserInfo { Login = ConfigurationManager.AppSettings["Login"], PostingWif = ConfigurationManager.AppSettings["PostingWif"], ActiveWif = ConfigurationManager.AppSettings["ActiveWif"] };
            }
            Assert.IsFalse(string.IsNullOrEmpty(User.PostingWif), "empty PostingWif");

            if (Api == null)
            {
                var jss = GetJsonSerializerSettings();
                var manager = new WebSocketManager(jss, 1024 * 1024);
                Api = new OperationManager(manager, jss);

                var urls = new List<string> { ConfigurationManager.AppSettings["Url"] };
                Api.TryConnectTo(urls, CancellationToken.None);
            }

            Assert.IsTrue(Api.IsConnected, "Enable connect to node");
        }


        public static JsonSerializerSettings GetJsonSerializerSettings()
        {
            var rez = new JsonSerializerSettings
            {
                DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",
                Culture = CultureInfo.InvariantCulture
            };
            return rez;
        }

        protected void TestPropetries<T, T2>(JsonRpcResponse<T> resp, JsonRpcResponse<T2> obj)
        {
            WriteLine(resp);
            WriteLine(obj);

            Assert.IsFalse(resp.IsError);

            if (obj.Result == null)
                throw new NullReferenceException("obj.Result");

            var type = typeof(T);
            object jObj = obj.Result;
            if (type.IsArray || typeof(IEnumerable).IsAssignableFrom(type))
            {
                var jArray = jObj as JArray;
                if (jArray?.Count > 0)
                {
                    type = type.GetElementType();
                    jObj = jArray.First.Value<JObject>();
                }
                else
                {
                    var jObject = obj as JObject[];
                    if (jObject.Length > 0)
                    {
                        type = type.GetElementType();
                        jObj = jObject[0];
                    }
                    else if (!IgnoreRequestWithBadData)
                        throw new NullReferenceException("Impossible to do test for this input data!");
                }
            }

            var propNames = GetPropertyNames(type);

            var jNames = ((JObject)jObj).Properties().Select(p => p.Name);

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

        protected void WriteLine(string s)
        {
            Console.WriteLine("---------------");
            Console.WriteLine(s);
        }

        protected void WriteLine(JsonRpcResponse r)
        {
            Console.WriteLine("---------------");
            Console.WriteLine(r.IsError
                ? JsonConvert.SerializeObject(r.Error, Formatting.Indented)
                : JsonConvert.SerializeObject(r.Result, Formatting.Indented));
        }
    }
}