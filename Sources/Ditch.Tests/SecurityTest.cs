using System;
using System.Linq;
using Ditch.Helpers;
using Ditch.Operations;
using NUnit.Framework;

namespace Ditch.Tests
{
    [TestFixture]
    public class SecurityTest : BaseTest
    {
        [Test]
        [TestCase((ushort)36029, (uint)1164960351, "2016-08-08T12:24:17", "xeroc", "xeroc", "piston", (ushort)10000, "bd8c5fe26f45f179a8570100057865726f63057865726f6306706973746f6e102700")]
        public void TransactionToMessageTest(ushort refBlockNum, uint refBlockPrefix, string expiration, string voter, string author, string permlink, ushort weight, string tSig)
        {
            var tr = new Transaction
            {
                RefBlockNum = refBlockNum,
                RefBlockPrefix = refBlockPrefix,
                Expiration = DateTime.Parse(expiration),
                BaseOperations = new BaseOperation[]
                {
                    new VoteOperation
                    {
                        Voter = voter,
                        Author = author,
                        Permlink = permlink,
                        Weight = weight
                    }
                }
            };
            var msg = SerializeHelper.TransactionToMessage(tr);
            var msgStr = string.Join(string.Empty, msg.Select(i => i.ToString("x2")));
            var chainId = Hex.ToString(tr.ChainId);
            var t = chainId + tSig;
            Assert.IsTrue(t.Equals(msgStr, StringComparison.OrdinalIgnoreCase), $"{msgStr} != {t}");
        }

        [Test]
        [TestCase("voter", "author", "permlink", (ushort)10000, "wif", ChainManager.KnownChains.Steem)]
        public void SignTransactionTest(string voter, string author, string permlink, ushort weight, string wif, ChainManager.KnownChains chain)
        {
            GlobalSettings.Init(voter, wif, chain);
            var manager = new OperationManager();

            var t = manager.Vote(author, permlink, weight);
            Assert.IsFalse(t.Result.IsError);
        }
    }
}