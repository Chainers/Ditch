using System;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
namespace Ditch.Steem.Tests
{
    [TestFixture]
    public class NetworkBroadcastApiTest : BaseTest
    {

//        [Test]
//        public void broadcast_transaction()
//        {
//            var resp = Api.BroadcastTransaction();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("broadcast_transaction");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void broadcast_transaction_with_callback()
//        {
//            var resp = Api.BroadcastTransactionWithCallback();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("broadcast_transaction_with_callback");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void broadcast_transaction_synchronous()
//        {
//            var resp = Api.BroadcastTransactionSynchronous();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("broadcast_transaction_synchronous");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

        //[Test]
        //public void broadcast_block()
        //{
        //    var resp = Api.BroadcastBlock(new Operations.Get.SignedBlock(), CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>("broadcast_block", CancellationToken.None, new Operations.Get.SignedBlock();
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //}

        [Test]
        public void set_max_block_age()
        {
            var resp = Api.SetMaxBlockAge(0, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("set_max_block_age", CancellationToken.None, 0);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void check_max_block_age()
        {
            var resp = Api.CheckMaxBlockAge(0, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("check_max_block_age", CancellationToken.None, 0);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

//        [Test]
//        public void on_applied_block()
//        {
//            var resp = Api.OnAppliedBlock();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("on_applied_block");
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
    }
}
