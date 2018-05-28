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
                RefBlockNum = 1234,
                RefBlockPrefix = 5678,
                Expiration = DateTime.Now.AddSeconds(30),
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

            };

            var transaction = GetTransaction();
            transaction.BaseOperations = new[] { op };

            var msg = Api.GetTransactionHex(transaction, token);
            var msg2 = Api.MessageSerializer.Serialize<SignedTransaction>(transaction);
            var arr2 = Hex.ToString(msg2);

            Assert.IsFalse(msg.IsError);

            var arr = Hex.HexToBytes(msg.Result);
            var data = Sha256Manager.GetHash(arr);
        }
    }
}
