using System;
using System.Threading;
using System.Threading.Tasks;
using Cryptography.ECDSA;
using Ditch.EOS.Models;
using NUnit.Framework;
using Action = Ditch.EOS.Models.Action;

namespace Ditch.EOS.Tests
{
    [TestFixture]
    public class WalletApiTest : BaseTest
    {
        [Test]
        public async Task CreateTest()
        {
            var name = $"testname{DateTime.Now:yyyyMMddhhmmss}";
            WriteLine(name);
            var resp = await Api.WalletCreate(name, CancellationToken.None);
            WriteLine(resp);
            Assert.IsTrue(resp.IsSuccess);
            WriteLine(resp);
        }

        [Test]
        public async Task WalletOpenTest()
        {
            const string name = "testname";
            WriteLine(name);
            var resp = await Api.WalletOpen(name, CancellationToken.None);
            WriteLine(resp);
            Assert.IsTrue(resp.IsSuccess);
        }

        [Test]
        public async Task WalletLockTest()
        {
            const string name = "testname";
            WriteLine(name);
            var resp = await Api.WalletLock(name, CancellationToken.None);
            WriteLine(resp);
            Assert.IsTrue(resp.IsSuccess);
        }

        [Test]
        public async Task WalletLockAllTest()
        {
            var resp = await Api.WalletLockAll(CancellationToken.None);
            WriteLine(resp);
            Assert.IsTrue(resp.IsSuccess);
        }

        [Test]
        public async Task WalletUnlockTest()
        {
            const string name = "testname20180422094827";
            const string password = "PW5KVaJ31DyAQnyyaVSsuQNyyLYqogdSBK51YaRAXbZroWtCQVCrE";
            var resp = await Api.WalletUnlock(name, password, CancellationToken.None);
            WriteLine(resp);
            Assert.IsTrue(resp.IsSuccess);
        }

        [Ignore("you need to put your own data")]
        [Test]
        public async Task WalletImportKeyTest()
        {
            const string name = "testname20180422094827";
            const string password = "5KVaJ31DyAQnyyaVSsuQNyyLYqogdSBK51YaRAXbZroWtCQVCrE";
            var resp = await Api.WalletImportKey(name, password, CancellationToken.None);
            WriteLine(resp);
            Assert.IsTrue(resp.IsSuccess);
        }

        [Test]
        public async Task WalletListTest()
        {
            var resp = await Api.WalletList(CancellationToken.None);
            WriteLine(resp);
            Assert.IsTrue(resp.IsSuccess);
            WriteLine(resp);
        }

        [Test]
        public async Task WalletListKeysTest()
        {
            var resp = await Api.WalletListKeys(CancellationToken.None);
            WriteLine(resp);
            Assert.IsTrue(resp.IsSuccess);
            WriteLine(resp);
        }

        [Test]
        public async Task WalletGetPublicKeysTest()
        {
            var resp = await Api.WalletGetPublicKeys(CancellationToken.None);
            WriteLine(resp);
            Assert.IsTrue(resp.IsSuccess);
            WriteLine(resp);
        }

        [Test]
        public async Task WalletSetTimeoutTest()
        {
            var resp = await Api.WalletSetTimeout(10, CancellationToken.None);
            WriteLine(resp);
            Assert.IsTrue(resp.IsSuccess);
            WriteLine(resp);
        }

        [Ignore("you need to put your own data")]
        [Test]
        public async Task WalletSignTrxTest()
        {
            var infoResp = await Api.GetInfo(CancellationToken.None);
            var info = infoResp.Result;

            var trx = new SignedTransaction
            {
                Expiration = info.HeadBlockTime.AddSeconds(30),
                Region = 0,
                RefBlockNum = (ushort)(info.HeadBlockNum & 0xffff),
                RefBlockPrefix = (uint)BitConverter.ToInt32(Hex.HexToBytes(info.HeadBlockId), 4),
                MaxNetUsageWords = 0,
                MaxKcpuUsage = 0,
                DelaySec = 0,
                ContextFreeActions = new Action[0],
                Actions = new[]
                    {
                        new Action
                        {
                            Account = "hackathon",
                            Name = "transfer",
                            Authorization = new[]
                            {
                                new PermissionLevel
                                {
                                    Actor = "test1",
                                    Permission = "active"
                                }
                            },
                            Data = "000000008090b1ca000000008090b1cae8030000000000000056494d00000000"
                        }
                    },
                Signatures = new string[0],
                ContextFreeData = new byte[0]
            };
            var publicKeys = new[] { string.Empty };
            var chainId = string.Empty;

            var resp = await Api.WalletSignTrx(trx, publicKeys, chainId, CancellationToken.None);
            WriteLine(resp);
            Assert.IsTrue(resp.IsSuccess);
            WriteLine(resp);
        }
    }
}
