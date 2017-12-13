using System;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Golos.Tests
{
    [TestFixture]
    public class MarketHistoryApiTest : BaseTest
    {
        //[Test]
        //public void set_subscribe_callback()
        //{
        //    var resp = Api.SetSubscribeCallback(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.MarketHistoryApi, "set_subscribe_callback", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void set_pending_transaction_callback()
        //{
        //    var resp = Api.SetPendingTransactionCallback(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.MarketHistoryApi, "set_pending_transaction_callback", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void set_block_applied_callback()
        //{
        //    var resp = Api.SetBlockAppliedCallback(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.MarketHistoryApi, "set_block_applied_callback", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void cancel_all_subscriptions()
        //{
        //    var resp = Api.CancelAllSubscriptions(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.MarketHistoryApi, "cancel_all_subscriptions",
        //        new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void subscribe_to_market()
        //{
        //    var resp = Api.SubscribeToMarket(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.MarketHistoryApi, "subscribe_to_market", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void unsubscribe_from_market()
        //{
        //    var resp = Api.UnsubscribeFromMarket(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.MarketHistoryApi, "unsubscribe_from_market", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_limit_orders_by_owner()
        //{
        //    var resp = Api.GetLimitOrdersByOwner(User.Login, CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.MarketHistoryApi, "get_limit_orders_by_owner",
        //        new object[] { User.Login }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_settle_orders_by_owner()
        //{
        //    var resp = Api.GetSettleOrdersByOwner(User.Login, CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.MarketHistoryApi, "get_settle_orders_by_owner",
        //        new object[] { User.Login }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_ticker()
        //{
        //    var resp = Api.GetTicker(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.MarketHistoryApi, "get_ticker", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_volume()
        //{
        //    var resp = Api.GetVolume(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.MarketHistoryApi, "get_volume", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        [Test]
        public void get_order_book()
        {
            var resp = Api.GetOrderBook(100, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.MarketHistoryApi, "get_order_book", new object[] { 100 },
                CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }
        
        //[Test]
        //public void get_trade_history()
        //{
        //    var resp = Api.GetTradeHistory(new DateTime(2017, 4, 2), new DateTime(2017, 4, 3), 100, CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JArray>(KnownApiNames.MarketHistoryApi, "get_trade_history", new object[] { new DateTime(2017, 4, 2), new DateTime(2017, 4, 3), 100 }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_fill_order_history()
        //{
        //    var resp = Api.GetFillOrderHistory(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.MarketHistoryApi, "get_fill_order_history", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_market_history()
        //{
        //    var resp = Api.GetMarketHistory(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JArray>(KnownApiNames.MarketHistoryApi, "get_market_history", new object[] { 100, new DateTime(2017, 4, 2), new DateTime(2017, 4, 3), }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_limit_orders()
        //{
        //    var resp = Api.GetLimitOrders(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.MarketHistoryApi, "get_limit_orders", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_call_orders()
        //{
        //    var resp = Api.GetCallOrders(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.MarketHistoryApi, "get_call_orders", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_settle_orders()
        //{
        //    var resp = Api.GetSettleOrders(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.MarketHistoryApi, "get_settle_orders", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_collateral_bids()
        //{
        //    var resp = Api.GetCollateralBids(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.MarketHistoryApi, "get_collateral_bids", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_margin_positions()
        //{
        //    var resp = Api.GetMarginPositions(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.MarketHistoryApi, "get_margin_positions", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}
    }
}