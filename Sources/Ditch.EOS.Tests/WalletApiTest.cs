using System;
using System.Threading;
using System.Threading.Tasks;
using Cryptography.ECDSA;
using Ditch.EOS.Tests.Models;
using NUnit.Framework;

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
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public async Task WalletImportKeyTest()
        {
            var user = new UserInfo()
            {
                Login = $"testname{DateTime.Now:yyyyMMddhhmmss}"
            };

            WriteLine(user.Login);
            var resp = await Api.WalletCreate(user.Login, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
            user.Password = resp.Result;

            var key1 = Secp256K1Manager.GenerateRandomKey();
            user.PrivateOwnerWif = Ditch.Core.Base58.EncodePrivateWif(key1);
            var pKey1 = Secp256K1Manager.GetPublicKey(key1, true);
            user.PublicOwnerWif = Ditch.Core.Base58.EncodePublicWif(pKey1, "EOS");

            var key2 = Secp256K1Manager.GenerateRandomKey();
            user.PrivateActiveWif = Ditch.Core.Base58.EncodePrivateWif(key2);
            var pKey2 = Secp256K1Manager.GetPublicKey(key2, true);
            user.PublicActiveWif = Ditch.Core.Base58.EncodePublicWif(pKey2, "EOS");

            WriteLine(user);

            var addOwner = await Api.WalletImportKey(user.Login, user.PrivateOwnerWif, CancellationToken.None);
            WriteLine(addOwner);
            Assert.IsFalse(resp.IsError);

            var addActive = await Api.WalletImportKey(user.Login, user.PrivateActiveWif, CancellationToken.None);
            WriteLine(addActive);
            Assert.IsFalse(resp.IsError);

            var unlock = await Api.WalletUnlock(user.Login, user.Password, CancellationToken);
            // Assert.IsTrue(unlock.IsSuccess);

            var walletGetPublicKeysResult = await Api.WalletGetPublicKeys(CancellationToken.None);
            WriteLine(walletGetPublicKeysResult);
            Assert.IsFalse(walletGetPublicKeysResult.IsError);
        }


        //--------------------
        //testname20180621043704
        //--------------------
        //"PW5KjL9Y5UWeMff4yR5kDkopfd365qeGoQX9iUioGS9D9kVkN3BxR"
        //--------------------
        //{
        //    "Login": "testname20180621043704",
        //    "PrivateOwnerWif": "5JhNqmjvavizox9LK8tYM77txzVuJMDmLt4NXG4HYfuEXX5Hnak",
        //    "PublicOwnerWif": "EOS8XsUUYjXRJSFPbcou56WRYJRsSxqRG2KA8asBWXg2X3pKuokXF",
        //    "PrivateActiveWif": "",
        //    "PublicActiveWif": "EOS6UM37jgVkx65nrwxH4cyMiTmzN1rQVawDfLxnCvnX94W92PJ6U",
        //    "Password": "PW5KjL9Y5UWeMff4yR5kDkopfd365qeGoQX9iUioGS9D9kVkN3BxR",
        //    "OwnerKeys": [
        //    "dAH2kDu8xpFV02wQ0FtzDmXPes+DFIcYF3RU0XZgVLA="
        //        ],
        //    "ActiveKeys": [
        //    ""
        //        ],
        //    "IsNsfw": false,
        //    "IsLowRated": false
        //}
        //--------------------
        //"PW5KjL9Y5UWeMff4yR5kDkopfd365qeGoQX9iUioGS9D9kVkN3BxR"
        //--------------------
        //"PW5KjL9Y5UWeMff4yR5kDkopfd365qeGoQX9iUioGS9D9kVkN3BxR"

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

        //[Test]
        //public async Task WalletSignTrxTest()
        //{
        //    var infoResp = await Api.GetInfo(CancellationToken.None);
        //    var info = infoResp.Result;

        //    var trx = new SignedTransaction
        //    {
        //        Expiration = info.HeadBlockTime.AddSeconds(30),
        //        RefBlockNum = (ushort)(info.HeadBlockNum & 0xffff),
        //        RefBlockPrefix = (uint)BitConverter.ToInt32(Hex.HexToBytes(info.HeadBlockId), 4),
        //        DelaySec = 0,
        //        ContextFreeActions = new Action[0],
        //        Actions = new[]
        //            {
        //                        new Action
        //                        {
        //                            Account = "hackathon",
        //                            Name = "transfer",
        //                            Authorization = new[]
        //                            {
        //                                new PermissionLevel
        //                                {
        //                                    Actor = "test1",
        //                                    Permission = "active"
        //                                }
        //                            },
        //                            Data = "000000008090b1ca000000008090b1cae8030000000000000056494d00000000"
        //                        }
        //                    },
        //        Signatures = new string[0],
        //        ContextFreeData = new byte[0]
        //    };
        //    var publicKeys = new[] { string.Empty };
        //    var chainId = string.Empty;

        //    var resp = await Api.WalletSignTrx(trx, publicKeys, chainId, CancellationToken.None);
        //    WriteLine(resp);
        //    Assert.IsFalse(resp.IsError);
        //}
    }
}
