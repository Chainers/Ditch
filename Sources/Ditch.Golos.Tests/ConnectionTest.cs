using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Core;
using NUnit.Framework;

namespace Ditch.Golos.Tests
{
    [TestFixture]
    public class ConnectionTest : BaseTest
    {
        [OneTimeSetUp]
        protected override void OneTimeSetUp() { }

        [Ignore("LongRuningTest")]
        [Test]
        [TestCase("wss://ws.golos.io")]
        [TestCase("wss://ws.testnet.golos.io")]
        [TestCase("wss://golosd.steepshot.org")]
        public void NodeTest(string url)
        {
            var manager = new OperationManager();

            var sw = new Stopwatch();
            var urls = new List<string> { url };
            sw.Restart();
            manager.TryConnectTo(urls, CancellationToken.None);
            sw.Stop();

            WriteLine($"time (mls): {sw.ElapsedMilliseconds}");
            Assert.IsTrue(manager.IsConnected, $"Not connected to {url}");
        }

        [Ignore("LongRuningTest")]
        [Test]
        public void HttpsNodeTest()
        {
            var urls = new List<string> { "https://public-ws.golos.io", "https://golosd.steepshot.org" };

            var jss = GetJsonSerializerSettings();
            var connectionManager = new HttpManager(jss);
            var manager = new OperationManager(connectionManager, jss);

            var sw = new Stopwatch();
            //test all urls
            for (var i = 0; i < urls.Count; i++)
            {
                var buf = new List<string> { urls[i] };
                sw.Restart();
                manager.TryConnectTo(buf, CancellationToken.None);
                sw.Stop();

                WriteLine($"{i} {(manager.IsConnected ? "conected" : "Not connected")} to {urls[i]} {sw.ElapsedMilliseconds}");

                if (manager.IsConnected)
                {
                    Assert.IsNotNull(manager.ChainId, "ChainId null");
                }
            }
        }

        [Ignore("LongRuningTest")]
        [Test]
        public async Task TryConnectToHttpsTest()
        {
            var urls = new List<string> { "https://public-ws.golos.io", "https://golosd.steepshot.org" };

            var jss = GetJsonSerializerSettings();
            var manager = new OperationManager(new HttpManager(jss), jss);

            var sw = new Stopwatch();
            for (var i = 0; i < 5; i++)
            {
                sw.Restart();
                var url = manager.TryConnectTo(urls, CancellationToken.None);
                sw.Stop();
                if (manager.IsConnected)
                {
                    WriteLine($"{i} conected to {url} {sw.ElapsedMilliseconds}");
                    Assert.IsNotNull(manager.ChainId, "ChainId null");
                    await Task.Delay(3000);
                }
                else
                {
                    WriteLine($"{i} not conected {sw.ElapsedMilliseconds}");
                }
            }
        }

        [Ignore("LongRuningTest")]
        [Test]
        public async Task TryConnectToWssTest()
        {
            var urls = new List<string> { "wss://ws.golos.io" };

            var manager = new OperationManager();

            var sw = new Stopwatch();
            for (var i = 0; i < 5; i++)
            {
                WriteLine($"{i} conect to golos.");
                sw.Restart();
                var url = manager.TryConnectTo(urls, CancellationToken.None);
                sw.Stop();
                if (manager.IsConnected)
                {
                    WriteLine($"{i} conected to {url} {sw.ElapsedMilliseconds}");
                    Assert.IsNotNull(manager.ChainId, "ChainId null");
                    await Task.Delay(3000);
                }
                else
                {
                    WriteLine($"{i} not conected to {url} {sw.ElapsedMilliseconds}");
                }
            }
        }
    }
}
