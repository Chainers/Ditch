using System.Linq;
using Cryptography.ECDSA;
using Xunit;
using Xunit.Abstractions;

namespace Ditch.Core.Tests
{
    public class Base58Test : BaseTest
    {
        public Base58Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData("02e649f63f8e8121345fd7f47d0d185a3ccaa843115cd2e9392dcd9b82263bc680", "KwKM6S22ZZDYw5dxBFhaRyFtcuWjaoxqDDfyCcBYSevnjdfm9Cjo")]
        [InlineData("021c7359cd885c0e319924d97e3980206ad64387aff54908241125b3a88b55ca16", "KwHpCk3sLE6VykHymAEyTMRznQ1Uh5ukvFfyDWpGToT7Hf5jzrie")]
        [InlineData("02f561e0b57a552df3fa1df2d87a906b7a9fc33a83d5d15fa68a644ecb0806b49a", "KwKTjyQbKe6mfrtsf4TFMtqAf5as5bSp526s341PQEQvq5ZzEo5W")]
        [InlineData("03e7595c3e6b58f907bee951dc29796f3757307e700ecf3d09307a0cc4a564eba3", "KwMJJgtyBxQ9FEvUCzJmvr8tXxB3zNWhkn14mWMCTGSMt5GwGLgz")]
        [InlineData("02b52e04a0acfe611a4b6963462aca94b6ae02b24e321eda86507661901adb49", "5HqUkGuo62BfcJU5vNhTXKJRXuUi9QSE6jp8C3uBJ2BVHtB8WSd")]
        [InlineData("5b921f7051be5e13e177a0253229903c40493df410ae04f4a450c85568f19131", "5JWcdkhL3w4RkVPcZMdJsjos22yB5cSkPExerktvKnRNZR5gx1S")]
        [InlineData("0e1bfc9024d1f55a7855dc690e45b2e089d2d825a4671a3c3c7e4ea4e74ec00e", "5HvVz6XMx84aC5KaaBbwYrRLvWE46cH6zVnv4827SBPLorg76oq")]
        [InlineData("6e5cc4653d46e690c709ed9e0570a2c75a286ad7c1bc69a648aae6855d919d3e", "5Jete5oFNjjk3aUMkKuxgAXsp7ZyhgJbYNiNjHLvq5xzXkiqw7R")]
        [InlineData("b84abd64d66ee1dd614230ebbe9d9c6d66d78d93927c395196666762e9ad69d8", "5KDT58ksNsVKjYShG4Ls5ZtredybSxzmKec8juj7CojZj6LPRF7")]
        public void Base58CheckDecodeTest(string key, string value)
        {
            var rez = Base58.Base58CheckDecode(value);
            var testrez = Hex.ToString(rez);
            Assert.Equal(key, testrez);
        }

        [Theory]
        [InlineData("02e649f63f8e8121345fd7f47d0d185a3ccaa843115cd2e9392dcd9b82263bc680", "KwKM6S22ZZDYw5dxBFhaRyFtcuWjaoxqDDfyCcBYSevnjdfm9Cjo")]
        [InlineData("021c7359cd885c0e319924d97e3980206ad64387aff54908241125b3a88b55ca16", "KwHpCk3sLE6VykHymAEyTMRznQ1Uh5ukvFfyDWpGToT7Hf5jzrie")]
        [InlineData("02f561e0b57a552df3fa1df2d87a906b7a9fc33a83d5d15fa68a644ecb0806b49a", "KwKTjyQbKe6mfrtsf4TFMtqAf5as5bSp526s341PQEQvq5ZzEo5W")]
        [InlineData("03e7595c3e6b58f907bee951dc29796f3757307e700ecf3d09307a0cc4a564eba3", "KwMJJgtyBxQ9FEvUCzJmvr8tXxB3zNWhkn14mWMCTGSMt5GwGLgz")]
        [InlineData("02b52e04a0acfe611a4b6963462aca94b6ae02b24e321eda86507661901adb49", "5HqUkGuo62BfcJU5vNhTXKJRXuUi9QSE6jp8C3uBJ2BVHtB8WSd")]
        [InlineData("5b921f7051be5e13e177a0253229903c40493df410ae04f4a450c85568f19131", "5JWcdkhL3w4RkVPcZMdJsjos22yB5cSkPExerktvKnRNZR5gx1S")]
        [InlineData("0e1bfc9024d1f55a7855dc690e45b2e089d2d825a4671a3c3c7e4ea4e74ec00e", "5HvVz6XMx84aC5KaaBbwYrRLvWE46cH6zVnv4827SBPLorg76oq")]
        [InlineData("6e5cc4653d46e690c709ed9e0570a2c75a286ad7c1bc69a648aae6855d919d3e", "5Jete5oFNjjk3aUMkKuxgAXsp7ZyhgJbYNiNjHLvq5xzXkiqw7R")]
        [InlineData("b84abd64d66ee1dd614230ebbe9d9c6d66d78d93927c395196666762e9ad69d8", "5KDT58ksNsVKjYShG4Ls5ZtredybSxzmKec8juj7CojZj6LPRF7")]
        public void Base58CheckEncodeTest(string key, string value)
        {
            var bytes = Hex.HexToBytes(key);
            var rez = Base58.Base58CheckEncode(0x80, bytes);
            Assert.Equal(value, rez);
        }

