using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ditch.Helpers;
using Ditch.Operations.Enums;
using Ditch.Operations.Post;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Tests
{
    [TestFixture]
    public class OperationManagerPostTest : BaseTest
    {
        private readonly Dictionary<string, string> _login;
        private readonly Dictionary<string, List<byte[]>> _userPrivateKeys;
        private readonly Dictionary<string, ChainInfo> _chain;
        private readonly OperationManager _steem;
        private readonly OperationManager _golos;

        public OperationManagerPostTest()
        {
            _login = new Dictionary<string, string>()
            {
                {"Steem", "UserLogin"},
                {"Golos", "UserLogin"}
            };
            _userPrivateKeys = new Dictionary<string, List<byte[]>>()
            {
                {"Steem", new List<byte[]> {Base58.GetBytes("5**************************************************")}},
                {"Golos", new List<byte[]> {Base58.GetBytes("5**************************************************")}}
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


        [Test]
        public void FollowTest([Values("Steem", "Golos")] string name)
        {
            var op = new FollowOperation(_login[name], "joseph.kalu", FollowType.blog, _login[name]);
            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(_userPrivateKeys[name], op);
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
            //var prop = Manager(name).BroadcastOperations(_userPrivateKeys[name], op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void UpVoteOperationTest([Values("Steem", "Golos")] string name)
        {
            var op = new UpVoteOperation(_login[name], "joseph.kalu", "fkkl");
            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(_userPrivateKeys[name], op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void DownVoteOperationTest([Values("Steem", "Golos")] string name)
        {
            var op = new DownVoteOperation(_login[name], "joseph.kalu", "fkkl");
            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(_userPrivateKeys[name], op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void FlagTest([Values("Steem", "Golos")] string name)
        {
            var op = new FlagOperation(_login[name], "joseph.kalu", "fkkl");
            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(_userPrivateKeys[name], op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public virtual void PostTest([Values("Steem")] string name)
        {
            var op = new PostOperation("test", _login[name], "test post with beneficiares", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg", "{\"app\": \"steepshot / 0.0.4\", \"tags\": []}");
            var popt = new BeneficiariesOperation(_login[name], op.Permlink, _chain[name].SbdSymbol, new Beneficiary("steepshot", 1000));
            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op, popt);
            //var prop = Manager(name).BroadcastOperations(UserPrivateKeys[name], op, popt);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public virtual void RuPostTest([Values("Steem", "Golos")] string name)
        {
            var op = new PostOperation("test", _login[name], "Тест с русскими буквами", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", "{\"app\": \"steepshot / 0.0.4\", \"tags\": []}");

            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(_userPrivateKeys[name], op, popt);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void ReplyTest([Values("Steem", "Golos")] string name)
        {
            var op = new ReplyOperation("steepshot", "Тест с русскими буквами", _login[name], "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", "{\"app\": \"steepshot / 0.0.4\", \"tags\": []}");
            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(_userPrivateKeys[name], op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void RepostTest([Values("Steem", "Golos")] string name)
        {
            var op = new RePostOperation(_login[name], "joseph.kalu", "fkkl", _login[name]);
            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(_userPrivateKeys[name], op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void VerifyAuthoritySuccessTest([Values("Steem", "Golos")] string name)
        {
            var op = new FollowOperation(_login[name], "steepshot", FollowType.blog, _login[name]);
            var resp = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            Assert.IsFalse(resp.IsError, resp.GetErrorMessage());
            Assert.IsTrue(resp.Result);
        }

        [Test]
        public void VerifyAuthorityFallTest([Values("Steem", "Golos")] string name)
        {
            var op = new FollowOperation(_login[name], "steepshot", FollowType.blog, "StubLogin");
            var resp = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            Assert.IsTrue(resp.IsError);
        }






        private void TestPropetries(Type type, JObject jObject)
        {
            var propNames = GetPropertyNames(type);

            var chSet = jObject.Children();

            List<string> msg = new List<string>();
            foreach (var jtoken in chSet)
            {
                if (!propNames.Contains(jtoken.Path))
                {
                    msg.Add($"Missing {jtoken}");
                }
            }

            if (msg.Any())
            {
                Assert.Fail($"Some properties ({msg.Count}) was missed! {Environment.NewLine} {string.Join(Environment.NewLine, msg)}");
            }
        }

        private void TestPropetries(Type type, JObject[] jObject)
        {
            if (jObject == null)
                throw new NullReferenceException("jObject");

            if (type.IsArray)
                TestPropetries(type.GetElementType(), jObject[0]);
            else
                throw new InvalidCastException();
        }

        private HashSet<string> GetPropertyNames(Type type)
        {
            var props = type.GetRuntimeProperties();
            var resp = new HashSet<string>();
            foreach (var prop in props)
            {
                var order = prop.GetCustomAttribute<JsonPropertyAttribute>();
                if (order != null)
                {
                    resp.Add(order.PropertyName);
                }
            }
            return resp;
        }
    }
}