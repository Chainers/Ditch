using System;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Ditch.Steem.Operations;

namespace Ditch.Steem.Tests
{
    [TestFixture]
    public class AccountByKeyApiTest : BaseTest
    {

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

        [Test]
        public void get_key_references()
        {
            var pubKey = "STM6C8GjDBAHrfSqaNRn4FnLLUdCfw3WgjY3td1cC4T7CKpb32YM6";

            var resp = Api.GetKeyReferences(new[] { pubKey }, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }
    }
}
