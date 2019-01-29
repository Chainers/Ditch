using System.Configuration;
using System.Threading;
using Ditch.Core;
using NUnit.Framework;

namespace Ditch.Ethereum.Tests.Apis
{
    [TestFixture]
    public class EthWssClientTest : EthHttpClientTest
    {
        [OneTimeSetUp]
        protected override void OneTimeSetUp()
        {
            if (Api == null)
            {
                var webSocketManager = new WebSocketManager();
                Api = new OperationManager(webSocketManager);

                var infuraKey = ConfigurationManager.AppSettings["InfuraKey"];
                var infuraMainnetWss = ConfigurationManager.AppSettings["InfuraMainnetWss"];
                Assert.IsTrue(Api.ConnectToAsync(infuraMainnetWss + infuraKey, CancellationToken.None).Result, "Сan`t connect to the node");
            }

            Assert.IsTrue(Api.IsConnected, "Сan`t connect to the node");
        }
    }
}
