using System;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Steem.Models;
using NUnit.Framework;

namespace Ditch.Steem.Tests.Apis
{
    [TestFixture]
    public class AccountHistoryApiTest : BaseTest
    {
        [Test][Parallelizable]
        public async Task get_ops_in_block()
        {
            var args = new GetOpsInBlockArgs
            {
                BlockNum = 2,
                OnlyVirtual = false
            };
            var resp = await Api.GetOpsInBlock(args, CancellationToken.None);
            TestPropetries(resp);
        }
        
        [Test][Parallelizable]
        public async Task get_transaction()
        {
            var args = new GetTransactionArgs
            {
                Id = ""
            };
            var resp = await Api.GetTransaction(args, CancellationToken.None);
            TestPropetries(resp);
        }
        
        [Test][Parallelizable]
        public async Task get_account_history()
        {
            var args = new GetAccountHistoryArgs
            {
                Account = User.Login
            };
            var resp = await Api.GetAccountHistory(args, CancellationToken.None);
            TestPropetries(resp);
        }
        
        [Test][Parallelizable]
        public async Task enum_virtual_ops()
        {
            try
            {
                var args = new EnumVirtualOpsArgs
                {
                    BlockRangeBegin = 2,
                    BlockRangeEnd = 20
                };
                var resp = await Api.EnumVirtualOps(args, CancellationToken.None);
                TestPropetries(resp);
            }
            catch (Exception ex)
            {
                var t = HttpClient;
            }

           
        }
    }
}
