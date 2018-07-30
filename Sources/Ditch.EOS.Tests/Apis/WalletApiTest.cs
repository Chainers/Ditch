using System;
using System.Threading;
using System.Threading.Tasks;
using Cryptography.ECDSA;
using NUnit.Framework;

namespace Ditch.EOS.Tests.Apis
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
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public async Task WalletImportKeyTest()
        {
            var user = new UserInfo
            {
                Login = $"testname{DateTime.Now:yyyyMMddhhmmss}"
            };

            WriteLine(user.Login);
            var resp = await Api.WalletCreate(user.Login, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
            user.Password = resp.Result;

            var key1 = Secp256K1Manager.GenerateRandomKey();
            user.PrivateOwnerWif = Core.Base58.EncodePrivateWif(key1);
            var pKey1 = Secp256K1Manager.GetPublicKey(key1, true);

            var key2 = Secp256K1Manager.GenerateRandomKey();
            user.PrivateActiveWif = Core.Base58.EncodePrivateWif(key2);
            var pKey2 = Secp256K1Manager.GetPublicKey(key2, true);

            WriteLine(user);

            var addOwner = await Api.WalletImportKey(user.Login, user.PrivateOwnerWif, CancellationToken.None);
            WriteLine(addOwner);
            Assert.IsFalse(resp.IsError);

            var addActive = await Api.WalletImportKey(user.Login, user.PrivateActiveWif, CancellationToken.None);
            WriteLine(addActive);
            Assert.IsFalse(resp.IsError);

            var unlock = await Api.WalletUnlock(user.Login, user.Password, CancellationToken);
            Assert.IsFalse(unlock.IsError);

            var walletGetPublicKeysResult = await Api.WalletGetPublicKeys(CancellationToken.None);
            WriteLine(walletGetPublicKeysResult);
            Assert.IsFalse(walletGetPublicKeysResult.IsError);
        }

        [Test]
        public async Task WalletOpenTest()
        {
            var resp = await Api.WalletOpen(User.Login, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public async Task WalletLockTest()
        {
            var resp = await Api.WalletLock(User.Login, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public async Task WalletLockAllTest()
        {
            var resp = await Api.WalletLockAll(CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public async Task WalletUnlockTest()
        {
            var resp = await Api.WalletUnlock(User.Login, User.Password, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public async Task WalletListTest()
        {
            var resp = await Api.WalletList(CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        [Ignore(" --- not work")]
        public async Task WalletListKeysTest()
        {
            var resp = await Api.WalletListKeys(CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public async Task WalletGetPublicKeysTest()
        {
            var unlock = await Api.WalletUnlock(User.Login, User.Password, CancellationToken);
            Assert.IsFalse(unlock.IsError);

            var resp = await Api.WalletGetPublicKeys(CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public async Task WalletSetTimeoutTest()
        {
            var resp = await Api.WalletSetTimeout(10, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }
    }
}
