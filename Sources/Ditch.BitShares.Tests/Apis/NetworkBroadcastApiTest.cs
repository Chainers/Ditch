using System.Threading;
using System.Threading.Tasks;
using Ditch.BitShares.Models;
using NUnit.Framework;
namespace Ditch.BitShares.Tests.Apis
{
    [TestFixture]
    public class NetworkBroadcastApiTest : BaseTest
    {
        [Ignore("data needed")]
        [Test][Parallelizable]
        public async Task broadcast_transaction()
        {
            var args = new SignedTransaction();
            var resp = await Api.BroadcastTransaction(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Ignore("data needed")]
        [Test][Parallelizable]
        public async Task broadcast_transaction_synchronous()
        {
            var args = new SignedTransaction();
            var resp = await Api.BroadcastTransactionSynchronous(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Ignore("data needed")]
        [Test][Parallelizable]
        public async Task broadcast_block()
        {
            var args = new SignedBlock();
            var resp = await Api.BroadcastBlock(args, CancellationToken.None);
            TestPropetries(resp);
        }
    }
}
