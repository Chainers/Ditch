using System.Linq;
using System.Threading.Tasks;
using Ditch.EOS.Models;
using NUnit.Framework;

namespace Ditch.EOS.Tests.Apis
{
    [TestFixture]
    public class HistoryApiTest : BaseTest
    {
        [Test]
        public async Task GetActionsTest()
        {
            var args = new GetActionsParams
            {
                AccountName = User.Login,
                Offset = 100,
                Pos = -1
            };
            var resp = await Api.GetActionsAsync(args, CancellationToken).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        public async Task GetTransactionTest()
        {
            var args = new GetTransactionParams
            {
                Id = "e98bafdecb902a2d3aa0d17575482c1551cda51d629b32079b80654aa0de0bb4",
                BlockNumHint = 7908800
            };
            var resp = await Api.GetTransactionAsync(args, CancellationToken).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        public async Task GetKeyAccountsTest()
        {
            var accArgs = new GetAccountParams(User.Login);
            var accRes = await Api.GetAccountAsync(accArgs, CancellationToken).ConfigureAwait(false);
            if (accRes.IsError)
            {
                WriteLine(accRes);
                Assert.Fail(nameof(accRes));
            }
            var publicKey = accRes.Result.Permissions
                .First(p => p.PermName == "active")
                .RequiredAuth.Keys.Select(k => k.Key)
                .First();

            var args = new GetKeyAccountsParams
            {
                PublicKey = new PublicKeyType(publicKey.Data)
            };
            var resp = await Api.GetKeyAccountsAsync(args, CancellationToken).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        public async Task GetControlledAccountsTest()
        {
            var args = new GetControlledAccountsParams
            {
                ControllingAccount = User.Login
            };
            var resp = await Api.GetControlledAccountsAsync(args, CancellationToken).ConfigureAwait(false);
            TestPropetries(resp);
        }

    }
}
