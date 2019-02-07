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
                var manager = new WebSocketManager();
                Api = new OperationManager(manager);

                var url = ConfigurationManager.AppSettings["MainnetWs"];
                Assert.IsTrue(Api.ConnectToAsync(url, CancellationToken.None).Result, "Сan`t connect to the node");
            }

            Assert.IsTrue(Api.IsConnected, "Сan`t connect to the node");
        }
    }
}
