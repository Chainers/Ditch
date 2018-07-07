using System.Threading;
using Ditch.Steem.Models;
using NUnit.Framework;

namespace Ditch.Steem.Tests.Apis
{
    [TestFixture]
    public class AccountHistoryApiTest : BaseTest
    {
        [Test]
        public void get_ops_in_block()
        {
            var args = new GetOpsInBlockArgs
            {
                BlockNum = 2,
                OnlyVirtual = false
            };
            var resp = Api.GetOpsInBlock(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_transaction()
        {
            var args = new GetTransactionArgs
            {
                Id = ""
            };
            var resp = Api.GetTransaction(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_account_history()
        {
            var args = new GetAccountHistoryArgs
            {
                Account = User.Login
            };
            var resp = Api.GetAccountHistory(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void enum_virtual_ops()
        {
            var args = new EnumVirtualOpsArgs
            {
                BlockRangeBegin = 2,
                BlockRangeEnd = 20
            };
            var resp = Api.EnumVirtualOps(args, CancellationToken.None);
            TestPropetries(resp);
        }
    }
}
