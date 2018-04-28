using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Ditch.Core;

namespace Ditch.Steem.Tests
{
    [TestFixture]
    public class OperationManagerConnectionTest : BaseTest
    {

        /// <summary>
        /// https://www.steem.center/index.php?title=Public_Websocket_Servers
        /// </summary>
        /// <param name="url"></param>
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
        public void NodeTest(string url)
        {
            var jss = GetJsonSerializerSettings();
            var connectionManager = new HttpManager(jss);
            var manager = new OperationManager(connectionManager, jss);

            var sw = new Stopwatch();
            var urls = new List<string> { url };
            sw.Restart();
            var connectedTo = manager.TryConnectTo(urls, CancellationToken.None);
            sw.Stop();

            Console.WriteLine($"time (mls): {sw.ElapsedMilliseconds}");
            Assert.IsTrue(manager.IsConnected, $"Not connected to {url}");

            if (manager.IsConnected)
                Assert.IsNotNull(manager.ChainId, "ChainId null");
        }

        [Test]
        public async Task TryConnectToHttpsTest()
        {
            var urls = new List<string> {
                "https://api.steemit.com",
                "https://steemd.steemit.com",
                "https://steemd.steemitstage.com",
                "https://steemd.steemitdev.com",
                "https://steemd.privex.io",
                "https://gtg.steem.house:8090",
                "https://rpc.steemliberator.com",
                "https://node.steem.ws",
                "https://steemd.minnowsupportproject.org",
                "https://rpc.buildteam.io",
                "https://steemd.pevo.science",
                "https://steemd.steemgigs.org",
                "https://rpc.buildteam.io",
                "https://steemd2.steepshot.org",
            };

            var jss = GetJsonSerializerSettings();
            var manager = new OperationManager(new HttpManager(jss), jss);

            var sw = new Stopwatch();
            for (var i = 0; i < 5; i++)
            {
                sw.Restart();
                var url = manager.TryConnectTo(urls, CancellationToken.None);
                sw.Stop();
                Console.WriteLine($"{i} conected to {url} {sw.ElapsedMilliseconds}");
                Assert.IsTrue(manager.IsConnected, "Not connected");
                Assert.IsNotNull(manager.ChainId, "ChainId null");
                await Task.Delay(3000);
            }
        }

        [Test]
        public async Task TryConnectToWssTest()
        {
            var urls = new List<string> { "wss://steemd.steemit.com", "wss://steemd2.steepshot.org" };

            var jss = GetJsonSerializerSettings();
            var manager = new OperationManager(new WebSocketManager(jss), jss);

            var sw = new Stopwatch();
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine($"{i} conect to golos.");
                sw.Restart();
                var url = manager.TryConnectTo(urls, CancellationToken.None);
                sw.Stop();
                Console.WriteLine($"{i} conected to {url} {sw.ElapsedMilliseconds}");
                Assert.IsTrue(manager.IsConnected, "Not connected");
                Assert.IsNotNull(manager.ChainId, "ChainId null");
                await Task.Delay(3000);
            }
        }
    }
}
