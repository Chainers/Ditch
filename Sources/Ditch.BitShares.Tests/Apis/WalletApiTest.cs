//using System.Threading;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using NUnit.Framework;

//namespace Ditch.BitShares.Tests.Apis
//{
//    [TestFixture]
//    public class WalletApiTest : BaseTest
//    {
//        [Test]
//        public void info()
//        {
//            var resp = Api.Info(CancellationToken.None);
//            WriteLine(resp);
//            Assert.IsFalse(resp.IsError);

//            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "info", CancellationToken.None);
//            TestPropetries(resp.Result.GetType(), obj.Result);
//            WriteLine("----------------------------------------------------------------------------");
//            WriteLine(obj);
//        }

//        [Test]
//        public void about()
//        {
//            var resp = Api.About(CancellationToken.None);
//            WriteLine(resp);
//            Assert.IsFalse(resp.IsError);

//            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "about", CancellationToken.None);
//            TestPropetries(resp.Result.GetType(), obj.Result);
//            WriteLine("----------------------------------------------------------------------------");
//            WriteLine(obj);
//        }

//        //[Test]
//        //public void get_block()
//        //{
//        //    var args = new UInt32();
//        //    var resp = Api.GetBlock(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_block", args, CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        [Test]
//        public void get_account_count()
//        {
//            var resp = Api.GetAccountCount(CancellationToken.None);
//            WriteLine(resp);
//            Assert.IsFalse(resp.IsError);
//        }

//        [Test]
//        public void list_my_accounts()
//        {
//            var resp = Api.ListMyAccounts(CancellationToken.None);
//            WriteLine(resp);
//            Assert.IsFalse(resp.IsError);

//            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "list_my_accounts",
//                CancellationToken.None);
//            TestPropetries(resp.Result.GetType(), obj.Result);
//            WriteLine("----------------------------------------------------------------------------");
//            WriteLine(obj);
//        }

//        //[Test]
//        //public void list_accounts()
//        //{
//        //    var args = new string();
//        //    var resp = Api.ListAccounts(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "list_accounts", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void list_account_balances()
//        //{
//        //    var args = new string();
//        //    var resp = Api.ListAccountBalances(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "list_account_balances", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void list_assets()
//        //{
//        //    var args = new string();
//        //    var resp = Api.ListAssets(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "list_assets", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void get_account_history()
//        //{
//        //    var args = new string();
//        //    var resp = Api.GetAccountHistory(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_account_history", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void get_relative_account_history()
//        //{
//        //    var args = new string();
//        //    var resp = Api.GetRelativeAccountHistory(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_relative_account_history", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void get_market_history()
//        //{
//        //    var args = new string();
//        //    var resp = Api.GetMarketHistory(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_market_history", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void get_limit_orders()
//        //{
//        //    var args = new string();
//        //    var resp = Api.GetLimitOrders(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_limit_orders", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void get_call_orders()
//        //{
//        //    var args = new string();
//        //    var resp = Api.GetCallOrders(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_call_orders", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void get_settle_orders()
//        //{
//        //    var args = new string();
//        //    var resp = Api.GetSettleOrders(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_settle_orders", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void get_collateral_bids()
//        //{
//        //    var args = new string();
//        //    var resp = Api.GetCollateralBids(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_collateral_bids", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        [Test]
//        public void get_global_properties()
//        {
//            var resp = Api.GetGlobalProperties(CancellationToken.None);
//            WriteLine(resp);
//            Assert.IsFalse(resp.IsError);

//            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_global_properties",
//                CancellationToken.None);
//            TestPropetries(resp.Result.GetType(), obj.Result);
//            WriteLine("----------------------------------------------------------------------------");
//            WriteLine(obj);
//        }

//        //[Test]
//        //public void get_account_history_by_operations()
//        //{
//        //    var args = new string();
//        //    var resp = Api.GetAccountHistoryByOperations(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_account_history_by_operations", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        [Test]
//        public void get_dynamic_global_properties()
//        {
//            var resp = Api.GetDynamicGlobalProperties(CancellationToken.None);
//            WriteLine(resp);
//            Assert.IsFalse(resp.IsError);

