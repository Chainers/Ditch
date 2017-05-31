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
        [TestCase((ushort)42584, (uint)3436728375, "2017-05-18T11:51:56", "testName", "timsaid", "myth-or-fact-17-cockroaches-can-survive-a-nuclear-catastrophe", (ushort)1000, TestWif, "200543831ba7558a8c21e3e7b60e61d4c72cd864eee1024c545a18cd8474e539744844b6ef064b53abb9ba55e29cec2da2b16c2e8cc01c2043e0e9f5fecf6c23de")]
        [TestCase((ushort)34294, (uint)3707022213, "2016-04-06T08:29:27", "foobara", "foobarc", "foobard", (ushort)1000, TestWif, "204336a7eb661cee8dae80f7442a52c5390b758616641349c4f86a550015102cf3535d7a3020775374914c5e18948a605f0d08bc13cfc24a194d3f5244e02215c7")]
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
            var curve = new Secp256K1();
            var key = new Base58(wif);
            var sig = curve.Sign(msg, key);

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