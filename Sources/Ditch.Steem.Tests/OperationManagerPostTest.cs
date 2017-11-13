using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Ditch.Core.Errors;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Operations.Enums;
using Ditch.Steem.Operations.Post;
using NUnit.Framework;

namespace Ditch.Steem.Tests
{
    [TestFixture]
    public class OperationManagerPostTest : BaseTest
    {
        private readonly Regex _errorMsg = new Regex(@"(?<=[\w\s\(\)&|\.<>=]+:\s+)[a-z\s0-9.]*", RegexOptions.IgnoreCase);
        private const bool IsVerify = true;

        private JsonRpcResponse Post(List<byte[]> postingKeys, bool isNeedBroadcast, params BaseOperation[] op)
        {
            if (!IsVerify || isNeedBroadcast)
                return Api.BroadcastOperations(postingKeys, op);

            return Api.VerifyAuthority(postingKeys, op);
        }

        [Test, Sequential]
        public void FollowTest()
        {
            var user = User;
            var autor = "steepshot";

            var op = new FollowOperation(user.Login, autor, FollowType.blog, user.Login);
            var response = Post(user.PostingKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        [Test, Sequential]
        public void FollowTest2()
        {
            var user = User;
            var autor = "steepshot";

            var fType = new[] { FollowType.blog };
            var op = new FollowOperation(user.Login, autor, fType, user.Login);
            var response = Post(user.PostingKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
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
        [Test, Sequential]
        public void UnFollowTest()
        {
            var user = User;
            var autor = "steepshot";

            var op = new UnfollowOperation(user.Login, autor, user.Login);
            var response = Post(user.PostingKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        [Test, Sequential]
        public void UnFollowTest2()
        {
            var user = User;
            var autor = "steepshot";

            var op = new FollowOperation(user.Login, autor, null, user.Login);
            var response = Post(user.PostingKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        [Test, Sequential]
        public void UpVoteOperationTest()
        {
            var user = User;
            var autor = "joseph.kalu";
            var permlink = "fkkl";

            var op = new UpVoteOperation(user.Login, autor, permlink);
            var response = Post(user.PostingKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        [Test, Sequential]
        public void DownVoteOperationTest()
        {
            var user = User;
            var autor = "joseph.kalu";
            var permlink = "fkkl";

            var op = new DownVoteOperation(user.Login, autor, permlink);
            var response = Post(user.PostingKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        [Test, Sequential]
        public void FlagTest()
        {
            var user = User;
            var autor = "joseph.kalu";
            var permlink = "fkkl";

            var op = new FlagOperation(user.Login, autor, permlink);
            var response = Post(user.PostingKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        [Test, Sequential]
        public void PostTest()
        {
            var manager = Api;
            var user = User;
            var op = new PostOperation("test", user.Login, "test", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg", GetMeta(null));
            var popt = new BeneficiariesOperation(user.Login, op.Permlink, manager.SbdSymbol, new Beneficiary("steepshot", 1000));
            var response = Post(user.PostingKeys, false, op, popt);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        [Test, Sequential]
        public void PostFailByTitleSizeTest()
        {
            var user = User;

            var op = new PostOperation("test", user.Login, new string('t', 666), "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg", GetMeta(new[] { "test", "spam" }));
            var response = Post(user.PostingKeys, true, op);
            Assert.IsTrue(response.IsError);
            Console.WriteLine(response.GetErrorMessage());
            Assert.IsTrue(response.Error is ResponseError);
            var typedError = (ResponseError)response.Error;
            Assert.IsTrue(typedError.Data.Code == 10);
            var match = _errorMsg.Match(typedError.Data.Stack[0].Format);
            Console.WriteLine(match.Value);
            Assert.IsTrue(match.Success);
            Assert.IsTrue(match.Value.Equals("Title larger than size limit"));
        }

        [Test, Sequential]
        public void RuPostTest()
        {
            var user = User;

            var op = new PostOperation("test", user.Login, "Тест с русскими буквами", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", GetMeta(null));
            var response = Post(user.PostingKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        [Test, Sequential]
        public void ReplyTest()
        {
            var user = User;

            var op = new ReplyOperation("steepshot", "Тест с русскими буквами", user.Login, "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", GetMeta(null));
            Assert.IsTrue(ReplyOperation.TimePostfix.IsMatch(op.Permlink));
            var response = Post(user.PostingKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        [Test, Sequential]
        public void RepostTest()
        {
            var user = User;

            var op = new RePostOperation(user.Login, "joseph.kalu", "fkkl", user.Login);
            var response = Post(user.PostingKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        [Test, Sequential]
        public void VerifyAuthoritySuccessTest()
        {
            var user = User;

            var op = new FollowOperation(user.Login, "steepshot", FollowType.blog, user.Login);
            var response = Post(user.PostingKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        [Test, Sequential]
        public void VerifyAuthorityFallTest()
        {
            var user = User;

            var op = new FollowOperation(user.Login, "steepshot", FollowType.blog, "StubLogin");
            var response = Post(user.PostingKeys, false, op);
            Assert.IsTrue(response.IsError);
        }
    }
}