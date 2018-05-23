using System;
using System.Threading;
using Newtonsoft.Json;
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
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.MarketHistory, "get_market_history", new object[] { 100, new DateTime(2017, 4, 2), new DateTime(2017, 4, 3), }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_market_history_buckets()
        {
            var resp = Api.GetMarketHistoryBuckets(CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);
        }

        [Test]
        public void get_open_orders()
        {
            var resp = Api.GetOpenOrders(User.Login, CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.MarketHistory, "get_open_orders", new object[] { User.Login }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_order_book()
        {
            var resp = Api.GetOrderBook(100, CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.MarketHistory, "get_order_book", new object[] { 100 },
                CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_order_book_extended()
        {
            uint arg0 = 1;
            var resp = Api.GetOrderBookExtended(arg0, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.MarketHistory, "get_order_book_extended", new object[] { arg0 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_recent_trades()
        {
            var resp = Api.GetRecentTrades(3, CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.MarketHistory, "get_recent_trades", new object[] { 3 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_ticker()
        {
            var resp = Api.GetTicker(CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.MarketHistory, "get_ticker", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_trade_history()
        {
            var resp = Api.GetTradeHistory(new DateTime(2017, 4, 2), new DateTime(2017, 4, 3), 100, CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.MarketHistory, "get_trade_history", new object[] { new DateTime(2017, 4, 2), new DateTime(2017, 4, 3), 100 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_volume()
        {
            var resp = Api.GetVolume(CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.MarketHistory, "get_volume", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }
    }
}