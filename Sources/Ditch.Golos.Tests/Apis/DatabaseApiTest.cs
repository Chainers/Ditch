using System;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Golos.Models;
using Ditch.Golos.Operations;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class DatabaseApiTest : BaseTest
    {
        [Test][Parallelizable]
        public async Task get_account_bandwidth()
        {
            var resp = await Api.GetAccountBandwidth(User.Login, BandwidthType.Post, CancellationToken.None);
            Assert.IsFalse(resp.IsError);
            resp = await Api.GetAccountBandwidth(User.Login, BandwidthType.Market, CancellationToken.None);
            Assert.IsFalse(resp.IsError);

            resp = await Api.GetAccountBandwidth(User.Login, BandwidthType.Forum, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_account_count()
        {
            var resp = await Api.GetAccountCount(CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test][Parallelizable]
        public async Task get_accounts()
        {
            var resp = await Api.GetAccounts(new[] { User.Login }, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_block()
        {
            var resp = await Api.GetBlock(42, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_block_header()
        {
            var resp = await Api.GetBlockHeader(42, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_chain_properties()
        {
            var resp = await Api.GetChainProperties(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_config()
        {
            var resp = await Api.GetConfig<JObject>(CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test][Parallelizable]
        public async Task get_conversion_requests()
        {
            var resp = await Api.GetConversionRequests(User.Login, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_dynamic_global_properties()
        {
            var resp = await Api.GetDynamicGlobalProperties(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_escrow()
        {
            var resp = await Api.GetEscrow(User.Login, 3, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_expiring_vesting_delegations()
        {
            var resp = await Api.GetExpiringVestingDelegations(User.Login, DateTime.Today, 3, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_hardfork_version()
        {
            var resp = await Api.GetHardforkVersion(CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test][Parallelizable]
        public async Task get_next_scheduled_hardfork()
        {
            var resp = await Api.GetNextScheduledHardfork(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_owner_history()
        {
            var resp = await Api.GetOwnerHistory(User.Login, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_potential_signatures()
        {
            var user = User;
            var autor = "steepshot";

            var op = new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            var prop = await Api.GetDynamicGlobalProperties(CancellationToken.None);
            var transaction = await Api.CreateTransaction(prop.Result, user.PostingKeys, op, CancellationToken.None);

            var resp = await Api.GetPotentialSignatures(transaction, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test][Parallelizable]
        public async Task get_proposed_transactions()
        {
            var resp = await Api.GetProposedTransactions(User.Login, 1, 1, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_recovery_request()
        {
            var resp = await Api.GetRecoveryRequest(User.Login, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_required_signatures()
        {
            var user = User;
            var autor = "steepshot";

            var op = new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            var prop = await Api.GetDynamicGlobalProperties(CancellationToken.None);
            var transaction = await Api.CreateTransaction(prop.Result, user.PostingKeys, op, CancellationToken.None);

            var resp = await Api.GetRequiredSignatures(transaction, new PublicKeyType[0], CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test][Parallelizable]
        public async Task get_savings_withdraw_from()
        {
            var resp = await Api.GetSavingsWithdrawFrom(User.Login, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_savings_withdraw_to()
        {
            var resp = await Api.GetSavingsWithdrawTo(User.Login, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_transaction_hex()
        {
            var user = User;
            var autor = "steepshot";

            var op = new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            var prop = await Api.GetDynamicGlobalProperties(CancellationToken.None);
            var transaction = await Api.CreateTransaction(prop.Result, user.PostingKeys, op, CancellationToken.None);

            var resp = await Api.GetTransactionHex(transaction, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test][Parallelizable]
        public async Task get_vesting_delegations()
        {
            var resp = await Api.GetVestingDelegations(User.Login, User.Login, 1, DelegationsType.Delegated, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_withdraw_routes()
        {
            var resp = await Api.GetWithdrawRoutes(User.Login, WithdrawRouteType.Incoming, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task lookup_account_names()
        {
            var resp = await Api.LookupAccountNames(new[] { User.Login }, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task lookup_accounts()
        {
            uint limit = 3;
            var resp = await Api.LookupAccounts(User.Login, limit, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test][Parallelizable]
        public async Task set_block_applied_callback()
        {
            var resp = await Api.SetBlockAppliedCallback(null, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task verify_account_authority()
        {
            var acc = await Api.LookupAccountNames(new[] { User.Login }, CancellationToken.None);

            var resp = await Api.VerifyAccountAuthority(User.Login, new[] { acc.Result[0].Active.KeyAuths[0].Key }, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test][Parallelizable]
        public async Task verify_authority()
        {
            var user = User;
            var autor = "steepshot";

            var op = new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            var prop = await Api.GetDynamicGlobalProperties(CancellationToken.None);
            var transaction = await Api.CreateTransaction(prop.Result, user.PostingKeys, op, CancellationToken.None);

            var resp = await Api.VerifyAuthority(transaction, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }
    }
}

