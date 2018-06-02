using System;
using System.Threading;
using Ditch.BitShares.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
namespace Ditch.BitShares.Tests.Apis
{
    [TestFixture]
    public class NetworkBroadcastApiTest : BaseTest
    {
        [Test]
        public void broadcast_transaction()
        {
            var args = new SignedTransaction();
            var resp = Api.BroadcastTransaction(args, CancellationToken.None);
            Console.WriteLine(resp);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.NetworkBroadcastApi, "broadcast_transaction", new[] { args }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(obj);
        }

        [Test]
        public void broadcast_transaction_synchronous()
        {
            var args = new SignedTransaction();
            var resp = Api.BroadcastTransactionSynchronous(args, CancellationToken.None);
            Console.WriteLine(resp);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.NetworkBroadcastApi, "broadcast_transaction_synchronous", new[] { args }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(obj);
        }

        [Test]
        public void broadcast_block()
        {
            var args = new SignedBlock();
            var resp = Api.BroadcastBlock(args, CancellationToken.None);
            Console.WriteLine(resp);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.NetworkBroadcastApi, "broadcast_block", new[] { args }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(obj);
        }
    }
}
