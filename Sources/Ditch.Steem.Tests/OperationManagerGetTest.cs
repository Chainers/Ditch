using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Steem.Operations.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Ditch.Core;

namespace Ditch.Steem.Tests
{
    [TestFixture]
    public class OperationManagerGetTest : BaseTest
    {

        [Test]
        public async Task TryConnectToHttpsTest()
        {
            var urls = new List<string> { "https://api.steemit.com", "https://steemd2.steepshot.org" };

            var jss = GetJsonSerializerSettings();
            var manager = new OperationManager(new HttpManager(jss), jss);

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
                Assert.IsNotNull(manager.SbdSymbol, "SbdSymbol null");
                Assert.IsNotNull(manager.Version, "Version null");
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
                Assert.IsNotNull(manager.SbdSymbol, "SbdSymbol null");
                Assert.IsNotNull(manager.Version, "Version null");
                await Task.Delay(3000);
            }
        }
    }
}
