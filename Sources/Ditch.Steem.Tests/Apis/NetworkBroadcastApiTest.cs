using System.Threading;
using Ditch.Steem.Models;
using NUnit.Framework;

namespace Ditch.Steem.Tests.Apis
{
    [TestFixture]
    public class NetworkBroadcastApiTest : BaseTest
    {
        [Test]
        [Ignore("Real transaction")]
        public void broadcast_transaction()
        {
            var args = new BroadcastTransactionArgs
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
            var args = new BroadcastTransactionSynchronousArgs
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
            var args = new BroadcastBlockArgs
            {
                Block = new SignedBlock()
            };
            var resp = Api.BroadcastBlock(args, CancellationToken.None);
            TestPropetries(resp);
        }
    }
}
