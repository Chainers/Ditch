using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using Ditch.Core;
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
        protected const string AppVersion = "ditch / 3.2.0-alpha";

        private const bool IgnoreRequestWithBadData = true;
        protected static UserInfo User;
        protected static OperationManager Api;
        protected string SbdSymbol = "SBD";
        protected CancellationToken token = CancellationToken.None;

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
                var manager = new HttpManager(jss, 1024 * 1024);
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

        protected void TestPropetries<T>(JsonRpcResponse<T> resp, JsonRpcResponse<JArray> obj)
        {
            WriteLine(resp);
            WriteLine(obj);

            Assert.IsFalse(resp.IsError);

            var jResult = obj.Result;

            if (jResult == null)
                throw new NullReferenceException("obj.Result");

            var type = typeof(T);
            if (type.IsArray) //list
            {
                type = type.GetElementType();
                var jObj = obj.Result.First.Value<JObject>();
                Compare(type, jObj);
            }
            else //dictionary
            {
                jResult = jResult.First().Value<JArray>();
                if (jResult == null)
                    throw new InvalidCastException(nameof(obj));

                while (type != null && !type.IsGenericType)
                {
                    type = type.BaseType;
                }

                if (type == null)
                    throw new InvalidCastException(nameof(obj));

                var types = type.GenericTypeArguments;

                if (types.Length != jResult.Count)
                {
                    throw new InvalidCastException(nameof(obj));
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

        protected void TestPropetries<T>(JsonRpcResponse<T> resp, JsonRpcResponse<JObject> obj)
        {
            WriteLine(resp);
            WriteLine(obj);

            Assert.IsFalse(resp.IsError);

            if (obj.Result == null)
                throw new NullReferenceException("obj.Result");

            Compare(typeof(T), obj.Result);
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

        protected string GetMeta(string[] tags)
        {
            var tagsm = tags == null || !tags.Any() ? string.Empty : $"\"{string.Join("\",\"", tags)}\"";
            return $"{{\"app\": \"{AppVersion}\", \"tags\": [{tagsm}]}}";
        }


        protected SignedTransaction GetSignedTransaction()
        {
            var user = User;
            const string autor = "steepshot";

            var op = new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            var prop = Api.GetDynamicGlobalProperties(CancellationToken.None);
            var transaction = Api.CreateTransaction(prop.Result, user.PostingKeys, CancellationToken.None, op);
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
            Console.WriteLine(r.IsError
                ? JsonConvert.SerializeObject(r.Error, Formatting.Indented)
                : JsonConvert.SerializeObject(r.Result, Formatting.Indented));
        }
    }
}