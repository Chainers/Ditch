using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.BitShares.Tests.Apis
{
    [TestFixture]
    public class DatabaseApiTest : BaseTest
    {
        //[Test]
        //public async Task get_objects()
        //{
        //    var args = new ObjectIdType();
        //    var resp = await Api.GetObjectsAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_block_header()
        //{
        //    var args = new UInt32();
        //    var resp = await Api.GetBlockHeaderAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_block_header_batch()
        //{
        //    var args = new UInt32();
        //    var resp = await Api.GetBlockHeaderBatchAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_block()
        //{
        //    var args = new UInt32();
        //    var resp = await Api.GetBlockAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_transaction()
        //{
        //    var args = new UInt32();
        //    var resp = await Api.GetTransactionAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_recent_transaction_by_id()
        //{
        //    var args = new string();
        //    var resp = await Api.GetRecentTransactionByIdAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        [Test][Parallelizable]
        public async Task get_chain_properties()
        {
            var resp = await Api.GetChainPropertiesAsync(CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_global_properties()
        {
            var resp = await Api.GetGlobalPropertiesAsync(CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_config()
        {
            var resp = await Api.GetConfigAsync<JObject>(CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
        }

        [Test][Parallelizable]
        public async Task get_chain_id()
        {
            var resp = await Api.GetChainIdAsync(CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
        }

        [Test][Parallelizable]
        public async Task get_dynamic_global_properties()
        {
            var resp = await Api.GetDynamicGlobalPropertiesAsync(CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        //[Test]
        //public async Task get_key_references()
        //{
        //    var args = new PublicKeyType();
        //    var resp = await Api.GetKeyReferencesAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task is_public_key_registered()
        //{
        //    var args = new string();
        //    var resp = await Api.IsPublicKeyRegisteredAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        [Test][Parallelizable]
        public async Task get_accounts()
        {
            var args = new[] { User.Account.Id };
            var resp = await Api.GetAccountsAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        //[Test]
        //public async Task get_full_accounts()
        //{
        //    var args = new string();
        //    TestPropetries(resp);
        //}

        [Test][Parallelizable]
        public async Task get_account_by_name()
        {
            var resp = await Api.GetAccountByNameAsync(User.Login, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        //[Test]
        //public async Task get_account_references()
        //{
        //    var args = new AccountIdType();
        //    var resp = await Api.GetAccountReferencesAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task lookup_account_names()
        //{
        //    var args = new string();
        //    var resp = await Api.LookupAccountNamesAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task lookup_accounts()
        //{
        //    var args = new string();
        //    var resp = await Api.LookupAccountsAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_account_balances()
        //{
        //    var args = new AccountIdType();
        //    var resp = await Api.GetAccountBalancesAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_named_account_balances()
        //{
        //    var args = new string();
        //    var resp = await Api.GetNamedAccountBalancesAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_balance_objects()
        //{
        //    var args = new Address();
        //    var resp = await Api.GetBalanceObjectsAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_vested_balances()
        //{
        //    var args = new BalanceIdType();
        //    var resp = await Api.GetVestedBalancesAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_vesting_balances()
        //{
        //    var args = new AccountIdType();
        //    var resp = await Api.GetVestingBalancesAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        [Test][Parallelizable]
        public async Task get_account_count()
        {
            var resp = await Api.GetAccountCountAsync(CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);

        }

        //[Test]
        //public async Task get_assets()
        //{
        //    var args = new AssetIdType();
        //    var resp = await Api.GetAssetsAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task list_assets()
        //{
        //    var args = new string();
        //    var resp = await Api.ListAssetsAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task lookup_asset_symbols()
        //{
        //    var args = new string();
        //    var resp = await Api.LookupAssetSymbolsAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_limit_orders()
        //{
        //    var args = new AssetIdType();
        //    var resp = await Api.GetLimitOrdersAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_call_orders()
        //{
        //    var args = new AssetIdType();
        //    var resp = await Api.GetCallOrdersAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_settle_orders()
        //{
        //    var args = new AssetIdType();
        //    var resp = await Api.GetSettleOrdersAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_collateral_bids()
        //{
        //    var args = new AssetIdType();
        //    var resp = await Api.GetCollateralBidsAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_margin_positions()
        //{
        //    var args = new AccountIdType();
        //    var resp = await Api.GetMarginPositionsAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task subscribe_to_market()
        //{
        //    var args = new Function();
        //    var resp = await Api.SubscribeToMarketAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task unsubscribe_from_market()
        //{
        //    var args = new AssetIdType();
        //    var resp = await Api.UnsubscribeFromMarketAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_ticker()
        //{
        //    var args = new string();
        //    var resp = await Api.GetTickerAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_24_volumeAsync()
        //{
        //    var args = new string();
        //    var resp = await Api.Get24VolumeAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_order_book()
        //{
        //    var args = new string();
        //    var resp = await Api.GetOrderBookAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_top_markets()
        //{
        //    var args = new UInt32();
        //    var resp = await Api.GetTopMarketsAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_trade_history()
        //{
        //    var args = new string();
        //    var resp = await Api.GetTradeHistoryAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_trade_history_by_sequence()
        //{
        //    var args = new string();
        //    var resp = await Api.GetTradeHistoryBySequenceAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_witnesses()
        //{
        //    var args = new WitnessIdType();
        //    var resp = await Api.GetWitnessesAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_witness_by_account()
        //{
        //    var args = new AccountIdType();
        //    var resp = await Api.GetWitnessByAccountAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task lookup_witness_accounts()
        //{
        //    var args = new string();
        //    var resp = await Api.LookupWitnessAccountsAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        [Test][Parallelizable]
        public async Task get_witness_count()
        {
            var resp = await Api.GetWitnessCountAsync(CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
        }

        //[Test]
        //public async Task get_committee_members()
        //{
        //    var args = new CommitteeMemberIdType();
        //    var resp = await Api.GetCommitteeMembersAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_committee_member_by_account()
        //{
        //    var args = new AccountIdType();
        //    var resp = await Api.GetCommitteeMemberByAccountAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task lookup_committee_member_accounts()
        //{
        //    var args = new string();
        //    var resp = await Api.LookupCommitteeMemberAccountsAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        [Test][Parallelizable]
        public async Task get_committee_count()
        {
            var resp = await Api.GetCommitteeCountAsync(CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
        }

        [Test][Parallelizable]
        public async Task get_all_workers()
        {
            var resp = await Api.GetAllWorkersAsync(CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        //[Test]
        //public async Task get_workers_by_account()
        //{
        //    var args = new AccountIdType();
        //    var resp = await Api.GetWorkersByAccountAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        [Test][Parallelizable]
        public async Task get_worker_count()
        {
            var resp = await Api.GetWorkerCountAsync(CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
        }

        //[Test]
        //public async Task lookup_vote_ids()
        //{
        //    var args = new VoteIdType();
        //    var resp = await Api.LookupVoteIdsAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_transaction_hex()
        //{
        //    var args = new SignedTransaction();
        //    var resp = await Api.GetTransactionHexAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_required_signatures()
        //{
        //    var args = new SignedTransaction();
        //    var resp = await Api.GetRequiredSignaturesAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_potential_signatures()
        //{
        //    var args = new SignedTransaction();
        //    var resp = await Api.GetPotentialSignaturesAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_potential_address_signatures()
        //{
        //    var args = new SignedTransaction();
        //    var resp = await Api.GetPotentialAddressSignaturesAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task verify_authority()
        //{
        //    var args = new SignedTransaction();
        //    var resp = await Api.VerifyAuthorityAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task verify_account_authority()
        //{
        //    var args = new string();
        //    var resp = await Api.VerifyAccountAuthorityAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task validate_transaction()
        //{
        //    var args = new SignedTransaction();
        //    var resp = await Api.ValidateTransactionAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_required_fees()
        //{
        //    var args = new Operation();
        //    var resp = await Api.GetRequiredFeesAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_proposed_transactions()
        //{
        //    var args = new AccountIdType();
        //    var resp = await Api.GetProposedTransactionsAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_blinded_balances()
        //{
        //    var args = new FlatSet();
        //    var resp = await Api.GetBlindedBalancesAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_withdraw_permissions_by_giver()
        //{
        //    var args = new AccountIdType();
        //    var resp = await Api.GetWithdrawPermissionsByGiverAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_withdraw_permissions_by_recipient()
        //{
        //    var args = new AccountIdType();
        //    var resp = await Api.GetWithdrawPermissionsByRecipientAsync(args, CancellationToken.None).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}
    }
}