//            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_dynamic_global_properties",
//                CancellationToken.None);
//            TestPropetries(resp.Result.GetType(), obj.Result);
//            WriteLine("----------------------------------------------------------------------------");
//            WriteLine(obj);
//        }

//        //[Test]
//        //public void get_account()
//        //{
//        //    var args = new string();
//        //    var resp = Api.GetAccount(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_account", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void get_asset()
//        //{
//        //    var args = new string();
//        //    var resp = Api.GetAsset(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_asset", args, CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void get_bitasset_data()
//        //{
//        //    var args = new string();
//        //    var resp = Api.GetBitassetData(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_bitasset_data", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void get_account_id()
//        //{
//        //    var args = new string();
//        //    var resp = Api.GetAccountId(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_account_id", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void get_object()
//        //{
//        //    var args = new ObjectIdType();
//        //    var resp = Api.GetObject(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_object", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void get_private_key()
//        //{
//        //    var args = new PublicKeyType();
//        //    var resp = Api.GetPrivateKey(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_private_key", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        [Test]
//        public void begin_builder_transaction()
//        {
//            var resp = Api.BeginBuilderTransaction(CancellationToken.None);
//            WriteLine(resp);
//            Assert.IsFalse(resp.IsError);

//            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "begin_builder_transaction", CancellationToken.None);
//            TestPropetries(resp.Result.GetType(), obj.Result);
//            WriteLine("----------------------------------------------------------------------------");
//            WriteLine(obj);
//        }

//        //[Test]
//        //public void add_operation_to_builder_transaction()
//        //{
//        //    var args = new UInt16();
//        //    var resp = Api.AddOperationToBuilderTransaction(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "add_operation_to_builder_transaction",
//        //        args, CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void replace_operation_in_builder_transaction()
//        //{
//        //    var args = new UInt16();
//        //    var resp = Api.ReplaceOperationInBuilderTransaction(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "replace_operation_in_builder_transaction",
//        //        args, CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void preview_builder_transaction()
//        //{
//        //    var args = new UInt16();
//        //    var resp = Api.PreviewBuilderTransaction(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "preview_builder_transaction", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void sign_builder_transaction()
//        //{
//        //    var args = new UInt16();
//        //    var resp = Api.SignBuilderTransaction(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "sign_builder_transaction", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void broadcast_transaction()
//        //{
//        //    var args = new SignedTransaction();
//        //    var resp = Api.BroadcastTransaction(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "broadcast_transaction", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void remove_builder_transaction()
//        //{
//        //    var args = new UInt16();
//        //    var resp = Api.RemoveBuilderTransaction(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "remove_builder_transaction", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        [Test]
//        public void is_new()
//        {
//            var resp = Api.IsNew(CancellationToken.None);
//            WriteLine(resp);
//            Assert.IsFalse(resp.IsError);

//            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "is_new", CancellationToken.None);
//            TestPropetries(resp.Result.GetType(), obj.Result);
//            WriteLine("----------------------------------------------------------------------------");
//            WriteLine(obj);
//        }

//        [Test]
//        public void is_locked()
//        {
//            var resp = Api.IsLocked(CancellationToken.None);
//            WriteLine(resp);
//            Assert.IsFalse(resp.IsError);

//            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "is_locked", CancellationToken.None);
//            TestPropetries(resp.Result.GetType(), obj.Result);
//            WriteLine("----------------------------------------------------------------------------");
//            WriteLine(obj);
//        }

//        [Test]
//        public void lockTest()
//        {
//            var resp = Api.Lock(CancellationToken.None);
//            WriteLine(resp);
//            Assert.IsFalse(resp.IsError);

//            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "lock", CancellationToken.None);
//            TestPropetries(resp.Result.GetType(), obj.Result);
//            WriteLine("----------------------------------------------------------------------------");
//            WriteLine(obj);
//        }

