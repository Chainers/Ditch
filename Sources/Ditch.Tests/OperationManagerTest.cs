using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Ditch.Helpers;
using Ditch.Operations.Post;
using NUnit.Framework;

namespace Ditch.Tests
{
    [TestFixture]
    public class OperationManagerTest : BaseTest
    {
        private readonly Dictionary<string, string> _login;
        private readonly Dictionary<string, List<byte[]>> _userPrivateKeys;
        private readonly Dictionary<string, ChainInfo> _chain;
        private readonly OperationManager _steem;
        private readonly OperationManager _golos;

        public OperationManagerTest()
        {
            _login = new Dictionary<string, string>()
            {
                { "Steem","Test Login" },
                { "Golos","Test Login" }
            };
            _userPrivateKeys = new Dictionary<string, List<byte[]>>()
            {
                { "Steem",new List<byte[]>{ Base58.GetBytes("5**************************************************") } },
                { "Golos",new List<byte[]>{ Base58.GetBytes("5**************************************************") } }
            };

            _chain = new Dictionary<string, ChainInfo>();

            var steemChainInfo = ChainManager.GetChainInfo(KnownChains.Steem);
            _chain.Add("Steem", steemChainInfo);
            _steem = new OperationManager(steemChainInfo.Url, steemChainInfo.ChainId);

            var golosChainInfo = ChainManager.GetChainInfo(KnownChains.Golos);
            _chain.Add("Golos", golosChainInfo);
            _golos = new OperationManager(golosChainInfo.Url, golosChainInfo.ChainId);
        }

        private OperationManager Manager(string name)
        {
            switch (name)
            {
                case "Steem":
                    return _steem;
                case "Golos":
                    return _golos;
                default:
                    return null;
            }
        }


        [Test, Sequential]
        public void GetDynamicGlobalPropertiesTest([Values("Steem", "Golos")] string name)
        {
            var prop = Manager(name).GetDynamicGlobalProperties();
            Assert.IsTrue(prop != null);
            Assert.IsTrue(prop.Result != null);
            Assert.IsFalse(prop.IsError);
        }

