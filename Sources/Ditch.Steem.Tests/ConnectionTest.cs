using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Core;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Steem.Tests
{
    [TestFixture]
    public class ConnectionTest : BaseTest
    {
        [OneTimeSetUp]
        protected override void OneTimeSetUp() { }

        /// <summary>
        /// https://www.steem.center/index.php?title=Public_Websocket_Servers
        /// </summary>
        /// <param name="url"></param>
        [Ignore("LongRuningTest")]
        [Test]
        [TestCase("https://api.steemit.com")]
        [TestCase("https://steemd.steemit.com")]
        [TestCase("https://steemd.steemitstage.com")]
        [TestCase("https://steemd.steemitdev.com")]
        [TestCase("https://steemd.privex.io")]
        [TestCase("https://gtg.steem.house:8090")]
        [TestCase("https://rpc.steemliberator.com")]
        [TestCase("https://node.steem.ws")]
        [TestCase("https://steemd.minnowsupportproject.org")]
        [TestCase("https://rpc.buildteam.io")]
        [TestCase("https://steemd.pevo.science")]
        [TestCase("https://steemd.steemgigs.org")]
        [TestCase("https://rpc.buildteam.io")]
        [TestCase("https://steemd2.steepshot.org")]
        [TestCase("https://steemd.steepshot.org")]
        public async Task NodeTest(string url)
        {
            var manager = new OperationManager(new HttpManager());
            var token = CancellationToken.None;

            var sw = new Stopwatch();
            sw.Start();
            if (manager.ConnectTo(url, token))
            {
                var hfvr = await manager.GetConfig<JObject>(token);
                WriteLine(hfvr);
                Assert.IsFalse(hfvr.IsError);
                JToken version;
                if (!hfvr.Result.TryGetValue("STEEM_BLOCKCHAIN_VERSION", out version))
                    if (!hfvr.Result.TryGetValue("STEEMIT_BLOCKCHAIN_VERSION", out version))
                        Assert.Fail();
                WriteLine(version.Value<string>());
            }
            sw.Stop();

            WriteLine($"time (mls): {sw.ElapsedMilliseconds}");
            Assert.IsTrue(manager.IsConnected);
        }
    }
}
