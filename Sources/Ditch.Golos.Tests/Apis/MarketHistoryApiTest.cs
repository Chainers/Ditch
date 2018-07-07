using System;
using System.Threading;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class MarketHistoryApiTest : BaseTest
    {
        [Test]
        public void get_market_history()
        {
            var resp = Api.GetMarketHistory(100, new DateTime(2017, 4, 2), DateTime.Now, CancellationToken.None);
            TestPropetries(resp);
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
            TestPropetries(resp);
        }

        [Test]
        public void get_order_book()
        {
            var resp = Api.GetOrderBook(100, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_order_book_extended()
        {
            uint arg0 = 1;
            var resp = Api.GetOrderBookExtended(arg0, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_recent_trades()
        {
            var resp = Api.GetRecentTrades(3, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_ticker()
        {
            var resp = Api.GetTicker(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_trade_history()
        {
            var resp = Api.GetTradeHistory(new DateTime(2017, 4, 2), new DateTime(2017, 4, 3), 100, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_volume()
        {
            var resp = Api.GetVolume(CancellationToken.None);
            TestPropetries(resp);
        }
    }
}