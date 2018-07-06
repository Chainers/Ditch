using System;
using System.Threading;
using Newtonsoft.Json;
using NUnit.Framework;
namespace Ditch.BitShares.Tests.Apis
{
    [TestFixture]
    public class HistoryApiTest : BaseTest
    {
        //[Test]
        //public void get_account_history()
        //{
        //    var resp = Api.GetAccountHistory(User.Account.Id, , 100, , CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_account_history_by_operations()
        //{
        //    var args = new object();
        //    var resp = Api.GetAccountHistoryByOperations(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_account_history_by_operations()
        //{
        //    var args = new object();
        //    var resp = Api.GetAccountHistoryByOperations(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_relative_account_history()
        //{
        //    var args = new object();
        //    var resp = Api.GetRelativeAccountHistory(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_fill_order_history()
        //{
        //    var args = new object();
        //    var resp = Api.GetFillOrderHistory(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_market_history()
        //{
        //    var args = new object();
        //    var resp = Api.GetMarketHistory(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        [Test]
        public void get_market_history_buckets()
        {
            var resp = Api.GetMarketHistoryBuckets(CancellationToken.None); Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }
    }
}
