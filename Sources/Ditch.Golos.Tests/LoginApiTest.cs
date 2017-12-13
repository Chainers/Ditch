using System;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Golos.Tests
{
    [TestFixture]
    public class LoginApiTest : BaseTest
    {
        [Test]
        public void login()
        {
            var resp = Api.Login(User.Login, User.Wif, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_api_by_name()
        {
            var resp = Api.GetApiByName(KnownApiNames.LoginApi, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_version()
        {
            var resp = Api.GetVersion(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.LoginApi, "get_version", new object[] { }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }
    }
}
