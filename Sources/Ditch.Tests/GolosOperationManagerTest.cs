using Ditch.Operations.Post;
using NUnit.Framework;

namespace Ditch.Tests
{
    [TestFixture]
    public class GolosOperationManagerTest : SteemOperationManagerTest
    {
        private const string Name = "login";
        private const string PostingKey = "wif";

        [SetUp]
        public override void SetUp()
        {
            if (OperationManager == null)
            {
                Assert.IsFalse(string.IsNullOrEmpty(Name) || Name.Equals("login"), "Please setup login before start!");
                Assert.IsFalse(string.IsNullOrEmpty(PostingKey) || PostingKey.Equals("wif"), "Please setup user private posting key before start!");

                GlobalSettings.Init(Name, PostingKey, KnownChains.Golos);
                OperationManager = new OperationManager();
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
            var op = new PostOperation("test", GlobalSettings.Login, permlink, title, body, jsonMetadata);
            //var popt = new BeneficiariesOperation(GlobalSettings.Login, permlink, GlobalSettings.ChainInfo.SbdSymbol, new Beneficiary(beneficiar, 1000));
            var prop = OperationManager.VerifyAuthority(op);
            //var prop = OperationManager.VerifyAuthority(op, popt);
            //var prop = OperationManager.BroadcastOperations(op, popt);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        [TestCase("steepshot", "rutestpostwithbeneficiares", "test post with beneficiares and ru text", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", "{\"app\": \"steepshot / 0.0.4\", \"tags\": []}")]
        public override void RuPostTest(string beneficiar, string permlink, string title, string body, string jsonMetadata)
        {
            var op = new PostOperation("test", GlobalSettings.Login, permlink, title, body, jsonMetadata);
            //var popt = new BeneficiariesOperation(GlobalSettings.Login, permlink, GlobalSettings.ChainInfo.SbdSymbol, new Beneficiary(beneficiar, 1000));
            var prop = OperationManager.VerifyAuthority(op);
            //var prop = OperationManager.VerifyAuthority(op, popt);
            //var prop = OperationManager.BroadcastOperations(op, popt);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }
    }
}