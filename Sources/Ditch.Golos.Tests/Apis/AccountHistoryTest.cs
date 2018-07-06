using System;
using System.Threading;
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
            TestPropetries(resp);
        }
    }
}
