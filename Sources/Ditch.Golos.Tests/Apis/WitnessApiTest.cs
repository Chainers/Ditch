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
            var resp = await Api.GetActiveWitnessesAsync(CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test][Parallelizable]
        public async Task get_current_median_history_price()
        {
            var resp = await Api.GetCurrentMedianHistoryPriceAsync(CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_feed_history()
        {
            var resp = await Api.GetFeedHistoryAsync(CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_miner_queue()
        {
            var resp = await Api.GetMinerQueueAsync(CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test][Parallelizable]
        public async Task get_witness_by_account()
        {
            var resp = await Api.GetWitnessByAccountAsync(User.Login, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_witness_count()
        {
            var resp = await Api.GetWitnessCountAsync(CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test][Parallelizable]
        public async Task get_witness_schedule()
        {
            var resp = await Api.GetWitnessScheduleAsync(CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_witnesses()
        {
            var witnes = await Api.GetWitnessesByVoteAsync(string.Empty, 100, CancellationToken.None).ConfigureAwait(false);
            WriteLine(witnes);
            Assert.IsFalse(witnes.IsError);

            var resp = await Api.GetWitnessesAsync(new[] { witnes.Result[0].Id }, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_witnesses_by_vote()
        {
            var resp = await Api.GetWitnessesByVoteAsync(string.Empty, 3, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task lookup_witness_accounts()
        {
            var resp = await Api.LookupWitnessAccountsAsync(string.Empty, 3, CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }
    }
}
