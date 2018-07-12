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
        //    var resp = await Api.GetAccountHistory(User.Account.Id, , 100, , CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_account_history_by_operations()
        //{
        //    var args = new object();
        //    var resp = await Api.GetAccountHistoryByOperations(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_account_history_by_operations()
        //{
        //    var args = new object();
        //    var resp = await Api.GetAccountHistoryByOperations(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_relative_account_history()
        //{
        //    var args = new object();
        //    var resp = await Api.GetRelativeAccountHistory(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_fill_order_history()
        //{
        //    var args = new object();
        //    var resp = await Api.GetFillOrderHistory(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_market_history()
        //{
        //    var args = new object();
        //    var resp = await Api.GetMarketHistory(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        [Test][Parallelizable]
        public async Task get_market_history_buckets()
        {
            var resp = await Api.GetMarketHistoryBuckets(CancellationToken.None);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            Assert.IsFalse(resp.IsError);
        }
    }
}
