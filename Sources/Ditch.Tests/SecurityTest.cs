using System;
using System.Linq;
using Ditch.Helpers;
using Ditch.Operations;
using Ditch.Operations.Post;
using NUnit.Framework;

namespace Ditch.Tests
{
    [TestFixture]
    public class SecurityTest : BaseTest
    {
        [Test]
        [TestCase((ushort)36029, (uint)1164960351, "2016-08-08T12:24:17", "xeroc", "xeroc", "piston", (short)10000, "bd8c5fe26f45f179a8570100057865726f63057865726f6306706973746f6e102700")]
        public void TransactionToMessageTest(ushort refBlockNum, uint refBlockPrefix, string expiration, string voter, string author, string permlink, short weight, string tSig)
        {
            var tr = new Transaction
            {
                RefBlockNum = refBlockNum,
                RefBlockPrefix = refBlockPrefix,
                Expiration = DateTime.Parse(expiration),
                BaseOperations = new BaseOperation[]
                {
                    new VoteOperation(voter, author, permlink, weight)
                }
            };
            var msg = SerializeHelper.TransactionToMessage(tr);
            var msgStr = Hex.ToString(msg);
            var chainId = Hex.ToString(tr.ChainId);
            var t = chainId + tSig;
            Assert.IsTrue(t.Equals(msgStr, StringComparison.OrdinalIgnoreCase), $"{msgStr} != {t}");
        }

        [Test]
        public void AddBeneficiaresOperationTest()
        {
            var ops = new BaseOperation[]
            {
                new BeneficiaresOperation("xeroc", "piston", "SBD", new BeneficiaresOperation.Beneficiary("good-karma",2000), new BeneficiaresOperation.Beneficiary("null",5000))
            };

            var tr = new Transaction
            {
                RefBlockNum = (ushort)34294,
                RefBlockPrefix = (uint)3707022213,
                Expiration = DateTime.Parse("2016-04-06T08:29:27"),
                BaseOperations = ops,
                ChainId = Hex.HexToBytes("0000000000000000000000000000000000000000000000000000000000000000")
            };
            var msg = SerializeHelper.TransactionToMessage(tr);
            var msgStr = Hex.ToString(msg);
            var t = "0000000000000000000000000000000000000000000000000000000000000000f68585abf4dce7c804570113057865726f6306706973746f6e00ca9a3b000000000353424400000000102701010100020a676f6f642d6b61726d61d007046e756c6c881300";
            Assert.IsTrue(t.Equals(msgStr, StringComparison.OrdinalIgnoreCase), $"{msgStr} != {t}");
        }
    }
}