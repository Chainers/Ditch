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
        private const bool IgnoreRequestWithBadData = true;
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

        protected void TestPropetries<T>(OperationResult<T> resp, OperationResult<JArray> obj)
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

        protected void TestPropetries<T>(OperationResult<T> resp, OperationResult<JObject> obj)
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

        protected void WriteLine(string s)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine(s);
        }

        protected void WriteLine(JsonRpcResponse r)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine(r.IsError
                ? JsonConvert.SerializeObject(r.Error, Formatting.Indented)
                : JsonConvert.SerializeObject(r.Result, Formatting.Indented));
        }

        protected void WriteLine<T>(OperationResult<T> r)
        {
            Console.WriteLine("--------------------");

            if (r.IsError)
            {

#if DEBUG
                Console.WriteLine($"Request:{Environment.NewLine}\t{r.RawRequest}{Environment.NewLine}Response:{Environment.NewLine}\t{r.RawResponse}");
#else
                Console.WriteLine(JsonConvert.SerializeObject(r.Error, Formatting.Indented));
#endif
            }
            else
            {
                Console.WriteLine(JsonConvert.SerializeObject(r.Result, Formatting.Indented));
            }
        }

        protected void WriteLine<T>(T r)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine(JsonConvert.SerializeObject(r, Formatting.Indented));
        }
    }
}