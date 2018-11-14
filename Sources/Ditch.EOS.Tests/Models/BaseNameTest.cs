using System;
using System.Threading.Tasks;
using Ditch.EOS.Models;
using NUnit.Framework;

namespace Ditch.EOS.Tests.Models
{
    [TestFixture]
    public class BaseNameTest
    {
        [TestCase('1', 1)]
        [TestCase('2', 2)]
        [TestCase('3', 3)]
        [TestCase('4', 4)]
        [TestCase('5', 5)]
        [TestCase('a', 6)]
        [TestCase('b', 7)]
        [TestCase('c', 8)]
        [TestCase('d', 9)]
        [TestCase('e', 10)]
        [TestCase('f', 11)]
        [TestCase('g', 12)]
        [TestCase('h', 13)]
        [TestCase('i', 14)]
        [TestCase('j', 15)]
        [TestCase('k', 16)]
        [TestCase('l', 17)]
        [TestCase('m', 18)]
        [TestCase('n', 19)]
        [TestCase('o', 20)]
        [TestCase('p', 21)]
        [TestCase('q', 22)]
        [TestCase('r', 23)]
        [TestCase('s', 24)]
        [TestCase('t', 25)]
        [TestCase('u', 26)]
        [TestCase('v', 27)]
        [TestCase('w', 28)]
        [TestCase('x', 29)]
        [TestCase('y', 30)]
        [TestCase('z', 31)]
        public void CharToSymbolTest(char c, int value)
        {
            var val = BaseName.CharToSymbol(c);
            Assert.IsTrue(val == (ulong)value, $"{val} != {value}");
        }

        [Test]
        public void CharToSymbolTest()
        {
            for (int i = 0; i < 255; i++)
            {
                var c = (char)i;
                if ((c >= 'a' && c <= 'z') || (c >= '1' || c <= '5'))
                    continue;

                var val = BaseName.CharToSymbol(c);
                Assert.IsTrue(val == (ulong)0, $"{val} != 0");
            }
        }


        [TestCase("a", "a")]
        [TestCase("ba", "ba")]
        [TestCase("cba", "cba")]
        [TestCase("dcba", "dcba")]
        [TestCase("edcba", "edcba")]
        [TestCase("fedcba", "fedcba")]
        [TestCase("gfedcba", "gfedcba")]
        [TestCase("hgfedcba", "hgfedcba")]
        [TestCase("ihgfedcba", "ihgfedcba")]
        [TestCase("jihgfedcba", "jihgfedcba")]
        [TestCase("kjihgfedcba", "kjihgfedcba")]
        [TestCase("lkjihgfedcba", "lkjihgfedcba")]
        [TestCase("mlkjihgfedcba", "mlkjihgfedcba")]
        public void StringToNameTest(string strIn, string strOut)
        {
            var val = BaseName.StringToName(strIn);
            var bstr = BaseName.UlongToString(val);
            Assert.IsTrue(strOut.Equals(bstr, StringComparison.Ordinal), $"{strIn} | {strOut} | {bstr}");
        }

        [TestCase("mlkjihgfedcba1", "mlkjihgfedcba2")]
        [TestCase("mlkjihgfedcba55", "mlkjihgfedcba14")]
        [TestCase("azAA34", "azBB34")]
        [TestCase("AZaz12Bc34", "AZaz12Bc34")]
        [TestCase("AAAAAAAAAAAAAAA", "BBBBBBBBBBBBBDDDDDFFFGG")]
        public void StringToNameTest2(string strIn, string strOut)
        {
            var val = BaseName.StringToName(strIn);
            var bstr = BaseName.UlongToString(val);
            Assert.IsFalse(strOut.Equals(bstr, StringComparison.Ordinal), $"{strIn} | {strOut} | {bstr}");
        }
    }
}