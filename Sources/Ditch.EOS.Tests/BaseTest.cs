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

namespace Ditch.EOS.Tests
{
    public class BaseTest
    {
        protected static OperationManager Api;
        private const bool IgnoreRequestWithBadData = true;


        [OneTimeSetUp]
        protected virtual void OneTimeSetUp()
        {
            if (Api != null)
                return;

            Api = new OperationManager();
            var url = ConfigurationManager.AppSettings["Url"];
            Api.TryConnectTo(new List<string> { url }, CancellationToken.None);

            //Assert.IsTrue(Api.IsConnected, "Enable connect to node");
        }

        protected void TestPropetries<T, T2>(OperationResult<T> resp, OperationResult<T2> obj)
        {
            WriteLine(resp);
            WriteLine(obj);

            Assert.IsFalse(resp.IsError);

            if (obj.Result == null)
                throw new NullReferenceException("obj.Result");

            var type = typeof(T);
            object jObj = obj.Result;
            if (type.IsArray)
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

        protected void WriteLine(string s)
        {
            Console.WriteLine(s);
        }

        protected void WriteLine(JsonRpcResponse r)
        {
            Console.WriteLine(r.IsError
                ? JsonConvert.SerializeObject(r.Error, Formatting.Indented)
                : JsonConvert.SerializeObject(r.Result, Formatting.Indented));
        }

        protected void WriteLine<T>(OperationResult<T> r)
        {
            Console.WriteLine(r.IsError
                ? JsonConvert.SerializeObject(r.Error, Formatting.Indented)
                : JsonConvert.SerializeObject(r.Result, Formatting.Indented));
        }
    }
}