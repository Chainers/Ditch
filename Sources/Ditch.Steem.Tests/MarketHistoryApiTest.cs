using System;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
namespace Ditch.Steem.Tests
{
    [TestFixture]
    public class MarketHistoryApiTest : BaseTest
    {
        //[Test]
        //public void on_api_startup()
        //{
        //    var resp = Api.OnApiStartup(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>("on_api_startup");
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //}

        [Test]
        public void get_ticker()
        {
            var resp = Api.GetTicker(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_ticker", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_volume()
        {
            var resp = Api.GetVolume(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_volume", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        //[Test]
        //public void get_order_book()
        //{
        //    var resp = Api.GetOrderBook(100, CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>("get_order_book", CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //}

        [Test]
        public void get_trade_history()
        {
            var resp = Api.GetTradeHistory(DateTime.Now.Subtract(TimeSpan.FromDays(5)), DateTime.Now, 100, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_trade_history",CancellationToken.None, DateTime.Now.Subtract(TimeSpan.FromDays(5)), DateTime.Now, 100);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_recent_trades()
        {
            var resp = Api.GetRecentTrades(100, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_recent_trades", CancellationToken.None, 100);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_market_history()
        {
            var resp = Api.GetMarketHistory(100, DateTime.Now.Subtract(TimeSpan.FromDays(5)), DateTime.Now, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_market_history", CancellationToken.None, 100, DateTime.Now.Subtract(TimeSpan.FromDays(5)), DateTime.Now);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

//        [Test]
//        public void get_market_history_buckets()
//        {
//            var resp = Api.GetMarketHistoryBuckets();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("get_market_history_buckets");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }
    }
}
