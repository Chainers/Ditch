using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Core;
using Ditch.Ethereum.Models;
using NUnit.Framework;

namespace Ditch.Ethereum.Tests
{
    [TestFixture]
    public class NodeTest
    {
        private static readonly string[] NodeUrlCases = new[]
        {
            "http://100.24.135.26:8545/",
            "http://104.248.31.170:8545/",
            "http://107.23.226.175:8545/",
            "http://112.171.26.55:8545/",
            "http://114.112.100.195:8545/",
            "http://117.27.142.8:8545/",
            "http://119.23.42.117:8545/",
            "http://120.79.63.29:8545/",
            "http://122.112.200.8:8545/",
            "http://128.199.139.57:8545/",
            "http://13.125.128.108:8545/",
            "http://13.229.140.19:8545/",
            "http://13.229.63.217:8545/",
            "http://13.229.66.9:8545/",
            "http://13.230.253.68:8545/",
            "http://133.167.117.29:8545/",
            "http://134.255.226.226:8545/",
            "http://138.197.72.213:8545/",
            "http://138.68.229.216:8545/",
            "http://142.93.103.53:8545/",
            "http://142.93.131.245:8545/",
            "http://144.76.184.144:8545/",
            "http://150.109.105.170:8545/",
            "http://157.230.129.214:8545/",
            "http://157.230.131.55:8545/",
            "http://157.230.137.40:8545/",
            "http://157.230.217.40:8545/",
            "http://159.203.77.71:8545/",
            "http://159.65.169.204:8545/",
            "http://159.65.182.117:8545/",
            "http://159.65.3.252:8545/",
            "http://159.69.144.20:8545/",
            "http://159.89.148.142:8545/",
            "http://167.99.174.117:8545/",
            "http://174.138.3.218:8545/",
            "http://176.107.130.249:8545/",
            "http://178.128.14.219:8545/",
            "http://178.128.44.21:8545/",
            "http://18.184.1.86:8545/",
            "http://18.191.247.132:8545/",
            "http://18.205.226.156:8545/",
            "http://18.207.134.211:8545/",
            "http://18.220.2.99:8545/",
            "http://18.220.63.140:8545/",
            "http://18.232.127.250:8545/",
            "http://185.25.116.181:8545/",
            "http://188.166.42.154:8545/",
            "http://188.68.46.45:8545/",
            "http://193.176.79.234:8545/",
            "http://193.9.245.198:8545/",
            "http://194.158.213.163:8545/",
            "http://195.154.187.6:8545/",
            "http://195.201.149.233:8545/",
            "http://206.189.169.30:8545/",
            "http://206.189.223.185:8545/",
            "http://209.250.244.14:8545/",
            "http://212.73.150.41:8545/",
            "http://213.133.99.138:8545/",
            "http://221.122.37.71:8545/",
            "http://222.143.26.165:8545/",
            "http://222.143.26.165:8545/",
            "http://23.111.92.68:8545/",
            "http://3.85.109.147:8545/",
            "http://34.201.49.145:8545/",
            "http://34.206.54.247:8545/",
            "http://34.239.35.249:8545/",
            "http://34.246.208.52:8545/",
            "http://35.175.1.22:8545/",
            "http://35.180.252.64:8545/",
            "http://35.200.87.13:8545/",
            "http://35.224.32.242:8545/",
            "http://35.226.0.132:8545/",
            "http://35.237.135.236:8545/",
            "http://35.238.72.118:8545/",
            "http://39.104.109.134:8545/",
            "http://39.107.152.172:8545/",
            "http://39.107.71.188:8545/",
            "http://45.77.223.197:8545/",
            "http://46.4.105.184:8545/",
            "http://47.100.9.22:8545/",
            "http://47.101.47.204:8545/",
            "http://47.105.187.43:8545/",
            "http://47.244.63.116:8545/",
            "http://47.52.208.179:8545/",
            "http://47.74.190.206:8545/",
            "http://47.75.65.225:8545/",
            "http://47.91.240.5:8545/",
            "http://47.94.211.136:8545/",
            "http://47.96.113.53:8545/",
            "http://47.98.35.209:8545/",
            "http://5.132.162.16:8545/",
            "http://52.187.147.199:8545/",
            "http://52.20.232.204:8545/",
            "http://52.224.68.242:8545/",
            "http://52.231.190.55:8545/",
            "http://54.254.156.188:8545/",
            "http://54.36.173.109:8545/",
            "http://58.87.127.141:8545/",
            "http://60.205.189.118:8545/",
            "http://66.42.110.218:8545/",
            "http://66.42.113.248:8545/",
            "http://66.42.90.153:8545/",
            "http://68.183.102.40:8545/",
            "http://68.183.173.169:8545/",
            "http://68.183.174.240:8545/",
            "http://68.183.234.247:8545/",
            "http://68.183.28.39:8545/",
            "http://86.57.162.8:8545/",
            "http://88.198.207.38:8545/",
            "http://92.60.38.249:8545/",
            "http://95.216.97.223:8545/",
            "https://mainnet.infura.io/v3/48dad23382a24366b089a31c16e6c441"
        };

