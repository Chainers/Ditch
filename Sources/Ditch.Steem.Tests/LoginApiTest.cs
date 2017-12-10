//using System;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using NUnit.Framework;
//namespace Ditch.Steem.Tests
//{
//    [TestFixture]
//    public class LoginApiTest : BaseTest
//    {

//        [Test]
//        public void login()
//        {
//            var resp = Api.Login();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("login");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void get_api_by_name()
//        {
//            var resp = Api.GetApiByName();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("get_api_by_name");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void get_version()
//        {
//            var resp = Api.GetVersion();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("get_version");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void on_api_startup()
//        {
//            var resp = Api.OnApiStartup();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("on_api_startup");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }
//    }
//}
