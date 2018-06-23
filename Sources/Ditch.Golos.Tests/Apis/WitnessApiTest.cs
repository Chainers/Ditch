using System.Threading;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class WitnessApiTest : BaseTest
    {
        [Test]
        public void get_active_witnesses()
        {
            var resp = Api.GetActiveWitnesses(CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public void get_current_median_history_price()
        {
            var resp = Api.GetCurrentMedianHistoryPrice(CancellationToken.None);
            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WitnessApi, "get_current_median_history_price", new object[] { }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_feed_history()
        {
            var resp = Api.GetFeedHistory(CancellationToken.None);
            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WitnessApi, "get_feed_history", new object[] { }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_miner_queue()
        {
            var resp = Api.GetMinerQueue(CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public void get_witness_by_account()
        {
            var resp = Api.GetWitnessByAccount(User.Login, CancellationToken.None);
            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WitnessApi, "get_witness_by_account", new object[] { User.Login }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_witness_count()
        {
            var resp = Api.GetWitnessCount(CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public void get_witness_schedule()
        {
            var resp = Api.GetWitnessSchedule(CancellationToken.None);
            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WitnessApi, "get_witness_schedule", new object[] { }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_witnesses()
        {
            var witnes = Api.GetWitnessesByVote(string.Empty, 100, CancellationToken.None);
            WriteLine(witnes);
            Assert.IsFalse(witnes.IsError);

            var resp = Api.GetWitnesses(new[] { witnes.Result[0].Id }, CancellationToken.None);
            var obj = Api.CustomGetRequest<JObject[]>(KnownApiNames.WitnessApi, "get_witnesses", new object[] { new[] { witnes.Result[0].Id } }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_witnesses_by_vote()
        {
            var resp = Api.GetWitnessesByVote(string.Empty, 3, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.WitnessApi, "get_witnesses_by_vote", new object[] { string.Empty, 3 }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void lookup_witness_accounts()
        {
            var resp = Api.LookupWitnessAccounts(string.Empty, 3, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }
    }
}

