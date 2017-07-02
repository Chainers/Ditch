using System;
using Ditch.Responses;
using NUnit.Framework;

namespace Ditch.Tests
{
    [TestFixture]
    public class OperationManagerTest : BaseTest
    {
        private readonly OperationManager _operationManager;
        private const string Name = "login";
        private const string PostingKey = "wif";

        public OperationManagerTest()
        {
            GlobalSettings.Init(Name, PostingKey, ChainManager.KnownChains.Steem);
            _operationManager = new OperationManager();
        }


        [Test]
        public void GetDynamicGlobalPropertiesTest()
        {
            var prop = _operationManager.GetDynamicGlobalProperties();
            Assert.IsTrue(prop != null);
            Assert.IsTrue(prop.Result != null);
            Assert.IsFalse(prop.IsError);
        }

        [Test]
        public void GetContentTest()
        {
            var prop = _operationManager.GetContent("steepshot", "c-lib-ditch-1-0-for-graphene-from-steepshot-team-under-the-mit-license");
            Assert.IsTrue(prop != null);
            Assert.IsTrue(prop.Result != null);
            Assert.IsFalse(prop.IsError);
            Assert.IsTrue(prop.Result.TotalPayoutValue.Value > 0);
        }

        [Test]
        [TestCase("277.126 SBD")]
        public void ParseTestTest(string test)
        {
            var money = new Money(test);
            Assert.IsTrue(Math.Abs(money.Value - 277.126) < 0.00001);
            Assert.IsTrue(money.Currency == "SBD");
        }

        [Test]
        public void GetHelp()
        {
            var ws = new WebSocketManager();
            var rez = ws.GetRequest<object>("help");
            Console.WriteLine(rez.Error);
        }

        [Test]
        [Ignore("make transaction")]
        public void FollowTest()
        {
            var prop = _operationManager.Follow("korzunav");
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        [Ignore("make transaction")]
        public void UnFollowTest()
        {
            var prop = _operationManager.UnFollow("joseph.kalu");
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        [Ignore("make transaction")]
        public void FlagTest()
        {
            var prop = _operationManager.Vote("joseph.kalu", "fkkl", -10000);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        [Ignore("make transaction")]
        [TestCase("steepshot", "testpermlink", "testtitle", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg", "{\"app\": \"steepshot / 0.0.4\", \"tags\": []}")]
        public void PostTest(string parentPermlink, string permlink, string title, string body, string jsonMetadata)
        {
            var prop = _operationManager.AddPost(permlink, title, body, jsonMetadata, parentPermlink);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        [Ignore("make transaction")]
        [TestCase("yanakorsak", "orchids")]
        public void RepostTest(string author, string permlink)
        {
            var prop = _operationManager.RePost(author, permlink);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }
    }
}