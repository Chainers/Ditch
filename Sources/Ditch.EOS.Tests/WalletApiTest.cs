using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;

namespace Ditch.EOS.Tests
{
    [TestFixture]
    public class WalletApiTest : BaseTest
    {
        [Test]
        public async Task CreateTest()
        {
            var name = $"testname{DateTime.Now.ToString("yyyyMMddhhmmss")}";
            Console.WriteLine(name);
            var resp = await Api.WalletCreate(name, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsTrue(resp.IsSuccess);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public async Task WalletOpenTest()
        {
            var name = "testname";
            Console.WriteLine(name);
            var resp = await Api.WalletOpen(name, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsTrue(resp.IsSuccess);
        }

        [Test]
        public async Task WalletLockTest()
        {
            var name = "testname";
            Console.WriteLine(name);
            var resp = await Api.WalletLock(name, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsTrue(resp.IsSuccess);
        }

        [Test]
        public async Task WalletLockAllTest()
        {
            var resp = await Api.WalletLockAll(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsTrue(resp.IsSuccess);
        }

        [Test]
        public async Task WalletUnlockTest()
        {
            var name = "testname20180422094827";
            var password = "PW5KVaJ31DyAQnyyaVSsuQNyyLYqogdSBK51YaRAXbZroWtCQVCrE";
            var resp = await Api.WalletUnlock(name, password, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsTrue(resp.IsSuccess);
        }

        [Test]
        public async Task WalletImportKeyTest()
        {
            var name = "testname20180422094827";
            var password = "5KVaJ31DyAQnyyaVSsuQNyyLYqogdSBK51YaRAXbZroWtCQVCrE";
            var resp = await Api.WalletImportKey(name, password, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsTrue(resp.IsSuccess);
        }

        [Test]
        public async Task WalletListTest()
        {
            var resp = await Api.WalletList(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsTrue(resp.IsSuccess);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public async Task WalletListKeysTest()
        {
            var resp = await Api.WalletListKeys(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsTrue(resp.IsSuccess);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public async Task WalletGetPublicKeysTest()
        {
            var resp = await Api.WalletGetPublicKeys(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsTrue(resp.IsSuccess);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public async Task WalletSetTimeoutTest()
        {
            var resp = await Api.WalletSetTimeout(10, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsTrue(resp.IsSuccess);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public async Task WalletSignTrxTest()
        {
            var resp = await Api.WalletSignTrx(null, null, null, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsTrue(resp.IsSuccess);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }
    }
}
