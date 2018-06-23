using System;
using System.Threading;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class MarketHistoryApiTest : BaseTest
    {
        [Test]
        public void get_market_history()
        {
            var resp = Api.GetMarketHistory(100, new DateTime(2017, 4, 2), new DateTime(2017, 4, 3), CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.MarketHistory, "get_market_history", new object[] { 100, new DateTime(2017, 4, 2), new DateTime(2017, 4, 3) }, CancellationToken.None);
            WriteLine(obj);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_market_history_buckets()
        {
            var resp = Api.GetMarketHistoryBuckets(CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public void get_open_orders()
        {
            var resp = Api.GetOpenOrders(User.Login, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.MarketHistory, "get_open_orders", new object[] { User.Login }, CancellationToken.None);
            WriteLine(obj);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_order_book()
        {
            var resp = Api.GetOrderBook(100, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.MarketHistory, "get_order_book", new object[] { 100 },
                CancellationToken.None);
            WriteLine(obj);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }


        [Test]
        public void get_recent_trades()
        {
            var resp = Api.GetRecentTrades(3, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.MarketHistory, "get_recent_trades", new object[] { 3 }, CancellationToken.None);
            WriteLine(obj);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_ticker()
        {
            var resp = Api.GetTicker(CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.MarketHistory, "get_ticker", CancellationToken.None);
            WriteLine(obj);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_trade_history()
        {
            var resp = Api.GetTradeHistory(new DateTime(2017, 4, 2), new DateTime(2017, 4, 3), 100, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.MarketHistory, "get_trade_history", new object[] { new DateTime(2017, 4, 2), new DateTime(2017, 4, 3), 100 }, CancellationToken.None);
            WriteLine(obj);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_volume()
        {
            var resp = Api.GetVolume(CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.MarketHistory, "get_volume", CancellationToken.None);
            WriteLine(obj);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }
    }
}