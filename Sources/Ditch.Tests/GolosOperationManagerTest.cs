using System.Collections.Generic;
using Ditch.Helpers;
using Ditch.Operations.Post;
using NUnit.Framework;

namespace Ditch.Tests
{
    [TestFixture]
    public class GolosOperationManagerTest : SteemOperationManagerTest
    {
        private const string Login = "login";
        private const string PostingKey = "wif";
        
        [SetUp]
        public virtual void SetUp()
        {
            if (OperationManager == null)
            {
                Assert.IsFalse(string.IsNullOrEmpty(Login) || Login.Equals("login"), "Please setup login before start!");
                Assert.IsFalse(string.IsNullOrEmpty(PostingKey) || PostingKey.Equals("wif"), "Please setup user private posting key before start!");
                Chain = ChainManager.GetChainInfo(KnownChains.Golos);
                OperationManager = new OperationManager(Chain.Url, Chain.ChainId, Chain.JsonSerializerSettings);
                userPrivateKeys = new List<byte[]>
                {
                    Base58.GetBytes(PostingKey)
                };
            }
        }


        [Test]
        [TestCase("golosmedia", "psk38")]
        public override void GetContentTest(string author, string permlink)
        {
            base.GetContentTest(author, permlink);
        }

        [Test]
        [TestCase("steepshot", "testpostwithbeneficiares", "test post with beneficiares", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg", "{\"app\": \"steepshot / 0.0.4\", \"tags\": []}")]
        public override void PostTest(string beneficiar, string permlink, string title, string body, string jsonMetadata)
        {
            var op = new PostOperation("test", Login, permlink, title, body, jsonMetadata);
            //var popt = new BeneficiariesOperation(GlobalSettings.Login, permlink, GlobalSettings.ChainInfo.SbdSymbol, new Beneficiary(beneficiar, 1000));
            var prop = OperationManager.VerifyAuthority(userPrivateKeys, op);
            //var prop = OperationManager.VerifyAuthority(op, popt);
            //var prop = OperationManager.BroadcastOperations(op, popt);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        [TestCase("steepshot", "rutestpostwithbeneficiares", "test post with beneficiares and ru text", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", "{\"app\": \"steepshot / 0.0.4\", \"tags\": []}")]
        public override void RuPostTest(string beneficiar, string permlink, string title, string body, string jsonMetadata)
        {
            var op = new PostOperation("test", Login, permlink, title, body, jsonMetadata);
            //var popt = new BeneficiariesOperation(GlobalSettings.Login, permlink, GlobalSettings.ChainInfo.SbdSymbol, new Beneficiary(beneficiar, 1000));
            var prop = OperationManager.VerifyAuthority(userPrivateKeys, op);
            //var prop = OperationManager.VerifyAuthority(op, popt);
            //var prop = OperationManager.BroadcastOperations(op, popt);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }
    }
}