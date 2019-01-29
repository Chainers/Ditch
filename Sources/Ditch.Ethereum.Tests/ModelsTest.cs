using System;
using Ditch.Ethereum.Models;
using NUnit.Framework;

namespace Ditch.Ethereum.Tests
{
    [TestFixture]
    public class ModelsTest
    {
        [Test]
        public void LongToHexLong()
        {
            long t = -1;
            for (int i = 0; i <= 64; i++)
            {
                t++;
                t <<= 1;
                var hl = new HexLong(t);
                Console.WriteLine(hl.ToString());
                var it = hl.Value;
                Assert.IsTrue(t == it, $"{t} != {it}");
            }
        }

        [Test]
        public void DecimalToHexDecimal()
        {
            decimal t = -1;
            for (int i = 0; i < 96; i++)
            {
                t++;
                t *= 2;
                var hl = new HexDecimal(t);
                Console.WriteLine(hl.ToString());
                var it = hl.Value;
                Assert.IsTrue(t == it, $"{t} != {it}");
            }
        }

        [Test]
        public void ArrayToHexDecimal()
        {
            var rand = new Random();

            var buf = new byte[32];
            rand.NextBytes(buf);
            var hl = new HexDecimal(buf, 0, buf.Length);
            var t = hl.Value;
        }
    }
}
