using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cryptography.ECDSA;
using Ditch.Core;
using Ditch.Ethereum.Models;
using NUnit.Framework;

namespace Ditch.Ethereum.Tests.Apis
{
    [TestFixture]
    public class EthHttpClientTest : BaseTest
    {
        [Test]
        [Parallelizable]
        public async Task eth_blockNumber()
        {
            var resp = await Api.BlockNumberAsync(CancellationToken.None)
                .ConfigureAwait(false);
            Console.WriteLine(resp.Result);
            TestPropetries(resp);
        }

        [Test]
        public void Test()
        {
            var bytes = Hex.HexToBytes("2809c7e17bf978fbc7194c0a694b638c4215e9140cacc6c38ca36010b45697df");
            var tt = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
            Console.WriteLine(tt);
        }

        //18160ddd totalSupply() public view returns (uint256 totalSupply) [Get the total token supply]
        //70a08231 balanceOf(address _owner) public view returns (uint256 balance) [Get the account balance of another account with address _owner]
        //095ea7b3 approve(address _spender, uint256 _value) public returns (bool success) [Allow _spender to withdraw from your account, multiple times, up to the _value amount. If this function is called again it overwrites the current allowance with _value]
        //dd62ed3e allowance(address _owner, address _spender) public view returns (uint256 remaining) [Returns the amount which _spender is still allowed to withdraw from _owner]
        //313ce567 decimals ‭00110001001111001110010101100111‬
        //06fdde03 name
        //95d89b41 symbol   ‭10010101110110001001101101000001‬
        //54fd4d50 version
        [Test]
        [Parallelizable]
        [TestCase("0x5d00d312e171be5342067c09bae883f9bcb2003b", "0x313ce567", "latest")]
        [TestCase("0x5d00d312e171be5342067c09bae883f9bcb2003b", "0x95d89b41", "latest")]
        [TestCase("0x80804eccd64b153572dcd0f6f494253a0d013492", "0x313ce567", "latest")]
        [TestCase("0x80804eccd64b153572dcd0f6f494253a0d013492", "0x95d89b41", "latest")]
        [TestCase("0xb8c77482e45f1f44de1745f52c74426c631bdd52", "0x313ce567", "latest")]
        [TestCase("0xb8c77482e45f1f44de1745f52c74426c631bdd52", "0x95d89b41", "latest")]
        public async Task eth_call(string contract, string data, string blockParam)
        {
            var args = new EthCallArgs
            {
                To = new HexAddress(contract),
                Data = new HexValue(data)
            };

            var resp = await Api.EthCallAsync<HexValue>(args, blockParam, CancellationToken.None)
                .ConfigureAwait(false);

            Console.WriteLine(resp.Result);
            TestPropetries(resp);
            Bytes32ToString(resp.Result.Bytes);

        }

        public void Bytes32ToString(byte[] source)
        {
            if (source.Length == 32 + 32 + 32)
            {
                var len = new HexDecimal(source, 20, 12);
                if (len.Value == 32)
                {
                    var count = new HexDecimal(source, 32 + 20, 12);
                    string utf8 = System.Text.Encoding.UTF8.GetString(source, 64, 32);
                    Console.WriteLine(utf8.Substring(0, (int)count.Value));
                }
                else
                {
                    Console.WriteLine(Hex.ToString(source));
                    throw new NotImplementedException();
                }
            }
        }

