using System;
using Cryptography.ECDSA;
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
                Console.WriteLine($"{hl} | {Hex.ToString(hl.Bytes)}");
                var it = hl.Value;
                Assert.IsTrue(t == it, $"{t} != {it}");
            }
        }

        [Test]
        public void ArrayToHexDecimal()
        {
            var rand = new Random();

            var buf = new byte[12];
            rand.NextBytes(buf);
            var hl = new HexDecimal(buf, 0, buf.Length);
            var t = hl.Value;
        }

        [Test]
        public void ArrayToHexDecimalInvalidCast()
        {
            var rand = new Random();

            var buf = new byte[32];
            rand.NextBytes(buf);
            try
            {
                var hl = new HexDecimal(buf, 0, buf.Length);
            }
            catch (InvalidCastException e)
            {
                Assert.Pass(e.Message);
                return;
            }
            Assert.Fail("expected exception");
        }


        [Test]
        public void DateTimeToHexTimeStampCast()
        {
            var dt = DateTime.Now;
            var hl = new HexTimeStamp(dt);
            Assert.IsTrue(dt == hl.Value, $"{dt} != {hl.Value}");
        }
    }
}
