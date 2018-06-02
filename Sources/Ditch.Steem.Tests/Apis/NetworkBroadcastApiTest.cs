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
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
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
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
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
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.NetworkBroadcastApi, "broadcast_block", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }
    }
}
