using System;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Steem.Models;
using NUnit.Framework;

namespace Ditch.Steem.Tests.Apis
{
    [TestFixture]
    public class MarketHistoryApiTest : BaseTest
    {
        [Test][Parallelizable]
        public async Task get_ticker()
        {
            var resp = await Api.GetTicker(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_volume()
        {
            var resp = await Api.GetVolume(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_order_book()
        {
            var args = new GetOrderBookArgs();
            var resp = await Api.GetOrderBook(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_trade_history()
        {
            var args = new GetTradeHistoryArgs
            {
                Start = new DateTime(2017, 4, 2),
                End = new DateTime(2017, 6, 2),
                Limit = 100
            };
            var resp = await Api.GetTradeHistory(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_recent_trades()
        {
            var args = new GetRecentTradesArgs();
            var resp = await Api.GetRecentTrades(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_market_history()
        {
            var args = new GetMarketHistoryArgs
            {
                Start = new DateTime(2017, 4, 2),
                BucketSeconds = 100,
                End = new DateTime(2017, 6, 2)
            };
            var resp = await Api.GetMarketHistory(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_market_history_buckets()
        {
            var resp = await Api.GetMarketHistoryBuckets(CancellationToken.None);
            TestPropetries(resp);
        }
    }
}
