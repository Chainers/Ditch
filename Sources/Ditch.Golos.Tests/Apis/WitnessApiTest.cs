using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class WitnessApiTest : BaseTest
    {
        [Test][Parallelizable]
        public async Task get_active_witnesses()
        {
            var resp = await Api.GetActiveWitnesses(CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test][Parallelizable]
        public async Task get_current_median_history_price()
        {
            var resp = await Api.GetCurrentMedianHistoryPrice(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_feed_history()
        {
            var resp = await Api.GetFeedHistory(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_miner_queue()
        {
            var resp = await Api.GetMinerQueue(CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test][Parallelizable]
        public async Task get_witness_by_account()
        {
            var resp = await Api.GetWitnessByAccount(User.Login, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_witness_count()
        {
            var resp = await Api.GetWitnessCount(CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test][Parallelizable]
        public async Task get_witness_schedule()
        {
            var resp = await Api.GetWitnessSchedule(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_witnesses()
        {
            var witnes = await Api.GetWitnessesByVote(string.Empty, 100, CancellationToken.None);
            WriteLine(witnes);
            Assert.IsFalse(witnes.IsError);

            var resp = await Api.GetWitnesses(new[] { witnes.Result[0].Id }, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_witnesses_by_vote()
        {
            var resp = await Api.GetWitnessesByVote(string.Empty, 3, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task lookup_witness_accounts()
        {
            var resp = await Api.LookupWitnessAccounts(string.Empty, 3, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }
    }
}
