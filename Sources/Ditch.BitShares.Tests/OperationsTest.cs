using System.Collections.Generic;
using System.Text.RegularExpressions;
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
        private readonly Regex _errorMsg = new Regex(@"(?<=[\w\s\(\)&|\.<>=]+:\s+)[a-z\s0-9.]*", RegexOptions.IgnoreCase);
        private const bool IsVerify = true;

        private JsonRpcResponse Post(List<byte[]> postingKeys, bool isNeedBroadcast, params BaseOperation[] op)
        {
            if (!IsVerify || isNeedBroadcast)
                return Api.BroadcastOperations(postingKeys, CancellationToken.None, op);

            return Api.VerifyAuthority(postingKeys, CancellationToken.None, op);
        }


        [Test]
        public async Task AccountCreateOperationTest()
        {
            var privateKey = Secp256K1Manager.GenerateRandomKey();
            var privateWif = Base58.EncodePrivateWif(privateKey);
            var k = Base58.DecodePrivateWif(privateWif);

            var tt = Hex.ToString(privateKey);
            var ktt = Hex.ToString(k);
            Assert.IsTrue(tt.Equals(ktt));

            var op = new AccountCreateOperation
            {
                Fee = new Asset()
                {
                    Amount = 58516,
                    AssetId = new AssetIdType(1, 3, 0)
                },
                Registrar = new AccountIdType(1, 2, 22765),
                Referrer = new AccountIdType(1, 2, 22765),
                ReferrerPercent = 7000,
                Name = "test-account-nano",
                Owner = new Authority(new PublicKeyType("TEST6FcnaaaP7eZWqUs5VHRPMwjD69V1SFAAVoJRHiq3YEJ7tVgyQc", "TEST")),
                Active = new Authority(new PublicKeyType("TEST6KCYpvc3syCbsRaofXLffEXoLDKixN2SLUCLPz4XubmptGNFfe", "TEST")),
                Options = new AccountOptions()
                {
                    MemoKey = new PublicKeyType("TEST6HWVwXazrgS3MsWZvvSV6qdRbc8GS7KpdfDw8mAcNug4RcPv3v", "TEST"),
                    VotingAccount = new AccountIdType(1, 2, 5),
                },
            };

            var response = Post(User.PrivateKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }
    }
}