using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Steem.Operations;
using Ditch.Steem.Operations.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Steem.Tests
{
    [TestFixture]
    public class OperationManagerGetTest : BaseTest
    {

        [Test]
        public async Task TryConnectToTest()
        {
            var urls = new List<string> { "wss://steemd.steemit.com", "wss://steemd2.steepshot.org" };

            var manager = new OperationManager();

            var sw = new Stopwatch();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{i} conect to golos.");
                sw.Restart();
                var url = manager.TryConnectTo(urls, CancellationToken.None);
                sw.Stop();
                Console.WriteLine($"{i} conected to {url} {sw.ElapsedMilliseconds}");
                Assert.IsTrue(manager.IsConnected, "Not connected");
                Assert.IsNotNull(manager.ChainId, "ChainId null");
                Assert.IsNotNull(manager.SbdSymbol, "SbdSymbol null");
                Assert.IsNotNull(manager.Version, "Version null");
                await Task.Delay(3000);
            }
        }

        [Test]
        public void get_dynamic_global_properties()
        {
            var resp = Api.GetDynamicGlobalProperties(CancellationToken.None);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_dynamic_global_properties", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_content()
        {
            var author = "steepshot";
            var permlink = "c-lib-ditch-1-0-for-graphene-from-steepshot-team-under-the-mit-license";

            var resp = Api.GetContent(author, permlink, CancellationToken.None);
            Assert.IsTrue(resp != null);
            Assert.IsTrue(resp.Result != null);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>("call", CancellationToken.None, KnownApiNames.DatabaseApi, "get_content", new[] { author, permlink });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_followers()
        {
            ushort count = 3;
            var resp = Api.GetFollowers(User.Login, string.Empty, FollowType.Blog, count, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Assert.IsTrue(resp.Result.Length <= count);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            var respNext = Api.GetFollowers(User.Login, resp.Result.Last().Follower, FollowType.Blog, count, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(respNext.IsError);
            Assert.IsTrue(respNext.Result.Length <= count);
            Assert.IsTrue(respNext.Result.First().Follower == resp.Result.Last().Follower);
            Console.WriteLine(JsonConvert.SerializeObject(respNext.Result));

            var obj = Api.CustomGetRequest<JObject[]>("call", CancellationToken.None, "follow_api", "get_followers", new object[] { User.Login, resp.Result.Last().Follower, FollowType.Blog.ToString().ToLower(), count });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_following()
        {
            ushort count = 3;
            var resp = Api.GetFollowing(User.Login, string.Empty, FollowType.Blog, count, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            Assert.IsTrue(resp.Result.Length <= count);

            var respNext = Api.GetFollowing(User.Login, resp.Result.Last().Following, FollowType.Blog, count, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(respNext.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(respNext.Result));
            Assert.IsTrue(respNext.Result.Length <= count);
            Assert.IsTrue(respNext.Result.First().Following == resp.Result.Last().Following);

            var obj = Api.CustomGetRequest<JObject[]>("call", CancellationToken.None, "follow_api", "get_following", new object[] { User.Login, resp.Result.Last().Follower, FollowType.Blog.ToString().ToLower(), count });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_discussions_by_author_before_date()
        {
            ushort count = 3;
            var dt = DateTime.Now;
            var resp = Api.GetDiscussionsByAuthorBeforeDate(User.Login, string.Empty, dt, count, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            Assert.IsTrue(resp.Result.Length <= count);

            var obj = Api.CustomGetRequest<JObject[]>("get_discussions_by_author_before_date", CancellationToken.None, User.Login, resp.Result[count - 1].Permlink, dt, count);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_active_witnesses()
        {
            var resp = Api.GetActiveWitnesses(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_miner_queue()
        {
            var resp = Api.GetMinerQueue(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_savings_withdraw_from()
        {
            var resp = Api.GetSavingsWithdrawFrom(User.Login, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_savings_withdraw_from", CancellationToken.None, User.Login);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_savings_withdraw_to()
        {
            var resp = Api.GetSavingsWithdrawTo(User.Login, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_savings_withdraw_to", CancellationToken.None, User.Login);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_witness_by_account()
        {
            var resp = Api.GetWitnessByAccount("steepshot", CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_witness_by_account", CancellationToken.None, User.Login);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_witnesses()
        {
            var witnes = Api.GetWitnessesByVote(string.Empty, 1, CancellationToken.None);
            Console.WriteLine(witnes.Error);
            Assert.IsFalse(witnes.IsError);

            var resp = Api.GetWitnesses(CancellationToken.None, witnes.Result[0].Id);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_witnesses", CancellationToken.None, new object[] { new[] { witnes.Result[0].Id } });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void lookup_witness_accounts()
        {
            var resp = Api.LookupWitnessAccounts(string.Empty, 3, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            //var obj = Api.CustomGetRequest<JObject[]>("lookup_witness_accounts", CancellationToken.None, string.Empty, 3);
            //TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_witness_count()
        {
            var resp = Api.GetWitnessCount(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);
        }

        [Test]
        public void get_order_book()
        {
            var resp = Api.GetOrderBook(3, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_order_book", CancellationToken.None, 3);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_open_orders()
        {
            var resp = Api.GetOpenOrders(User.Login, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_open_orders", CancellationToken.None, User.Login);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_witnesses_by_vote()
        {
            var resp = Api.GetWitnessesByVote(string.Empty, 3, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_witnesses_by_vote", CancellationToken.None, string.Empty, 3);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_state()
        {
            var resp = Api.GetState("path", CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_state", CancellationToken.None, "[\"path\"]");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_config()
        {
            var resp = Api.GetConfig(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_chain_properties()
        {
            var resp = Api.GetChainProperties(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_chain_properties", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_feed_history()
        {
            var resp = Api.GetFeedHistory(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_feed_history", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_current_median_history_price()
        {
            var resp = Api.GetCurrentMedianHistoryPrice(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_current_median_history_price", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_witness_schedule()
        {
            var resp = Api.GetWitnessSchedule(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_witness_schedule", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_hardfork_version()
        {
            var resp = Api.GetHardforkVersion(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);
        }

        [Test]
        public void get_next_scheduled_hardfork()
        {
            var resp = Api.GetNextScheduledHardfork(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_next_scheduled_hardfork", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_key_references()
        {
            var acResp = Api.GetAccounts(CancellationToken.None, User.Login);
            Assert.IsFalse(acResp.IsError);
            var ac = acResp.Result;
            Assert.IsTrue(ac.Length == 1);

            var key = ac[0].Active.KeyAuths[0][0] as string;
            var resp = Api.GetKeyReferences(CancellationToken.None, new[] { key });
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_accounts()
        {
            var resp = Api.GetAccounts(CancellationToken.None, User.Login);

            Assert.IsFalse(resp.IsError, resp.GetErrorMessage());
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_accounts", CancellationToken.None, new object[] { new[] { User.Login } });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        [Ignore("Code: '1'. Message: '10 assert_exception: Assert Exception false: database_api::get_account_references --- Needs to be refactored for steem.")]
        public void get_account_references()
        {
            var ac = Api.GetAccounts(CancellationToken.None, User.Login);
            Assert.IsFalse(ac.IsError);

            var resp = Api.GetAccountReferences(ac.Result[0].Id, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Console.WriteLine(resp.Result);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public void lookup_account_names()
        {
            var resp = Api.LookupAccountNames(CancellationToken.None, User.Login);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("lookup_account_names", CancellationToken.None, new object[] { new[] { User.Login } });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void lookup_accounts()
        {
            UInt32 limit = 3;
            var resp = Api.LookupAccounts(User.Login, limit, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_account_count()
        {
            var resp = Api.GetAccountCount(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Console.WriteLine(resp.Result);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);
        }

        [Test]
        public void get_conversion_requests()
        {
            var resp = Api.GetConversionRequests(User.Login, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("call", CancellationToken.None, KnownApiNames.DatabaseApi, "get_conversion_requests", User.Login);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_account_history()
        {
            UInt64 from = 3;
            UInt32 limit = 3;
            var resp = Api.GetAccountHistory(User.Login, from, limit, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_owner_history()
        {
            var resp = Api.GetOwnerHistory(CancellationToken.None, User.Login);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_owner_history", CancellationToken.None, User.Login);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_recovery_request()
        {
            var resp = Api.GetRecoveryRequest(CancellationToken.None, User.Login);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_recovery_request", CancellationToken.None, User.Login);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_withdraw_routes()
        {
            var resp = Api.GetWithdrawRoutes(User.Login, WithdrawRouteType.Incoming, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Console.WriteLine(resp.Result);
            Assert.IsFalse(resp.IsError);

            resp = Api.GetWithdrawRoutes(User.Login, WithdrawRouteType.Outgoing, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Console.WriteLine(resp.Result);
            Assert.IsFalse(resp.IsError);

            resp = Api.GetWithdrawRoutes(User.Login, WithdrawRouteType.All, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Console.WriteLine(resp.Result);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject[]>("get_withdraw_routes", CancellationToken.None, User.Login, "all");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_account_bandwidth()
        {
            var resp = Api.GetAccountBandwidth(User.Login, BandwidthType.Post, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            resp = Api.GetAccountBandwidth(User.Login, BandwidthType.Market, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            resp = Api.GetAccountBandwidth(User.Login, BandwidthType.Forum, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_account_bandwidth", CancellationToken.None, User.Login, BandwidthType.Forum.ToString().ToLower());
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_trending_tags()
        {
            var resp = Api.GetTrendingTags(User.Login, 3, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_trending_tags", CancellationToken.None, User.Login, 3);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_block_header()
        {
            var resp = Api.GetBlockHeader(42, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_block_header", CancellationToken.None, 42);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_block()
        {
            var resp = Api.GetBlock(42, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_block", CancellationToken.None, 42);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_ops_in_block()
        {
            var resp = Api.GetOpsInBlock(1234, false, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_ops_in_block", CancellationToken.None, 1234, false);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_escrow()
        {
            var resp = Api.GetEscrow(string.Empty, 3, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject[]>("get_escrow", CancellationToken.None, string.Empty, 3);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }
    }
}
