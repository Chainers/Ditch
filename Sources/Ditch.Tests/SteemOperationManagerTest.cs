using System;
using System.Collections.Generic;
using System.Globalization;
using Ditch.Helpers;
using Ditch.Operations.Post;
using NUnit.Framework;

namespace Ditch.Tests
{
    [TestFixture]
    public class SteemOperationManagerTest : BaseTest
    {
        private const string Login = "login";
        private const string WIF = "wif";
        protected OperationManager OperationManager;
        protected ChainInfo Chain;

        protected List<byte[]> userPrivateKeys;

        [SetUp]
        public virtual void SetUp()
        {
            if (OperationManager == null)
            {
                Assert.IsFalse(string.IsNullOrEmpty(Login) || Login.Equals("login"), "Please setup login before start!");
                Assert.IsFalse(string.IsNullOrEmpty(WIF) || WIF.Equals("wif"), "Please setup user private posting key before start!");
                Chain = ChainManager.GetChainInfo(KnownChains.Steem);
                OperationManager = new OperationManager(Chain.Url, Chain.ChainId, Chain.JsonSerializerSettings);
                userPrivateKeys = new List<byte[]>
                {
                    Base58.GetBytes(WIF)
                };
            }
        }


        [Test]
        public void GetDynamicGlobalPropertiesTest()
        {
            var prop = OperationManager.GetDynamicGlobalProperties();
            Assert.IsTrue(prop != null);
            Assert.IsTrue(prop.Result != null);
            Assert.IsFalse(prop.IsError);
        }

        [Test]
        [TestCase("steepshot", "c-lib-ditch-1-0-for-graphene-from-steepshot-team-under-the-mit-license")]
        public virtual void GetContentTest(string author, string permlink)
        {
            var prop = OperationManager.GetContent(author, permlink);
            Assert.IsTrue(prop != null);
            Assert.IsTrue(prop.Result != null);
            Assert.IsFalse(prop.IsError);
        }

        [Test]
        [TestCase("277.126 SBD")]
        public void ParseTestTest(string test)
        {
            var money = new Money(test, CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator, CultureInfo.InvariantCulture.NumberFormat.NumberGroupSeparator);
            Assert.IsTrue(money.Value == 277126);
            Assert.IsTrue(money.Precision == 3);
            Assert.IsTrue(money.Currency == "SBD");
        }

        [Test]
        public void GetHelp()
        {
            var rez = OperationManager.CustomGetRequest<object>("help");
            Console.WriteLine(rez.Error);
        }

        [Test]
        public void VerifyAuthoritySuccessTest()
        {
            var op = new FollowOperation(Login, "steepshot", FollowType.Blog, Login);
            var rez = OperationManager.VerifyAuthority(userPrivateKeys, op);
            Assert.IsFalse(rez.IsError, rez.GetErrorMessage());
            Assert.IsTrue(rez.Result);
        }

        [Test]
        public void VerifyAuthorityFallTest()
        {
            var op = new FollowOperation(Login, "steepshot", FollowType.Blog, "StubLogin");
            var rez = OperationManager.VerifyAuthority(userPrivateKeys, op);
            Assert.IsTrue(rez.IsError);
        }

        [Test]
        public void GetAccountsTest()
        {
            var rez = OperationManager.GetAccounts(Login);
            Assert.IsFalse(rez.IsError, rez.GetErrorMessage());
        }

        [Test]
        public void GetChainPropertiesHelp()
        {
            var rez = OperationManager.CustomGetRequest<object>("get_chain_properties");
            Console.WriteLine(rez.Error);
        }

