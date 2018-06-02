using System;
using System.Threading;
using Ditch.BitShares.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
namespace Ditch.BitShares.Tests.Apis
{
    [TestFixture]
    public class HistoryApiTest : BaseTest
    {
        [Test]
        public void get_account_history()
        {
            var resp = Api.GetAccountHistory(User.Account.Id, null, 100, null, CancellationToken.None);
            Console.WriteLine(resp);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.HistoryApi, "get_account_history", new object[] { User.Account.Id, null, 100, null, }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(obj);
        }

        //[Test]
        //public void get_account_history_by_operations()
        //{
        //    var args = new object();
        //    var resp = Api.GetAccountHistoryByOperations(args, CancellationToken.None);
        //    Console.WriteLine(resp);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.HistoryApi, "get_account_history_by_operations", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(obj);
        //}

        //[Test]
        //public void get_account_history_by_operations()
        //{
        //    var args = new object();
        //    var resp = Api.GetAccountHistoryByOperations(args, CancellationToken.None);
        //    Console.WriteLine(resp);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.HistoryApi, "get_account_history_by_operations", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(obj);
        //}

        //[Test]
        //public void get_relative_account_history()
        //{
        //    var args = new object();
        //    var resp = Api.GetRelativeAccountHistory(args, CancellationToken.None);
        //    Console.WriteLine(resp);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.HistoryApi, "get_relative_account_history", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(obj);
        //}

        //[Test]
        //public void get_fill_order_history()
        //{
        //    var args = new object();
        //    var resp = Api.GetFillOrderHistory(args, CancellationToken.None);
        //    Console.WriteLine(resp);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.HistoryApi, "get_fill_order_history", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(obj);
        //}

        //[Test]
        //public void get_market_history()
        //{
        //    var args = new object();
        //    var resp = Api.GetMarketHistory(args, CancellationToken.None);
        //    Console.WriteLine(resp);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.HistoryApi, "get_market_history", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(obj);
        //}

        [Test]
        public void get_market_history_buckets()
        {
            var resp = Api.GetMarketHistoryBuckets(CancellationToken.None);
            Console.WriteLine(resp);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }
    }
}
