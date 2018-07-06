using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cryptography.ECDSA;
using Ditch.BitShares.Models;
using Ditch.BitShares.Models.Operations;
using Ditch.Core.JsonRpc;
using NUnit.Framework;
using Base58 = Ditch.Core.Base58;

namespace Ditch.BitShares.Tests
{
    [TestFixture]
    public class OperationsTest : BaseTest
    {
        private JsonRpcResponse Post(List<byte[]> postingKeys, bool isNeedBroadcast, params BaseOperation[] op)
        {
            return isNeedBroadcast
                ? (JsonRpcResponse)Api.BroadcastOperations(postingKeys, CancellationToken.None, op)
                : Api.VerifyAuthority(postingKeys, CancellationToken.None, op);
        }


        [Test]
        public void AccountCreateOperationTest()
        {
            var name = "userlogin";
            var key = Secp256K1Manager.GenerateRandomKey();
            var pwif = "P" + Base58.EncodePrivateWif(key);

            var user = User.Account.Id;

            var op = new AccountCreateOperation
            {
                Fee = new Asset()
                {
                    Amount = 100000,
                    AssetId = new AssetIdType(1, 3, 0)
                },
                Registrar = user,
                Referrer = user,
                ReferrerPercent = 10000,
                Name = name,
                Options = new AccountOptions()
                {
                    VotingAccount = new AccountIdType(1, 2, 5),
                },
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

            var response = Post(User.ActiveKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }
    }
}