        [Test]
        public virtual void GetContentTest(
            [Values("Steem", "Golos")] string name,
            [Values("steepshot", "golosmedia")] string author,
            [Values("c-lib-ditch-1-0-for-graphene-from-steepshot-team-under-the-mit-license", "psk38")] string permlink)
        {
            var prop = Manager(name).GetContent(author, permlink);
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
        public void GetHelp([Values("Steem", "Golos")] string name)
        {
            var rez = Manager(name).CustomGetRequest<object>("help");
            Console.WriteLine(rez.Error);
        }

        [Test]
        public void VerifyAuthoritySuccessTest([Values("Steem", "Golos")] string name)
        {
            var op = new FollowOperation(_login[name], "steepshot", FollowType.Blog, _login[name]);
            var rez = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            Assert.IsFalse(rez.IsError, rez.GetErrorMessage());
            Assert.IsTrue(rez.Result);
        }

        [Test]
        public void VerifyAuthorityFallTest([Values("Steem", "Golos")] string name)
        {
            var op = new FollowOperation(_login[name], "steepshot", FollowType.Blog, "StubLogin");
            var rez = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            Assert.IsTrue(rez.IsError);
        }

        [Test]
        public void GetAccountsTest([Values("Steem", "Golos")] string name)
        {
            var rez = Manager(name).GetAccounts(_login[name]);
            Assert.IsFalse(rez.IsError, rez.GetErrorMessage());
        }

        [Test]
        public void GetChainPropertiesHelp([Values("Steem", "Golos")] string name)
        {
            var rez = Manager(name).CustomGetRequest<object>("get_chain_properties");
            Console.WriteLine(rez.Error);
        }

        [Test]
        public void FollowTest([Values("Steem", "Golos")] string name)
        {
            var op = new FollowOperation(_login[name], "joseph.kalu", FollowType.Blog | FollowType.Posts, _login[name]);
            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(op);
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
        public void UnFollowTest([Values("Steem", "Golos")] string name)
        {
            var op = new UnfollowOperation(_login[name], "joseph.kalu", _login[name]);
            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void UpVoteOperationTest([Values("Steem", "Golos")] string name)
        {
            var op = new UpVoteOperation(_login[name], "joseph.kalu", "fkkl");
            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void DownVoteOperationTest([Values("Steem", "Golos")] string name)
        {
            var op = new DownVoteOperation(_login[name], "joseph.kalu", "fkkl");
            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void FlagTest([Values("Steem", "Golos")] string name)
        {
            var op = new FlagOperation(_login[name], "joseph.kalu", "fkkl");
            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public virtual void PostTest([Values("Steem")] string name)
        {
            var op = new PostOperation("test", _login[name], "testpostwithbeneficiares", "test post with beneficiares", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg", "{\"app\": \"steepshot / 0.0.4\", \"tags\": []}");
            var popt = new BeneficiariesOperation(_login[name], "testpostwithbeneficiares", _chain[name].SbdSymbol, new Beneficiary("steepshot", 1000));
            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op, popt);
            //var prop = Manager(name).BroadcastOperations(UserPrivateKeys[name], op, popt);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public virtual void RuPostTest([Values("Steem", "Golos")] string name)
        {
            var op = new PostOperation("test", _login[name], "Тест с русскими буквами", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", "{\"app\": \"steepshot / 0.0.4\", \"tags\": []}");

            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(op, popt);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void ReplyTest([Values("Steem", "Golos")] string name)
        {
            var op = new ReplyOperation("steepshot", "Тест с русскими буквами", _login[name], "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", "{\"app\": \"steepshot / 0.0.4\", \"tags\": []}");
            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void RepostTest([Values("Steem", "Golos")] string name)
        {
            var op = new RePostOperation(_login[name], "joseph.kalu", "fkkl", _login[name]);
            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void GetFollowersTest([Values("Steem", "Golos")] string name)
        {
            ushort count = 3;
            var resp = Manager(name).GetFollowers(_login[name], string.Empty, FollowType.Blog, count);
            Assert.IsFalse(resp.IsError);
            Assert.IsTrue(resp.Result.Count <= count);
            var respNext = Manager(name).GetFollowers(_login[name], resp.Result.Last().Follower, FollowType.Blog, count);
            Assert.IsFalse(respNext.IsError);
            Assert.IsTrue(respNext.Result.Count <= count);
            Assert.IsTrue(respNext.Result.First().Follower == resp.Result.Last().Follower);
        }

        [Test]
        public void GetFollowingTest([Values("Steem", "Golos")] string name)
        {
            ushort count = 3;
            var resp = Manager(name).GetFollowing(_login[name], string.Empty, FollowType.Blog, count);
            Assert.IsFalse(resp.IsError);
            Assert.IsTrue(resp.Result.Count <= count);
            var respNext = Manager(name).GetFollowing(_login[name], resp.Result.Last().Following, FollowType.Blog, count);
            Assert.IsFalse(respNext.IsError);
            Assert.IsTrue(respNext.Result.Count <= count);
            Assert.IsTrue(respNext.Result.First().Following == resp.Result.Last().Following);
        }

        [Test]
        public void GetDiscussionsByAuthorBeforeDateTest([Values("Steem", "Golos")] string name)
        {
            ushort count = 3;
            var dt = new DateTime(2017, 7, 1);
            var resp = Manager(name).GetDiscussionsByAuthorBeforeDate(_login[name], string.Empty, dt, count);
            Assert.IsFalse(resp.IsError);
            Assert.IsTrue(resp.Result.Count <= count);
            var respNext = Manager(name).GetDiscussionsByAuthorBeforeDate(_login[name], resp.Result[count - 1].Permlink, dt, count);
            Assert.IsFalse(respNext.IsError);
            Assert.IsTrue(respNext.Result.Count <= count);
            Assert.IsTrue(respNext.Result[0].Permlink == resp.Result[count - 1].Permlink);
        }
    }
}