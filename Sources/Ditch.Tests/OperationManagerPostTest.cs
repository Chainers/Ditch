using System;
using Ditch.Operations.Enums;
using Ditch.Operations.Post;
using NUnit.Framework;

namespace Ditch.Tests
{
    [TestFixture]
    public class OperationManagerPostTest : BaseTest
    {
        [Test]
        public void FollowTest([Values("Steem", "Golos")] string name)
        {
            var op = new FollowOperation(Login[name], "joseph.kalu", FollowType.blog, Login[name]);
            var prop = Manager(name).VerifyAuthority(UserPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(UserPrivateKeys[name], op);
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
            var op = new UnfollowOperation(Login[name], "joseph.kalu", Login[name]);
            var prop = Manager(name).VerifyAuthority(UserPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(UserPrivateKeys[name], op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void UpVoteOperationTest([Values("Steem", "Golos")] string name)
        {
            var op = new UpVoteOperation(Login[name], "joseph.kalu", "fkkl");
            var prop = Manager(name).VerifyAuthority(UserPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(UserPrivateKeys[name], op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void DownVoteOperationTest([Values("Steem", "Golos")] string name)
        {
            var op = new DownVoteOperation(Login[name], "joseph.kalu", "fkkl");
            var prop = Manager(name).VerifyAuthority(UserPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(UserPrivateKeys[name], op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void FlagTest([Values("Steem", "Golos")] string name)
        {
            var op = new FlagOperation(Login[name], "joseph.kalu", "fkkl");
            var prop = Manager(name).VerifyAuthority(UserPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(UserPrivateKeys[name], op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public virtual void PostTest([Values("Steem")] string name)
        {
            var op = new PostOperation("steepshot", Login[name], "test", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg", "{\"app\": \"steepshot / 0.0.4\", \"tags\": []}");
            var popt = new BeneficiariesOperation(Login[name], op.Permlink, Chain[name].SbdSymbol, new Beneficiary("steepshot", 1000));
            var prop = Manager(name).VerifyAuthority(UserPrivateKeys[name], op, popt);
            //var prop = Manager(name).BroadcastOperations(UserPrivateKeys[name], op, popt);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public virtual void RuPostTest([Values("Steem", "Golos")] string name)
        {
            var op = new PostOperation("test", Login[name], "Тест с русскими буквами", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", "{\"app\": \"steepshot / 0.0.4\", \"tags\": []}");

            var prop = Manager(name).VerifyAuthority(UserPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(UserPrivateKeys[name], op, popt);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void ReplyTest([Values("Steem", "Golos")] string name)
        {
            var op = new ReplyOperation("steepshot", "Тест с русскими буквами", Login[name], "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", "{\"app\": \"steepshot / 0.0.4\", \"tags\": []}");
            Assert.IsTrue(ReplyOperation.TimePostfix.IsMatch(op.Permlink));
            var prop = Manager(name).VerifyAuthority(UserPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(UserPrivateKeys[name], op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void RepostTest([Values("Steem", "Golos")] string name)
        {
            var op = new RePostOperation(Login[name], "joseph.kalu", "fkkl", Login[name]);
            var prop = Manager(name).VerifyAuthority(UserPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(UserPrivateKeys[name], op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void VerifyAuthoritySuccessTest([Values("Steem", "Golos")] string name)
        {
            var op = new FollowOperation(Login[name], "steepshot", FollowType.blog, Login[name]);
            var resp = Manager(name).VerifyAuthority(UserPrivateKeys[name], op);
            Assert.IsFalse(resp.IsError, resp.GetErrorMessage());
            Assert.IsTrue(resp.Result);
        }

        [Test]
        public void VerifyAuthorityFallTest([Values("Steem", "Golos")] string name)
        {
            var op = new FollowOperation(Login[name], "steepshot", FollowType.blog, "StubLogin");
            var resp = Manager(name).VerifyAuthority(UserPrivateKeys[name], op);
            Assert.IsTrue(resp.IsError);
        }
    }
}