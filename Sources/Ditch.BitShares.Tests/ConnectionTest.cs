using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Ditch.Core;
using Xunit;
using Xunit.Abstractions;

namespace Ditch.BitShares.Tests
{
    public class ConnectionTest : BaseTest
    {
        public ConnectionTest(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// https://www.steem.center/index.php?title=Public_Websocket_Servers
        /// </summary>
        /// <param name="url"></param>
        [Theory]
        [InlineData("wss://eu.openledger.info/ws")]
        [InlineData("wss://bitshares.crypto.fans/ws")]
        [InlineData("wss://dex.rnglab.org")]
        [InlineData("wss://dexnode.net/ws")]
        [InlineData("wss://la.dexnode.net/ws")]
        [InlineData("wss://openledger.hk/ws")]
        [InlineData("wss://bitshares.openledger.info/ws")]
        [InlineData("wss://ws.gdex.top")]
        [InlineData("wss://bit.btsabc.org/ws")]
        [InlineData("wss://node.testnet.bitshares.eu")]
        [InlineData("wss://bts.ai.la/ws")]
        [InlineData("wss://bitshares.apasia.tech/ws")]
        [InlineData("wss://bitshares.dacplay.org/ws")]
        [InlineData("wss://japan.bitshares.apasia.tech/ws")]
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
