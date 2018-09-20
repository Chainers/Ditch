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
        [Test]
        [Parallelizable]
        public async Task get_account_bandwidth()
        {
            var resp = await Api.GetAccountBandwidthAsync(User.Login, BandwidthType.Post, CancellationToken.None).ConfigureAwait(false);
            Assert.IsFalse(resp.IsError);
            resp = await Api.GetAccountBandwidthAsync(User.Login, BandwidthType.Market, CancellationToken.None).ConfigureAwait(false);
            Assert.IsFalse(resp.IsError);

            resp = await Api.GetAccountBandwidthAsync(User.Login, BandwidthType.Forum, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_account_count()
        {
            var resp = await Api.GetAccountCountAsync(CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        [Parallelizable]
        public async Task get_accounts()
        {
            var resp = await Api.GetAccountsAsync(new[] { User.Login }, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_block()
        {
            var resp = await Api.GetBlockAsync(42, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_block_header()
        {
            var resp = await Api.GetBlockHeaderAsync(42, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_chain_properties()
        {
            var resp = await Api.GetChainPropertiesAsync(CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_config()
        {
            var resp = await Api.GetConfigAsync<JObject>(CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        [Parallelizable]
        public async Task get_conversion_requests()
        {
            var resp = await Api.GetConversionRequestsAsync(User.Login, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_dynamic_global_properties()
        {
            var resp = await Api.GetDynamicGlobalPropertiesAsync(CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_escrow()
        {
            var resp = await Api.GetEscrowAsync(User.Login, 3, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_expiring_vesting_delegations()
        {
            var resp = await Api.GetExpiringVestingDelegationsAsync(User.Login, DateTime.Today, 3, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_hardfork_version()
        {
            var resp = await Api.GetHardforkVersionAsync(CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        [Parallelizable]
        public async Task get_next_scheduled_hardfork()
        {
            var resp = await Api.GetNextScheduledHardforkAsync(CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_owner_history()
        {
            var resp = await Api.GetOwnerHistoryAsync(User.Login, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_potential_signatures()
        {
            var user = User;
            var autor = "steepshot";

            var op = new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            var prop = await Api.GetDynamicGlobalPropertiesAsync(CancellationToken.None).ConfigureAwait(false);
            var transaction = await Api.CreateTransactionAsync(prop.Result, user.PostingKeys, op, CancellationToken.None).ConfigureAwait(false);

            var resp = await Api.GetPotentialSignaturesAsync(transaction, CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        [Parallelizable]
        public async Task get_proposed_transactions()
        {
            var resp = await Api.GetProposedTransactionsAsync(User.Login, 1, 1, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_recovery_request()
        {
            var resp = await Api.GetRecoveryRequestAsync(User.Login, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_required_signatures()
        {
            var user = User;
            var autor = "steepshot";

            var op = new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            var prop = await Api.GetDynamicGlobalPropertiesAsync(CancellationToken.None).ConfigureAwait(false);
            var transaction = await Api.CreateTransactionAsync(prop.Result, user.PostingKeys, op, CancellationToken.None).ConfigureAwait(false);

            var resp = await Api.GetRequiredSignaturesAsync(transaction, new PublicKeyType[0], CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        [Parallelizable]
        public async Task get_savings_withdraw_from()
        {
            var resp = await Api.GetSavingsWithdrawFromAsync(User.Login, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_savings_withdraw_to()
        {
            var resp = await Api.GetSavingsWithdrawToAsync(User.Login, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_transaction_hex()
        {
            var user = User;
            var autor = "steepshot";

            var op = new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            var prop = await Api.GetDynamicGlobalPropertiesAsync(CancellationToken.None).ConfigureAwait(false);
            var transaction = await Api.CreateTransactionAsync(prop.Result, user.PostingKeys, op, CancellationToken.None).ConfigureAwait(false);

            var resp = await Api.GetTransactionHexAsync(transaction, CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        [Parallelizable]
        public async Task get_vesting_delegations()
        {
            var resp = await Api.GetVestingDelegationsAsync(User.Login, User.Login, 1, DelegationsType.Delegated, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_withdraw_routes()
        {
            var resp = await Api.GetWithdrawRoutesAsync(User.Login, WithdrawRouteType.Incoming, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task lookup_account_names()
        {
            var resp = await Api.LookupAccountNamesAsync(new[] { User.Login }, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task lookup_accounts()
        {
            uint limit = 3;
            var resp = await Api.LookupAccountsAsync(User.Login, limit, CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        [Parallelizable]
        public async Task set_block_applied_callback()
        {
            var resp = await Api.SetBlockAppliedCallbackAsync(null, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task verify_account_authority()
        {
            var acc = await Api.LookupAccountNamesAsync(new[] { User.Login }, CancellationToken.None).ConfigureAwait(false);

            var resp = await Api.VerifyAccountAuthorityAsync(User.Login, new[] { acc.Result[0].Active.KeyAuths[0].Key }, CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        [Parallelizable]
        public async Task verify_authority()
        {
            var user = User;
            var autor = "steepshot";

            var op = new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            var prop = await Api.GetDynamicGlobalPropertiesAsync(CancellationToken.None).ConfigureAwait(false);
            var transaction = await Api.CreateTransactionAsync(prop.Result, user.PostingKeys, op, CancellationToken.None).ConfigureAwait(false);

            var resp = await Api.VerifyAuthorityAsync(transaction, CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }
    }
}

