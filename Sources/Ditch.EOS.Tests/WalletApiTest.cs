using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cryptography.ECDSA;
using Ditch.EOS.Models;
using Ditch.EOS.Tests.Models;
using NUnit.Framework;

namespace Ditch.EOS.Tests
{
    [TestFixture]
    public class WalletApiTest : BaseTest
    {
        private const string CreatePostActionName = "createpost";

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
            user.PublicOwnerWif = Core.Base58.EncodePublicWif(pKey1, "EOS");

            var key2 = Secp256K1Manager.GenerateRandomKey();
            user.PrivateActiveWif = Core.Base58.EncodePrivateWif(key2);
            var pKey2 = Secp256K1Manager.GetPublicKey(key2, true);
            user.PublicActiveWif = Core.Base58.EncodePublicWif(pKey2, "EOS");

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

        [Test]
        public async Task WalletSignTrxTest()
        {
            var abiJsonToBinArgs = new AbiJsonToBinParams
            {
                Code = ContractInfo.ContractName,
                Action = CreatePostActionName,
                Args = new CreatePostArgs
                {
                    UrlPhoto = "test_1_url",
                    AccountCreator = User.Login,
                    IpfsHashPhoto = "test_1_hash"
                    //ParentPost = 1
                }
            };
            var abiJsonToBin = await Api.AbiJsonToBin(abiJsonToBinArgs, CancellationToken);
            Assert.IsFalse(abiJsonToBin.IsError);

            var accountParams = new GetAccountParams
            {
                AccountName = User.Login
            };

            var unlock = await Api.WalletUnlock(User.Login, User.Password, CancellationToken);
            Assert.IsFalse(unlock.IsError);

            var accR = await Api.GetAccount(accountParams, CancellationToken);
            Assert.IsFalse(accR.IsError);

            var publicKeys = accR.Result.Permissions.First(p => p.PermName == "active").RequiredAuth.Keys.Select(k => k.Key).ToArray();

            var args = new CreateTransactionArgs
            {
                Actions = new[]
                {
                    new EOS.Models.Action
                    {
                        Account = User.Login,
                        Name = CreatePostActionName,
                        Authorization = new[]
                        {
                            new PermissionLevel
                            {
                                Actor = User.Login,
                                Permission = "active"
                            }
                        },
                        Data =  abiJsonToBin.Result.Binargs
                    }
                },
                PrivateKeys = new List<byte[]> { User.PrivateActiveKey }
            };
            var trx = await Api.CreateTransaction(args, CancellationToken);

            var infoResp = await Api.GetInfo(CancellationToken.None);
            var info = infoResp.Result;

            var resp = await Api.WalletSignTrx(trx, publicKeys, info.ChainId, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var wlock = await Api.WalletLock(User.Login, CancellationToken);
            Assert.IsFalse(wlock.IsError);
        }
    }
}
