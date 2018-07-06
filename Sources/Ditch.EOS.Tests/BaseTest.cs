using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.EOS.Tests.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.EOS.Tests
{
    public class BaseTest
    {
        protected static UserInfo User;
        protected static ContractInfo ContractInfo;

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
                    PublicOwnerWif = ConfigurationManager.AppSettings["PublicOwnerWif"],
                    PrivateOwnerWif = ConfigurationManager.AppSettings["PrivateOwnerWif"],
                    PublicActiveWif = ConfigurationManager.AppSettings["PublicActiveWif"],
                    PrivateActiveWif = ConfigurationManager.AppSettings["PrivateActiveWif"],
                    Password = ConfigurationManager.AppSettings["Password"],
                };
            }

            if (ContractInfo == null)
            {
                ContractInfo = new ContractInfo
                {
                    ContractName = ConfigurationManager.AppSettings["ContractName"],
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
                Console.WriteLine(JsonConvert.SerializeObject(r.Error, Formatting.Indented));
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

        protected void WriteLine<T>(T r)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine(JsonConvert.SerializeObject(r, Formatting.Indented));
        }
    }
}