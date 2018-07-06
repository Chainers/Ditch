using System.Threading;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.BitShares.Tests.Apis
{
    [TestFixture]
    public class DatabaseApiTest : BaseTest
    {
        //[Test]
        //public void get_objects()
        //{
        //    var args = new ObjectIdType();
        //    var resp = Api.GetObjects(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_block_header()
        //{
        //    var args = new UInt32();
        //    var resp = Api.GetBlockHeader(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_block_header_batch()
        //{
        //    var args = new UInt32();
        //    var resp = Api.GetBlockHeaderBatch(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_block()
        //{
        //    var args = new UInt32();
        //    var resp = Api.GetBlock(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_transaction()
        //{
        //    var args = new UInt32();
        //    var resp = Api.GetTransaction(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_recent_transaction_by_id()
        //{
        //    var args = new string();
        //    var resp = Api.GetRecentTransactionById(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        [Test]
        public void get_chain_properties()
        {
            var resp = Api.GetChainProperties(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_global_properties()
        {
            var resp = Api.GetGlobalProperties(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_config()
        {
            var resp = Api.GetConfig<JObject>(CancellationToken.None);
            WriteLine(resp);
        }

        [Test]
        public void get_chain_id()
        {
            var resp = Api.GetChainId(CancellationToken.None);
            WriteLine(resp);
        }

        [Test]
        public void get_dynamic_global_properties()
        {
            var resp = Api.GetDynamicGlobalProperties(CancellationToken.None);
            TestPropetries(resp);
        }

        //[Test]
        //public void get_key_references()
        //{
        //    var args = new PublicKeyType();
        //    var resp = Api.GetKeyReferences(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void is_public_key_registered()
        //{
        //    var args = new string();
        //    var resp = Api.IsPublicKeyRegistered(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        [Test]
        public void get_accounts()
        {
            var args = new[] { User.Account.Id };
            var resp = Api.GetAccounts(args, CancellationToken.None);
            TestPropetries(resp);
        }

        //[Test]
        //public void get_full_accounts()
        //{
        //    var args = new string();
        //    TestPropetries(resp);
        //}

        [Test]
        public void get_account_by_name()
        {
            var resp = Api.GetAccountByName(User.Login, CancellationToken.None);
            TestPropetries(resp);
        }

        //[Test]
        //public void get_account_references()
        //{
        //    var args = new AccountIdType();
        //    var resp = Api.GetAccountReferences(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void lookup_account_names()
        //{
        //    var args = new string();
        //    var resp = Api.LookupAccountNames(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void lookup_accounts()
        //{
        //    var args = new string();
        //    var resp = Api.LookupAccounts(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_account_balances()
        //{
        //    var args = new AccountIdType();
        //    var resp = Api.GetAccountBalances(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_named_account_balances()
        //{
        //    var args = new string();
        //    var resp = Api.GetNamedAccountBalances(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_balance_objects()
        //{
        //    var args = new Address();
        //    var resp = Api.GetBalanceObjects(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_vested_balances()
        //{
        //    var args = new BalanceIdType();
        //    var resp = Api.GetVestedBalances(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_vesting_balances()
        //{
        //    var args = new AccountIdType();
        //    var resp = Api.GetVestingBalances(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        [Test]
        public void get_account_count()
        {
            var resp = Api.GetAccountCount(CancellationToken.None);
            WriteLine(resp);

        }

        //[Test]
        //public void get_assets()
        //{
        //    var args = new AssetIdType();
        //    var resp = Api.GetAssets(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void list_assets()
        //{
        //    var args = new string();
        //    var resp = Api.ListAssets(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void lookup_asset_symbols()
        //{
        //    var args = new string();
        //    var resp = Api.LookupAssetSymbols(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_limit_orders()
        //{
        //    var args = new AssetIdType();
        //    var resp = Api.GetLimitOrders(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_call_orders()
        //{
        //    var args = new AssetIdType();
        //    var resp = Api.GetCallOrders(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_settle_orders()
        //{
        //    var args = new AssetIdType();
        //    var resp = Api.GetSettleOrders(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_collateral_bids()
        //{
        //    var args = new AssetIdType();
        //    var resp = Api.GetCollateralBids(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_margin_positions()
        //{
        //    var args = new AccountIdType();
        //    var resp = Api.GetMarginPositions(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void subscribe_to_market()
        //{
        //    var args = new Function();
        //    var resp = Api.SubscribeToMarket(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void unsubscribe_from_market()
        //{
        //    var args = new AssetIdType();
        //    var resp = Api.UnsubscribeFromMarket(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_ticker()
        //{
        //    var args = new string();
        //    var resp = Api.GetTicker(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_24_volume()
        //{
        //    var args = new string();
        //    var resp = Api.Get24Volume(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_order_book()
        //{
        //    var args = new string();
        //    var resp = Api.GetOrderBook(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_top_markets()
        //{
        //    var args = new UInt32();
        //    var resp = Api.GetTopMarkets(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_trade_history()
        //{
        //    var args = new string();
        //    var resp = Api.GetTradeHistory(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_trade_history_by_sequence()
        //{
        //    var args = new string();
        //    var resp = Api.GetTradeHistoryBySequence(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_witnesses()
        //{
        //    var args = new WitnessIdType();
        //    var resp = Api.GetWitnesses(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_witness_by_account()
        //{
        //    var args = new AccountIdType();
        //    var resp = Api.GetWitnessByAccount(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void lookup_witness_accounts()
        //{
        //    var args = new string();
        //    var resp = Api.LookupWitnessAccounts(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        [Test]
        public void get_witness_count()
        {
            var resp = Api.GetWitnessCount(CancellationToken.None);
            WriteLine(resp);
        }

        //[Test]
        //public void get_committee_members()
        //{
        //    var args = new CommitteeMemberIdType();
        //    var resp = Api.GetCommitteeMembers(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_committee_member_by_account()
        //{
        //    var args = new AccountIdType();
        //    var resp = Api.GetCommitteeMemberByAccount(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void lookup_committee_member_accounts()
        //{
        //    var args = new string();
        //    var resp = Api.LookupCommitteeMemberAccounts(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        [Test]
        public void get_committee_count()
        {
            var resp = Api.GetCommitteeCount(CancellationToken.None);
            WriteLine(resp);
        }

        [Test]
        public void get_all_workers()
        {
            var resp = Api.GetAllWorkers(CancellationToken.None);
            TestPropetries(resp);
        }

        //[Test]
        //public void get_workers_by_account()
        //{
        //    var args = new AccountIdType();
        //    var resp = Api.GetWorkersByAccount(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        [Test]
        public void get_worker_count()
        {
            var resp = Api.GetWorkerCount(CancellationToken.None);
            WriteLine(resp);
        }

        //[Test]
        //public void lookup_vote_ids()
        //{
        //    var args = new VoteIdType();
        //    var resp = Api.LookupVoteIds(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_transaction_hex()
        //{
        //    var args = new SignedTransaction();
        //    var resp = Api.GetTransactionHex(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_required_signatures()
        //{
        //    var args = new SignedTransaction();
        //    var resp = Api.GetRequiredSignatures(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_potential_signatures()
        //{
        //    var args = new SignedTransaction();
        //    var resp = Api.GetPotentialSignatures(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_potential_address_signatures()
        //{
        //    var args = new SignedTransaction();
        //    var resp = Api.GetPotentialAddressSignatures(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void verify_authority()
        //{
        //    var args = new SignedTransaction();
        //    var resp = Api.VerifyAuthority(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void verify_account_authority()
        //{
        //    var args = new string();
        //    var resp = Api.VerifyAccountAuthority(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void validate_transaction()
        //{
        //    var args = new SignedTransaction();
        //    var resp = Api.ValidateTransaction(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_required_fees()
        //{
        //    var args = new Operation();
        //    var resp = Api.GetRequiredFees(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_proposed_transactions()
        //{
        //    var args = new AccountIdType();
        //    var resp = Api.GetProposedTransactions(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_blinded_balances()
        //{
        //    var args = new FlatSet();
        //    var resp = Api.GetBlindedBalances(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_withdraw_permissions_by_giver()
        //{
        //    var args = new AccountIdType();
        //    var resp = Api.GetWithdrawPermissionsByGiver(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}

        //[Test]
        //public void get_withdraw_permissions_by_recipient()
        //{
        //    var args = new AccountIdType();
        //    var resp = Api.GetWithdrawPermissionsByRecipient(args, CancellationToken.None);
        //    TestPropetries(resp);
        //}
    }
}
