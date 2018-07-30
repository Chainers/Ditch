using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Core;
using NUnit.Framework;

namespace Ditch.EOS.Tests
{
    [TestFixture]
    public class ScatterTest
    {
        public WebSocketManager WebSocketManager = new WebSocketManager();
        // http://127.0.0.1:50005/tfZYsSST3DyG1ohtRxmYaYAYa2LtoSqZmwXQrFrVvd7xJnTIrOsHVjSxYlY32rhx
        [Test]
        public async Task BroadcastWithScatterTest()
        {
            //TcpClient client = new TcpClient("localhost", 50005);
            //NetworkStream stream = client.GetStream();
            //string response = "Ditch";
            //byte[] data = System.Text.Encoding.UTF8.GetBytes(response);
            //stream.Write(data, 0, data.Length);
            //stream.Flush();

            //byte[] rdata = new byte[256];
            //int bytes = stream.Read(rdata, 0, rdata.Length); // получаем количество считанных байтов
            //string message = Encoding.UTF8.GetString(rdata, 0, bytes);


            //client.Close();

            //if (!WebSocketManager.IsConnected)
            //    WebSocketManager.ConnectTo("ws://127.0.0.1:50005/scatter", CancellationToken.None);


            //Assert.IsTrue(WebSocketManager.IsConnected);

            //var args = new object[] { trx, publicKeys, chainId };

        }
    }
}
