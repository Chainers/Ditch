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
            ulong from = 3;
            uint limit = 3;
            var resp = Api.GetAccountHistory(User.Login, from, limit, CancellationToken.None);
            TestPropetries(resp);
        }
    }
}
