//using System;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using NUnit.Framework;
//namespace Ditch.Golos.Tests
//{
//    [TestFixture]
//    public class MarketHistoryApiTest : BaseTest
//    {

//        [Test]
//        public void on_api_startup()
//        {
//            var resp = Api.OnApiStartup();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("on_api_startup");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void set_subscribe_callback()
//        {
//            var resp = Api.SetSubscribeCallback();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("set_subscribe_callback");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void set_pending_transaction_callback()
//        {
//            var resp = Api.SetPendingTransactionCallback();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("set_pending_transaction_callback");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void set_block_applied_callback()
//        {
//            var resp = Api.SetBlockAppliedCallback();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("set_block_applied_callback");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void cancel_all_subscriptions()
//        {
//            var resp = Api.CancelAllSubscriptions();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("cancel_all_subscriptions");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void subscribe_to_market()
//        {
//            var resp = Api.SubscribeToMarket();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("subscribe_to_market");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void unsubscribe_from_market()
//        {
//            var resp = Api.UnsubscribeFromMarket();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("unsubscribe_from_market");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void get_limit_orders_by_owner()
//        {
//            var resp = Api.GetLimitOrdersByOwner();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("get_limit_orders_by_owner");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void get_call_orders_by_owner()
//        {
//            var resp = Api.GetCallOrdersByOwner();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("get_call_orders_by_owner");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void get_settle_orders_by_owner()
//        {
//            var resp = Api.GetSettleOrdersByOwner();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("get_settle_orders_by_owner");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void get_ticker()
//        {
//            var resp = Api.GetTicker();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("get_ticker");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void get_volume()
//        {
//            var resp = Api.GetVolume();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("get_volume");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void get_order_book()
//        {
//            var resp = Api.GetOrderBook();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("get_order_book");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void get_trade_history()
//        {
//            var resp = Api.GetTradeHistory();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("get_trade_history");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void get_fill_order_history()
//        {
//            var resp = Api.GetFillOrderHistory();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("get_fill_order_history");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void get_market_history()
//        {
//            var resp = Api.GetMarketHistory();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("get_market_history");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

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

//        [Test]
//        public void get_limit_orders()
//        {
//            var resp = Api.GetLimitOrders();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("get_limit_orders");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void get_call_orders()
//        {
//            var resp = Api.GetCallOrders();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("get_call_orders");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void get_settle_orders()
//        {
//            var resp = Api.GetSettleOrders();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("get_settle_orders");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void get_collateral_bids()
//        {
//            var resp = Api.GetCollateralBids();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("get_collateral_bids");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void get_margin_positions()
//        {
//            var resp = Api.GetMarginPositions();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("get_margin_positions");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }

//        [Test]
//        public void get_liquidity_queue()
//        {
//            var resp = Api.GetLiquidityQueue();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("get_liquidity_queue");
//            TestPropetries(resp.Result.GetType(), obj.Result);
//        }
//    }
//}
