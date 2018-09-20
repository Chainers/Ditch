//using System.Threading;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using NUnit.Framework;

//namespace Ditch.BitShares.Tests.Apis
//{
//    [TestFixture]
//    public class WalletApiTest : BaseTest
//    {
//        [Test][Parallelizable]
//        public async Task info()
//        {
//            var resp = await Api.InfoAsync(CancellationToken.None).ConfigureAwait(false);
//        }

//        [Test][Parallelizable]
//        public async Task about()
//        {
//            var resp = await Api.AboutAsync(CancellationToken.None).ConfigureAwait(false);
//        }

//        //[Test]
//        //public async Task get_block()
//        //{
//        //    var args = new UInt32();
//        //    var resp = await Api.GetBlockAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        [Test][Parallelizable]
//        public async Task get_account_count()
//        {
//            var resp = await Api.GetAccountCountAsync(CancellationToken.None).ConfigureAwait(false);
//        }

//        [Test][Parallelizable]
//        public async Task list_my_accounts()
//        {
//            var resp = await Api.ListMyAccountsAsync(CancellationToken.None).ConfigureAwait(false);
//            TestPropetries(resp);
//        }

//        //[Test]
//        //public async Task list_accounts()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.ListAccountsAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task list_account_balances()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.ListAccountBalancesAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task list_assets()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.ListAssetsAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_account_history()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetAccountHistoryAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_relative_account_history()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetRelativeAccountHistoryAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_market_history()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetMarketHistoryAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_limit_orders()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetLimitOrdersAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_call_orders()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetCallOrdersAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_settle_orders()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetSettleOrdersAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_collateral_bids()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetCollateralBidsAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        [Test][Parallelizable]
//        public async Task get_global_properties()
//        {
//            var resp = await Api.GetGlobalPropertiesAsync(CancellationToken.None).ConfigureAwait(false);
//            TestPropetries(resp);
//        }

//        //[Test]
//        //public async Task get_account_history_by_operations()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetAccountHistoryByOperationsAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        [Test][Parallelizable]
//        public async Task get_dynamic_global_properties()
//        {
//            var resp = await Api.GetDynamicGlobalPropertiesAsync(CancellationToken.None).ConfigureAwait(false);
//            TestPropetries(resp);
//        }

//        //[Test]
//        //public async Task get_account()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetAccountAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_asset()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetAssetAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_bitasset_data()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetBitassetDataAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_account_id()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetAccountIdAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_object()
//        //{
//        //    var args = new ObjectIdType();
//        //    var resp = await Api.GetObjectAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_private_key()
//        //{
//        //    var args = new PublicKeyType();
//        //    var resp = await Api.GetPrivateKeyAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        [Test][Parallelizable]
//        public async Task begin_builder_transaction()
//        {
//            var resp = await Api.BeginBuilderTransactionAsync(CancellationToken.None).ConfigureAwait(false);
//            TestPropetries(resp);
//        }

//        //[Test]
//        //public async Task add_operation_to_builder_transaction()
//        //{
//        //    var args = new UInt16();
//        //    var resp = await Api.AddOperationToBuilderTransactionAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task replace_operation_in_builder_transaction()
//        //{
//        //    var args = new UInt16();
//        //    var resp = await Api.ReplaceOperationInBuilderTransactionAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task preview_builder_transaction()
//        //{
//        //    var args = new UInt16();
//        //    var resp = await Api.PreviewBuilderTransactionAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task sign_builder_transaction()
//        //{
//        //    var args = new UInt16();
//        //    var resp = await Api.SignBuilderTransactionAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task broadcast_transaction()
//        //{
//        //    var args = new SignedTransaction();
//        //    var resp = await Api.BroadcastTransactionAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task remove_builder_transaction()
//        //{
//        //    var args = new UInt16();
//        //    var resp = await Api.RemoveBuilderTransactionAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        [Test][Parallelizable]
//        public async Task is_new()
//        {
//            var resp = await Api.IsNewAsync(CancellationToken.None).ConfigureAwait(false);
//            TestPropetries(resp);
//        }

//        [Test][Parallelizable]
//        public async Task is_locked()
//        {
//            var resp = await Api.IsLockedAsync(CancellationToken.None).ConfigureAwait(false);
//            TestPropetries(resp);
//        }

//        [Test][Parallelizable]
//        public async Task lockTest()
//        {
//            var resp = await Api.LockAsync(CancellationToken.None).ConfigureAwait(false);
//            TestPropetries(resp);
//        }

//        //[Test]
//        //public async Task unlock()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.UnlockAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task set_password()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.SetPasswordAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        [Test][Parallelizable]
//        public async Task dump_private_keys()
//        {
//            var resp = await Api.DumpPrivateKeysAsync(CancellationToken.None).ConfigureAwait(false);
//            TestPropetries(resp);
//        }

