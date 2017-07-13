using System;
using Ditch.Helpers;
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
        public void PostWithBeneficiaresOperationTest()
        {
            var ops = new BaseOperation[]
            {
                new CommentOperation("parent_author_test1","parent_permlink_test2","author_test3","permlink_test4","title_test5","body_test6","{\"foo\": \"bar\"}"),
                new BeneficiaresOperation("author_test7", "permlink_test8", "SBD", new Beneficiary("account_test9",2000), new Beneficiary("account_test10",5000))
            };

            var tr = new Transaction
            {
                RefBlockNum = 34294,
                RefBlockPrefix = 3707022213,
                Expiration = DateTime.Parse("2016-04-06T08:29:27"),
                BaseOperations = ops,
                ChainId = Hex.HexToBytes("0000000000000000000000000000000000000000000000000000000000000000")
            };
            var msg = SerializeHelper.TransactionToMessage(tr);
            var msgStr = Hex.ToString(msg);
            var t = "0000000000000000000000000000000000000000000000000000000000000000f68585abf4dce7c80457020113706172656e745f617574686f725f746573743115706172656e745f7065726d6c696e6b5f74657374320c617574686f725f74657374330e7065726d6c696e6b5f74657374340b7469746c655f74657374350a626f64795f74657374360e7b22666f6f223a2022626172227d130c617574686f725f74657374370e7065726d6c696e6b5f746573743800ca9a3b000000000353424400000000102701010100020d6163636f756e745f7465737439d0070e6163636f756e745f746573743130881300";
            Assert.IsTrue(t.Equals(msgStr, StringComparison.OrdinalIgnoreCase), $"{msgStr} != {t}");
        }

        [Test]
        public void PostRuTest()
        {
            var ops = new BaseOperation[]
            {
                new CommentOperation("foobara","foobarb","foobarc","foobard","foobare","какой либо текст с русскими буквами!","{\"foo\": \"bar\"}"),
            };

            var tr = new Transaction
            {
                RefBlockNum = 34294,
                RefBlockPrefix = 3707022213,
                Expiration = DateTime.Parse("2016-04-06T08:29:27"),
                BaseOperations = ops,
                ChainId = Hex.HexToBytes("0000000000000000000000000000000000000000000000000000000000000000")
            };
            var msg = SerializeHelper.TransactionToMessage(tr);
            var msgStr = Hex.ToString(msg);
            var t = "0000000000000000000000000000000000000000000000000000000000000000f68585abf4dce7c80457010107666f6f6261726107666f6f6261726207666f6f6261726307666f6f6261726407666f6f6261726542d0bad0b0d0bad0bed0b920d0bbd0b8d0b1d0be20d182d0b5d0bad181d18220d18120d180d183d181d181d0bad0b8d0bcd0b820d0b1d183d0bad0b2d0b0d0bcd0b8210e7b22666f6f223a2022626172227d00";
            Assert.IsTrue(t.Equals(msgStr, StringComparison.OrdinalIgnoreCase), $"{msgStr} != {t}");
        }

    }
}