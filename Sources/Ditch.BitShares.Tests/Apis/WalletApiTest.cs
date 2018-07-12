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
//            var resp = await Api.Info(CancellationToken.None);
//        }

//        [Test][Parallelizable]
//        public async Task about()
//        {
//            var resp = await Api.About(CancellationToken.None);
//        }

//        //[Test]
//        //public async Task get_block()
//        //{
//        //    var args = new UInt32();
//        //    var resp = await Api.GetBlock(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        [Test][Parallelizable]
//        public async Task get_account_count()
//        {
//            var resp = await Api.GetAccountCount(CancellationToken.None);
//        }

//        [Test][Parallelizable]
//        public async Task list_my_accounts()
//        {
//            var resp = await Api.ListMyAccounts(CancellationToken.None);
//            TestPropetries(resp);
//        }

//        //[Test]
//        //public async Task list_accounts()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.ListAccounts(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task list_account_balances()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.ListAccountBalances(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task list_assets()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.ListAssets(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_account_history()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetAccountHistory(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_relative_account_history()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetRelativeAccountHistory(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_market_history()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetMarketHistory(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_limit_orders()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetLimitOrders(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_call_orders()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetCallOrders(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_settle_orders()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetSettleOrders(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_collateral_bids()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetCollateralBids(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        [Test][Parallelizable]
//        public async Task get_global_properties()
//        {
//            var resp = await Api.GetGlobalProperties(CancellationToken.None);
//            TestPropetries(resp);
//        }

//        //[Test]
//        //public async Task get_account_history_by_operations()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetAccountHistoryByOperations(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        [Test][Parallelizable]
//        public async Task get_dynamic_global_properties()
//        {
//            var resp = await Api.GetDynamicGlobalProperties(CancellationToken.None);
//            TestPropetries(resp);
//        }

//        //[Test]
//        //public async Task get_account()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetAccount(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_asset()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetAsset(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_bitasset_data()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetBitassetData(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_account_id()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetAccountId(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_object()
//        //{
//        //    var args = new ObjectIdType();
//        //    var resp = await Api.GetObject(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_private_key()
//        //{
//        //    var args = new PublicKeyType();
//        //    var resp = await Api.GetPrivateKey(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        [Test][Parallelizable]
//        public async Task begin_builder_transaction()
//        {
//            var resp = await Api.BeginBuilderTransaction(CancellationToken.None);
//            TestPropetries(resp);
//        }

//        //[Test]
//        //public async Task add_operation_to_builder_transaction()
//        //{
//        //    var args = new UInt16();
//        //    var resp = await Api.AddOperationToBuilderTransaction(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task replace_operation_in_builder_transaction()
//        //{
//        //    var args = new UInt16();
//        //    var resp = await Api.ReplaceOperationInBuilderTransaction(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task preview_builder_transaction()
//        //{
//        //    var args = new UInt16();
//        //    var resp = await Api.PreviewBuilderTransaction(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task sign_builder_transaction()
//        //{
//        //    var args = new UInt16();
//        //    var resp = await Api.SignBuilderTransaction(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task broadcast_transaction()
//        //{
//        //    var args = new SignedTransaction();
//        //    var resp = await Api.BroadcastTransaction(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task remove_builder_transaction()
//        //{
//        //    var args = new UInt16();
//        //    var resp = await Api.RemoveBuilderTransaction(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        [Test][Parallelizable]
//        public async Task is_new()
//        {
//            var resp = await Api.IsNew(CancellationToken.None);
//            TestPropetries(resp);
//        }

//        [Test][Parallelizable]
//        public async Task is_locked()
//        {
//            var resp = await Api.IsLocked(CancellationToken.None);
//            TestPropetries(resp);
//        }

//        [Test][Parallelizable]
//        public async Task lockTest()
//        {
//            var resp = await Api.Lock(CancellationToken.None);
//            TestPropetries(resp);
//        }

//        //[Test]
//        //public async Task unlock()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.Unlock(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task set_password()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.SetPassword(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        [Test][Parallelizable]
//        public async Task dump_private_keys()
//        {
//            var resp = await Api.DumpPrivateKeys(CancellationToken.None);
//            TestPropetries(resp);
//        }

//        [Test][Parallelizable]
//        public async Task help()
//        {
//            var resp = await Api.Help(CancellationToken.None);
//            TestPropetries(resp);
//        }

