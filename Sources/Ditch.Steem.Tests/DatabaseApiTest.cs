using System;
using System.Threading;
using Ditch.Steem.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Steem.Tests
{
    [TestFixture]
    public class DatabaseApiTest : BaseTest
    {
        /*
        [Test]
        public void set_block_applied_callback()
        {
            var resp = Api.SetBlockAppliedCallback(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "set_block_applied_callback", new object[] { }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }
        */

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
            var resp = Api.GetOpsInBlock(1, false, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_ops_in_block", new object[] { 1, false }, CancellationToken.None);
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

        /*
        [Test]
        public void get_reward_fund()
        {
            var resp = Api.GetRewardFund(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_reward_fund", new object[] { }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }
        
        [Test]
        public void get_key_references()
        {
            var resp = Api.GetKeyReferences(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_key_references", new object[] { }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }
        */
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
        [Ignore("Code: '1'. Message: '10 assert_exception: Assert Exception false: database_api::get_account_references --- Needs to be refactored for steem.")]
        public void get_account_references()
        {
            var ac = Api.GetAccounts(new[] { User.Login }, CancellationToken.None);
            Assert.IsFalse(ac.IsError);

            var resp = Api.GetAccountReferences(ac.Result[0].Id, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_account_references", new object[] { ac.Result[0].Id }, CancellationToken.None);
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

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "lookup_account_names", new object[] { new[] { User.Login }, }, CancellationToken.None);
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

            var obj = Api.CallRequest<JObject[]>(KnownApiNames.DatabaseApi, "get_recovery_request", new object[] { User.Login }, CancellationToken.None);
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
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            resp = Api.GetWithdrawRoutes(User.Login, WithdrawRouteType.Outgoing, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            resp = Api.GetWithdrawRoutes(User.Login, WithdrawRouteType.All, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

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

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_account_bandwidth", new object[] { User.Login, BandwidthType.Forum.ToString().ToLower() }, CancellationToken.None);
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
        /*
        [Test]
        public void get_vesting_delegations()
        {
            var resp = Api.GetVestingDelegations(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_vesting_delegations", new object[] { }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_expiring_vesting_delegations()
        {
            var resp = Api.GetExpiringVestingDelegations(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_expiring_vesting_delegations", new object[] { }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }
        */
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
        public void get_order_book()
        {
            var resp = Api.GetOrderBook(3, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_order_book", new object[] { 3 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_open_orders()
        {
            var resp = Api.GetOpenOrders(User.Login, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_open_orders", new object[] { User.Login }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_liquidity_queue()
        {
            var resp = Api.GetLiquidityQueue(string.Empty, 10, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_liquidity_queue", new object[] { string.Empty, 1 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }
        /*
        [Test]
        public void get_transaction_hex()
        {
            var resp = Api.GetTransactionHex(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_transaction_hex", new object[] { }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_transaction()
        {
            var resp = Api.GetTransaction(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_transaction", new object[] { }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }
        
        [Test]
        public void get_required_signatures()
        {
            var resp = Api.GetRequiredSignatures(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_required_signatures", new object[] { }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_potential_signatures()
        {
            var resp = Api.GetPotentialSignatures(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_potential_signatures", new object[] { }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }
        
        [Test]
        public void verify_authority()
        {
            var resp = Api.VerifyAuthority(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "verify_authority", new object[] { }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }
        
        [Test]
        public void verify_account_authority()
        {
            var resp = Api.VerifyAccountAuthority(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "verify_account_authority", new object[] { }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void verify_signatures()
        {
            var resp = Api.VerifySignatures(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "verify_signatures", new object[] { }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }
        
        [Test]
        public void get_active_votes()
        {
            var resp = Api.GetActiveVotes(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_active_votes", new object[] { }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_account_votes()
        {
            var resp = Api.GetAccountVotes(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_account_votes", new object[] { }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }
        */
        [Test]
        public void get_content()
        {
            var author = "steepshot";
            var permlink = "c-lib-ditch-1-0-for-graphene-from-steepshot-team-under-the-mit-license";

            var resp = Api.GetContent(author, permlink, CancellationToken.None);
            Assert.IsTrue(resp != null);
            Assert.IsTrue(resp.Result != null);
            Console.WriteLine(resp.Error);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_content", new object[] { author, permlink }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }
        /*
       [Test]
       public void get_content_replies()
       {
           var resp = Api.GetContentReplies(CancellationToken.None);
           Console.WriteLine(resp.Error);
           Assert.IsFalse(resp.IsError);
           Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

           var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_content_replies", new object[] { }, CancellationToken.None);
           TestPropetries(resp.Result.GetType(), obj.Result);
           Console.WriteLine("----------------------------------------------------------------------------");
           Console.WriteLine(JsonConvert.SerializeObject(obj));
       }

       [Test]
       public void get_tags_used_by_author()
       {
           var resp = Api.GetTagsUsedByAuthor(CancellationToken.None);
           Console.WriteLine(resp.Error);
           Assert.IsFalse(resp.IsError);
           Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

           var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_tags_used_by_author", new object[] { }, CancellationToken.None);
           TestPropetries(resp.Result.GetType(), obj.Result);
           Console.WriteLine("----------------------------------------------------------------------------");
           Console.WriteLine(JsonConvert.SerializeObject(obj));
       }

       [Test]
       public void get_discussions_by_payout()
       {
           var resp = Api.GetDiscussionsByPayout(CancellationToken.None);
           Console.WriteLine(resp.Error);
           Assert.IsFalse(resp.IsError);
           Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

           var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_discussions_by_payout", new object[] { }, CancellationToken.None);
           TestPropetries(resp.Result.GetType(), obj.Result);
           Console.WriteLine("----------------------------------------------------------------------------");
           Console.WriteLine(JsonConvert.SerializeObject(obj));
       }

       [Test]
       public void get_post_discussions_by_payout()
       {
           var resp = Api.GetPostDiscussionsByPayout(CancellationToken.None);
           Console.WriteLine(resp.Error);
           Assert.IsFalse(resp.IsError);
           Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

           var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_post_discussions_by_payout", new object[] { }, CancellationToken.None);
           TestPropetries(resp.Result.GetType(), obj.Result);
           Console.WriteLine("----------------------------------------------------------------------------");
           Console.WriteLine(JsonConvert.SerializeObject(obj));
       }

       [Test]
       public void get_comment_discussions_by_payout()
       {
           var resp = Api.GetCommentDiscussionsByPayout(CancellationToken.None);
           Console.WriteLine(resp.Error);
           Assert.IsFalse(resp.IsError);
           Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

           var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_comment_discussions_by_payout", new object[] { }, CancellationToken.None);
           TestPropetries(resp.Result.GetType(), obj.Result);
           Console.WriteLine("----------------------------------------------------------------------------");
           Console.WriteLine(JsonConvert.SerializeObject(obj));
       }

       [Test]
       public void get_discussions_by_trending()
       {
           var resp = Api.GetDiscussionsByTrending(CancellationToken.None);
           Console.WriteLine(resp.Error);
           Assert.IsFalse(resp.IsError);
           Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

           var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_discussions_by_trending", new object[] { }, CancellationToken.None);
           TestPropetries(resp.Result.GetType(), obj.Result);
           Console.WriteLine("----------------------------------------------------------------------------");
           Console.WriteLine(JsonConvert.SerializeObject(obj));
       }

       [Test]
       public void get_discussions_by_created()
       {
           var resp = Api.GetDiscussionsByCreated(CancellationToken.None);
           Console.WriteLine(resp.Error);
           Assert.IsFalse(resp.IsError);
           Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

           var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_discussions_by_created", new object[] { }, CancellationToken.None);
           TestPropetries(resp.Result.GetType(), obj.Result);
           Console.WriteLine("----------------------------------------------------------------------------");
           Console.WriteLine(JsonConvert.SerializeObject(obj));
       }

       [Test]
       public void get_discussions_by_active()
       {
           var resp = Api.GetDiscussionsByActive(CancellationToken.None);
           Console.WriteLine(resp.Error);
           Assert.IsFalse(resp.IsError);
           Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

           var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_discussions_by_active", new object[] { }, CancellationToken.None);
           TestPropetries(resp.Result.GetType(), obj.Result);
           Console.WriteLine("----------------------------------------------------------------------------");
           Console.WriteLine(JsonConvert.SerializeObject(obj));
       }

       [Test]
       public void get_discussions_by_cashout()
       {
           var resp = Api.GetDiscussionsByCashout(CancellationToken.None);
           Console.WriteLine(resp.Error);
           Assert.IsFalse(resp.IsError);
           Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

           var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_discussions_by_cashout", new object[] { }, CancellationToken.None);
           TestPropetries(resp.Result.GetType(), obj.Result);
           Console.WriteLine("----------------------------------------------------------------------------");
           Console.WriteLine(JsonConvert.SerializeObject(obj));
       }

       [Test]
       public void get_discussions_by_votes()
       {
           var resp = Api.GetDiscussionsByVotes(CancellationToken.None);
           Console.WriteLine(resp.Error);
           Assert.IsFalse(resp.IsError);
           Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

           var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_discussions_by_votes", new object[] { }, CancellationToken.None);
           TestPropetries(resp.Result.GetType(), obj.Result);
           Console.WriteLine("----------------------------------------------------------------------------");
           Console.WriteLine(JsonConvert.SerializeObject(obj));
       }

       [Test]
       public void get_discussions_by_children()
       {
           var resp = Api.GetDiscussionsByChildren(CancellationToken.None);
           Console.WriteLine(resp.Error);
           Assert.IsFalse(resp.IsError);
           Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

           var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_discussions_by_children", new object[] { }, CancellationToken.None);
           TestPropetries(resp.Result.GetType(), obj.Result);
           Console.WriteLine("----------------------------------------------------------------------------");
           Console.WriteLine(JsonConvert.SerializeObject(obj));
       }

       [Test]
       public void get_discussions_by_hot()
       {
           var resp = Api.GetDiscussionsByHot(CancellationToken.None);
           Console.WriteLine(resp.Error);
           Assert.IsFalse(resp.IsError);
           Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

           var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_discussions_by_hot", new object[] { }, CancellationToken.None);
           TestPropetries(resp.Result.GetType(), obj.Result);
           Console.WriteLine("----------------------------------------------------------------------------");
           Console.WriteLine(JsonConvert.SerializeObject(obj));
       }

       [Test]
       public void get_discussions_by_feed()
       {
           var resp = Api.GetDiscussionsByFeed(CancellationToken.None);
           Console.WriteLine(resp.Error);
           Assert.IsFalse(resp.IsError);
           Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

           var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_discussions_by_feed", new object[] { }, CancellationToken.None);
           TestPropetries(resp.Result.GetType(), obj.Result);
           Console.WriteLine("----------------------------------------------------------------------------");
           Console.WriteLine(JsonConvert.SerializeObject(obj));
       }

       [Test]
       public void get_discussions_by_blog()
       {
           var resp = Api.GetDiscussionsByBlog(CancellationToken.None);
           Console.WriteLine(resp.Error);
           Assert.IsFalse(resp.IsError);
           Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

           var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_discussions_by_blog", new object[] { }, CancellationToken.None);
           TestPropetries(resp.Result.GetType(), obj.Result);
           Console.WriteLine("----------------------------------------------------------------------------");
           Console.WriteLine(JsonConvert.SerializeObject(obj));
       }

       [Test]
       public void get_discussions_by_comments()
       {
           var resp = Api.GetDiscussionsByComments(CancellationToken.None);
           Console.WriteLine(resp.Error);
           Assert.IsFalse(resp.IsError);
           Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

           var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_discussions_by_comments", new object[] { }, CancellationToken.None);
           TestPropetries(resp.Result.GetType(), obj.Result);
           Console.WriteLine("----------------------------------------------------------------------------");
           Console.WriteLine(JsonConvert.SerializeObject(obj));
       }

       [Test]
       public void get_discussions_by_promoted()
       {
           var resp = Api.GetDiscussionsByPromoted(CancellationToken.None);
           Console.WriteLine(resp.Error);
           Assert.IsFalse(resp.IsError);
           Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

           var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_discussions_by_promoted", new object[] { }, CancellationToken.None);
           TestPropetries(resp.Result.GetType(), obj.Result);
           Console.WriteLine("----------------------------------------------------------------------------");
           Console.WriteLine(JsonConvert.SerializeObject(obj));
       }

       [Test]
       public void get_replies_by_last_update()
       {
           var resp = Api.GetRepliesByLastUpdate(CancellationToken.None);
           Console.WriteLine(resp.Error);
           Assert.IsFalse(resp.IsError);
           Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

           var obj = Api.CallRequest<JObject>(KnownApiNames.DatabaseApi, "get_replies_by_last_update", new object[] { }, CancellationToken.None);
           TestPropetries(resp.Result.GetType(), obj.Result);
           Console.WriteLine("----------------------------------------------------------------------------");
           Console.WriteLine(JsonConvert.SerializeObject(obj));
       }
       */
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

            var obj = Api.CallRequest<JArray>(KnownApiNames.DatabaseApi, "get_account_history", new object[] { User.Login, from, limit }, CancellationToken.None);
            //TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }
    }
}
