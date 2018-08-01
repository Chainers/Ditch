using System;
using Cryptography.ECDSA;
using NUnit.Framework;

namespace Ditch.EOS.Tests
{
    [TestFixture]
    public class KeyGenerator
    {
        [Test]
        public void GenerateKeys()
        {
            var pk = Secp256K1Manager.GenerateRandomKey();
            var privateWif = Base58.EncodePrivateWif(pk);
            Console.WriteLine($"private owner: {privateWif}");
            var pubKey = Secp256K1Manager.GetPublicKey(pk, true);
            var publicWif = Base58.EncodePublicWif(pubKey, "EOS");
            Console.WriteLine($"public owner: {publicWif}");

            pk = Secp256K1Manager.GenerateRandomKey();
            privateWif = Base58.EncodePrivateWif(pk);
            Console.WriteLine($"private active: {privateWif}");
            pubKey = Secp256K1Manager.GetPublicKey(pk, true);
            publicWif = Base58.EncodePublicWif(pubKey, "EOS");
            Console.WriteLine($"public active: {publicWif}");
        }
    }
}