        [Theory]
        [InlineData("5KQwrPbwdL6PhXujxW37FSSQZ1JiwsST4cqQzDeyXtP79zkvFD3", "d2653ff7cbb2d8ff129ac27ef5781ce68b2558c41a74af1f2ddca635cbeef07d")]
        public void Base58HexTest(string key, string value)
        {
            var hex = Base58.DecodePrivateWif(key);
            var sHex = string.Join(string.Empty, hex.Select(i => i.ToString("x2")));
            Assert.Equal(sHex, value);

        }


        [Theory]
        [InlineData("029b458cb5ebb3766fe6bcd993bbf707112a53862d2eb4404c5108d75e4c64560c", "STM", "STM64sZSzJgW9wj44BQG3YyiMY7Z6pDeTNhm4n2xux87iZzVLNXHG")]
        public void EncodePublicWifTest(string key, string prefix, string expected)
        {
            var hex = Hex.HexToBytes(key);
            var wif = Base58.EncodePublicWif(hex, prefix);
            Assert.Equal(expected, wif);
        }

        [Theory]
        [InlineData("STM64sZSzJgW9wj44BQG3YyiMY7Z6pDeTNhm4n2xux87iZzVLNXHG", "STM", "029b458cb5ebb3766fe6bcd993bbf707112a53862d2eb4404c5108d75e4c64560c")]
        public void DecodePublicWifTest(string key, string prefix, string expected)
        {
            var wif = Base58.DecodePublicWif(key, prefix);
            var hex = Hex.ToString(wif);
            Assert.Equal(expected, hex);
        }


        [Theory]
        [InlineData("5JSMFNCV2rciddgrAtNs23Q2iCP7VuhDYFVQ4NppTVT1bzoNtZN", "STM5SLu1JSgYJDPTszgm9xqPDvo3NSRC64gYyirPnQTsDQ38Pg7WC")]
        public void GetPublicKeyTest(string privateKey, string expectedPubKey)
        {
            var pk = Base58.DecodePrivateWif(privateKey);
            var publicKey = Secp256K1Manager.GetPublicKey(pk, true);
            var pWif = Base58.EncodePublicWif(publicKey, "STM");
            Assert.Equal(expectedPubKey, pWif);
        }

        [Fact]
        public void GenerateKeys()
        {
            WriteLine("password key:");
            var privateKey = Secp256K1Manager.GenerateRandomKey();
            var privateWif = "P" + Base58.EncodePrivateWif(privateKey);
            WriteLine(privateWif);
            WriteLine(Hex.ToString(privateKey));

            var publicKey = Secp256K1Manager.GetPublicKey(privateKey, true);
            var encodePublicWif = Base58.EncodePublicWif(publicKey, "STM");
            WriteLine(encodePublicWif);
            WriteLine(Hex.ToString(publicKey));

            const string name = "userlogin";
            string[] roles = { "posting", "active", "owner", "memo" };

            foreach (var role in roles)
            {
                WriteLine(role);
                var subWif = Base58.GetSubWif(name, privateWif, role);
                WriteLine(subWif);
                var pk = Base58.DecodePrivateWif(subWif);
                WriteLine(Hex.ToString(pk));
                var subPublicKey = Secp256K1Manager.GetPublicKey(pk, true);
                var publicWif = Base58.EncodePublicWif(subPublicKey, "STM");
                WriteLine(publicWif);
                WriteLine(Hex.ToString(subPublicKey));
            }
        }
    }
}