        [Test]
        [Parallelizable]
        [TestCase(46147)]
        [TestCase(46169)]
        [TestCase(689170)]
        [TestCase(4832686)]
        [TestCase(4832685)]
        public async Task eth_getBlockByNumber(long blockNum)
        {
            var resp = await Api.GetBlockByNumberAsync(blockNum, true, CancellationToken.None).ConfigureAwait(false);
            Console.WriteLine(resp.Result.Timestamp.Value);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        [TestCase("0xbb3a336e3f823ec18197f1e13ee875700f08f03e2cab75f0d0b118dabb44cba0")]
        [TestCase("0x31ded263506ea36e6ea777efc2c39a999e6fba4f4d338c7313af6aac6d9bf3e3")]
        [TestCase("0xd327b2bfc0e703e3bc12e5b3f6272eaac2a7d6004a35688469d0e8d406b79483")]
        [TestCase("0x19f1df2c7ee6b464720ad28e903aeda1a5ad8780afc22f0b960827bd4fcf656d")]
        [TestCase("0x19f1df2c7ee6b464720ad28e903aeda1a5ad8780afc22f0b960827bd4fcf656d")]
        [TestCase("0x0ec5bc927df001dafe6634826e41618a40b74a879ced2e93813a4ca2703bd952")]
        [TestCase("0x54852d72eba983b3ca200d925211b6d9da4115ea34761163ec7a744558ff6b8f")] //721
        public async Task eth_getTransactionByHash(string hash)
        {
            var resp = await Api.GetTransactionByHashAsync(new HexValue(hash), CancellationToken.None)
                .ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task TryGetLastTransactionReceipt()
        {
            var token = CancellationToken.None;
            long prev = 0;
            for (int i = 0; i < 10; i++)
            {
                var lastBlockNum = await Api.BlockNumberAsync(token);
                Assert.IsFalse(lastBlockNum.IsError);

                if (prev == lastBlockNum.Result.Value)
                {
                    i--;
                    await Task.Delay(300, token);
                    continue;
                }

                prev = lastBlockNum.Result.Value;
                var block = await Api.GetBlockByNumberAsync(lastBlockNum.Result.Value, true, token);
                Assert.IsFalse(block.IsError);

                Console.WriteLine($"[{prev}]");
                foreach (var transaction in block.Result.Transactions)
                {
                    var resp = await Api.GetTransactionReceiptAsync(transaction.Hash, CancellationToken.None)
                        .ConfigureAwait(false);

                    //TestPropetries(resp, false);
                    if (resp.Result == null)
                    {

                    }
                    Console.WriteLine($"{transaction.Hash} {resp.Result?.Status}");
                }
            }
        }

        [Test]
        [Parallelizable]
        [TestCase("0xbb3a336e3f823ec18197f1e13ee875700f08f03e2cab75f0d0b118dabb44cba0")]
        [TestCase("0x31ded263506ea36e6ea777efc2c39a999e6fba4f4d338c7313af6aac6d9bf3e3")]
        [TestCase("0xd327b2bfc0e703e3bc12e5b3f6272eaac2a7d6004a35688469d0e8d406b79483")]
        [TestCase("0x19f1df2c7ee6b464720ad28e903aeda1a5ad8780afc22f0b960827bd4fcf656d")]
        [TestCase("0x7141570cd9169abdb99281074795874690c58be6655283b35d2480a782058232")]
        [TestCase("0x0ec5bc927df001dafe6634826e41618a40b74a879ced2e93813a4ca2703bd952")]
        [TestCase("0x54852d72eba983b3ca200d925211b6d9da4115ea34761163ec7a744558ff6b8f")] //721
        public async Task eth_getTransactionReceipt(string hash)
        {
            var resp = await Api.GetTransactionReceiptAsync(new HexValue(hash), CancellationToken.None)
                .ConfigureAwait(false);
            TestPropetries(resp);
        }

        ////https://www.ethernodes.org/network/1/nodes
        //[Test]
        //[Parallelizable]
        //[TestCase("185.243.112.83", 52960)]
        //[TestCase("35.203.186.223", 52660)]
        //[TestCase("151.236.217.113", 39608)]
        //[TestCase("84.234.52.190", 30303)]
        //[TestCase("47.244.62.15", 54212)]
        //public void Test(string server, int port)
        //{
        //    var message = "{\"method\": \"eth_getBlockByNumber\",\"params\": [\"0xB443\",true],\"jsonrpc\": \"2.0\",\"id\": 1}";
        //    // TestTcpClient(server, port, message);
        //    TestSocket2(server, port, message);
        //}

        //private void TestSocket2(string ip, int port, string jsonrpc)
        //{
        //    var manager = new WebSocketManager();
        //    Api = new OperationManager(manager);

        //    var isConnected = Api.ConnectToAsync($"wss:\\{ip}:{port}", CancellationToken.None).Result;
        //    Assert.IsTrue(isConnected);

        //}

        //private void TestTcpClient(string ip, int port, string msg)
        //{
        //    try
        //    {
        //        TcpClient client = new TcpClient(ip, port);

        //        // Translate the passed message into ASCII and store it as a Byte array.
        //        Byte[] data = System.Text.Encoding.ASCII.GetBytes(msg);

        //        // Get a client stream for reading and writing.
        //        //  Stream stream = client.GetStream();

        //        NetworkStream stream = client.GetStream();

        //        // Send the message to the connected TcpServer. 
        //        stream.Write(data, 0, data.Length);

        //        Console.WriteLine("Sent: {0}", msg);

        //        // Receive the TcpServer.response.

        //        // Buffer to store the response bytes.
        //        data = new Byte[256];

        //        // String to store the response ASCII representation.
        //        String responseData = String.Empty;

        //        // Read the first batch of the TcpServer response bytes.
        //        Int32 bytes = stream.Read(data, 0, data.Length);
        //        responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
        //        Console.WriteLine("Received: {0}", responseData);

        //        // Close everything.
        //        stream.Close();
        //        client.Close();
        //    }
        //    catch (ArgumentNullException e)
        //    {
        //        Console.WriteLine("ArgumentNullException: {0}", e);
        //    }
        //    catch (SocketException e)
        //    {
        //        Console.WriteLine("SocketException: {0}", e);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Exception: {0}", e);
        //    }
        //}

        //private void TestSocket(string ip, int port, string jsonrpc)
        //{
        //    var set = new string[][]
        //    {
        //        new[] {"Unspecified", "Dgram", "Udp"},
        //        new[] {"Unspecified", "Raw", "Icmp"},
        //        new[] {"Unspecified", "Raw", "IcmpV6"},
        //        new[] {"InterNetwork", "Dgram", "Udp"},
        //        new[] {"InterNetwork", "Dgram", "IPv6HopByHopOptions"},
        //        new[] {"InterNetwork", "Dgram", "IP"},
        //        new[] {"InterNetwork", "Dgram", "Unspecified"},
        //        new[] {"InterNetwork", "Raw", "Icmp"},
        //        new[] {"InterNetwork", "Raw", "IcmpV6"},
        //        new[] {"InterNetworkV6", "Raw", "Icmp"},
        //        new[] {"InterNetworkV6", "Raw", "IcmpV6"},
        //    };

        //    byte[] bytes = new byte[1024];


        //    foreach (var itm in set)
        //    {
        //        try
        //        {
        //            var aft = (AddressFamily)Enum.Parse(typeof(AddressFamily), itm[0]);
        //            var stt = (SocketType)Enum.Parse(typeof(SocketType), itm[1]);
        //            var ptt = (ProtocolType)Enum.Parse(typeof(ProtocolType), itm[2]);


        //            Socket sock = new Socket(aft, stt, ptt);
        //            sock.ReceiveTimeout = 3000;
        //            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
        //            sock.Connect(endPoint);

        //            // Encode the data string into a byte array.  
        //            byte[] msg = Encoding.UTF8.GetBytes(jsonrpc);

        //            // Send the data through the socket.  

        //            int bytesSent = sock.Send(msg);
        //            if (bytesSent != msg.Length)
        //            {

        //            }

        //            // Receive the response from the remote device.  
        //            do
        //            {
        //                int bytesRec = sock.Receive(bytes);
        //                Console.WriteLine("Echoed test = {0}", Encoding.UTF8.GetString(bytes, 0, bytesRec));
        //                if (bytesRec < 1024)
        //                    break;
        //            } while (true);


        //            // Release the socket.  
        //            sock.Shutdown(SocketShutdown.Both);
        //            sock.Close();

        //            // code past this never hits because the line above fails
        //        }
        //        catch (Exception e)
        //        {
        //            // Console.WriteLine("Exception: {0}", e);
        //        }

        //    }
        //}

        //private void TestSocketAll(string ip, int port, string jsonrpc)
        //{
        //    var afs = Enum.GetNames(typeof(AddressFamily));
        //    var sts = Enum.GetNames(typeof(SocketType));
        //    var pts = Enum.GetNames(typeof(ProtocolType));
        //    byte[] bytes = new byte[1024];


        //    foreach (var af in afs)
        //    {
        //        foreach (var st in sts)
        //        {
        //            foreach (var pt in pts)
        //            {

        //                try
        //                {
        //                    var aft = (AddressFamily)Enum.Parse(typeof(AddressFamily), af);
        //                    var stt = (SocketType)Enum.Parse(typeof(SocketType), st);
        //                    var ptt = (ProtocolType)Enum.Parse(typeof(ProtocolType), pt);


        //                    Socket sock = new Socket(aft, stt, ptt);
        //                    IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
        //                    sock.Connect(endPoint);

        //                    Console.WriteLine($"!!! {af} {st} {pt}");

        //                    // Encode the data string into a byte array.  
        //                    byte[] msg = Encoding.UTF8.GetBytes(jsonrpc);

        //                    // Send the data through the socket.  

        //                    int bytesSent = sock.Send(msg);
        //                    if (bytesSent != msg.Length)
        //                    {

        //                    }

        //                    // Receive the response from the remote device.  
        //                    do
        //                    {
        //                        int bytesRec = sock.Receive(bytes);
        //                        Console.WriteLine("Echoed test = {0}", Encoding.UTF8.GetString(bytes, 0, bytesRec));
        //                        if (bytesRec < 1024)
        //                            break;
        //                    } while (true);


        //                    // Release the socket.  
        //                    sock.Shutdown(SocketShutdown.Both);
        //                    sock.Close();

        //                    // code past this never hits because the line above fails
        //                }
        //                catch (Exception e)
        //                {
        //                    // Console.WriteLine("Exception: {0}", e);
        //                }

        //            }
        //        }
        //    }
        //}
    }
}
