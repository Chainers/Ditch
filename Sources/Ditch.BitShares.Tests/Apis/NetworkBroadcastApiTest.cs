using System.Threading;
using Ditch.BitShares.Models;
using NUnit.Framework;
namespace Ditch.BitShares.Tests.Apis
{
    [TestFixture]
    public class NetworkBroadcastApiTest : BaseTest
    {
        [Ignore("data needed")]
        [Test]
        public void broadcast_transaction()
        {
            var args = new SignedTransaction();
            var resp = Api.BroadcastTransaction(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Ignore("data needed")]
        [Test]
        public void broadcast_transaction_synchronous()
        {
            var args = new SignedTransaction();
            var resp = Api.BroadcastTransactionSynchronous(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Ignore("data needed")]
        [Test]
        public void broadcast_block()
        {
            var args = new SignedBlock();
            var resp = Api.BroadcastBlock(args, CancellationToken.None);
            TestPropetries(resp);
        }
    }
}
