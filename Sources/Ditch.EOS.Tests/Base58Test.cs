using System;
using Cryptography.ECDSA;
using NUnit.Framework;

namespace Ditch.EOS.Tests
{
    public class Base58Test
    {
        [Test]
        [TestCase("1f51e63a5068bd9ec2955a071653526a2f16624b260d3a8b25d2d82f615fc0103e1bba7e3a28608727d6abde73e9af3a0a57b8892d5e572ac8b9289970dd0f2841",
            "SIG_K1_K5yET3oNUar9q9ULajJg81BGSJL2PLBVTqikXiisw94Q9hVrfnbp85Eod8jYU6WdMNfLxmPPNDEbNYddhxeAS4NDSRxbQw")]
        public void EncodePrivateWifTest(string privateKey, string expected)
        {
            var bk = Hex.HexToBytes(privateKey);
            var pk = Base58.EncodeSig(bk);
            Console.WriteLine(pk);
            Assert.IsTrue(pk.Equals(expected));
        }
    }
}