using System;
using System.Threading;
using System.Threading.Tasks;
using Ditch.EOS.Contracts.Eosio.Actions;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;
using NUnit.Framework;

namespace Ditch.EOS.Tests.Apis
{
    [TestFixture]
    public class WalletApiTest : BaseTest
    {
        [Test]
        public async Task CreateTest()
        {
            var resp = await Api.WalletCreate(User.Login, CancellationToken.None);
            WriteLine(resp);
            if (resp.IsError) //already added
            {

                resp = await Api.WalletCreate(User.Login + DateTime.Now.Millisecond, CancellationToken.None);
                WriteLine(resp);
                Assert.IsFalse(resp.IsError);
            }
        }

        [Test]
        public async Task WalletImportKeyTest()
        {
            var testLogin2 = User.Login + DateTime.Now.Millisecond;
            var resp = await Api.WalletCreate(User.Login, CancellationToken.None);
            WriteLine(resp);
            if (!resp.IsError)
                User.Password = resp.Result;
            if (resp.IsError) //already added
            {

                resp = await Api.WalletCreate(testLogin2, CancellationToken.None);
                WriteLine(resp);
                Assert.IsFalse(resp.IsError);
            }

            var addOwner = await Api.WalletImportKey(User.Login, User.PrivateOwnerWif, CancellationToken.None);
            WriteLine(addOwner);
            if (resp.IsError) //already added
            {

                addOwner = await Api.WalletImportKey(testLogin2, User.PrivateOwnerWif, CancellationToken.None);
                WriteLine(addOwner);
                Assert.IsFalse(addOwner.IsError);
            }

            var addActive = await Api.WalletImportKey(User.Login, User.PrivateActiveWif, CancellationToken.None);
            WriteLine(addActive);
            if (resp.IsError) //already added
            {

                addActive = await Api.WalletImportKey(testLogin2, User.PrivateActiveWif, CancellationToken.None);
                WriteLine(addActive);
                Assert.IsFalse(addActive.IsError);
            }
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

            await Api.WalletLock(User.Login, CancellationToken);
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
            await Api.WalletLock(User.Login, CancellationToken);
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
        public async Task SignTransactionTest()
        {
            var op = new BuyramAction
            {
                Account = User.Login,

                Args = new Buyram
                {
                    Payer = User.Login,
                    Receiver = User.Login,
                    Quant = new Asset("0.001 EOS")

                },
                Authorization = new[]
                {
                    new PermissionLevel
                    {
                        Actor = User.Login,
                        Permission = "active"
                    }
                }
            };

            var initOpRez = await Api.AbiJsonToBin(new[] { op }, CancellationToken);
            if (initOpRez.IsError)
            {
                WriteLine(initOpRez);
                Assert.Fail();
            }

            var infoResp = await Api.GetInfo(CancellationToken);
            if (infoResp.IsError)
            {
                WriteLine(infoResp);
                Assert.Fail();
            }

            var info = infoResp.Result;

            var blockArgs = new GetBlockParams
            {
                BlockNumOrId = info.HeadBlockId
            };
            var getBlock = await Api.GetBlock(blockArgs, CancellationToken);
            if (getBlock.IsError)
            {
                WriteLine(getBlock);
                Assert.Fail();
            }

            var block = getBlock.Result;

            var trx = new SignedTransaction
            {
                Actions = new[] { op },
                RefBlockNum = (ushort)(block.BlockNum & 0xffff),
                RefBlockPrefix = block.RefBlockPrefix,
                Expiration = block.Timestamp.Value.AddSeconds(30)
            };


            await Api.WalletOpen(User.Login, CancellationToken);
            await Api.WalletUnlock(User.Login, User.Password, CancellationToken);

            var resp = await Api.WalletSignTransaction(trx, new[] { new PublicKey(User.PublicActiveWif), }, info.ChainId, CancellationToken.None);
            await Api.WalletLock(User.Login, CancellationToken);
            WriteLine(resp);

            Assert.IsFalse(resp.IsError);
            Assert.IsTrue(resp.Result.Signatures.Length == 1);
        }

        [Test]
        public async Task BroadcastActionsTest()
        {
            var op = new BuyramAction
            {
                Account = User.Login,

                Args = new Buyram
                {
                    Payer = User.Login,
                    Receiver = User.Login,
                    Quant = new Asset("0.001 EOS")

                },
                Authorization = new[]
                {
                    new PermissionLevel
                    {
                        Actor = User.Login,
                        Permission = "active"
                    }
                }
            };

            await Api.WalletOpen(User.Login, CancellationToken);
            await Api.WalletUnlock(User.Login, User.Password, CancellationToken);

            var resp = await Api.BroadcastActionsWithWallet(new[] { op }, new[] { new PublicKey(User.PublicActiveWif) }, CancellationToken);
            await Api.WalletLock(User.Login, CancellationToken);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }
    }
}
