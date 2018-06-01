using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading;
using Ditch.Core.JsonRpc;

namespace Ditch.EOS.Tests
{
    public class BaseTest
    {
        protected static OperationManager Api;
        private bool IgnoreRequestWithBadData = true;


        [OneTimeSetUp]
        protected virtual void OneTimeSetUp()
        {
            if (Api == null)
            {
                Api = new OperationManager();
                var url = ConfigurationManager.AppSettings["Url"];
                var connectedTo = Api.TryConnectTo(new List<string> { url }, CancellationToken.None);
            }

            //Assert.IsTrue(Api.IsConnected, "Enable connect to node");
        }

        protected void TestPropetries(Type type, JObject jObject)
        {
            var propNames = GetPropertyNames(type);
            var chSet = jObject.Children();

            var msg = new List<string>();
            foreach (JProperty jtoken in chSet)
            {
                if (!propNames.Contains(jtoken.Name))
                {
                    msg.Add($"Missing {jtoken}");
                }
            }

            if (msg.Any())
            {
                Assert.Fail($"Some properties ({msg.Count}) was missed! {Environment.NewLine} {string.Join(Environment.NewLine, msg)}");
            }
        }

        protected void TestPropetries(Type type, JArray jArray)
        {
            if (jArray == null)
                throw new NullReferenceException("jArray");

            if (type.IsArray)
            {
                if (jArray.Count > 0)
                    TestPropetries(type.GetElementType(), (JObject)jArray[0]);
                else if (!IgnoreRequestWithBadData)
                    throw new NullReferenceException("Impossible to do test for this input data!");
            }
            else
                throw new InvalidCastException();
        }

        protected void TestPropetries(Type type, JObject[] jObject)
        {
            if (jObject == null)
                throw new NullReferenceException("jObject");

            if (type.IsArray)
            {
                if (jObject.Length > 0)
                    TestPropetries(type.GetElementType(), jObject[0]);
                else if (!IgnoreRequestWithBadData)
                    throw new NullReferenceException("Impossible to do test for this input data!");
            }
            else
                throw new InvalidCastException();
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
            WriteLine(s);
        }

        protected void WriteLine(JsonRpcResponse r)
        {
            if (r.IsError)
                Console.WriteLine(JsonConvert.SerializeObject(r.Error, Formatting.Indented));
            else
                Console.WriteLine(JsonConvert.SerializeObject(r.Result, Formatting.Indented));
        }

        protected void WriteLine<T>(OperationResult<T> r)
        {
            if (r.IsSuccess)
                Console.WriteLine(JsonConvert.SerializeObject(r.Result, Formatting.Indented));
            else
                Console.WriteLine(JsonConvert.SerializeObject(r.Error, Formatting.Indented));
        }
    }
}