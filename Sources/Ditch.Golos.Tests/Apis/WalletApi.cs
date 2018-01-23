using System;
using System.Threading;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class WalletApiTest : BaseTest
    {
        //[Test]
        //[Ignore("no method")]
        //public void help()
        //{
        //    var resp = Api.Help(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        //}

        //[Test]
        //[Ignore("no method")]
        //public void info()
        //{
        //    var resp = Api.Info(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        //}

        //[Test]
        //[Ignore("no method")]
        //public void about()
        //{
        //    var resp = Api.About(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        //}

        //    [Test]
        //    public void get_ops_in_block()
        //    {
        //        var resp = Api.GetOpsInBlock(CancellationToken.None);
        //        Console.WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //        var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_ops_in_block", new object[] { }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        Console.WriteLine("----------------------------------------------------------------------------");
        //        Console.WriteLine(JsonConvert.SerializeObject(obj));
        //    }

        //    [Test]
        //    public void get_feed_history()
        //    {
        //        var resp = Api.GetFeedHistory(CancellationToken.None);
        //        Console.WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //        var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_feed_history", new object[] { }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        Console.WriteLine("----------------------------------------------------------------------------");
        //        Console.WriteLine(JsonConvert.SerializeObject(obj));
        //    }

        //    [Test]
        //    public void get_active_witnesses()
        //    {
        //        var resp = Api.GetActiveWitnesses(CancellationToken.None);
        //        Console.WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //        var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_active_witnesses", new object[] { }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        Console.WriteLine("----------------------------------------------------------------------------");
        //        Console.WriteLine(JsonConvert.SerializeObject(obj));
        //    }

        //    [Test]
        //    public void get_miner_queue()
        //    {
        //        var resp = Api.GetMinerQueue(CancellationToken.None);
        //        Console.WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //        var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_miner_queue", new object[] { }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        Console.WriteLine("----------------------------------------------------------------------------");
        //        Console.WriteLine(JsonConvert.SerializeObject(obj));
        //    }

        //    [Test]
        //    public void get_withdraw_routes()
        //    {
        //        var resp = Api.GetWithdrawRoutes(CancellationToken.None);
        //        Console.WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //        var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_withdraw_routes", new object[] { }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        Console.WriteLine("----------------------------------------------------------------------------");
        //        Console.WriteLine(JsonConvert.SerializeObject(obj));
        //    }

        //    [Test]
        //    public void get_steem_per_mvests()
        //    {
        //        var resp = Api.GetSteemPerMvests(CancellationToken.None);
        //        Console.WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //        var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_steem_per_mvests", new object[] { }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        Console.WriteLine("----------------------------------------------------------------------------");
        //        Console.WriteLine(JsonConvert.SerializeObject(obj));
        //    }

        //    [Test]
        //    public void list_my_accounts()
        //    {
        //        var resp = Api.ListMyAccounts(CancellationToken.None);
        //        Console.WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //        var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "list_my_accounts", new object[] { }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        Console.WriteLine("----------------------------------------------------------------------------");
        //        Console.WriteLine(JsonConvert.SerializeObject(obj));
        //    }

        //    [Test]
        //    public void list_accounts()
        //    {
        //        var resp = Api.ListAccounts(CancellationToken.None);
        //        Console.WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //        var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "list_accounts", new object[] { }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        Console.WriteLine("----------------------------------------------------------------------------");
        //        Console.WriteLine(JsonConvert.SerializeObject(obj));
        //    }

        //    [Test]
        //    public void list_account_balances()
        //    {
        //        var resp = Api.ListAccountBalances(CancellationToken.None);
        //        Console.WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //        var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "list_account_balances", new object[] { }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        Console.WriteLine("----------------------------------------------------------------------------");
        //        Console.WriteLine(JsonConvert.SerializeObject(obj));
        //    }

        //    [Test]
        //    public void list_assets()
        //    {
        //        var resp = Api.ListAssets(CancellationToken.None);
        //        Console.WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //        var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "list_assets", new object[] { }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        Console.WriteLine("----------------------------------------------------------------------------");
        //        Console.WriteLine(JsonConvert.SerializeObject(obj));
        //    }

        //    [Test]
        //    public void get_account()
        //    {
        //        var resp = Api.GetAccount(CancellationToken.None);
        //        Console.WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //        var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_account", new object[] { }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        Console.WriteLine("----------------------------------------------------------------------------");
        //        Console.WriteLine(JsonConvert.SerializeObject(obj));
        //    }

        //    [Test]
        //    public void get_asset()
        //    {
        //        var resp = Api.GetAsset(CancellationToken.None);
        //        Console.WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //        var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_asset", new object[] { }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        Console.WriteLine("----------------------------------------------------------------------------");
        //        Console.WriteLine(JsonConvert.SerializeObject(obj));
        //    }

        //    [Test]
        //    public void get_proposal()
        //    {
        //        var resp = Api.GetProposal(CancellationToken.None);
        //        Console.WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //        var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_proposal", new object[] { }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        Console.WriteLine("----------------------------------------------------------------------------");
        //        Console.WriteLine(JsonConvert.SerializeObject(obj));
        //    }

        //    [Test]
        //    public void get_bitasset_data()
        //    {
        //        var resp = Api.GetBitassetData(CancellationToken.None);
        //        Console.WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //        var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_bitasset_data", new object[] { }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        Console.WriteLine("----------------------------------------------------------------------------");
        //        Console.WriteLine(JsonConvert.SerializeObject(obj));
        //    }

        //    [Test]
        //    public void get_private_key()
        //    {
        //        var resp = Api.GetPrivateKey(CancellationToken.None);
        //        Console.WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //        var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_private_key", new object[] { }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        Console.WriteLine("----------------------------------------------------------------------------");
        //        Console.WriteLine(JsonConvert.SerializeObject(obj));
        //    }

        //    [Test]
        //    public void get_private_key_from_password()
        //    {
        //        var resp = Api.GetPrivateKeyFromPassword(CancellationToken.None);
        //        Console.WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //        var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_private_key_from_password", new object[] { }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        Console.WriteLine("----------------------------------------------------------------------------");
        //        Console.WriteLine(JsonConvert.SerializeObject(obj));
        //    }

        //    [Test]
        //    public void get_transaction()
        //    {
        //        var resp = Api.GetTransaction(CancellationToken.None);
        //        Console.WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //        var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_transaction", new object[] { }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        Console.WriteLine("----------------------------------------------------------------------------");
        //        Console.WriteLine(JsonConvert.SerializeObject(obj));
        //    }

        //    [Test]
        //    public void is_new()
        //    {
        //        var resp = Api.IsNew(CancellationToken.None);
        //        Console.WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //        var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "is_new", new object[] { }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        Console.WriteLine("----------------------------------------------------------------------------");
        //        Console.WriteLine(JsonConvert.SerializeObject(obj));
        //    }

        //    [Test]
        //    public void is_locked()
        //    {
        //        var resp = Api.IsLocked(CancellationToken.None);
        //        Console.WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //        var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "is_locked", new object[] { }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        Console.WriteLine("----------------------------------------------------------------------------");
        //        Console.WriteLine(JsonConvert.SerializeObject(obj));
        //    }

        //    [Test]
        //    public void lock()
        //    {
        //        var resp = Api.Lock(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //        var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "lock", new object[] { }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //        Console.WriteLine(JsonConvert.SerializeObject(obj));
        //    }

        //[Test]
        //public void unlock()
        //{
        //    var resp = Api.Unlock(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "unlock", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void set_password()
        //{
        //    var resp = Api.SetPassword(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "set_password", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void list_keys()
        //{
        //    var resp = Api.ListKeys(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "list_keys", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_help()
        //{
        //    var resp = Api.GetHelp(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_help", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void suggest_brain_key()
        //{
        //    var resp = Api.SuggestBrainKey(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "suggest_brain_key", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void serialize_transaction()
        //{
        //    var resp = Api.SerializeTransaction(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "serialize_transaction", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void import_key()
        //{
        //    var resp = Api.ImportKey(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "import_key", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void create_account()
        //{
        //    var resp = Api.CreateAccount(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "create_account", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void create_account_with_keys()
        //{
        //    var resp = Api.CreateAccountWithKeys(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "create_account_with_keys", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void create_account_delegated()
        //{
        //    var resp = Api.CreateAccountDelegated(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "create_account_delegated", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void create_account_with_keys_delegated()
        //{
        //    var resp = Api.CreateAccountWithKeysDelegated(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "create_account_with_keys_delegated", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void update_account_auth_key()
        //{
        //    var resp = Api.UpdateAccountAuthKey(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "update_account_auth_key", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void update_account_auth_account()
        //{
        //    var resp = Api.UpdateAccountAuthAccount(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "update_account_auth_account", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void update_account_auth_threshold()
        //{
        //    var resp = Api.UpdateAccountAuthThreshold(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "update_account_auth_threshold", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void update_account_memo_key()
        //{
        //    var resp = Api.UpdateAccountMemoKey(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "update_account_memo_key", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void delegate_vesting_shares()
        //{
        //    var resp = Api.DelegateVestingShares(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "delegate_vesting_shares", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void list_witnesses()
        //{
        //    var resp = Api.ListWitnesses(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "list_witnesses", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_witness()
        //{
        //    var resp = Api.GetWitness(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_witness", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_conversion_requests()
        //{
        //    var resp = Api.GetConversionRequests(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_conversion_requests", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void update_witness()
        //{
        //    var resp = Api.UpdateWitness(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "update_witness", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void set_voting_proxy()
        //{
        //    var resp = Api.SetVotingProxy(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "set_voting_proxy", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void transfer()
        //{
        //    var resp = Api.Transfer(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "transfer", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void transfer_to_vesting()
        //{
        //    var resp = Api.TransferToVesting(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "transfer_to_vesting", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void transfer_to_savings()
        //{
        //    var resp = Api.TransferToSavings(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "transfer_to_savings", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void transfer_from_savings()
        //{
        //    var resp = Api.TransferFromSavings(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "transfer_from_savings", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void withdraw_vesting()
        //{
        //    var resp = Api.WithdrawVesting(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "withdraw_vesting", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void set_withdraw_vesting_route()
        //{
        //    var resp = Api.SetWithdrawVestingRoute(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "set_withdraw_vesting_route", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void publish_feed()
        //{
        //    var resp = Api.PublishFeed(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "publish_feed", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void sign_transaction()
        //{
        //    var resp = Api.SignTransaction(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "sign_transaction", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_prototype_operation()
        //{
        //    var resp = Api.GetPrototypeOperation(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_prototype_operation", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void network_add_nodes()
        //{
        //    var resp = Api.NetworkAddNodes(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "network_add_nodes", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void network_get_connected_peers()
        //{
        //    var resp = Api.NetworkGetConnectedPeers(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "network_get_connected_peers", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_order_book()
        //{
        //    var resp = Api.GetOrderBook(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_order_book", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_limit_orders_by_owner()
        //{
        //    var resp = Api.GetLimitOrdersByOwner(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_limit_orders_by_owner", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_call_orders_by_owner()
        //{
        //    var resp = Api.GetCallOrdersByOwner(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_call_orders_by_owner", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_collateral_bids()
        //{
        //    var resp = Api.GetCollateralBids(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_collateral_bids", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void bid_collateral()
        //{
        //    var resp = Api.BidCollateral(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "bid_collateral", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void create_order()
        //{
        //    var resp = Api.CreateOrder(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "create_order", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void cancel_order()
        //{
        //    var resp = Api.CancelOrder(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "cancel_order", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void sell_asset()
        //{
        //    var resp = Api.SellAsset(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "sell_asset", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void sell()
        //{
        //    var resp = Api.Sell(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "sell", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void buy()
        //{
        //    var resp = Api.Buy(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "buy", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void borrow_asset()
        //{
        //    var resp = Api.BorrowAsset(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "borrow_asset", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void create_asset()
        //{
        //    var resp = Api.CreateAsset(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "create_asset", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void update_asset()
        //{
        //    var resp = Api.UpdateAsset(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "update_asset", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void update_bitasset()
        //{
        //    var resp = Api.UpdateBitasset(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "update_bitasset", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void update_asset_feed_producers()
        //{
        //    var resp = Api.UpdateAssetFeedProducers(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "update_asset_feed_producers", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void publish_asset_feed()
        //{
        //    var resp = Api.PublishAssetFeed(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "publish_asset_feed", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void fund_asset_fee_pool()
        //{
        //    var resp = Api.FundAssetFeePool(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "fund_asset_fee_pool", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void reserve_asset()
        //{
        //    var resp = Api.ReserveAsset(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "reserve_asset", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void global_settle_asset()
        //{
        //    var resp = Api.GlobalSettleAsset(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "global_settle_asset", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void whitelist_account()
        //{
        //    var resp = Api.WhitelistAccount(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "whitelist_account", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void post_comment()
        //{
        //    var resp = Api.PostComment(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "post_comment", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void extend_payout_by_cost()
        //{
        //    var resp = Api.ExtendPayoutByCost(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "extend_payout_by_cost", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void send_private_message()
        //{
        //    var resp = Api.SendPrivateMessage(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "send_private_message", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_inbox()
        //{
        //    var resp = Api.GetInbox(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_inbox", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_outbox()
        //{
        //    var resp = Api.GetOutbox(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_outbox", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void vote()
        //{
        //    var resp = Api.Vote(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "vote", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void set_transaction_expiration()
        //{
        //    var resp = Api.SetTransactionExpiration(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "set_transaction_expiration", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void challenge()
        //{
        //    var resp = Api.Challenge(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "challenge", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void request_account_recovery()
        //{
        //    var resp = Api.RequestAccountRecovery(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "request_account_recovery", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void change_recovery_account()
        //{
        //    var resp = Api.ChangeRecoveryAccount(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "change_recovery_account", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_owner_history()
        //{
        //    var resp = Api.GetOwnerHistory(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_owner_history", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void prove()
        //{
        //    var resp = Api.Prove(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "prove", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void follow()
        //{
        //    var resp = Api.Follow(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "follow", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void reblog()
        //{
        //    var resp = Api.Reblog(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "reblog", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void get_encrypted_memo()
        //{
        //    var resp = Api.GetEncryptedMemo(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "get_encrypted_memo", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void decrypt_memo()
        //{
        //    var resp = Api.DecryptMemo(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "decrypt_memo", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void decline_voting_rights()
        //{
        //    var resp = Api.DeclineVotingRights(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "decline_voting_rights", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void begin_builder_transaction()
        //{
        //    var resp = Api.BeginBuilderTransaction(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "begin_builder_transaction", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void add_operation_to_builder_transaction()
        //{
        //    var resp = Api.AddOperationToBuilderTransaction(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "add_operation_to_builder_transaction", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void preview_builder_transaction()
        //{
        //    var resp = Api.PreviewBuilderTransaction(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "preview_builder_transaction", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void sign_builder_transaction()
        //{
        //    var resp = Api.SignBuilderTransaction(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "sign_builder_transaction", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public void remove_builder_transaction()
        //{
        //    var resp = Api.RemoveBuilderTransaction(CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CallRequest<JObject>(KnownApiNames.WalletApi, "remove_builder_transaction", new object[] { }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}
    }
}
