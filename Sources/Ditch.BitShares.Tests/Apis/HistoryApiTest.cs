using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
namespace Ditch.BitShares.Tests.Apis
{
    [TestFixture]
    public class HistoryApiTest : BaseTest
    {
        //[Test]
        //public async Task get_account_history()
        //{
        //    var resp = await Api.GetAccountHistoryAsync(User.Account.Id, , 100, , CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_account_history_by_operations()
        //{
        //    var args = new object();
        //    var resp = await Api.GetAccountHistoryByOperationsAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_account_history_by_operations()
        //{
        //    var args = new object();
        //    var resp = await Api.GetAccountHistoryByOperationsAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_relative_account_history()
        //{
        //    var args = new object();
        //    var resp = await Api.GetRelativeAccountHistoryAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_fill_order_history()
        //{
        //    var args = new object();
        //    var resp = await Api.GetFillOrderHistoryAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_market_history()
        //{
        //    var args = new object();
        //    var resp = await Api.GetMarketHistoryAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        [Test][Parallelizable]
        public async Task get_market_history_buckets()
        {
            var resp = await Api.GetMarketHistoryBucketsAsync(CancellationToken.None).ConfigureAwait(false);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            Assert.IsFalse(resp.IsError);
        }
    }
}
