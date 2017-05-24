using System;
using System.Linq;
using Cryptography.ECDSA;
using Cryptography.ECDSA.Curves;
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
                BaseOperations = new []
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
        [TestCase((ushort)42584, (uint)3436728375, "2017-05-18T11:51:56", JosephName, "timsaid", "myth-or-fact-17-cockroaches-can-survive-a-nuclear-catastrophe", (ushort)1000, JosephWif, "1f7756a69121e16532538d2124475a34f5249b3690d30a94a9dca99a8ecd71c8a0518b5c7b56a4b0cca8f3ad4bc24559990d96f39e96f25246cc27b080e5858a29")]
        [TestCase((ushort)34294, (uint)3707022213, "2016-04-06T08:29:27", "foobara", "foobarc", "foobard", (ushort)1000, JosephWif, "20716d95af34005849f1b0b0aa4c093724c4692de37ae897f196b2637d02bde5ed71ca372f56ae04a63dcce7ff1ccbbe5e464f8762b063a4a6116b96274417bf79")]
        public void VoteTransactionTest(ushort refBlockNum, uint refBlockPrefix, string expiration, string voter, string author, string permlink, ushort weight, string wif, string tSig)
        {
            var tr = new Transaction
            {
                ChainId = ChainManager.GetChainInfo(ChainManager.KnownChains.Steem).ChainId,
                RefBlockNum = refBlockNum,
                RefBlockPrefix = refBlockPrefix,
                Expiration = DateTime.Parse(expiration),
                BaseOperations = new []
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
            var curve = new Secp256K1();
            var key = new Base58(wif);
            var sig = curve.Sign(msg, key);

            var hs = Hex.ToString(sig);
            Assert.IsTrue(tSig.Equals(hs));

            Console.WriteLine(hs);
        }

        [Test]
        [Ignore("broadcast to blockchain")]
        public void SignTransactionTest()
        {
            var manager = new TransactionManager(JosephWif, ChainManager.KnownChains.Steem);
            var voteUp = new VoteOperation()
            {
                Author = "xeroc",
                Voter = JosephName,
                Permlink = "meanwhile-bitcoin-full-ethereum-forked-unintended",
                Weight = 10000
            };
            manager.AddOperation(voteUp);
        }
    }
}