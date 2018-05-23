using System;
using System.Threading;
using Ditch.BitShares.Models;
using Newtonsoft.Json;
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
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_objects", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_block_header()
        //{
        //    var args = new UInt32();
        //    var resp = Api.GetBlockHeader(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_block_header", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_block_header_batch()
        //{
        //    var args = new UInt32();
        //    var resp = Api.GetBlockHeaderBatch(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_block_header_batch", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_block()
        //{
        //    var args = new UInt32();
        //    var resp = Api.GetBlock(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_block", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_transaction()
        //{
        //    var args = new UInt32();
        //    var resp = Api.GetTransaction(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_transaction", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_recent_transaction_by_id()
        //{
        //    var args = new string();
        //    var resp = Api.GetRecentTransactionById(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_recent_transaction_by_id", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        [Test]
        public void get_chain_properties()
        {
            var resp = Api.GetChainProperties(CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_chain_properties", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_global_properties()
        {
            var resp = Api.GetGlobalProperties(CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_global_properties", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_config()
        {
            var resp = Api.GetConfig<JObject>(CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);
        }

        [Test]
        public void get_chain_id()
        {
            var resp = Api.GetChainId(CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);
        }

        [Test]
        public void get_dynamic_global_properties()
        {
            var resp = Api.GetDynamicGlobalProperties(CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_dynamic_global_properties", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(JsonConvert.SerializeObject(obj));
        }

        //[Test]
        //public void get_key_references()
        //{
        //    var args = new PublicKeyType();
        //    var resp = Api.GetKeyReferences(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_key_references", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void is_public_key_registered()
        //{
        //    var args = new string();
        //    var resp = Api.IsPublicKeyRegistered(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "is_public_key_registered", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_accounts()
        //{
        //    var args = new AccountIdType();
        //    var resp = Api.GetAccounts(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_accounts", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_full_accounts()
        //{
        //    var args = new string();
        //    var resp = Api.GetFullAccounts(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_full_accounts", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_account_by_name()
        //{
        //    var args = new string();
        //    var resp = Api.GetAccountByName(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_account_by_name", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_account_references()
        //{
        //    var args = new AccountIdType();
        //    var resp = Api.GetAccountReferences(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_account_references", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void lookup_account_names()
        //{
        //    var args = new string();
        //    var resp = Api.LookupAccountNames(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "lookup_account_names", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void lookup_accounts()
        //{
        //    var args = new string();
        //    var resp = Api.LookupAccounts(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "lookup_accounts", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_account_balances()
        //{
        //    var args = new AccountIdType();
        //    var resp = Api.GetAccountBalances(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_account_balances", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_named_account_balances()
        //{
        //    var args = new string();
        //    var resp = Api.GetNamedAccountBalances(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_named_account_balances", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_balance_objects()
        //{
        //    var args = new Address();
        //    var resp = Api.GetBalanceObjects(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_balance_objects", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_vested_balances()
        //{
        //    var args = new BalanceIdType();
        //    var resp = Api.GetVestedBalances(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_vested_balances", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_vesting_balances()
        //{
        //    var args = new AccountIdType();
        //    var resp = Api.GetVestingBalances(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_vesting_balances", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        [Test]
        public void get_account_count()
        {
            var resp = Api.GetAccountCount(CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);
        }

        //[Test]
        //public void get_assets()
        //{
        //    var args = new AssetIdType();
        //    var resp = Api.GetAssets(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_assets", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void list_assets()
        //{
        //    var args = new string();
        //    var resp = Api.ListAssets(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "list_assets", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void lookup_asset_symbols()
        //{
        //    var args = new string();
        //    var resp = Api.LookupAssetSymbols(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "lookup_asset_symbols", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_limit_orders()
        //{
        //    var args = new AssetIdType();
        //    var resp = Api.GetLimitOrders(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_limit_orders", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_call_orders()
        //{
        //    var args = new AssetIdType();
        //    var resp = Api.GetCallOrders(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_call_orders", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_settle_orders()
        //{
        //    var args = new AssetIdType();
        //    var resp = Api.GetSettleOrders(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_settle_orders", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_collateral_bids()
        //{
        //    var args = new AssetIdType();
        //    var resp = Api.GetCollateralBids(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_collateral_bids", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_margin_positions()
        //{
        //    var args = new AccountIdType();
        //    var resp = Api.GetMarginPositions(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_margin_positions", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void subscribe_to_market()
        //{
        //    var args = new Function();
        //    var resp = Api.SubscribeToMarket(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "subscribe_to_market", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void unsubscribe_from_market()
        //{
        //    var args = new AssetIdType();
        //    var resp = Api.UnsubscribeFromMarket(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "unsubscribe_from_market", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_ticker()
        //{
        //    var args = new string();
        //    var resp = Api.GetTicker(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_ticker", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_24_volume()
        //{
        //    var args = new string();
        //    var resp = Api.Get24Volume(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_24_volume", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_order_book()
        //{
        //    var args = new string();
        //    var resp = Api.GetOrderBook(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_order_book", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_top_markets()
        //{
        //    var args = new UInt32();
        //    var resp = Api.GetTopMarkets(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_top_markets", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_trade_history()
        //{
        //    var args = new string();
        //    var resp = Api.GetTradeHistory(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_trade_history", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_trade_history_by_sequence()
        //{
        //    var args = new string();
        //    var resp = Api.GetTradeHistoryBySequence(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_trade_history_by_sequence", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_witnesses()
        //{
        //    var args = new WitnessIdType();
        //    var resp = Api.GetWitnesses(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_witnesses", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_witness_by_account()
        //{
        //    var args = new AccountIdType();
        //    var resp = Api.GetWitnessByAccount(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_witness_by_account", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void lookup_witness_accounts()
        //{
        //    var args = new string();
        //    var resp = Api.LookupWitnessAccounts(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "lookup_witness_accounts", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        [Test]
        public void get_witness_count()
        {
            var resp = Api.GetWitnessCount(CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);
        }

        //[Test]
        //public void get_committee_members()
        //{
        //    var args = new CommitteeMemberIdType();
        //    var resp = Api.GetCommitteeMembers(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_committee_members", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_committee_member_by_account()
        //{
        //    var args = new AccountIdType();
        //    var resp = Api.GetCommitteeMemberByAccount(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_committee_member_by_account", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void lookup_committee_member_accounts()
        //{
        //    var args = new string();
        //    var resp = Api.LookupCommitteeMemberAccounts(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "lookup_committee_member_accounts", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        [Test]
        public void get_committee_count()
        {
            var resp = Api.GetCommitteeCount(CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);
        }

        [Test]
        public void get_all_workers()
        {
            var resp = Api.GetAllWorkers(CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_all_workers", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(JsonConvert.SerializeObject(obj));
        }

        //[Test]
        //public void get_workers_by_account()
        //{
        //    var args = new AccountIdType();
        //    var resp = Api.GetWorkersByAccount(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_workers_by_account", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        [Test]
        public void get_worker_count()
        {
            var resp = Api.GetWorkerCount(CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);
        }

        //[Test]
        //public void lookup_vote_ids()
        //{
        //    var args = new VoteIdType();
        //    var resp = Api.LookupVoteIds(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "lookup_vote_ids", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_transaction_hex()
        //{
        //    var args = new SignedTransaction();
        //    var resp = Api.GetTransactionHex(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_transaction_hex", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_required_signatures()
        //{
        //    var args = new SignedTransaction();
        //    var resp = Api.GetRequiredSignatures(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_required_signatures", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_potential_signatures()
        //{
        //    var args = new SignedTransaction();
        //    var resp = Api.GetPotentialSignatures(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_potential_signatures", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_potential_address_signatures()
        //{
        //    var args = new SignedTransaction();
        //    var resp = Api.GetPotentialAddressSignatures(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_potential_address_signatures", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void verify_authority()
        //{
        //    var args = new SignedTransaction();
        //    var resp = Api.VerifyAuthority(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "verify_authority", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void verify_account_authority()
        //{
        //    var args = new string();
        //    var resp = Api.VerifyAccountAuthority(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "verify_account_authority", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void validate_transaction()
        //{
        //    var args = new SignedTransaction();
        //    var resp = Api.ValidateTransaction(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "validate_transaction", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_required_fees()
        //{
        //    var args = new Operation();
        //    var resp = Api.GetRequiredFees(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_required_fees", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_proposed_transactions()
        //{
        //    var args = new AccountIdType();
        //    var resp = Api.GetProposedTransactions(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_proposed_transactions", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_blinded_balances()
        //{
        //    var args = new FlatSet();
        //    var resp = Api.GetBlindedBalances(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_blinded_balances", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_withdraw_permissions_by_giver()
        //{
        //    var args = new AccountIdType();
        //    var resp = Api.GetWithdrawPermissionsByGiver(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_withdraw_permissions_by_giver", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_withdraw_permissions_by_recipient()
        //{
        //    var args = new AccountIdType();
        //    var resp = Api.GetWithdrawPermissionsByRecipient(args, CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_withdraw_permissions_by_recipient", args, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    WriteLine("----------------------------------------------------------------------------");
        //    WriteLine(JsonConvert.SerializeObject(obj));
        //}
    }
}
