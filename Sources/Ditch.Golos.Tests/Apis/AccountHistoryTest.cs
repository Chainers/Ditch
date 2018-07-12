using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class AccountHistoryTest : BaseTest
    {
        [Test][Parallelizable]
        public async Task get_account_history()
        {
            ulong from = 3;
            uint limit = 3;
            var resp = await Api.GetAccountHistory(User.Login, from, limit, CancellationToken.None);
            TestPropetries(resp);
        }
    }
}
