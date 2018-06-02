using System;
using System.Threading;
using Ditch.Steem.Models.Args;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Steem.Tests.Apis
{
    [TestFixture]
    public class AccountHistoryApiTest : BaseTest
    {
        [Test]
        public void get_ops_in_block()
        {
            var args = new GetOpsInBlockArgs()
            {
                BlockNum = 2,
                OnlyVirtual = false
            };
            var resp = Api.GetOpsInBlock(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.AccountHistoryApi, "get_ops_in_block", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_transaction()
        {
            var args = new GetTransactionArgs()
            {
                Id = ""
            };
            var resp = Api.GetTransaction(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.AccountHistoryApi, "get_transaction", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_account_history()
        {
            var args = new GetAccountHistoryArgs()
            {
                Account = User.Login
            };
            var resp = Api.GetAccountHistory(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.AccountHistoryApi, "get_account_history", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void enum_virtual_ops()
        {
            var args = new EnumVirtualOpsArgs()
            {
                BlockRangeBegin = 2,
                BlockRangeEnd = 20
            };
            var resp = Api.EnumVirtualOps(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.AccountHistoryApi, "enum_virtual_ops", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }
    }
}
