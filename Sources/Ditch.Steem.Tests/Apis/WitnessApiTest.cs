using System.Threading;
using Ditch.Steem.Models;
using NUnit.Framework;

namespace Ditch.Steem.Tests.Apis
{
    [TestFixture]
    public class WitnessApiTest : BaseTest
    {
        [Test]
        public void get_account_bandwidth()
        {
            var args = new GetAccountBandwidthArgs
            {
                Account = User.Login,
                Type = BandwidthType.Forum
            };
            var resp = Api.GetAccountBandwidth(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_reserve_ratio()
        {
            var args = new GetReserveRatioArgs();
            var resp = Api.GetReserveRatio(args, CancellationToken.None);
            TestPropetries(resp);
        }
    }
}
