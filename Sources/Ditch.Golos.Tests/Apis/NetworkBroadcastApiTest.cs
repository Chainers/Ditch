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
            var prop = await Api.GetDynamicGlobalPropertiesAsync(CancellationToken.None).ConfigureAwait(false);
            var transaction = await Api.CreateTransactionAsync(prop.Result, user.PostingKeys, op, CancellationToken.None).ConfigureAwait(false);

            var resp = await Api.BroadcastTransactionAsync(transaction, CancellationToken.None).ConfigureAwait(false);
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
            var prop = await Api.GetDynamicGlobalPropertiesAsync(CancellationToken.None).ConfigureAwait(false);
            var transaction = await Api.CreateTransactionAsync(prop.Result, user.PostingKeys, op, CancellationToken.None).ConfigureAwait(false);

            var resp = await Api.BroadcastTransactionSynchronousAsync(transaction, CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test][Parallelizable]
        [Ignore("Real transaction")]
        public async Task broadcast_block()
        {
            var resp = await Api.BroadcastBlockAsync(new SignedBlock(), CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }
    }
}
