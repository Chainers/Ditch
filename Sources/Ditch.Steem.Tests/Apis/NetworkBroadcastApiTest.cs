using System;
using System.Threading;
using Ditch.Steem.Models.Args;
using Ditch.Steem.Models.Other;
using Newtonsoft.Json;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

namespace Ditch.Steem.Tests.Apis
{
    [TestFixture]
    public class NetworkBroadcastApiTest : BaseTest
    {
        [Test]
        [Ignore("Real transaction")]
        public void broadcast_transaction()
        {
            var args = new BroadcastTransactionArgs()
            {
                Trx = GetSignedTransaction()
            };
            var resp = Api.BroadcastTransaction(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        [Ignore("Real transaction")]
        public void broadcast_transaction_synchronous()
        {
            var args = new BroadcastTransactionSynchronousArgs()
            {
                Trx = GetSignedTransaction()
            };
            var resp = Api.BroadcastTransactionSynchronous(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        [Ignore("Real transaction")]
        public void broadcast_block()
        {
            var args = new BroadcastBlockArgs()
            {
                Block = new SignedBlock()
            };
            var resp = Api.BroadcastBlock(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.NetworkBroadcastApi, "broadcast_block", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }
    }
}
