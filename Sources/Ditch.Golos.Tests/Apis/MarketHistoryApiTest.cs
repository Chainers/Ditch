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
            var resp = await Api.GetMarketHistoryAsync(100, new DateTime(2017, 4, 2), DateTime.Now, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_market_history_buckets()
        {
            var resp = await Api.GetMarketHistoryBucketsAsync(CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test][Parallelizable]
        public async Task get_open_orders()
        {
            var resp = await Api.GetOpenOrdersAsync(User.Login, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_order_book()
        {
            var resp = await Api.GetOrderBookAsync(100, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_order_book_extended()
        {
            uint arg0 = 1;
            var resp = await Api.GetOrderBookExtendedAsync(arg0, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_recent_trades()
        {
            var resp = await Api.GetRecentTradesAsync(3, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_ticker()
        {
            var resp = await Api.GetTickerAsync(CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_trade_history()
        {
            var resp = await Api.GetTradeHistoryAsync(new DateTime(2017, 4, 2), new DateTime(2017, 4, 3), 100, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_volume()
        {
            var resp = await Api.GetVolumeAsync(CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }
    }
}