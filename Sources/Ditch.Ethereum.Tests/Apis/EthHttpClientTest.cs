using System;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Ethereum.Models;
using NUnit.Framework;

namespace Ditch.Ethereum.Tests.Apis
{
    [TestFixture]
    public class EthHttpClientTest : BaseTest
    {
        [Test]
        [Parallelizable]
        public async Task eth_blockNumber()
        {
            var resp = await Api.BlockNumberAsync(CancellationToken.None)
                .ConfigureAwait(false);
            Console.WriteLine(resp.Result);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        [TestCase(46147)]
        [TestCase(46169)]
        [TestCase(47205)]
        [TestCase(6040059)]
        public async Task eth_getBlockByNumber(long blockNum)
        {
            var resp = await Api.GetBlockByNumberAsync(blockNum, true, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        [TestCase("0xbb3a336e3f823ec18197f1e13ee875700f08f03e2cab75f0d0b118dabb44cba0")]
        [TestCase("0x31ded263506ea36e6ea777efc2c39a999e6fba4f4d338c7313af6aac6d9bf3e3")]
        [TestCase("0xd327b2bfc0e703e3bc12e5b3f6272eaac2a7d6004a35688469d0e8d406b79483")]
        public async Task eth_getTransactionReceipt(string hash)
        {
            var resp = await Api.GetTransactionReceipt(new HexValue(hash), CancellationToken.None)
                .ConfigureAwait(false);
            TestPropetries(resp);
        }
    }
}
