using System.Threading;
using System.Threading.Tasks;
using Ditch.Golos.Models;
using Ditch.Golos.Operations;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class NetworkBroadcastApiTest : BaseTest
    {
        [Test][Parallelizable]
        [Ignore("Real transaction")]
        public async Task broadcast_transaction()
        {
            var user = User;
            var autor = "steepshot";

            var op = new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            var prop = await Api.GetDynamicGlobalProperties(CancellationToken.None);
            var transaction = await Api.CreateTransaction(prop.Result, user.PostingKeys, op, CancellationToken.None);

            var resp = await Api.BroadcastTransaction(transaction, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test][Parallelizable]
        [Ignore("Real transaction")]
        public async Task broadcast_transaction_synchronous()
        {
            var user = User;
            var autor = "steepshot";

            var op = new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            var prop = await Api.GetDynamicGlobalProperties(CancellationToken.None);
            var transaction = await Api.CreateTransaction(prop.Result, user.PostingKeys, op, CancellationToken.None);

            var resp = await Api.BroadcastTransactionSynchronous(transaction, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test][Parallelizable]
        [Ignore("Real transaction")]
        public async Task broadcast_block()
        {
            var resp = await Api.BroadcastBlock(new SignedBlock(), CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }
    }
}
