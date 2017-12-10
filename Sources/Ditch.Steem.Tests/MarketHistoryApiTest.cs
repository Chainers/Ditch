//using System;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using NUnit.Framework;
//namespace Ditch.Steem.Tests
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
//        public void get_recent_trades()
//        {
//            var resp = Api.GetRecentTrades();
//            Console.WriteLine(resp.Error);
//            Assert.IsFalse(resp.IsError);
//            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

//            var obj = Api.CustomGetRequest<JObject>("get_recent_trades");
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
//    }
//}
