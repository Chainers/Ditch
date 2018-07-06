using System.Threading.Tasks;
using Ditch.EOS.Models;
using NUnit.Framework;

namespace Ditch.EOS.Tests
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
        public async Task GetTransactionTest()
        {
            var args = new GetTransactionParams
            {
                TransactionId = ""
            };
            var resp = await Api.GetTransaction(args, CancellationToken);
            TestPropetries(resp);
        }

        [Test]
        public async Task GetKeyAccountsTest()
        {
            var args = new GetKeyAccountsParams
            {
                PublicKey = new PublicKeyType(User.PublicActiveWif)
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
