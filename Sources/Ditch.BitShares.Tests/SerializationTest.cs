using System;
using System.Threading;
using Cryptography.ECDSA;
using Ditch.BitShares.Models;
using Ditch.BitShares.Models.Operations;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Ditch.BitShares.Tests
{
    [TestFixture]
    public class SerializationTest : BaseTest
    {
        public SignedTransaction GetTransaction()
        {
            return new SignedTransaction
            {
                ChainId = Api.ChainId,
                RefBlockNum = 5446,
                RefBlockPrefix = 1867525305,
                Expiration = DateTime.Parse("2018-05-28T10:14:18"),
                BaseOperations = new BaseOperation[0],
            };
        }

        [Test]
        public void EmptyTransactionTest()
        {
            var token = CancellationToken.None;
            var transaction = GetTransaction();
            transaction.BaseOperations = new BaseOperation[0];

            var msg = Api.GetTransactionHex(transaction, token);
            Assert.IsFalse(msg.IsError, JsonConvert.SerializeObject(msg.Error, Formatting.Indented));

            var msg2 = Api.MessageSerializer.Serialize<SignedTransaction>(transaction);
            var sHex = Hex.ToString(msg2);

            var fullTransactionHex = Hex.ToString(transaction.ChainId) + msg.Result.Remove(msg.Result.Length - 2);

            Assert.IsTrue(fullTransactionHex.Equals(sHex));
        }

        [Test]
        public void AccountCreateOperationTest()
        {
            var token = CancellationToken.None;
            var op = new AccountCreateOperation
            {
                Fee = new Asset()
                {
                    Amount = 58516,
                    AssetId = new AssetIdType(1, 3, 0)
                },
                Registrar = "1.2.22760",
                Referrer = "1.2.22760",
                ReferrerPercent = 7000,
                Name = "test-account-nano",
                Owner = new Authority(new PublicKeyType("TEST6FcnaaaP7eZWqUs5VHRPMwjD69V1SFAAVoJRHiq3YEJ7tVgyQc", "TEST")),
                Active = new Authority(new PublicKeyType("TEST6KCYpvc3syCbsRaofXLffEXoLDKixN2SLUCLPz4XubmptGNFfe", "TEST")),
                Options = new AccountOptions()
                {
                    MemoKey = new PublicKeyType("TEST6HWVwXazrgS3MsWZvvSV6qdRbc8GS7KpdfDw8mAcNug4RcPv3v", "TEST"),
                    VotingAccount = "1.2.5",
                    NumWitness = 0,
                    NumCommittee = 0,
                    Votes = new object[0],
                    Extensions = new object[0],
                },
                Extensions = new object(),

            };

            var transaction = GetTransaction();
            transaction.BaseOperations = new[] { op };

            //var msgHex = Api.GetTransactionHex(transaction, token);
            //Assert.IsFalse(msgHex.IsError, JsonConvert.SerializeObject(msgHex.Error, Formatting.Indented));
            //var msg = Hex.ToString(Api.ChainId) + msgHex.Result;

            var sMsg = Api.MessageSerializer.Serialize<SignedTransaction>(transaction);
            var msg2 = Hex.ToString(sMsg);

            //Assert.IsTrue(msg.Equals(msg2));
        }
    }
}

