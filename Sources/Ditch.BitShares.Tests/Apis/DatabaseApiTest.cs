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
        //    var resp = await Api.GetObjects(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_block_header()
        //{
        //    var args = new UInt32();
        //    var resp = await Api.GetBlockHeader(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_block_header_batch()
        //{
        //    var args = new UInt32();
        //    var resp = await Api.GetBlockHeaderBatch(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_block()
        //{
        //    var args = new UInt32();
        //    var resp = await Api.GetBlock(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_transaction()
        //{
        //    var args = new UInt32();
        //    var resp = await Api.GetTransaction(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_recent_transaction_by_id()
        //{
        //    var args = new string();
        //    var resp = await Api.GetRecentTransactionById(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        [Test][Parallelizable]
        public async Task get_chain_properties()
        {
            var resp = await Api.GetChainProperties(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_global_properties()
        {
            var resp = await Api.GetGlobalProperties(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_config()
        {
            var resp = await Api.GetConfig<JObject>(CancellationToken.None);
            WriteLine(resp);
        }

        [Test][Parallelizable]
        public async Task get_chain_id()
        {
            var resp = await Api.GetChainId(CancellationToken.None);
            WriteLine(resp);
        }

        [Test][Parallelizable]
        public async Task get_dynamic_global_properties()
        {
            var resp = await Api.GetDynamicGlobalProperties(CancellationToken.None);
            TestPropetries(resp);
        }

        //[Test]
        //public async Task get_key_references()
        //{
        //    var args = new PublicKeyType();
        //    var resp = await Api.GetKeyReferences(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task is_public_key_registered()
        //{
        //    var args = new string();
        //    var resp = await Api.IsPublicKeyRegistered(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        [Test][Parallelizable]
        public async Task get_accounts()
        {
            var args = new[] { User.Account.Id };
            var resp = await Api.GetAccounts(args, CancellationToken.None);
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
            var resp = await Api.GetAccountByName(User.Login, CancellationToken.None);
            TestPropetries(resp);
        }

        //[Test]
        //public async Task get_account_references()
        //{
        //    var args = new AccountIdType();
        //    var resp = await Api.GetAccountReferences(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task lookup_account_names()
        //{
        //    var args = new string();
        //    var resp = await Api.LookupAccountNames(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task lookup_accounts()
        //{
        //    var args = new string();
        //    var resp = await Api.LookupAccounts(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_account_balances()
        //{
        //    var args = new AccountIdType();
        //    var resp = await Api.GetAccountBalances(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_named_account_balances()
        //{
        //    var args = new string();
        //    var resp = await Api.GetNamedAccountBalances(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_balance_objects()
        //{
        //    var args = new Address();
        //    var resp = await Api.GetBalanceObjects(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_vested_balances()
        //{
        //    var args = new BalanceIdType();
        //    var resp = await Api.GetVestedBalances(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_vesting_balances()
        //{
        //    var args = new AccountIdType();
        //    var resp = await Api.GetVestingBalances(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        [Test][Parallelizable]
        public async Task get_account_count()
        {
            var resp = await Api.GetAccountCount(CancellationToken.None);
            WriteLine(resp);

        }

        //[Test]
        //public async Task get_assets()
        //{
        //    var args = new AssetIdType();
        //    var resp = await Api.GetAssets(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task list_assets()
        //{
        //    var args = new string();
        //    var resp = await Api.ListAssets(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task lookup_asset_symbols()
        //{
        //    var args = new string();
        //    var resp = await Api.LookupAssetSymbols(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_limit_orders()
        //{
        //    var args = new AssetIdType();
        //    var resp = await Api.GetLimitOrders(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_call_orders()
        //{
        //    var args = new AssetIdType();
        //    var resp = await Api.GetCallOrders(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_settle_orders()
        //{
        //    var args = new AssetIdType();
        //    var resp = await Api.GetSettleOrders(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_collateral_bids()
        //{
        //    var args = new AssetIdType();
        //    var resp = await Api.GetCollateralBids(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_margin_positions()
        //{
        //    var args = new AccountIdType();
        //    var resp = await Api.GetMarginPositions(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task subscribe_to_market()
        //{
        //    var args = new Function();
        //    var resp = await Api.SubscribeToMarket(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task unsubscribe_from_market()
        //{
        //    var args = new AssetIdType();
        //    var resp = await Api.UnsubscribeFromMarket(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_ticker()
        //{
        //    var args = new string();
        //    var resp = await Api.GetTicker(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_24_volume()
        //{
        //    var args = new string();
        //    var resp = await Api.Get24Volume(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_order_book()
        //{
        //    var args = new string();
        //    var resp = await Api.GetOrderBook(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_top_markets()
        //{
        //    var args = new UInt32();
        //    var resp = await Api.GetTopMarkets(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_trade_history()
        //{
        //    var args = new string();
        //    var resp = await Api.GetTradeHistory(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_trade_history_by_sequence()
        //{
        //    var args = new string();
        //    var resp = await Api.GetTradeHistoryBySequence(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_witnesses()
        //{
        //    var args = new WitnessIdType();
        //    var resp = await Api.GetWitnesses(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_witness_by_account()
        //{
        //    var args = new AccountIdType();
        //    var resp = await Api.GetWitnessByAccount(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task lookup_witness_accounts()
        //{
        //    var args = new string();
        //    var resp = await Api.LookupWitnessAccounts(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        [Test][Parallelizable]
        public async Task get_witness_count()
        {
            var resp = await Api.GetWitnessCount(CancellationToken.None);
            WriteLine(resp);
        }

        //[Test]
        //public async Task get_committee_members()
        //{
        //    var args = new CommitteeMemberIdType();
        //    var resp = await Api.GetCommitteeMembers(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_committee_member_by_account()
        //{
        //    var args = new AccountIdType();
        //    var resp = await Api.GetCommitteeMemberByAccount(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task lookup_committee_member_accounts()
        //{
        //    var args = new string();
        //    var resp = await Api.LookupCommitteeMemberAccounts(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        [Test][Parallelizable]
        public async Task get_committee_count()
        {
            var resp = await Api.GetCommitteeCount(CancellationToken.None);
            WriteLine(resp);
        }

        [Test][Parallelizable]
        public async Task get_all_workers()
        {
            var resp = await Api.GetAllWorkers(CancellationToken.None);
            TestPropetries(resp);
        }

        //[Test]
        //public async Task get_workers_by_account()
        //{
        //    var args = new AccountIdType();
        //    var resp = await Api.GetWorkersByAccount(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        [Test][Parallelizable]
        public async Task get_worker_count()
        {
            var resp = await Api.GetWorkerCount(CancellationToken.None);
            WriteLine(resp);
        }

        //[Test]
        //public async Task lookup_vote_ids()
        //{
        //    var args = new VoteIdType();
        //    var resp = await Api.LookupVoteIds(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_transaction_hex()
        //{
        //    var args = new SignedTransaction();
        //    var resp = await Api.GetTransactionHex(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_required_signatures()
        //{
        //    var args = new SignedTransaction();
        //    var resp = await Api.GetRequiredSignatures(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_potential_signatures()
        //{
        //    var args = new SignedTransaction();
        //    var resp = await Api.GetPotentialSignatures(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_potential_address_signatures()
        //{
        //    var args = new SignedTransaction();
        //    var resp = await Api.GetPotentialAddressSignatures(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task verify_authority()
        //{
        //    var args = new SignedTransaction();
        //    var resp = await Api.VerifyAuthority(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task verify_account_authority()
        //{
        //    var args = new string();
        //    var resp = await Api.VerifyAccountAuthority(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task validate_transaction()
        //{
        //    var args = new SignedTransaction();
        //    var resp = await Api.ValidateTransaction(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_required_fees()
        //{
        //    var args = new Operation();
        //    var resp = await Api.GetRequiredFees(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_proposed_transactions()
        //{
        //    var args = new AccountIdType();
        //    var resp = await Api.GetProposedTransactions(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_blinded_balances()
        //{
        //    var args = new FlatSet();
        //    var resp = await Api.GetBlindedBalances(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_withdraw_permissions_by_giver()
        //{
        //    var args = new AccountIdType();
        //    var resp = await Api.GetWithdrawPermissionsByGiver(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public async Task get_withdraw_permissions_by_recipient()
        //{
        //    var args = new AccountIdType();
        //    var resp = await Api.GetWithdrawPermissionsByRecipient(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}
    }
}
