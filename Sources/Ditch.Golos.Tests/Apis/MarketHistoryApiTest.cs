using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class MarketHistoryApiTest : BaseTest
    {
        [Test][Parallelizable]
        public async Task get_market_history()
        {
            var resp = await Api.GetMarketHistory(100, new DateTime(2017, 4, 2), DateTime.Now, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_market_history_buckets()
        {
            var resp = await Api.GetMarketHistoryBuckets(CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test][Parallelizable]
        public async Task get_open_orders()
        {
            var resp = await Api.GetOpenOrders(User.Login, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_order_book()
        {
            var resp = await Api.GetOrderBook(100, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_order_book_extended()
        {
            uint arg0 = 1;
            var resp = await Api.GetOrderBookExtended(arg0, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_recent_trades()
        {
            var resp = await Api.GetRecentTrades(3, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_ticker()
        {
            var resp = await Api.GetTicker(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_trade_history()
        {
            var resp = await Api.GetTradeHistory(new DateTime(2017, 4, 2), new DateTime(2017, 4, 3), 100, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_volume()
        {
            var resp = await Api.GetVolume(CancellationToken.None);
            TestPropetries(resp);
        }
    }
}