//        [Test][Parallelizable]
//        public async Task help()
//        {
//            var resp = await Api.HelpAsync(CancellationToken.None).ConfigureAwait(false);
//            TestPropetries(resp);
//        }

//        //[Test]
//        //public async Task gethelp()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GethelpAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        [Test][Parallelizable]
//        public async Task suggest_brain_key()
//        {
//            var resp = await Api.SuggestBrainKeyAsync(CancellationToken.None).ConfigureAwait(false);
//            TestPropetries(resp);
//        }

//        //[Test]
//        //public async Task derive_owner_keys_from_brain_key()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.DeriveOwnerKeysFromBrainKeyAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task is_public_key_registered()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.IsPublicKeyRegisteredAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task serialize_transaction()
//        //{
//        //    var args = new SignedTransaction();
//        //    var resp = await Api.SerializeTransactionAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task import_key()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.ImportKeyAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task import_accounts()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.ImportAccountsAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task import_account_keys()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.ImportAccountKeysAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task import_balance()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.ImportBalanceAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task normalize_brain_key()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.NormalizeBrainKeyAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task register_account()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.RegisterAccountAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task upgrade_account()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.UpgradeAccountAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task create_account_with_brain_key()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.CreateAccountWithBrainKeyAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task transfer()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.TransferAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task sign_memo()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.SignMemoAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task read_memo()
//        //{
//        //    var args = new MemoData();
//        //    var resp = await Api.ReadMemoAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task create_blind_account()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.CreateBlindAccountAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_blind_balances()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetBlindBalancesAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        [Test][Parallelizable]
//        public async Task get_blind_accounts()
//        {
//            var resp = await Api.GetBlindAccountsAsync(CancellationToken.None).ConfigureAwait(false);
//            TestPropetries(resp);
//        }

//        [Test][Parallelizable]
//        public async Task get_my_blind_accounts()
//        {
//            var resp = await Api.GetMyBlindAccountsAsync(CancellationToken.None).ConfigureAwait(false);
//            TestPropetries(resp);
//        }

//        //[Test]
//        //public async Task get_public_key()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetPublicKeyAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task blind_history()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.BlindHistoryAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task receive_blind_transfer()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.ReceiveBlindTransferAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task blind_transfer()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.BlindTransferAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task sell_asset()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.SellAssetAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task borrow_asset()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.BorrowAssetAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task cancel_order()
//        //{
//        //    var args = new ObjectIdType();
//        //    var resp = await Api.CancelOrderAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task create_asset()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.CreateAssetAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task issue_asset()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.IssueAssetAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task update_asset()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.UpdateAssetAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task update_bitasset()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.UpdateBitassetAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task update_asset_feed_producers()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.UpdateAssetFeedProducersAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task publish_asset_feed()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.PublishAssetFeedAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task fund_asset_fee_pool()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.FundAssetFeePoolAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task reserve_asset()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.ReserveAssetAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task global_settle_asset()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GlobalSettleAssetAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task settle_asset()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.SettleAssetAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task bid_collateral()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.BidCollateralAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task whitelist_account()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.WhitelistAccountAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task create_committee_member()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.CreateCommitteeMemberAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task list_witnesses()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.ListWitnessesAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task list_committee_members()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.ListCommitteeMembersAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_witness()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetWitnessAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_committee_member()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetCommitteeMemberAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task create_witness()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.CreateWitnessAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task update_witness()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.UpdateWitnessAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_vesting_balances()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetVestingBalancesAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task vote_for_committee_member()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.VoteForCommitteeMemberAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task vote_for_witness()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.VoteForWitnessAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task set_voting_proxy()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.SetVotingProxyAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task set_desired_witness_and_committee_member_count()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.SetDesiredWitnessAndCommitteeMemberCountAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task sign_transaction()
//        //{
//        //    var args = new SignedTransaction();
//        //    var resp = await Api.SignTransactionAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_prototype_operation()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetPrototypeOperationAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_order_book()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetOrderBookAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task dbg_make_uia()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.DbgMakeUiaAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task dbg_make_mia()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.DbgMakeMiaAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task dbg_push_blocks()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.DbgPushBlocksAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task dbg_generate_blocks()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.DbgGenerateBlocksAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task dbg_stream_json_objects()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.DbgStreamJsonObjectsAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task dbg_update_object()
//        //{
//        //    var args = new object();
//        //    var resp = await Api.DbgUpdateObjectAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task flood_network()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.FloodNetworkAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task network_add_nodes()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.NetworkAddNodesAsync(args, CancellationToken.None).ConfigureAwait(false);
//        //    TestPropetries(resp);
//        //}

//        [Test][Parallelizable]
//        public async Task network_get_connected_peers()
//        {
//            var resp = await Api.NetworkGetConnectedPeersAsync(CancellationToken.None).ConfigureAwait(false);
//            TestPropetries(resp);
//        }
//    }
//}
