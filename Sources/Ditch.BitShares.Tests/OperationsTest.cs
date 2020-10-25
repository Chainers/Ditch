using System;
using Cryptography.ECDSA;
using Ditch.BitShares.Models;
using Ditch.BitShares.Operations;
using Ditch.Core.JsonRpc;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Base58 = Ditch.Core.Base58;

namespace Ditch.BitShares.Tests
{
    [TestFixture]
    public class OperationsTest : BaseTest
    {
        private async Task Post(IList<byte[]> postingKeys, bool isNeedBroadcast, params BaseOperation[] op)
        {
            JsonRpcResponse response;
            if (isNeedBroadcast)
                response = await Api.BroadcastOperationsAsync(postingKeys, op, CancellationToken.None).ConfigureAwait(false);
            else
                response = await Api.VerifyAuthorityAsync(postingKeys, op, CancellationToken.None).ConfigureAwait(false);

            WriteLine(response);

            Assert.IsFalse(response.IsError);
        }

        [Test]
        public async Task AccountCreateOperationTest()
        {
            var name = $"ditch-test-user-{DateTime.Now.Ticks}";
            WriteLine($"name: {name}");
            var key = Secp256K1Manager.GenerateRandomKey();
            var pwif = "P" + Base58.EncodePrivateWif(key);
            WriteLine($"pwif: {pwif}");

            var user = User;
            var userId = user.Account.Id;

            var op = new AccountCreateOperation
            {
                Fee = new Asset
                {
                    Amount = 500000,
                    AssetId = new AssetIdType(1, 3, 0)
                },
                Registrar = userId,
                Referrer = userId,
                ReferrerPercent = 10000,
                Name = name,
                Options = new AccountOptions
                {
                    VotingAccount = new AccountIdType(1, 2, 5)
                }
            };

            var subWif = Base58.GetSubWif(name, pwif, "owner");
            WriteLine($"owner: {subWif}");
            var pk = Base58.DecodePrivateWif(subWif);
            var subPublicKey = Secp256K1Manager.GetPublicKey(pk, true);
            op.Owner = new Authority(new PublicKeyType(subPublicKey, SbdSymbol));

            subWif = Base58.GetSubWif(name, pwif, "active");
            WriteLine($"active: {subWif}");
            pk = Base58.DecodePrivateWif(subWif);
            subPublicKey = Secp256K1Manager.GetPublicKey(pk, true);
            op.Active = new Authority(new PublicKeyType(subPublicKey, SbdSymbol));

            subWif = Base58.GetSubWif(name, pwif, "memo");
            WriteLine($"memo: {subWif}");
            pk = Base58.DecodePrivateWif(subWif);
            subPublicKey = Secp256K1Manager.GetPublicKey(pk, true);
            op.Options.MemoKey = new PublicKeyType(subPublicKey, SbdSymbol);


            await Post(user.ActiveKeys, false, op).ConfigureAwait(false);
        }

        [Test]
        public async Task TransferOperationTest()
        {
            var fromUser = User;
            var toUser = Api.GetAccountByNameAsync("ditchtest1", CancellationToken.None).Result.Result;

            var op = new TransferOperation
            {
                Fee = new Asset
                {
                    Amount = 100,
                    AssetId = new AssetIdType(1, 3, 0)
                },
                From = fromUser.Account.Id,
                To = toUser.Id,
                Amount = new Asset
                {
                    Amount = 100000,
                    AssetId = new AssetIdType(1, 3, 0)
                },
                Memo = new MemoData
                {
                    From = fromUser.Account.Active.KeyAuths[0].Key,
                    To = toUser.Active.KeyAuths[0].Key,
                    Message = "",
                    Nonce = 0
                },
                Extensions = new object[0],
            };


            await Post(fromUser.ActiveKeys, false, op).ConfigureAwait(false);
        }
    }
}