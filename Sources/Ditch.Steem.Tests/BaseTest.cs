using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Threading;
using Ditch.Core;
using System.Globalization;
using Ditch.Steem.Helpers;

namespace Ditch.Steem.Tests
{
    public class BaseTest
    {
        protected const string AppVersion = "ditch / 2.2.12";

        private bool IgnoreRequestWithBadData = true;
        protected readonly UserInfo User;
        protected readonly OperationManager Api;
        protected int Version;
        protected string SbdSymbol = "SBD";

        public BaseTest()
        {
            User = new UserInfo { Login = ConfigurationManager.AppSettings["Login"], PostingWif = ConfigurationManager.AppSettings["PostingWif"], ActiveWif = ConfigurationManager.AppSettings["ActiveWif"] };
            Assert.IsFalse(string.IsNullOrEmpty(User.PostingWif));
            var jss = GetJsonSerializerSettings();
            var manager = new HttpManager(jss, 1024 * 1024);
            Api = new OperationManager(manager, jss);
            var connectedTo = Api.TryConnectTo(new List<string> { ConfigurationManager.AppSettings["Url"] }, CancellationToken.None);
            Assert.IsFalse(string.IsNullOrEmpty(connectedTo));

            var response = Api.GetHardforkVersion(CancellationToken.None);
            Assert.IsFalse(response.IsError);
            Version = VersionHelper.ToInteger(response.Result);
        }

        protected static JsonSerializerSettings GetJsonSerializerSettings()
        {
            var rez = new JsonSerializerSettings
            {
                DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",
                Culture = CultureInfo.InvariantCulture
            };
            return rez;
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

        protected string GetMeta(string[] tags)
        {
            var tagsm = tags == null || !tags.Any() ? string.Empty : $"\"{string.Join("\",\"", tags)}\"";
            return $"{{\"app\": \"{AppVersion}\", \"tags\": [{tagsm}]}}";
        }
    }
}