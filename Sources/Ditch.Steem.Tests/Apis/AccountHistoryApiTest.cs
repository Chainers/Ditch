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
            var resp = await Api.GetOpsInBlockAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }
        
        [Test][Parallelizable]
        public async Task get_transaction()
        {
            var args = new GetTransactionArgs
            {
                Id = ""
            };
            var resp = await Api.GetTransactionAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }
        
        [Test][Parallelizable]
        public async Task get_account_history()
        {
            var args = new GetAccountHistoryArgs
            {
                Account = User.Login
            };
            var resp = await Api.GetAccountHistoryAsync(args, CancellationToken.None).ConfigureAwait(false);
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
                var resp = await Api.EnumVirtualOpsAsync(args, CancellationToken.None).ConfigureAwait(false);
                TestPropetries(resp);
            }
            catch (Exception ex)
            {
                var t = HttpClient;
            }

           
        }
    }
}
