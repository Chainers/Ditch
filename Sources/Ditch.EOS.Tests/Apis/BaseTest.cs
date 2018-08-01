using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading;
using Ditch.Core.JsonRpc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.EOS.Tests.Apis
{
    public class BaseTest
    {
        protected static UserInfo User;

        protected static OperationManager Api;
        protected CancellationToken CancellationToken = CancellationToken.None;

        [OneTimeSetUp]
        protected virtual void OneTimeSetUp()
        {
            if (User == null)
            {
                User = new UserInfo
                {
                    Login = ConfigurationManager.AppSettings["Login"],
                    PrivateOwnerWif = ConfigurationManager.AppSettings["PrivateOwnerWif"],
                    PublicOwnerWif = ConfigurationManager.AppSettings["PublicOwnerWif"],
                    PrivateActiveWif = ConfigurationManager.AppSettings["PrivateActiveWif"],
                    PublicActiveWif = ConfigurationManager.AppSettings["PublicActiveWif"],
                    Password = ConfigurationManager.AppSettings["Password"]
                };
            }

            if (Api == null)
            {
                Api = new OperationManager
                {
                    ChainUrl = ConfigurationManager.AppSettings["ChainUrl"],
                    WalletUrl = ConfigurationManager.AppSettings["WalletUrl"]
                };
            }
        }

        protected void TestPropetries<T>(OperationResult<T> resp)
        {
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
            var jResult = JsonConvert.DeserializeObject<JObject>(resp.RawResponse);
            Compare(typeof(T), jResult);
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
            Console.WriteLine("--------------------");
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

        protected void WriteLine<T>(OperationResult<T> r)
        {
            Console.WriteLine("---------------");
            if (r.IsError)
            {
                Console.WriteLine("Error:");
                if (r.Error != null)
                    Console.WriteLine(r.Error.ToString());
            }
            else
            {
                Console.WriteLine("Result:");
                Console.WriteLine(JsonConvert.SerializeObject(r.Result, Formatting.Indented));
            }

            Console.WriteLine("Request:");
            Console.WriteLine(r.RawRequest);
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

        protected void WriteLine<T>(T r)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine(JsonConvert.SerializeObject(r, Formatting.Indented));
        }
    }
}