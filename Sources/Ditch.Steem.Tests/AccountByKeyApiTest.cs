//using System;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using NUnit.Framework;
//namespace Ditch.Steem.Tests
//{
//    [TestFixture]
//    public class AccountByKeyApiTest : BaseTest
//    {

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

//        [Test]
//        public void get_key_references()
//        {
//            var resp = Api.GetKeyReferences();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("get_key_references");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }
//    }
//}
