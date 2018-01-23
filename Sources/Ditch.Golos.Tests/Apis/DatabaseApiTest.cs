using System;
using System.Threading;
using Ditch.Core;
using Ditch.Golos.Enums;
using Ditch.Golos.Helpers;
using Ditch.Golos.Objects;
using Ditch.Golos.Operations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class DatabaseApiTest : BaseTest
    {
        [Test]
        public void get_trending_tags()
        {
            var resp = Api.GetTrendingTags(User.Login, 3, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject[]>(KnownApiNames.DatabaseApi, "get_trending_tags", new object[] { User.Login, 3 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_trending_categories()
        {
            var resp = Api.GetTrendingCategories(string.Empty, 3, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject[]>(KnownApiNames.DatabaseApi, "get_trending_categories", new object[] { string.Empty, 3 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_best_categories()
        {
            var resp = Api.GetBestCategories(string.Empty, 3, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject[]>(KnownApiNames.DatabaseApi, "get_best_categories", new object[] { string.Empty, 3 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_active_categories()
        {
            var resp = Api.GetActiveCategories(User.Login, 3, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_active_categories", new object[] { User.Login, 3 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_recent_categories()
        {
            var resp = Api.GetRecentCategories(string.Empty, 3, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_recent_categories", new object[] { string.Empty, 3 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
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
        public void get_state()
        {
            var resp = Api.GetState("path", CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_state", new object[] { "path" }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_block_header()
        {
            var resp = Api.GetBlockHeader(42, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_block_header", new object[] { 42 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_block()
        {
            var resp = Api.GetBlock(42, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_block", new object[] { 42 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_ops_in_block()
        {
            uint id = 2;
            var resp = Api.GetOpsInBlock(id, false, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_ops_in_block", new object[] { id, false }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
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
        [Ignore("no method with name 'get_free_memory'")]
        public void get_free_memory()
        {
            var resp = Api.GetFreeMemory(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_dynamic_global_properties()
        {
            var resp = Api.GetDynamicGlobalProperties(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_dynamic_global_properties", new object[] { }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_chain_properties()
        {
            var resp = Api.GetChainProperties(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_chain_properties", new object[] { }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_current_median_history_price()
        {
            var resp = Api.GetCurrentMedianHistoryPrice(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_current_median_history_price", new object[] { }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_feed_history()
        {
            var resp = Api.GetFeedHistory(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_feed_history", new object[] { }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_witness_schedule()
        {
            var resp = Api.GetWitnessSchedule(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_witness_schedule", new object[] { }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_hardfork_version()
        {
            var resp = Api.GetHardforkVersion(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_next_scheduled_hardfork()
        {
            var resp = Api.GetNextScheduledHardfork(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_next_scheduled_hardfork", new object[] { }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_reward_fund()
        {
            if (VersionHelper.GetHardfork(Api.Version) > 16)
            {
                var resp = Api.GetRewardFund(User.Login, CancellationToken.None);
                Console.WriteLine(resp.Error);
                Assert.IsFalse(resp.IsError);
                Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

                var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_reward_fund", new object[] { User.Login }, CancellationToken.None);
                TestPropetries(resp.Result.GetType(), obj.Result);
                Console.WriteLine("----------------------------------------------------------------------------");
                Console.WriteLine(JsonConvert.SerializeObject(obj));
            }
            else
            {
                Console.WriteLine("Added in hf 17");
            }
        }

        [Test]
        public void get_name_cost()
        {
            if (VersionHelper.GetHardfork(Api.Version) > 16)
            {
                var resp = Api.GetNameCost(User.Login, CancellationToken.None);
                Console.WriteLine(resp.Error);
                Assert.IsFalse(resp.IsError);
                Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

                var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_name_cost", new object[] { User.Login }, CancellationToken.None);
                TestPropetries(resp.Result.GetType(), obj.Result);
                Console.WriteLine("----------------------------------------------------------------------------");
                Console.WriteLine(JsonConvert.SerializeObject(obj));
            }
            else
            {
                Console.WriteLine("Added in hf 17");
            }
        }

        [Test]
        public void get_accounts()
        {
            var resp = Api.GetAccounts(new[] { User.Login }, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_accounts", new object[] { new[] { User.Login } }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void lookup_account_names()
        {
            var resp = Api.LookupAccountNames(new[] { User.Login }, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "lookup_account_names", new object[] { new[] { User.Login } }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
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
        public void get_account_balances()
        {
            if (VersionHelper.GetHardfork(Api.Version) > 16)
            {
                var resp = Api.GetAccountBalances(User.Login, new string[0], CancellationToken.None);
                Console.WriteLine(resp.Error);
                Assert.IsFalse(resp.IsError);
                Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            }
            else
            {
                Console.WriteLine("Added in hf 17");
            }
        }

        [Test]
        public void get_account_count()
        {
            var resp = Api.GetAccountCount(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_owner_history()
        {
            var resp = Api.GetOwnerHistory(User.Login, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_owner_history", new object[] { User.Login }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_recovery_request()
        {
            var resp = Api.GetRecoveryRequest(User.Login, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_recovery_request", new object[] { User.Login }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_escrow()
        {
            var resp = Api.GetEscrow(string.Empty, 3, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_escrow", new object[] { string.Empty, 3 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_withdraw_routes()
        {
            var resp = Api.GetWithdrawRoutes(User.Login, WithdrawRouteType.Incoming, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            Assert.IsFalse(resp.IsError);

            resp = Api.GetWithdrawRoutes(User.Login, WithdrawRouteType.Outgoing, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            Assert.IsFalse(resp.IsError);

            resp = Api.GetWithdrawRoutes(User.Login, WithdrawRouteType.All, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            Assert.IsFalse(resp.IsError);

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_withdraw_routes", new object[] { User.Login, "all" }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
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

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_account_bandwidth", new object[] { User.Login, BandwidthType.Forum }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_savings_withdraw_from()
        {
            var resp = Api.GetSavingsWithdrawFrom(User.Login, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_savings_withdraw_from", new object[] { User.Login }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_savings_withdraw_to()
        {
            var resp = Api.GetSavingsWithdrawTo(User.Login, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject[]>(KnownApiNames.DatabaseApi, "get_savings_withdraw_to", new object[] { User.Login }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_vesting_delegations()
        {
            if (VersionHelper.GetHardfork(Api.Version) > 16)
            {
                var resp = Api.GetVestingDelegations(User.Login, string.Empty, 10, CancellationToken.None);
                Console.WriteLine(resp.Error);
                Assert.IsFalse(resp.IsError);
                Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

                var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_vesting_delegations", new object[] { User.Login, string.Empty, 10 }, CancellationToken.None);
                TestPropetries(resp.Result.GetType(), obj.Result);
                Console.WriteLine("----------------------------------------------------------------------------");
                Console.WriteLine(JsonConvert.SerializeObject(obj));
            }
            else
            {
                Console.WriteLine("Added in hf 17");
            }
        }

        [Test]
        public void get_expiring_vesting_delegations()
        {
            if (VersionHelper.GetHardfork(Api.Version) > 16)
            {
                var resp = Api.GetExpiringVestingDelegations(User.Login, new DateTime(2017, 01, 01), 100, CancellationToken.None);
                Console.WriteLine(resp.Error);
                Assert.IsFalse(resp.IsError);
                Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

                var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_expiring_vesting_delegations", new object[] { User.Login, new DateTime(2017, 01, 01), 100 }, CancellationToken.None);
                TestPropetries(resp.Result.GetType(), obj.Result);
                Console.WriteLine("----------------------------------------------------------------------------");
                Console.WriteLine(JsonConvert.SerializeObject(obj));
            }
            else
            {
                Console.WriteLine("Added in hf 17");
            }
        }

        [Test]
        public void get_witnesses()
        {
            var witnes = Api.GetWitnessesByVote(string.Empty, 100, CancellationToken.None);
            Console.WriteLine(witnes.Error);
            Assert.IsFalse(witnes.IsError);

            var resp = Api.GetWitnesses(new[] { witnes.Result[0].Id }, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject[]>(KnownApiNames.DatabaseApi, "get_witnesses", new object[] { new[] { witnes.Result[0].Id } }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_conversion_requests()
        {
            var resp = Api.GetConversionRequests(User.Login, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_conversion_requests", new object[] { User.Login }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_witness_by_account()
        {
            var witness = "good-karma";
            var resp = Api.GetWitnessByAccount(witness, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_witness_by_account", new object[] { witness }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_witnesses_by_vote()
        {
            var resp = Api.GetWitnessesByVote(string.Empty, 3, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_witnesses_by_vote", new object[] { string.Empty, 3 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void lookup_witness_accounts()
        {
            var resp = Api.LookupWitnessAccounts(string.Empty, 3, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_witness_count()
        {
            var resp = Api.GetWitnessCount(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }


        [Test]
        public void get_assets()
        {
            if (VersionHelper.GetHardfork(Api.Version) > 16)
            {
                var resp = Api.GetAssets(new[] { "GBG", "GOLOS" }, CancellationToken.None);
                Console.WriteLine(resp.Error);
                Assert.IsFalse(resp.IsError);
                Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

                var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_assets", new object[] { new[] { "GBG" } }, CancellationToken.None);
                TestPropetries(resp.Result.GetType(), obj.Result);
                Console.WriteLine("----------------------------------------------------------------------------");
                Console.WriteLine(JsonConvert.SerializeObject(obj));
            }
            else
            {
                Console.WriteLine("Added in hf 17");
            }
        }

        [Test]
        public void get_assets_by_issuer()
        {
            if (VersionHelper.GetHardfork(Api.Version) > 16)
            {
                var resp = Api.GetAssetsByIssuer("b1acksun", CancellationToken.None);
                Console.WriteLine(resp.Error);
                Assert.IsFalse(resp.IsError);
                Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

                var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_assets_by_issuer", new object[] { "b1acksun" }, CancellationToken.None);
                TestPropetries(resp.Result.GetType(), obj.Result);
                Console.WriteLine("----------------------------------------------------------------------------");
                Console.WriteLine(JsonConvert.SerializeObject(obj));
            }
            else
            {
                Console.WriteLine("Added in hf 17");
            }
        }

        [Test]
        public void get_assets_dynamic_data()
        {
            if (VersionHelper.GetHardfork(Api.Version) > 16)
            {
                var resp = Api.GetAssetsDynamicData(new[] { "GBG" }, CancellationToken.None);
                Console.WriteLine(resp.Error);
                Assert.IsFalse(resp.IsError);
                Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

                var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_assets_dynamic_data", new object[] { new[] { "GBG" } }, CancellationToken.None);
                TestPropetries(resp.Result.GetType(), obj.Result);
                Console.WriteLine("----------------------------------------------------------------------------");
                Console.WriteLine(JsonConvert.SerializeObject(obj));
            }
            else
            {
                Console.WriteLine("Added in hf 17");
            }
        }

        [Test]
        public void get_bitassets_data()
        {
            if (VersionHelper.GetHardfork(Api.Version) > 16)
            {
                var resp = Api.GetBitassetsData(new[] { "GBG" }, CancellationToken.None);
                Console.WriteLine(resp.Error);
                Assert.IsFalse(resp.IsError);
                Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

                var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_bitassets_data", new object[] { new[] { "GBG" } }, CancellationToken.None);
                TestPropetries(resp.Result.GetType(), obj.Result);
                Console.WriteLine("----------------------------------------------------------------------------");
                Console.WriteLine(JsonConvert.SerializeObject(obj));
            }
            else
            {
                Console.WriteLine("Added in hf 17");
            }
        }

        [Test]
        public void list_assets()
        {
            if (VersionHelper.GetHardfork(Api.Version) > 16)
            {
                var resp = Api.ListAssets(string.Empty, 10, CancellationToken.None);
                Console.WriteLine(resp.Error);
                Assert.IsFalse(resp.IsError);
                Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

                var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "list_assets", new object[] { string.Empty, 1 }, CancellationToken.None);
                TestPropetries(resp.Result.GetType(), obj.Result);
                Console.WriteLine("----------------------------------------------------------------------------");
                Console.WriteLine(JsonConvert.SerializeObject(obj));
            }
            else
            {
                Console.WriteLine("Added in hf 17");
            }
        }

        [Test]
        public void get_transaction_hex()
        {
            var user = User;
            var autor = "steepshot";

            var op = new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            var prop = Api.GetDynamicGlobalProperties(CancellationToken.None);
            var transaction = Api.CreateTransaction(prop.Result, user.PostingKeys, CancellationToken.None, op);

            var resp = Api.GetTransactionHex(transaction, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_transaction()
        {
            var op = Api.GetOpsInBlock(2, false, CancellationToken.None);
            Assert.IsFalse(op.IsError);

            var resp = Api.GetTransaction(op.Result[0].TrxId, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_transaction", new object[] { op.Result[0].TrxId }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_required_signatures()
        {
            var user = User;
            var autor = "steepshot";

            var op = new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            var prop = Api.GetDynamicGlobalProperties(CancellationToken.None);
            var transaction = Api.CreateTransaction(prop.Result, user.PostingKeys, CancellationToken.None, op);

            var resp = Api.GetRequiredSignatures(transaction, new PublicKeyType[0], CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_potential_signatures()
        {
            var user = User;
            var autor = "steepshot";

            var op = new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            var prop = Api.GetDynamicGlobalProperties(CancellationToken.None);
            var transaction = Api.CreateTransaction(prop.Result, user.PostingKeys, CancellationToken.None, op);

            var resp = Api.GetPotentialSignatures(transaction, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void verify_authority()
        {
            var user = User;
            var autor = "steepshot";

            var op = new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            var prop = Api.GetDynamicGlobalProperties(CancellationToken.None);
            var transaction = Api.CreateTransaction(prop.Result, user.PostingKeys, CancellationToken.None, op);

            var resp = Api.VerifyAuthority(transaction, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        [Ignore("---")]
        public void verify_account_authority()
        {
            var resp = Api.VerifyAccountAuthority(User.Login, new PublicKeyType[0], CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_active_votes()
        {
            var permlink = "test";
            var resp = Api.GetActiveVotes(User.Login, permlink, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_active_votes", new object[] { User.Login, permlink }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_account_votes()
        {
            var resp = Api.GetAccountVotes(User.Login, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_account_votes", new object[] { User.Login }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_content()
        {
            var author = "steepshot";
            var permlink = "znakomtes-steepshot-io";

            var resp = Api.GetContent(author, permlink, CancellationToken.None);
            Assert.IsTrue(resp != null);
            Assert.IsTrue(resp.Result != null);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_content", new object[] { author, permlink }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        [Ignore("add data for test")]
        public void get_content_replies()
        {
            var parent = "";
            var parentPermink = "";
            var resp = Api.GetContentReplies(parent, parentPermink, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_content_replies", new object[] { parent, parentPermink }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_tags_used_by_author()
        {
            var resp = Api.GetTagsUsedByAuthor(User.Login, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_tags_used_by_author", new object[] { User.Login }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_discussions_by_trending()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByTrending(query, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_discussions_by_trending", new object[] { query }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_discussions_by_created()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };

            var resp = Api.GetDiscussionsByCreated(query, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_discussions_by_created", new object[] { query }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_discussions_by_active()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByActive(query, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_discussions_by_active", new object[] { query }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_discussions_by_cashout()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByCashout(query, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_discussions_by_cashout", new object[] { query }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_discussions_by_payout()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByPayout(query, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_discussions_by_payout", new object[] { query }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_post_discussions_by_payout()
        {
            if (VersionHelper.GetHardfork(Api.Version) > 16)
            {
                var query = new DiscussionQuery()
                {
                    SelectAuthors = new[] { User.Login }
                };
                var resp = Api.GetPostDiscussionsByPayout(query, CancellationToken.None);
                Console.WriteLine(resp.Error);
                Assert.IsFalse(resp.IsError);
                Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

                var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_post_discussions_by_payout", new object[] { query }, CancellationToken.None);
                TestPropetries(resp.Result.GetType(), obj.Result);
                Console.WriteLine("----------------------------------------------------------------------------");
                Console.WriteLine(JsonConvert.SerializeObject(obj));
            }
            else
            {
                Console.WriteLine("Added in hf 17");
            }
        }

        [Test]
        public void get_comment_discussions_by_payout()
        {
            if (VersionHelper.GetHardfork(Api.Version) > 16)
            {
                var query = new DiscussionQuery()
                {
                    SelectAuthors = new[] { User.Login }
                };
                var resp = Api.GetCommentDiscussionsByPayout(query, CancellationToken.None);
                Console.WriteLine(resp.Error);
                Assert.IsFalse(resp.IsError);
                Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

                var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_comment_discussions_by_payout", new object[] { query }, CancellationToken.None);
                TestPropetries(resp.Result.GetType(), obj.Result);
                Console.WriteLine("----------------------------------------------------------------------------");
                Console.WriteLine(JsonConvert.SerializeObject(obj));
            }
            else
            {
                Console.WriteLine("Added in hf 17");
            }
        }

        [Test]
        public void get_discussions_by_votes()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByVotes(query, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_discussions_by_votes", new object[] { query }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_discussions_by_children()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByChildren(query, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_discussions_by_children", new object[] { query }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_discussions_by_hot()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByHot(query, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_discussions_by_hot", new object[] { query }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_discussions_by_feed()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByFeed(query, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_discussions_by_feed", new object[] { query }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_discussions_by_blog()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByBlog(query, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_discussions_by_blog", new object[] { query }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        [Ignore("add data for test")]
        public void get_discussions_by_comments()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByComments(query, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_discussions_by_comments", new object[] { query }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_discussions_by_promoted()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByPromoted(query, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_discussions_by_promoted", new object[] { query }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_replies_by_last_update()
        {
            var resp = Api.GetRepliesByLastUpdate(User.Login, string.Empty, 10, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_replies_by_last_update", new object[] { User.Login, string.Empty, 10 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
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

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_discussions_by_author_before_date", new object[] { User.Login, string.Empty, dt, count }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
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
        [Ignore("add data for test")]
        public void get_payout_extension_cost()
        {
            var parmlink = "";
            var resp = Api.GetPayoutExtensionCost(User.Login, parmlink, new DateTime(2017, 1, 1), CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_payout_extension_cost", new object[] { User.Login, parmlink, new DateTime(2017, 1, 1) }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        [Ignore("add data for test")]
        public void get_payout_extension_time()
        {
            var parmlink = "";
            var resp = Api.GetPayoutExtensionTime(User.Login, parmlink, new Asset(0, 3, "GBG"), CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_payout_extension_time", new object[] { User.Login, parmlink, new Asset(0, 3, "GBG") },
                CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_proposed_transactions()
        {
            if (VersionHelper.GetHardfork(Api.Version) > 16)
            {
                var resp = Api.GetProposedTransactions(User.Login, CancellationToken.None);
                Console.WriteLine(resp.Error);
                Assert.IsFalse(resp.IsError);
                Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

                var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_proposed_transactions", new object[] { User.Login }, CancellationToken.None);
                TestPropetries(resp.Result.GetType(), obj.Result);
                Console.WriteLine("----------------------------------------------------------------------------");
                Console.WriteLine(JsonConvert.SerializeObject(obj));
            }
            else
            {
                Console.WriteLine("Added in hf 17");
            }
        }
    }
}

