using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Core;
using NUnit.Framework;

namespace Ditch.BitShares.Tests
{
    [TestFixture]
    public class ConnectionTest : BaseTest
    {
        [OneTimeSetUp]
        protected override void OneTimeSetUp()
        {
            var ws = new WebSocketManager();
            Api = new OperationManager(ws);
        }

        /// <summary>
        /// https://www.steem.center/index.php?title=Public_Websocket_Servers
        /// </summary>
        /// <param name="url"></param>
        [Test]
        [TestCase("wss://eu.openledger.info/ws")]
        [TestCase("wss://bitshares.crypto.fans/ws")]
        [TestCase("wss://dex.rnglab.org")]
        [TestCase("wss://dexnode.net/ws")]
        [TestCase("wss://la.dexnode.net/ws")]
        [TestCase("wss://openledger.hk/ws")]
        [TestCase("wss://bitshares.openledger.info/ws")]
        [TestCase("wss://ws.gdex.top")]
        [TestCase("wss://bit.btsabc.org/ws")]
        [TestCase("wss://node.testnet.bitshares.eu")]
        [TestCase("wss://bts.ai.la/ws")]
        [TestCase("wss://bitshares.apasia.tech/ws")]
        [TestCase("wss://bitshares.dacplay.org/ws")]
        [TestCase("wss://japan.bitshares.apasia.tech/ws")]
        public async Task NodeTest(string url)
        {
            var sw = new Stopwatch();
            sw.Start();
            await Api.ConnectTo(url, CancellationToken.None);
            sw.Stop();

            Console.WriteLine($"time (mls): {sw.ElapsedMilliseconds}");
            Assert.True(Api.IsConnected);
        }
    }
}
