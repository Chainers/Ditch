using System;
using System.Threading;
using Ditch.Golos.Models.Enums;
using Ditch.Golos.Models.Operations;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class NetworkBroadcastApiTest : BaseTest
    {
        [Test]
        public void broadcast_transaction()
        {
            var user = User;
            var autor = "steepshot";

            var op = new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            var prop = Api.GetDynamicGlobalProperties(CancellationToken.None);
            var transaction = Api.CreateTransaction(prop.Result, user.PostingKeys, CancellationToken.None, op);

            var resp = Api.BroadcastTransaction(transaction, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        //[Test]
        //public void broadcast_transaction_with_callback()
        //{
        //    var resp = Api.BroadcastTransactionWithCallback(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        //}

        //[Test]
        //public void broadcast_transaction_synchronous()
        //{
        //    var resp = Api.BroadcastTransactionSynchronous(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        //}

        //[Test]
        //public void broadcast_block()
        //{
        //    var resp = Api.BroadcastBlock(new Operations.Get.SignedBlock(), CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.NetworkBroadcastApi, "broadcast_block", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void set_max_block_age()
        //{
        //    var resp = Api.SetMaxBlockAge(0, CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        //}
    }
}
