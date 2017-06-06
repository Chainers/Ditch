using System;
using System.Linq;
using Cryptography.ECDSA;
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
                BaseOperations = new[]
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
        [TestCase((ushort)42584, (uint)3436728375, "2017-05-18T11:51:56", "testName", "timsaid", "myth-or-fact-17-cockroaches-can-survive-a-nuclear-catastrophe", (ushort)1000, TestWif, "3045022100a9ada7beb5ac589324cbe9d552c390c254f3aff4b1966c3b6396452b6d6d2bec0220774608bf21f1c8d5e5d2675878d4b11e940ab0254a77526987792fb9cb01f914")]
        [TestCase((ushort)34294, (uint)3707022213, "2016-04-06T08:29:27", "foobara", "foobarc", "foobard", (ushort)1000, TestWif, "304402200f131d009c8d2090fe1f406c3a0db416789b06a5489eb3ba31f689ece70c51d90220207d50135635d701a043714c688b7039169e4b9c25b4875e2e4f512039ba3b9d")]
        public void VoteTransactionTest(ushort refBlockNum, uint refBlockPrefix, string expiration, string voter, string author, string permlink, ushort weight, string wif, string tSig)
        {
            var tr = new Transaction
            {
                ChainId = ChainManager.GetChainInfo(ChainManager.KnownChains.Steem).ChainId,
                RefBlockNum = refBlockNum,
                RefBlockPrefix = refBlockPrefix,
                Expiration = DateTime.Parse(expiration),
                BaseOperations = new[]
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
            var key = Base58.GetBytes(wif);
            var digest = Proxy.GetMessageHash(msg);
            var sig = Proxy.Sign(digest, key);

            var hs = Hex.ToString(sig);
            Assert.IsTrue(tSig.Equals(hs), $"{tSig} != {hs}");

            Console.WriteLine(hs);
        }

        [Test]
        [Ignore("broadcast to blockchain / set our own data for test")]
        [TestCase("voter", "author", "permlink", (ushort)10000, "wif", ChainManager.KnownChains.Steem)]
        public void SignTransactionTest(string voter, string author, string permlink, ushort weight, string wif, ChainManager.KnownChains chain)
        {
            var manager = new TransactionManager(wif, chain);
            var vote = new VoteOperation()
            {
                Author = author,
                Voter = voter,
                Permlink = permlink,
                Weight = weight
            };
            manager.AddOperation(vote);
        }
    }
}