//        //[Test]
//        //public void unlock()
//        //{
//        //    var args = new string();
//        //    var resp = Api.Unlock(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "unlock", args, CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void set_password()
//        //{
//        //    var args = new string();
//        //    var resp = Api.SetPassword(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "set_password", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        [Test]
//        public void dump_private_keys()
//        {
//            var resp = Api.DumpPrivateKeys(CancellationToken.None);
//            WriteLine(resp);
//            Assert.IsFalse(resp.IsError);

//            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "dump_private_keys",
//                CancellationToken.None);
//            TestPropetries(resp.Result.GetType(), obj.Result);
//            WriteLine("----------------------------------------------------------------------------");
//            WriteLine(obj);
//        }

//        [Test]
//        public void help()
//        {
//            var resp = Api.Help(CancellationToken.None);
//            WriteLine(resp);
//            Assert.IsFalse(resp.IsError);

//            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "help", CancellationToken.None);
//            TestPropetries(resp.Result.GetType(), obj.Result);
//            WriteLine("----------------------------------------------------------------------------");
//            WriteLine(obj);
//        }

//        //[Test]
//        //public void gethelp()
//        //{
//        //    var args = new string();
//        //    var resp = Api.Gethelp(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "gethelp", args, CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        [Test]
//        public void suggest_brain_key()
//        {
//            var resp = Api.SuggestBrainKey(CancellationToken.None);
//            WriteLine(resp);
//            Assert.IsFalse(resp.IsError);

//            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "suggest_brain_key",
//                CancellationToken.None);
//            TestPropetries(resp.Result.GetType(), obj.Result);
//            WriteLine("----------------------------------------------------------------------------");
//            WriteLine(obj);
//        }

//        //[Test]
//        //public void derive_owner_keys_from_brain_key()
//        //{
//        //    var args = new string();
//        //    var resp = Api.DeriveOwnerKeysFromBrainKey(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "derive_owner_keys_from_brain_key", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void is_public_key_registered()
//        //{
//        //    var args = new string();
//        //    var resp = Api.IsPublicKeyRegistered(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "is_public_key_registered", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void serialize_transaction()
//        //{
//        //    var args = new SignedTransaction();
//        //    var resp = Api.SerializeTransaction(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "serialize_transaction", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void import_key()
//        //{
//        //    var args = new string();
//        //    var resp = Api.ImportKey(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "import_key", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void import_accounts()
//        //{
//        //    var args = new string();
//        //    var resp = Api.ImportAccounts(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "import_accounts", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void import_account_keys()
//        //{
//        //    var args = new string();
//        //    var resp = Api.ImportAccountKeys(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "import_account_keys", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void import_balance()
//        //{
//        //    var args = new string();
//        //    var resp = Api.ImportBalance(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "import_balance", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void normalize_brain_key()
//        //{
//        //    var args = new string();
//        //    var resp = Api.NormalizeBrainKey(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "normalize_brain_key", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void register_account()
//        //{
//        //    var args = new string();
//        //    var resp = Api.RegisterAccount(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "register_account", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void upgrade_account()
//        //{
//        //    var args = new string();
//        //    var resp = Api.UpgradeAccount(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "upgrade_account", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void create_account_with_brain_key()
//        //{
//        //    var args = new string();
//        //    var resp = Api.CreateAccountWithBrainKey(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "create_account_with_brain_key", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void transfer()
//        //{
//        //    var args = new string();
//        //    var resp = Api.Transfer(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "transfer", args, CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void sign_memo()
//        //{
//        //    var args = new string();
//        //    var resp = Api.SignMemo(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "sign_memo", args, CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void read_memo()
//        //{
//        //    var args = new MemoData();
//        //    var resp = Api.ReadMemo(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "read_memo", args, CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void create_blind_account()
//        //{
//        //    var args = new string();
//        //    var resp = Api.CreateBlindAccount(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "create_blind_account", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void get_blind_balances()
//        //{
//        //    var args = new string();
//        //    var resp = Api.GetBlindBalances(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_blind_balances", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        [Test]
//        public void get_blind_accounts()
//        {
//            var resp = Api.GetBlindAccounts(CancellationToken.None);
//            WriteLine(resp);
//            Assert.IsFalse(resp.IsError);

