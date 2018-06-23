using System;
using System.Threading;
using Ditch.Golos.Models;
using Ditch.Golos.Operations;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class DatabaseApiTest : BaseTest
    {
        [Test]
        public void get_account_bandwidth()
        {
            var resp = Api.GetAccountBandwidth(User.Login, BandwidthType.Post, CancellationToken.None);
            Assert.IsFalse(resp.IsError);
            resp = Api.GetAccountBandwidth(User.Login, BandwidthType.Market, CancellationToken.None);
            Assert.IsFalse(resp.IsError);

            resp = Api.GetAccountBandwidth(User.Login, BandwidthType.Forum, CancellationToken.None);
            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_account_bandwidth", new object[] { User.Login, BandwidthType.Forum }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_account_count()
        {
            var resp = Api.GetAccountCount(CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public void get_accounts()
        {
            var resp = Api.GetAccounts(new[] { User.Login }, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.DatabaseApi, "get_accounts", new object[] { new[] { User.Login } }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_block()
        {
            var resp = Api.GetBlock(42, CancellationToken.None);
            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_block", new object[] { 42 }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_block_header()
        {
            var resp = Api.GetBlockHeader(42, CancellationToken.None);
            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_block_header", new object[] { 42 }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_chain_properties()
        {
            var resp = Api.GetChainProperties(CancellationToken.None);
            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_chain_properties", new object[] { }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_config()
        {
            var resp = Api.GetConfig<JObject>(CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public void get_conversion_requests()
        {
            var resp = Api.GetConversionRequests(User.Login, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.DatabaseApi, "get_conversion_requests", new object[] { User.Login }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_dynamic_global_properties()
        {
            var resp = Api.GetDynamicGlobalProperties(CancellationToken.None);
            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_dynamic_global_properties", new object[] { }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_escrow()
        {
            var resp = Api.GetEscrow(User.Login, 3, CancellationToken.None);
            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_escrow", new object[] { string.Empty, 3 }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_expiring_vesting_delegations()
        {
            var resp = Api.GetExpiringVestingDelegations(User.Login, DateTime.Today, 3, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.DatabaseApi, "get_expiring_vesting_delegations", new object[] { User.Login, DateTime.Today, 3 }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_hardfork_version()
        {
            var resp = Api.GetHardforkVersion(CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public void get_next_scheduled_hardfork()
        {
            var resp = Api.GetNextScheduledHardfork(CancellationToken.None);
            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_next_scheduled_hardfork", new object[] { }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_owner_history()
        {
            var resp = Api.GetOwnerHistory(User.Login, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.DatabaseApi, "get_owner_history", new object[] { User.Login }, CancellationToken.None);
            TestPropetries(resp, obj);
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
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public void get_proposed_transactions()
        {
            var resp = Api.GetProposedTransactions(User.Login, 1, 1, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.DatabaseApi, "get_proposed_transactions", new object[] { User.Login, 1, 1 }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_recovery_request()
        {
            var resp = Api.GetRecoveryRequest(User.Login, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.DatabaseApi, "get_recovery_request", new object[] { User.Login }, CancellationToken.None);
            TestPropetries(resp, obj);
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
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public void get_savings_withdraw_from()
        {
            var resp = Api.GetSavingsWithdrawFrom(User.Login, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.DatabaseApi, "get_savings_withdraw_from", new object[] { User.Login }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_savings_withdraw_to()
        {
            var resp = Api.GetSavingsWithdrawTo(User.Login, CancellationToken.None);
            var obj = Api.CustomGetRequest<JObject[]>(KnownApiNames.DatabaseApi, "get_savings_withdraw_to", new object[] { User.Login }, CancellationToken.None);
            TestPropetries(resp, obj);
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
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public void get_vesting_delegations()
        {
            var resp = Api.GetVestingDelegations(User.Login, User.Login, 1, DelegationsType.Delegated, CancellationToken.None);
            var obj = Api.CustomGetRequest<JObject[]>(KnownApiNames.DatabaseApi, "get_vesting_delegations", new object[] { User.Login, User.Login, 1, DelegationsType.Delegated }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_withdraw_routes()
        {
            var resp = Api.GetWithdrawRoutes(User.Login, WithdrawRouteType.Incoming, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.DatabaseApi, "get_withdraw_routes", new object[] { User.Login, "all" }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void lookup_account_names()
        {
            var resp = Api.LookupAccountNames(new[] { User.Login }, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.DatabaseApi, "lookup_account_names", new object[] { new[] { User.Login } }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void lookup_accounts()
        {
            UInt32 limit = 3;
            var resp = Api.LookupAccounts(User.Login, limit, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public void set_block_applied_callback()
        {
            var resp = Api.SetBlockAppliedCallback(null, CancellationToken.None);
            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "set_block_applied_callback", new object[] { null }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void verify_account_authority()
        {
            var acc = Api.LookupAccountNames(new[] { User.Login }, CancellationToken.None);

            var resp = Api.VerifyAccountAuthority(User.Login, new[] { acc.Result[0].Active.KeyAuths[0].Key }, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
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
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }
    }
}

