using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Ditch.Core;
using NUnit.Framework;

namespace Ditch.BitShares.Tests
{
    [TestFixture()]
    public class ConnectionTest
    {
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
        public void NodeTest(string url)
        {
            var jss = BaseTest.GetJsonSerializerSettings();
            var connectionManager = new WebSocketManager(jss);
            var manager = new OperationManager(connectionManager, jss);

            var sw = new Stopwatch();
            var urls = new List<string> { url };
            sw.Restart();
            var connectedTo = manager.TryConnectTo(urls, CancellationToken.None);
            sw.Stop();

            Console.WriteLine($"time (mls): {sw.ElapsedMilliseconds}");
            Assert.True(manager.IsConnected);
        }
    }
}
