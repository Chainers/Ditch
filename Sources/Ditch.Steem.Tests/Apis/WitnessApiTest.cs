using System.Threading;
using System.Threading.Tasks;
using Ditch.Steem.Models;
using NUnit.Framework;

namespace Ditch.Steem.Tests.Apis
{
    [TestFixture]
    public class WitnessApiTest : BaseTest
    {
        [Test][Parallelizable]
        public async Task get_account_bandwidth()
        {
            var args = new GetAccountBandwidthArgs
            {
                Account = User.Login,
                Type = BandwidthType.Forum
            };
            var resp = await Api.GetAccountBandwidth(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_reserve_ratio()
        {
            var args = new GetReserveRatioArgs();
            var resp = await Api.GetReserveRatio(args, CancellationToken.None);
            TestPropetries(resp);
        }
    }
}
