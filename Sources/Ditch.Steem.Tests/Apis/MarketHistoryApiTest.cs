using System;
using System.Threading;
using Ditch.Steem.Models.Args;
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
            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.MarketHistoryApi, "get_ticker", CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_volume()
        {
            var resp = Api.GetVolume(CancellationToken.None);
            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.MarketHistoryApi, "get_volume", CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_order_book()
        {
            var args = new GetOrderBookArgs();
            var resp = Api.GetOrderBook(args, CancellationToken.None);
            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.MarketHistoryApi, "get_order_book", args, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_trade_history()
        {
            var args = new GetTradeHistoryArgs
            {
                Start = new DateTime(2017, 4, 2),
                End = new DateTime(2017, 6, 2),
                Limit = 100
            };
            var resp = Api.GetTradeHistory(args, CancellationToken.None);
            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.MarketHistoryApi, "get_trade_history", args, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_recent_trades()
        {
            var args = new GetRecentTradesArgs();
            var resp = Api.GetRecentTrades(args, CancellationToken.None);
            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.MarketHistoryApi, "get_recent_trades", args, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_market_history()
        {
            var args = new GetMarketHistoryArgs
            {
                Start = new DateTime(2017, 4, 2),
                BucketSeconds = 100,
                End = new DateTime(2017, 6, 2)
            };
            var resp = Api.GetMarketHistory(args, CancellationToken.None);
            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.MarketHistoryApi, "get_market_history", args, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_market_history_buckets()
        {
            var resp = Api.GetMarketHistoryBuckets(CancellationToken.None);
            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.MarketHistoryApi, "get_market_history_buckets", CancellationToken.None);
            TestPropetries(resp, obj);
        }
    }
}