//        //[Test]
//        //public async Task gethelp()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.Gethelp(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        [Test][Parallelizable]
//        public async Task suggest_brain_key()
//        {
//            var resp = await Api.SuggestBrainKey(CancellationToken.None);
//            TestPropetries(resp);
//        }

//        //[Test]
//        //public async Task derive_owner_keys_from_brain_key()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.DeriveOwnerKeysFromBrainKey(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task is_public_key_registered()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.IsPublicKeyRegistered(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task serialize_transaction()
//        //{
//        //    var args = new SignedTransaction();
//        //    var resp = await Api.SerializeTransaction(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task import_key()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.ImportKey(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task import_accounts()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.ImportAccounts(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task import_account_keys()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.ImportAccountKeys(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task import_balance()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.ImportBalance(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task normalize_brain_key()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.NormalizeBrainKey(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task register_account()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.RegisterAccount(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task upgrade_account()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.UpgradeAccount(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task create_account_with_brain_key()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.CreateAccountWithBrainKey(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task transfer()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.Transfer(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task sign_memo()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.SignMemo(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task read_memo()
//        //{
//        //    var args = new MemoData();
//        //    var resp = await Api.ReadMemo(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task create_blind_account()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.CreateBlindAccount(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_blind_balances()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetBlindBalances(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        [Test][Parallelizable]
//        public async Task get_blind_accounts()
//        {
//            var resp = await Api.GetBlindAccounts(CancellationToken.None);
//            TestPropetries(resp);
//        }

//        [Test][Parallelizable]
//        public async Task get_my_blind_accounts()
//        {
//            var resp = await Api.GetMyBlindAccounts(CancellationToken.None);
//            TestPropetries(resp);
//        }

//        //[Test]
//        //public async Task get_public_key()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetPublicKey(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task blind_history()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.BlindHistory(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task receive_blind_transfer()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.ReceiveBlindTransfer(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task blind_transfer()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.BlindTransfer(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task sell_asset()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.SellAsset(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task borrow_asset()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.BorrowAsset(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task cancel_order()
//        //{
//        //    var args = new ObjectIdType();
//        //    var resp = await Api.CancelOrder(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task create_asset()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.CreateAsset(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task issue_asset()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.IssueAsset(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task update_asset()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.UpdateAsset(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task update_bitasset()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.UpdateBitasset(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task update_asset_feed_producers()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.UpdateAssetFeedProducers(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task publish_asset_feed()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.PublishAssetFeed(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task fund_asset_fee_pool()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.FundAssetFeePool(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task reserve_asset()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.ReserveAsset(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task global_settle_asset()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GlobalSettleAsset(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task settle_asset()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.SettleAsset(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task bid_collateral()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.BidCollateral(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task whitelist_account()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.WhitelistAccount(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task create_committee_member()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.CreateCommitteeMember(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task list_witnesses()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.ListWitnesses(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task list_committee_members()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.ListCommitteeMembers(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_witness()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetWitness(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_committee_member()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetCommitteeMember(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task create_witness()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.CreateWitness(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task update_witness()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.UpdateWitness(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_vesting_balances()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetVestingBalances(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task vote_for_committee_member()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.VoteForCommitteeMember(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task vote_for_witness()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.VoteForWitness(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task set_voting_proxy()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.SetVotingProxy(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task set_desired_witness_and_committee_member_count()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.SetDesiredWitnessAndCommitteeMemberCount(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task sign_transaction()
//        //{
//        //    var args = new SignedTransaction();
//        //    var resp = await Api.SignTransaction(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_prototype_operation()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetPrototypeOperation(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task get_order_book()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.GetOrderBook(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task dbg_make_uia()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.DbgMakeUia(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task dbg_make_mia()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.DbgMakeMia(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task dbg_push_blocks()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.DbgPushBlocks(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task dbg_generate_blocks()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.DbgGenerateBlocks(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task dbg_stream_json_objects()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.DbgStreamJsonObjects(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task dbg_update_object()
//        //{
//        //    var args = new object();
//        //    var resp = await Api.DbgUpdateObject(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task flood_network()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.FloodNetwork(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        //[Test]
//        //public async Task network_add_nodes()
//        //{
//        //    var args = new string();
//        //    var resp = await Api.NetworkAddNodes(args, CancellationToken.None);
//        //    TestPropetries(resp);
//        //}

//        [Test][Parallelizable]
//        public async Task network_get_connected_peers()
//        {
//            var resp = await Api.NetworkGetConnectedPeers(CancellationToken.None);
//            TestPropetries(resp);
//        }
//    }
//}
