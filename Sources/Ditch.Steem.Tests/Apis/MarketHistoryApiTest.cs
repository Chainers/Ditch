using System;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Steem.Tests.Apis
{
    [TestFixture]
    public class MarketHistoryApiTest : BaseTest
    {
        [Test]
        public void get_ticker()
        {
            var resp = Api.GetTicker(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            Assert.IsTrue(resp.Result.SbdVolume.Amount != null);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.MarketHistoryApi, "get_ticker", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_volume()
        {
            var resp = Api.GetVolume(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            Assert.IsTrue(resp.Result.SbdVolume.Amount != null);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.MarketHistoryApi, "get_volume", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_order_book()
        {
            var count = 100;
            var resp = Api.GetOrderBook2(100, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            Assert.IsTrue(resp.Result.Asks.Length == count || resp.Result.Bids.Length == count);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.MarketHistoryApi, "get_order_book", new object[] { 100 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_trade_history()
        {
            uint count = 100;
            var resp = Api.GetTradeHistory(new DateTime(2017, 4, 2), new DateTime(2017, 4, 3), count, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            Assert.IsTrue(resp.Result.Length == count);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.MarketHistoryApi, "get_trade_history", new object[] { new DateTime(2017, 4, 2), new DateTime(2017, 4, 3), 100 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_recent_trades()
        {
            var resp = Api.GetRecentTrades(100, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            Assert.IsTrue(resp.Result.Length > 0);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.MarketHistoryApi, "get_recent_trades", new object[] { 100 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_market_history()
        {
            var resp = Api.GetMarketHistory(100, new DateTime(2017, 4, 2), new DateTime(2017, 4, 3), CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.MarketHistoryApi, "get_market_history", new object[] { 100, new DateTime(2017, 4, 2), new DateTime(2017, 4, 3), }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_market_history_buckets()
        {
            var resp = Api.GetMarketHistoryBuckets(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }
    }
}