        [Test]
        public void FollowTest()
        {
            var op = new FollowOperation(Login, "joseph.kalu", FollowType.Blog | FollowType.Posts, Login);
            var prop = OperationManager.VerifyAuthority(userPrivateKeys, op);
            //var prop = OperationManager.BroadcastOperations(op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        /// <summary>
        /// "params": [
        ///     3,
        ///     "broadcast_transaction",
        ///     [
        ///         {
        ///             "ref_block_num": 7663,
        ///             "ref_block_prefix": 66978938,
        ///             "expiration": "2017-07-06T09:42:45",
        ///             "operations": [
        ///                 [
        ///                     "custom_json",
        ///                     {
        ///                         "required_auths": [],
        ///                         "required_posting_auths": [
        ///                             "joseph.kalu"
        ///                         ],
        ///                         "id": "follow",
        ///                         "json": "[\"follow\", {\"follower\": \"joseph.kalu\", \"following\": \"joseph.kalu\", \"what\": [\"\"]}]"
        ///                     }
        ///                 ]
        ///             ],
        ///             "extensions": [],
        ///             "signatures": ["**********************************************************************************************************************************"
        ///             ]
        ///         }
        ///     ]
        /// ],
        /// </summary>
        [Test]
        public void UnFollowTest()
        {
            var op = new UnfollowOperation(Login, "joseph.kalu", Login);
            var prop = OperationManager.VerifyAuthority(userPrivateKeys, op);
            //var prop = OperationManager.BroadcastOperations(op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void UpVoteOperationTest()
        {
            var op = new UpVoteOperation(Login, "joseph.kalu", "fkkl");
            var prop = OperationManager.VerifyAuthority(userPrivateKeys, op);
            //var prop = OperationManager.BroadcastOperations(op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void DownVoteOperationTest()
        {
            var op = new DownVoteOperation(Login, "joseph.kalu", "fkkl");
            var prop = OperationManager.VerifyAuthority(userPrivateKeys, op);
            //var prop = OperationManager.BroadcastOperations(op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void FlagTest()
        {
            var op = new FlagOperation(Login, "joseph.kalu", "fkkl");
            var prop = OperationManager.VerifyAuthority(userPrivateKeys, op);
            //var prop = OperationManager.BroadcastOperations(op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        [TestCase("steepshot", "testpostwithbeneficiares", "test post with beneficiares", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg", "{\"app\": \"steepshot / 0.0.4\", \"tags\": []}")]
        public virtual void PostTest(string beneficiar, string permlink, string title, string body, string jsonMetadata)
        {
            var op = new PostOperation("test", Login, permlink, title, body, jsonMetadata);
            var popt = new BeneficiariesOperation(Login, permlink, Chain.SbdSymbol, new Beneficiary(beneficiar, 1000));
            var prop = OperationManager.VerifyAuthority(userPrivateKeys, op, popt);
            //var prop = OperationManager.BroadcastOperations(op, popt);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        [TestCase("parentAuthorTest", "parentPermlinkTest", "bodytest", "{\"app\": \"steepshot / 0.0.4\", \"tags\": []}")]
        public void ReplyTest(string parentAuthor, string parentPermlink, string body, string jsonMetadata)
        {
            var op = new ReplyOperation(parentAuthor, parentPermlink, Login, body, jsonMetadata);
            var prop = OperationManager.VerifyAuthority(userPrivateKeys, op);
            //var prop = OperationManager.BroadcastOperations(op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        [TestCase("steepshot", "rutestpostwithbeneficiares", "test post with beneficiares and ru text", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", "{\"app\": \"steepshot / 0.0.4\", \"tags\": []}")]
        public virtual void RuPostTest(string beneficiar, string permlink, string title, string body, string jsonMetadata)
        {
            var op = new PostOperation("test", Login, permlink, title, body, jsonMetadata);
            var popt = new BeneficiariesOperation(Login, permlink, Chain.SbdSymbol, new Beneficiary(beneficiar, 1000));
            var prop = OperationManager.VerifyAuthority(userPrivateKeys, op, popt);
            //var prop = OperationManager.BroadcastOperations(op, popt);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        [TestCase("joseph.kalu", "fkkl")]
        public void RepostTest(string author, string permlink)
        {
            var op = new RePostOperation(Login, author, permlink, Login);
            var prop = OperationManager.VerifyAuthority(userPrivateKeys, op);
            //var prop = OperationManager.BroadcastOperations(op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }
    }
}