//            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_blind_accounts",
//                CancellationToken.None);
//            TestPropetries(resp.Result.GetType(), obj.Result);
//            WriteLine("----------------------------------------------------------------------------");
//            WriteLine(obj);
//        }

//        [Test]
//        public void get_my_blind_accounts()
//        {
//            var resp = Api.GetMyBlindAccounts(CancellationToken.None);
//            WriteLine(resp);
//            Assert.IsFalse(resp.IsError);

//            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_my_blind_accounts",
//                CancellationToken.None);
//            TestPropetries(resp.Result.GetType(), obj.Result);
//            WriteLine("----------------------------------------------------------------------------");
//            WriteLine(obj);
//        }

//        //[Test]
//        //public void get_public_key()
//        //{
//        //    var args = new string();
//        //    var resp = Api.GetPublicKey(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_public_key", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void blind_history()
//        //{
//        //    var args = new string();
//        //    var resp = Api.BlindHistory(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "blind_history", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void receive_blind_transfer()
//        //{
//        //    var args = new string();
//        //    var resp = Api.ReceiveBlindTransfer(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "receive_blind_transfer", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void blind_transfer()
//        //{
//        //    var args = new string();
//        //    var resp = Api.BlindTransfer(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "blind_transfer", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void sell_asset()
//        //{
//        //    var args = new string();
//        //    var resp = Api.SellAsset(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "sell_asset", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void borrow_asset()
//        //{
//        //    var args = new string();
//        //    var resp = Api.BorrowAsset(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "borrow_asset", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void cancel_order()
//        //{
//        //    var args = new ObjectIdType();
//        //    var resp = Api.CancelOrder(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "cancel_order", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void create_asset()
//        //{
//        //    var args = new string();
//        //    var resp = Api.CreateAsset(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "create_asset", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void issue_asset()
//        //{
//        //    var args = new string();
//        //    var resp = Api.IssueAsset(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "issue_asset", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void update_asset()
//        //{
//        //    var args = new string();
//        //    var resp = Api.UpdateAsset(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "update_asset", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void update_bitasset()
//        //{
//        //    var args = new string();
//        //    var resp = Api.UpdateBitasset(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "update_bitasset", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void update_asset_feed_producers()
//        //{
//        //    var args = new string();
//        //    var resp = Api.UpdateAssetFeedProducers(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "update_asset_feed_producers", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void publish_asset_feed()
//        //{
//        //    var args = new string();
//        //    var resp = Api.PublishAssetFeed(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "publish_asset_feed", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void fund_asset_fee_pool()
//        //{
//        //    var args = new string();
//        //    var resp = Api.FundAssetFeePool(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "fund_asset_fee_pool", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void reserve_asset()
//        //{
//        //    var args = new string();
//        //    var resp = Api.ReserveAsset(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "reserve_asset", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void global_settle_asset()
//        //{
//        //    var args = new string();
//        //    var resp = Api.GlobalSettleAsset(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "global_settle_asset", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void settle_asset()
//        //{
//        //    var args = new string();
//        //    var resp = Api.SettleAsset(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "settle_asset", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void bid_collateral()
//        //{
//        //    var args = new string();
//        //    var resp = Api.BidCollateral(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "bid_collateral", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void whitelist_account()
//        //{
//        //    var args = new string();
//        //    var resp = Api.WhitelistAccount(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "whitelist_account", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void create_committee_member()
//        //{
//        //    var args = new string();
//        //    var resp = Api.CreateCommitteeMember(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "create_committee_member", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void list_witnesses()
//        //{
//        //    var args = new string();
//        //    var resp = Api.ListWitnesses(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "list_witnesses", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void list_committee_members()
//        //{
//        //    var args = new string();
//        //    var resp = Api.ListCommitteeMembers(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "list_committee_members", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void get_witness()
//        //{
//        //    var args = new string();
//        //    var resp = Api.GetWitness(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_witness", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void get_committee_member()
//        //{
//        //    var args = new string();
//        //    var resp = Api.GetCommitteeMember(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_committee_member", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void create_witness()
//        //{
//        //    var args = new string();
//        //    var resp = Api.CreateWitness(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "create_witness", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void update_witness()
//        //{
//        //    var args = new string();
//        //    var resp = Api.UpdateWitness(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "update_witness", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void get_vesting_balances()
//        //{
//        //    var args = new string();
//        //    var resp = Api.GetVestingBalances(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_vesting_balances", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void vote_for_committee_member()
//        //{
//        //    var args = new string();
//        //    var resp = Api.VoteForCommitteeMember(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "vote_for_committee_member", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void vote_for_witness()
//        //{
//        //    var args = new string();
//        //    var resp = Api.VoteForWitness(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "vote_for_witness", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void set_voting_proxy()
//        //{
//        //    var args = new string();
//        //    var resp = Api.SetVotingProxy(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "set_voting_proxy", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void set_desired_witness_and_committee_member_count()
//        //{
//        //    var args = new string();
//        //    var resp = Api.SetDesiredWitnessAndCommitteeMemberCount(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi,
//        //        "set_desired_witness_and_committee_member_count", args, CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void sign_transaction()
//        //{
//        //    var args = new SignedTransaction();
//        //    var resp = Api.SignTransaction(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "sign_transaction", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void get_prototype_operation()
//        //{
//        //    var args = new string();
//        //    var resp = Api.GetPrototypeOperation(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_prototype_operation", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void get_order_book()
//        //{
//        //    var args = new string();
//        //    var resp = Api.GetOrderBook(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "get_order_book", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void dbg_make_uia()
//        //{
//        //    var args = new string();
//        //    var resp = Api.DbgMakeUia(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "dbg_make_uia", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void dbg_make_mia()
//        //{
//        //    var args = new string();
//        //    var resp = Api.DbgMakeMia(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "dbg_make_mia", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void dbg_push_blocks()
//        //{
//        //    var args = new string();
//        //    var resp = Api.DbgPushBlocks(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "dbg_push_blocks", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void dbg_generate_blocks()
//        //{
//        //    var args = new string();
//        //    var resp = Api.DbgGenerateBlocks(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "dbg_generate_blocks", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void dbg_stream_json_objects()
//        //{
//        //    var args = new string();
//        //    var resp = Api.DbgStreamJsonObjects(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "dbg_stream_json_objects", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void dbg_update_object()
//        //{
//        //    var args = new object();
//        //    var resp = Api.DbgUpdateObject(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "dbg_update_object", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void flood_network()
//        //{
//        //    var args = new string();
//        //    var resp = Api.FloodNetwork(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "flood_network", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        //[Test]
//        //public void network_add_nodes()
//        //{
//        //    var args = new string();
//        //    var resp = Api.NetworkAddNodes(args, CancellationToken.None);
//        //    WriteLine(resp);
//        //    Assert.IsFalse(resp.IsError);
//        //    WriteLine(resp);

//        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "network_add_nodes", args,
//        //        CancellationToken.None);
//        //    TestPropetries(resp.Result.GetType(), obj.Result);
//        //    WriteLine("----------------------------------------------------------------------------");
//        //    WriteLine(obj);
//        //}

//        [Test]
//        public void network_get_connected_peers()
//        {
//            var resp = Api.NetworkGetConnectedPeers(CancellationToken.None);
//            WriteLine(resp);
//            Assert.IsFalse(resp.IsError);

//            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WalletApi, "network_get_connected_peers",
//                CancellationToken.None);
//            TestPropetries(resp.Result.GetType(), obj.Result);
//            WriteLine("----------------------------------------------------------------------------");
//            WriteLine(obj);
//        }
//    }
//}
