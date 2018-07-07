using System;
using System.IO;
using Cryptography.ECDSA;
using Ditch.Core.Models;
using NUnit.Framework;

namespace Ditch.Core.Tests
{
    [TestFixture]
    public class Uint128Test
    {
        [Test]
        [TestCase("0", "00000000000000000000000000000000")]
        [TestCase("1", "01000000000000000000000000000000")]
        [TestCase("2", "02000000000000000000000000000000")]
        [TestCase("3", "03000000000000000000000000000000")]
        [TestCase("4", "04000000000000000000000000000000")]
        [TestCase("5", "05000000000000000000000000000000")]
        [TestCase("6", "06000000000000000000000000000000")]
        [TestCase("7", "07000000000000000000000000000000")]
        [TestCase("8", "08000000000000000000000000000000")]
        [TestCase("9", "09000000000000000000000000000000")]
        [TestCase("10", "0A000000000000000000000000000000")]
        [TestCase("11", "0B000000000000000000000000000000")]
        [TestCase("12", "0C000000000000000000000000000000")]
        [TestCase("13", "0D000000000000000000000000000000")]
        [TestCase("14", "0E000000000000000000000000000000")]
        [TestCase("15", "0F000000000000000000000000000000")]
        [TestCase("16", "10000000000000000000000000000000")]
        [TestCase("17", "11000000000000000000000000000000")]
        [TestCase("42", "2A000000000000000000000000000000")]
        [TestCase("63", "3F000000000000000000000000000000")]
        [TestCase("64", "40000000000000000000000000000000")]
        [TestCase("65", "41000000000000000000000000000000")]
        [TestCase("127", "7F000000000000000000000000000000")]
        [TestCase("128", "80000000000000000000000000000000")]
        [TestCase("129", "81000000000000000000000000000000")]
        [TestCase("255", "FF000000000000000000000000000000")]
        [TestCase("256", "00010000000000000000000000000000")]
        [TestCase("511", "FF010000000000000000000000000000")]
        [TestCase("512", "00020000000000000000000000000000")]
        [TestCase("513", "01020000000000000000000000000000")]
        [TestCase("1023", "FF030000000000000000000000000000")]
        [TestCase("1024", "00040000000000000000000000000000")]
        [TestCase("1025", "01040000000000000000000000000000")]
        [TestCase("340282366920938463463374607431768211455", "ffffffffffffffffffffffffffffffff")]
        public void SerializationTet(string value, string expect)
        {
            var uint128 = new UInt128(value);
            using (var ms = new MemoryStream())
            {
                uint128.Serializer(ms, null);
                var hex = Hex.ToString(ms.ToArray());
                Assert.IsTrue(expect.Equals(hex, StringComparison.OrdinalIgnoreCase), $"expect {expect} {Environment.NewLine}  was    {hex}");
            }
        }
    }
}
