using System.Threading;
using System.Threading.Tasks;
using Ditch.Steem.Models;
using NUnit.Framework;

namespace Ditch.Steem.Tests.Apis
{
    [TestFixture]
    public class NetworkBroadcastApiTest : BaseTest
    {
        [Test]
        [Parallelizable]
        [Ignore("Real transaction")]
        public async Task broadcast_transaction()
        {
            var args = new BroadcastTransactionArgs
            {
                Trx = await GetSignedTransaction()
            };
            var resp = await Api.BroadcastTransaction(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        [Parallelizable]
        [Ignore("Real transaction")]
        public async Task broadcast_transaction_synchronous()
        {
            var args = new BroadcastTransactionSynchronousArgs
            {
                Trx = await GetSignedTransaction()
            };
            var resp = await Api.BroadcastTransactionSynchronous(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        [Parallelizable]
        [Ignore("Real transaction")]
        public async Task broadcast_block()
        {
            var args = new BroadcastBlockArgs
            {
                Block = new SignedBlock()
            };
            var resp = await Api.BroadcastBlock(args, CancellationToken.None);
            TestPropetries(resp);
        }
    }
}
