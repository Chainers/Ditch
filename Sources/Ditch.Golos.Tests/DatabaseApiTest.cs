using System;
using Ditch.Golos.Operations;
using Ditch.Golos.Operations.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Golos.Tests
{
    [TestFixture]
    public class DatabaseApiTest : BaseTest
    {
        [Test]
        public void get_trending_tags()
        {
            var resp = Api.GetTrendingTags(User.Login, 3);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_trending_tags", User.Login, 3);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_trending_categories()
        {
            var resp = Api.GetTrendingCategories(string.Empty, 3);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_trending_categories", string.Empty, 3);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_best_categories()
        {
            var resp = Api.GetBestCategories(string.Empty, 3);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_best_categories", string.Empty, 3);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_active_categories()
        {
            var resp = Api.GetActiveCategories(string.Empty, 3);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_active_categories", string.Empty, 3);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_recent_categories()
        {
            var resp = Api.GetRecentCategories(string.Empty, 3);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_recent_categories", string.Empty, 3);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }


        [Test]
        public void get_active_witnesses()
        {
            var resp = Api.GetActiveWitnesses();
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_miner_queue()
        {
            var resp = Api.GetMinerQueue();
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_state()
        {
            var resp = Api.GetState("path");
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_state", "[\"path\"]");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_block_header()
        {
            var resp = Api.GetBlockHeader(42);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_block_header", 42);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_block()
        {
            var resp = Api.GetBlock(42);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_block", 42);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_ops_in_block()
        {
            var resp = Api.GetOpsInBlock(1234, false);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_ops_in_block", 1234, false);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }


        [Test]
        public void get_config()
        {
            var resp = Api.GetConfig();
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_dynamic_global_properties()
        {
            var resp = Api.GetDynamicGlobalProperties();
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_dynamic_global_properties");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_chain_properties()
        {
            var resp = Api.GetChainProperties();
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_chain_properties");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_current_median_history_price()
        {
            var resp = Api.GetCurrentMedianHistoryPrice();
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_current_median_history_price");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_feed_history()
        {
            var resp = Api.GetFeedHistory();
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_feed_history");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_witness_schedule()
        {
            var resp = Api.GetWitnessSchedule();
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_witness_schedule");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }


        [Test]
        public void get_hardfork_version()
        {
            var resp = Api.GetHardforkVersion();
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);
        }


        [Test]
        public void get_next_scheduled_hardfork()
        {
            var resp = Api.GetNextScheduledHardfork();
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_next_scheduled_hardfork");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        //[Test]
        //public void get_name_cost()
        //{
        //    var resp = Api.GetNameCost();
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>("get_name_cost");
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //}

        [Test]
        public void get_accounts()
        {
            var resp = Api.GetAccounts(User.Login);

            Assert.IsFalse(resp.IsError, resp.GetErrorMessage());
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_accounts", new object[] { new[] { User.Login } });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void lookup_account_names()
        {
            var resp = Api.LookupAccountNames(User.Login);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("lookup_account_names", new object[] { new[] { User.Login } });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void lookup_accounts()
        {
            UInt32 limit = 3;
            var resp = Api.LookupAccounts(User.Login, limit);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_account_count()
        {
            var resp = Api.GetAccountCount();
            Console.WriteLine(resp.Error);
            Console.WriteLine(resp.Result);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);
        }

        [Test]
        public void get_owner_history()
        {
            var resp = Api.GetOwnerHistory(User.Login);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_owner_history", User.Login);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }



        [Test]
        public void get_recovery_request()
        {
            var resp = Api.GetRecoveryRequest(User.Login);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_recovery_request", User.Login);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_escrow()
        {
            var resp = Api.GetEscrow(string.Empty, 3);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_escrow", string.Empty, 3);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_withdraw_routes()
        {
            var resp = Api.GetWithdrawRoutes(User.Login, WithdrawRouteType.Incoming);
            Console.WriteLine(resp.Error);
            Console.WriteLine(resp.Result);
            Assert.IsFalse(resp.IsError);

            resp = Api.GetWithdrawRoutes(User.Login, WithdrawRouteType.Outgoing);
            Console.WriteLine(resp.Error);
            Console.WriteLine(resp.Result);
            Assert.IsFalse(resp.IsError);

            resp = Api.GetWithdrawRoutes(User.Login, WithdrawRouteType.All);
            Console.WriteLine(resp.Error);
            Console.WriteLine(resp.Result);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject[]>("get_withdraw_routes", User.Login, "all");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_account_bandwidth()
        {
            var resp = Api.GetAccountBandwidth(User.Login, BandwidthType.Post);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            resp = Api.GetAccountBandwidth(User.Login, BandwidthType.Market);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            resp = Api.GetAccountBandwidth(User.Login, BandwidthType.Forum);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_account_bandwidth", User.Login, BandwidthType.Forum.ToString().ToLower());
            TestPropetries(resp.Result.GetType(), obj.Result);
        }


        [Test]
        public void get_savings_withdraw_from()
        {
            var resp = Api.GetSavingsWithdrawFrom(User.Login);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_savings_withdraw_from", User.Login);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_savings_withdraw_to()
        {
            var resp = Api.GetSavingsWithdrawTo(User.Login);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_savings_withdraw_to", User.Login);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_witnesses()
        {
            var witnes = Api.GetWitnessesByVote(string.Empty, 1);
            Console.WriteLine(witnes.Error);
            Assert.IsFalse(witnes.IsError);

            var resp = Api.GetWitnesses(witnes.Result[0].Id);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_witnesses", new object[] { new[] { witnes.Result[0].Id } });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_conversion_requests()
        {
            var resp = Api.GetConversionRequests(User.Login);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_conversion_requests", User.Login);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }


        [Test]
        public void get_witness_by_account()
        {
            var resp = Api.GetWitnessByAccount("steepshot");
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_witness_by_account", User.Login);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }


        [Test]
        public void get_witnesses_by_vote()
        {
            var resp = Api.GetWitnessesByVote(string.Empty, 3);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_witnesses_by_vote", string.Empty, 3);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void lookup_witness_accounts()
        {
            var resp = Api.LookupWitnessAccounts(string.Empty, 3);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            //var obj = Api.CustomGetRequest<JObject[]>("lookup_witness_accounts", string.Empty, 3);
            //TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_witness_count()
        {
            var resp = Api.GetWitnessCount();
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);
        }

        //[Test]
        //public void get_assets()
        //{
        //    var resp = Api.GetAssets();
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>("get_assets");
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //}

        //[Test]
        //public void get_transaction_hex()
        //{
        //    var resp = Api.GetTransactionHex();
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>("get_transaction_hex");
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //}

        //[Test]
        //public void verify_authority()
        //{
        //    var resp = Api.VerifyAuthority();
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>("verify_authority");
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //}

        //[Test]
        //public void get_active_votes()
        //{
        //    var resp = Api.GetActiveVotes();
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>("get_active_votes");
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //}

        [Test]
        public void get_content()
        {
            var author = "golosmedia";
            var permlink = "psk38";

            var resp = Api.GetContent(author, permlink);
            Assert.IsTrue(resp != null);
            Assert.IsTrue(resp.Result != null);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>("call", KnownApiNames.DatabaseApi, "get_content", new[] { author, permlink });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }


        //[Test]
        //public void get_content_replies()
        //{
        //    var resp = Api.GetContentReplies();
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>("get_content_replies");
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //}

        //[Test]
        //public void get_tags_used_by_author()
        //{
        //    var resp = Api.GetTagsUsedByAuthor();
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>("get_tags_used_by_author");
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //}

        //[Test]
        //public void get_replies_by_last_update()
        //{
        //    var resp = Api.GetRepliesByLastUpdate();
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>("get_replies_by_last_update");
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //}

        [Test]
        public void get_discussions_by_author_before_date()
        {
            ushort count = 3;
            var dt = DateTime.Now;
            var resp = Api.GetDiscussionsByAuthorBeforeDate(User.Login, string.Empty, dt, count);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            Assert.IsTrue(resp.Result.Length <= count);

            var obj = Api.CustomGetRequest<JObject[]>("get_discussions_by_author_before_date", User.Login, string.Empty, dt, count);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_account_history()
        {
            UInt64 from = 3;
            UInt32 limit = 3;
            var resp = Api.GetAccountHistory(User.Login, from, limit);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        //[Test]
        //public void get_payout_extension_cost()
        //{
        //    var resp = Api.GetPayoutExtensionCost();
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>("get_payout_extension_cost");
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //}

        //[Test]
        //public void get_payout_extension_time()
        //{
        //    var resp = Api.GetPayoutExtensionTime();
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>("get_payout_extension_time");
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //}

    }
}
