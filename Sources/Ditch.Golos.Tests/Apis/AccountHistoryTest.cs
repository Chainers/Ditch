using System;
using System.Threading;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class AccountHistoryTest : BaseTest
    {
        [Test]
        public void get_account_history()
        {
            UInt64 from = 3;
            UInt32 limit = 3;
            var resp = Api.GetAccountHistory(User.Login, from, limit, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.AccountHistory, "get_account_history", new object[] { User.Login, from, limit }, CancellationToken.None);
            TestPropetries(resp, obj);
        }
    }
}