        private static readonly string[] NodeUrlCasesFailed = new string[]
        {
          
        };

        [Test]
        [Parallelizable(ParallelScope.All)]
        [TestCaseSource(nameof(NodeUrlCases))]
        public async Task TestNode(string url)
        {
            var sw = new Stopwatch();
            Console.WriteLine(url);

            sw.Start();
            var token = CancellationToken.None;
            var httpClient = new RepeatHttpClient();
            var httpManager = new HttpManager(httpClient);
            var api = new OperationManager(httpManager);
            httpManager.UrlToConnect = url;
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            var resp1 = await api.ProtocolVersionAsync(token)
                .ConfigureAwait(false);
            Assert.IsFalse(resp1.IsError);
            Console.WriteLine($"{resp1.Result}");
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            var resp2 = await api.NetVersionAsync(CancellationToken.None)
                .ConfigureAwait(false);
            Assert.IsFalse(resp2.IsError);
            Console.WriteLine($"{resp2.Result}");
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            var resp3 = await api.BlockNumberAsync(CancellationToken.None)
                .ConfigureAwait(false);
            Assert.IsFalse(resp3.IsError);
            Console.WriteLine($"{resp3.Result}");
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            var resp4 = await api.GetBlockByNumberAsync(resp3.Result.Value, true, CancellationToken.None)
                .ConfigureAwait(false);
            Assert.IsFalse(resp4.IsError);
            Console.WriteLine($"{resp4.Result}");
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            var resp5 = await api.GetTransactionReceiptAsync(new HexValue("0x9959ddd050dbcd23f9732e5c3870813eaf8155d081d10785694420160dc7e747"), CancellationToken.None)
                .ConfigureAwait(false);
            Assert.IsFalse(resp5.IsError);
            Assert.IsFalse(resp5.Result == null);
            Console.WriteLine($"{resp5.Result}");
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            var resp6 = await api.GetBlockByNumberAsync(4837041, true, CancellationToken.None)
                .ConfigureAwait(false);
            Assert.IsFalse(resp6.IsError);
            Assert.IsFalse(resp6.Result == null);
            Assert.IsTrue(resp6.Result.Transactions.Length == 221);
            Console.WriteLine($"{resp6.Result}");
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
     
        [Test]
        [Parallelizable(ParallelScope.All)]
        [TestCaseSource(nameof(NodeUrlCasesFailed))]
        public async Task TestFailedNode(string url)
        {
            var sw = new Stopwatch();
            Console.WriteLine(url);

            sw.Start();
            var token = CancellationToken.None;
            var httpClient = new RepeatHttpClient();
            var httpManager = new HttpManager(httpClient);
            var api = new OperationManager(httpManager);
            httpManager.UrlToConnect = url;
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            var resp1 = await api.ProtocolVersionAsync(token)
                .ConfigureAwait(false);
            Assert.IsFalse(resp1.IsError);
            Console.WriteLine($"{resp1.Result}");
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            var resp2 = await api.NetVersionAsync(CancellationToken.None)
                .ConfigureAwait(false);
            Assert.IsFalse(resp2.IsError);
            Console.WriteLine($"{resp2.Result}");
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            var resp3 = await api.BlockNumberAsync(CancellationToken.None)
                .ConfigureAwait(false);
            Assert.IsFalse(resp3.IsError);
            Console.WriteLine($"{resp3.Result}");
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            var resp4 = await api.GetBlockByNumberAsync(resp3.Result.Value, true, CancellationToken.None)
                .ConfigureAwait(false);
            Assert.IsFalse(resp4.IsError);
            Console.WriteLine($"{resp4.Result}");
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            var resp5 = await api.GetTransactionReceiptAsync(new HexValue("0x9959ddd050dbcd23f9732e5c3870813eaf8155d081d10785694420160dc7e747"), CancellationToken.None)
                .ConfigureAwait(false);
            Assert.IsFalse(resp5.IsError);
            Assert.IsFalse(resp5.Result == null);
            Console.WriteLine($"{resp5.Result}");
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            var resp6 = await api.GetBlockByNumberAsync(4837041, true, CancellationToken.None)
                .ConfigureAwait(false);
            Assert.IsFalse(resp6.IsError);
            Assert.IsFalse(resp6.Result == null);
            Assert.IsTrue(resp6.Result.Transactions.Length == 221);
            Console.WriteLine($"{resp6.Result}");
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}
