using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Core;
using Ditch.Steem.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Net;

namespace Ditch.Steem.Tests
{
    [TestFixture]
    public class ConnectionTest : BaseTest
    {
        [OneTimeSetUp]
        protected override void OneTimeSetUp()
        {
            HttpClient = new RepeatHttpClient();
            HttpManager = new HttpManager(HttpClient);
            Api = new OperationManager(HttpManager);
        }

        /// <summary>
        /// https://developers.steem.io/quickstart/
        /// https://www.steem.center/index.php?title=Public_Websocket_Servers
        /// </summary>
        /// <param name="url"></param>
        [Test]
        [Parallelizable]
        [TestCase("https://api.steemit.com")]
        [TestCase("https://api.steemitdev.com")]
        [TestCase("https://steemd-appbase.steemit.com")]
        [TestCase("https://api.steem.house")]
        [TestCase("https://appbasetest.timcliff.com")]
        //[TestCase("https://rpc.curiesteem.com")]
        [TestCase("https://rpc.steemviz.com")]
        [TestCase("https://steemd.minnowsupportproject.org")]
        //[TestCase("https://steemd.privex.io")]
        //[TestCase("https://anyx.io")]

        //[TestCase("https://api.steemitstage.com")]
        //[TestCase("https://appbase.buildteam.io")]
        //[TestCase("https://gtg.steem.house:8090")]
        //[TestCase("https://node.steem.ws")]
        //[TestCase("https://rpc.buildteam.io")]
        //[TestCase("https://rpc.steemliberator.com")]
        //[TestCase("https://steemd.pevo.science")]
        //[TestCase("https://steemd.steemgigs.org")]

        //[TestCase("https://steemd.steemit.com")]
        //[TestCase("https://steemd.steemitstage.com")]
        [TestCase("https://steemd.steemitdev.com")]
        //[TestCase("https://steemd2.steepshot.org")]
        //[TestCase("https://steemd.steepshot.org")]
        public async Task NodeTest(string url)
        {
            var token = CancellationToken.None;

            var sw = new Stopwatch();
            sw.Start();
            try
            {
                var isConnected = await Api
                    .ConnectToAsync(url, token)
                    .ConfigureAwait(false);

                Assert.IsTrue(isConnected, $"1 - DOWN {sw.ElapsedMilliseconds}");
            }
            catch (AssertionException)
            {
                throw;
            }
            catch (Exception e)
            {
                Assert.Fail($"1 - DOWN {sw.ElapsedMilliseconds}");
                return;
            }

            var configResp = await Api
                .GetConfigAsync<JObject>(token)
                .ConfigureAwait(false);

            Assert.IsFalse(configResp.IsError, $"2 - NO CONFIG {sw.ElapsedMilliseconds}");

            var conf = configResp.Result;

            var isTestNet = conf.Value<bool>("IS_TEST_NET");
            Assert.IsFalse(isTestNet, "3 - Testnet");

            var version = configResp.Result.Value<string>("STEEM_BLOCKCHAIN_VERSION");
            if (string.IsNullOrEmpty(version))
                version = configResp.Result.Value<string>("STEEMIT_BLOCKCHAIN_VERSION");

            Assert.IsFalse(string.IsNullOrEmpty(version), "4 - no version");
            Assert.IsTrue(new Regex("^0.20.[0-9]{1,2}$").IsMatch(version), "5 - not supported version");
            WriteLine(version);

            var args = new GetBlockArgs
            {
                BlockNum = 28000000
            };
            var block = await Api
                .GetBlockAsync(args, CancellationToken.None)
                .ConfigureAwait(false);

            Assert.IsFalse(block.IsError, "6 - get block error");

            var testDir = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
            var testFile = Path.Combine(testDir, "TestBlock28000000.txt");
            Assert.IsTrue(File.Exists(testFile), "test file not exist!");

            var validJson = File.ReadAllText(testFile);
            var t = JsonBeautify(block.RawResponse);
            Assert.IsTrue(t.Contains(validJson), $"7 - block validation fail{Environment.NewLine}{t}");

            WriteLine($"time (mls): {sw.ElapsedMilliseconds}");
            Assert.IsTrue(Api.IsConnected);
        }


      
    }
}
