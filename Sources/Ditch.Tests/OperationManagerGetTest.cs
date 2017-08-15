using System;
using System.Linq;
using Ditch.Operations;
using Ditch.Operations.Enums;
using Ditch.Operations.Get;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Tests
{
    [TestFixture]
    public class OperationManagerGetTest : BaseTest
    {
        [Test, Sequential]
        public void get_dynamic_global_properties([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetDynamicGlobalProperties();
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject>("get_dynamic_global_properties");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public virtual void get_content(
            [Values("Steem", "Golos")] string name,
            [Values("steepshot", "golosmedia")] string author,
            [Values("c-lib-ditch-1-0-for-graphene-from-steepshot-team-under-the-mit-license", "psk38")] string permlink)
        {
            var resp = Manager(name).GetContent(author, permlink);
            Assert.IsTrue(resp != null);
            Assert.IsTrue(resp.Result != null);
            Assert.IsFalse(resp.IsError);

            var obj = Manager(name).CustomGetRequest<JObject>("call", (int)Api.DefaultApi, "get_content", new[] { author, permlink });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void help([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).CustomGetRequest<object>("help");
            Console.WriteLine(resp.Error);
            Console.WriteLine(resp.Result);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public void get_followers([Values("Steem", "Golos")] string name)
        {
            ushort count = 3;
            var resp = Manager(name).GetFollowers(Login[name], string.Empty, FollowType.blog, count);
            Assert.IsFalse(resp.IsError);
            Assert.IsTrue(resp.Result.Length <= count);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            var respNext = Manager(name).GetFollowers(Login[name], resp.Result.Last().Follower, FollowType.blog, count);
            Assert.IsFalse(respNext.IsError);
            Assert.IsTrue(respNext.Result.Length <= count);
            Assert.IsTrue(respNext.Result.First().Follower == resp.Result.Last().Follower);
            Console.WriteLine(JsonConvert.SerializeObject(respNext.Result));

            var obj = Manager(name).CustomGetRequest<JObject[]>("call", "follow_api", "get_followers", new object[] { Login[name], resp.Result.Last().Follower, FollowType.blog.ToString().ToLower(), count });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_following([Values("Steem", "Golos")] string name)
        {
            ushort count = 3;
            var resp = Manager(name).GetFollowing(Login[name], string.Empty, FollowType.blog, count);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            Assert.IsTrue(resp.Result.Length <= count);

            var respNext = Manager(name).GetFollowing(Login[name], resp.Result.Last().Following, FollowType.blog, count);
            Assert.IsFalse(respNext.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(respNext.Result));
            Assert.IsTrue(respNext.Result.Length <= count);
            Assert.IsTrue(respNext.Result.First().Following == resp.Result.Last().Following);

            var obj = Manager(name).CustomGetRequest<JObject[]>("call", "follow_api", "get_following", new object[] { Login[name], resp.Result.Last().Follower, FollowType.blog.ToString().ToLower(), count });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_discussions_by_author_before_date([Values("Steem", "Golos")] string name)
        {
            ushort count = 3;
            var dt = new DateTime(2017, 7, 1);
            var resp = Manager(name).GetDiscussionsByAuthorBeforeDate(Login[name], string.Empty, dt, count);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            Assert.IsTrue(resp.Result.Length <= count);

            var obj = Manager(name).CustomGetRequest<JObject[]>("get_discussions_by_author_before_date", Login[name], resp.Result[count - 1].Permlink, dt, count);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_state([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetState("path");
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject>("get_state", "[\"path\"]");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_config([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetConfig();
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_chain_properties([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetChainProperties();
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject>("get_chain_properties");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_feed_history([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetFeedHistory();
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject>("get_feed_history");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_current_median_history_price([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetCurrentMedianHistoryPrice();
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject>("get_current_median_history_price");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_witness_schedule([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetWitnessSchedule();
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject>("get_witness_schedule");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_hardfork_version([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetHardforkVersion();
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);
        }

        [Test]
        public void get_next_scheduled_hardfork([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetNextScheduledHardfork();
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject>("get_next_scheduled_hardfork");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_key_references([Values("Steem", "Golos")] string name)
        {
            var acResp = Manager(name).GetAccounts(Login[name]);
            Assert.IsFalse(acResp.IsError);
            var ac = acResp.Result;
            Assert.IsTrue(ac.Length == 1);

            var resp = Manager(name).GetKeyReferences(new object[1][] { new[] { ac[0].Active } });
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_accounts([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetAccounts(Login[name]);

            Assert.IsFalse(resp.IsError, resp.GetErrorMessage());
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject[]>("get_accounts", new object[] { new[] { Login[name] } });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_account_references([Values("Steem", "Golos")] string name)
        {
            var ac = Manager(name).GetAccounts(Login[name]);
            Assert.IsFalse(ac.IsError);

            var resp = Manager(name).GetAccountReferences(ac.Result[0].Id);
            Console.WriteLine(resp.Error);
            Console.WriteLine(resp.Result);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public void lookup_account_names([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).LookupAccountNames(Login[name]);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject[]>("lookup_account_names", new object[] { new[] { Login[name] } });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void lookup_accounts([Values("Steem", "Golos")] string name)
        {
            UInt32 limit = 3;
            var resp = Manager(name).LookupAccounts(Login[name], limit);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_account_count([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetAccountCount();
            Console.WriteLine(resp.Error);
            Console.WriteLine(resp.Result);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);
        }

        [Test]
        public void get_conversion_requests([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetConversionRequests(Login[name]);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject[]>("call", (int)Api.DefaultApi, "get_conversion_requests", Login[name]);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_account_history([Values("Steem", "Golos")] string name)
        {
            UInt64 from = 3;
            UInt32 limit = 3;
            var resp = Manager(name).GetAccountHistory(Login[name], from, limit);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_owner_history([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetOwnerHistory(Login[name]);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject[]>("get_owner_history", Login[name]);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_recovery_request([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetRecoveryRequest(Login[name]);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject[]>("get_recovery_request", Login[name]);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_withdraw_routes([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetWithdrawRoutes(Login[name], WithdrawRouteType.Incoming);
            Console.WriteLine(resp.Error);
            Console.WriteLine(resp.Result);
            Assert.IsFalse(resp.IsError);

            resp = Manager(name).GetWithdrawRoutes(Login[name], WithdrawRouteType.Outgoing);
            Console.WriteLine(resp.Error);
            Console.WriteLine(resp.Result);
            Assert.IsFalse(resp.IsError);

            resp = Manager(name).GetWithdrawRoutes(Login[name], WithdrawRouteType.All);
            Console.WriteLine(resp.Error);
            Console.WriteLine(resp.Result);
            Assert.IsFalse(resp.IsError);

            var obj = Manager(name).CustomGetRequest<JObject[]>("get_withdraw_routes", Login[name], "all");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_account_bandwidth([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetAccountBandwidth(Login[name], BandwidthType.Post);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            resp = Manager(name).GetAccountBandwidth(Login[name], BandwidthType.Market);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            resp = Manager(name).GetAccountBandwidth(Login[name], BandwidthType.Forum);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject>("get_account_bandwidth", Login[name], BandwidthType.Forum.ToString().ToLower());
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_trending_tags([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetTrendingTags(Login[name], 3);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject[]>("get_trending_tags", Login[name], 3);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_block_header([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetBlockHeader(42);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject>("get_block_header", 42);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_block([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetBlock(42);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject>("get_block", 42);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_ops_in_block([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetOpsInBlock(1234, false);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject[]>("get_ops_in_block", 1234, false);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }


        [Test]
        public void get_trending_categories([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetBestCategories(string.Empty, 3);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject[]>("get_best_categories", string.Empty, 3);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_active_categories([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetActiveCategories(string.Empty, 3);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject[]>("get_active_categories", string.Empty, 3);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_recent_categories([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetRecentCategories(string.Empty, 3);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject[]>("get_recent_categories", string.Empty, 3);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_escrow([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetEscrow(string.Empty, 3);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject[]>("get_escrow", string.Empty, 3);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }
    }
}