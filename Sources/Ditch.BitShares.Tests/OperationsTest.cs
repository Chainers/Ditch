using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cryptography.ECDSA;
using Ditch.BitShares.Models;
using Ditch.BitShares.Operations;
using Ditch.Core.JsonRpc;
using NUnit.Framework;
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
                response = await Api.BroadcastOperations(postingKeys, op, CancellationToken.None);
            else
                response = await Api.VerifyAuthority(postingKeys, op, CancellationToken.None);

            WriteLine(response);

            Assert.IsFalse(response.IsError);
        }

        [Test]
        public async Task AccountCreateOperationTestAsync()
        {
            var name = "userlogin";
            var key = Secp256K1Manager.GenerateRandomKey();
            var pwif = "P" + Base58.EncodePrivateWif(key);

            var user = User.Account.Id;

            var op = new AccountCreateOperation
            {
                Fee = new Asset
                {
                    Amount = 100000,
                    AssetId = new AssetIdType(1, 3, 0)
                },
                Registrar = user,
                Referrer = user,
                ReferrerPercent = 10000,
                Name = name,
                Options = new AccountOptions
                {
                    VotingAccount = new AccountIdType(1, 2, 5)
                }
            };

            var subWif = Base58.GetSubWif(name, pwif, "owner");
            var pk = Base58.DecodePrivateWif(subWif);
            var subPublicKey = Secp256K1Manager.GetPublicKey(pk, true);
            op.Owner = new Authority(new PublicKeyType(subPublicKey, "TEST"));

            subWif = Base58.GetSubWif(name, pwif, "active");
            pk = Base58.DecodePrivateWif(subWif);
            subPublicKey = Secp256K1Manager.GetPublicKey(pk, true);
            op.Active = new Authority(new PublicKeyType(subPublicKey, "TEST"));

            subWif = Base58.GetSubWif(name, pwif, "memo");
            pk = Base58.DecodePrivateWif(subWif);
            subPublicKey = Secp256K1Manager.GetPublicKey(pk, true);
            op.Options.MemoKey = new PublicKeyType(subPublicKey, "TEST");

            await Post(User.ActiveKeys, false, op);
        }
    }
}