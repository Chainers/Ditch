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
            var resp = await Api.WalletCreateAsync(User.Login, CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            if (resp.IsError) //already added
            {

                resp = await Api.WalletCreateAsync(User.Login + DateTime.Now.Millisecond, CancellationToken.None).ConfigureAwait(false);
                WriteLine(resp);
                Assert.IsFalse(resp.IsError);
            }
        }

        [Test]
        public async Task WalletImportKeyTest()
        {
            var testLogin2 = User.Login + DateTime.Now.Millisecond;
            var resp = await Api.WalletCreateAsync(User.Login, CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            if (!resp.IsError)
                User.Password = resp.Result;
            if (resp.IsError) //already added
            {

                resp = await Api.WalletCreateAsync(testLogin2, CancellationToken.None).ConfigureAwait(false);
                WriteLine(resp);
                Assert.IsFalse(resp.IsError);
            }

            var addOwner = await Api.WalletImportKeyAsync(User.Login, User.PrivateOwnerWif, CancellationToken.None).ConfigureAwait(false);
            WriteLine(addOwner);
            if (resp.IsError) //already added
            {

                addOwner = await Api.WalletImportKeyAsync(testLogin2, User.PrivateOwnerWif, CancellationToken.None).ConfigureAwait(false);
                WriteLine(addOwner);
                Assert.IsFalse(addOwner.IsError);
            }

            var addActive = await Api.WalletImportKeyAsync(User.Login, User.PrivateActiveWif, CancellationToken.None).ConfigureAwait(false);
            WriteLine(addActive);
            if (resp.IsError) //already added
            {

                addActive = await Api.WalletImportKeyAsync(testLogin2, User.PrivateActiveWif, CancellationToken.None).ConfigureAwait(false);
                WriteLine(addActive);
                Assert.IsFalse(addActive.IsError);
            }
        }

        [Test]
        public async Task WalletOpenTest()
        {
            var resp = await Api.WalletOpenAsync(User.Login, CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public async Task WalletLockTest()
        {
            var resp = await Api.WalletLockAsync(User.Login, CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public async Task WalletLockAllTest()
        {
            var resp = await Api.WalletLockAllAsync(CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public async Task WalletUnlockTest()
        {
            var resp = await Api.WalletUnlockAsync(User.Login, User.Password, CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            await Api.WalletLockAsync(User.Login, CancellationToken).ConfigureAwait(false);
        }

        [Test]
        public async Task WalletListTest()
        {
            var resp = await Api.WalletListAsync(CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        [Ignore(" --- not work")]
        public async Task WalletListKeysTest()
        {
            var resp = await Api.WalletListKeysAsync(CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public async Task WalletGetPublicKeysTest()
        {
            var unlock = await Api.WalletUnlockAsync(User.Login, User.Password, CancellationToken).ConfigureAwait(false);
            Assert.IsFalse(unlock.IsError);

            var resp = await Api.WalletGetPublicKeysAsync(CancellationToken.None).ConfigureAwait(false);
            await Api.WalletLockAsync(User.Login, CancellationToken).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public async Task WalletSetTimeoutTest()
        {
            var resp = await Api.WalletSetTimeoutAsync(10, CancellationToken.None).ConfigureAwait(false);
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

            var initOpRez = await Api.AbiJsonToBinAsync(new[] { op }, CancellationToken).ConfigureAwait(false);
            if (initOpRez.IsError)
            {
                WriteLine(initOpRez);
                Assert.Fail();
            }

            var infoResp = await Api.GetInfoAsync(CancellationToken).ConfigureAwait(false);
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
            var getBlock = await Api.GetBlockAsync(blockArgs, CancellationToken).ConfigureAwait(false);
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


            await Api.WalletOpenAsync(User.Login, CancellationToken).ConfigureAwait(false);
            await Api.WalletUnlockAsync(User.Login, User.Password, CancellationToken).ConfigureAwait(false);

            var resp = await Api.WalletSignTransactionAsync(trx, new[] { new PublicKey(User.PublicActiveWif), }, info.ChainId, CancellationToken.None).ConfigureAwait(false);
            await Api.WalletLockAsync(User.Login, CancellationToken).ConfigureAwait(false);
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

            await Api.WalletOpenAsync(User.Login, CancellationToken).ConfigureAwait(false);
            await Api.WalletUnlockAsync(User.Login, User.Password, CancellationToken).ConfigureAwait(false);

            var resp = await Api.BroadcastActionsWithWalletAsync(new[] { op }, new[] { new PublicKey(User.PublicActiveWif) }, CancellationToken).ConfigureAwait(false);
            await Api.WalletLockAsync(User.Login, CancellationToken).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }
    }
}
