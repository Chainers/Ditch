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
            var resp = await Api.GetActions(args, CancellationToken);
            TestPropetries(resp);
        }

        [Test]
        public async Task GetTransactionTest(string testTransactionId)
        {
            var args = new GetTransactionParams
            {
                Id = "e98bafdecb902a2d3aa0d17575482c1551cda51d629b32079b80654aa0de0bb4",
                BlockNumHint = 7908800
            };
            var resp = await Api.GetTransaction(args, CancellationToken);
            TestPropetries(resp);
        }

        [Test]
        public async Task GetKeyAccountsTest()
        {
            var accArgs = new GetAccountParams(User.Login);
            var accRes = await Api.GetAccount(accArgs, CancellationToken);
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
            var resp = await Api.GetKeyAccounts(args, CancellationToken);
            TestPropetries(resp);
        }

        [Test]
        public async Task GetControlledAccountsTest()
        {
            var args = new GetControlledAccountsParams
            {
                ControllingAccount = User.Login
            };
            var resp = await Api.GetControlledAccounts(args, CancellationToken);
            TestPropetries(resp);
        }

    }
}
