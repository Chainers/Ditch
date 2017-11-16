using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ditch.Core.Errors;
using Ditch.Core.JsonRpc;
using Ditch.Golos.Operations.Enums;
using Ditch.Golos.Operations.Post;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Ditch.Golos.Tests
{
    [TestFixture]
    public class OperationManagerPostTest : BaseTest
    {
        private readonly Regex _errorMsg = new Regex(@"(?<=[\w\s\(\)&|\.<>=]+:\s+)[a-z\s0-9.]*", RegexOptions.IgnoreCase);
        private const bool IsVerify = false;

        private JsonRpcResponse Post(List<byte[]> postingKeys, bool isNeedBroadcast, params BaseOperation[] op)
        {
            if (!IsVerify || isNeedBroadcast)
                return Api.BroadcastOperations(postingKeys, op);

            return Api.VerifyAuthority(postingKeys, op);
        }

        [Test]
        public async Task FollowUnfollowTest()
        {
            var user = User;
            var autor = "steepshot";


            var isFollow = IsFollow(autor);

            var op = isFollow
                ? new UnfollowOperation(user.Login, autor, user.Login)
                : new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            var response = Post(user.PostingKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());

            if (!IsVerify)
            {
                await Task.Delay(500);
                var isFollow2 = IsFollow(autor);
                Assert.IsTrue(IsVerify | isFollow != isFollow2);
            }
            isFollow = !isFollow;

            op = isFollow
                ? new UnfollowOperation(user.Login, autor, user.Login)
                : new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            response = Post(user.PostingKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());

            if (!IsVerify)
            {
                await Task.Delay(500);
                var isFollow2 = IsFollow(autor);
                Assert.IsTrue(IsVerify | isFollow != isFollow2);
            }
            isFollow = !isFollow;

            var fType = isFollow ? new FollowType[0] : new[] { FollowType.Blog };
            op = new FollowOperation(user.Login, autor, fType, user.Login);
            response = Post(user.PostingKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());

            if (!IsVerify)
            {
                await Task.Delay(500);
                var isFollow2 = IsFollow(autor);
                Assert.IsTrue(IsVerify | isFollow != isFollow2);
            }
            isFollow = !isFollow;

            fType = isFollow ? new FollowType[0] : new[] { FollowType.Blog };
            op = new FollowOperation(user.Login, autor, fType, user.Login);
            response = Post(user.PostingKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());

            if (!IsVerify)
            {
                await Task.Delay(500);
                var isFollow2 = IsFollow(autor);
                Assert.IsTrue(IsVerify | isFollow != isFollow2);
            }
        }

        private bool IsFollow(string autor)
        {
            var resp = Api.GetFollowing(User.Login, autor, FollowType.Blog, 1);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            return resp.Result.Length > 0 && resp.Result[0].Following == autor;
        }


        [Test]
        public void UpVoteOperationTest()
        {
            var user = User;
            var autor = "joseph.kalu";
            var permlink = "test-s-russkimi-bukvami-2017-11-16-17-12-05";

            var op = new VoteOperation(user.Login, autor, permlink, VoteOperation.MaxUpVote);
            var response = Post(user.PostingKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        [Test]
        public void DownVoteOperationTest()
        {
            var user = User;
            var autor = "joseph.kalu";
            var permlink = "normal-2017-11-08-12-27-30";

            var op = new VoteOperation(user.Login, autor, permlink, VoteOperation.NoneVote);
            var response = Post(user.PostingKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        [Test]
        public void FlagTest()
        {
            var user = User;
            var autor = "joseph.kalu";
            var permlink = "normal-2017-11-08-12-27-30";

            var op = new VoteOperation(user.Login, autor, permlink, VoteOperation.MaxFlagVote);
            var response = Post(user.PostingKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        [Test]
        public void PostTest()
        {
            var manager = Api;
            var user = User;
            var op = new PostOperation("test", user.Login, "test with beneficiarie", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg", GetMeta(null));
            var op2 = new BeneficiariesOperation(user.Login, op.Permlink, manager.SbdSymbol, new Beneficiary("steepshot", 1000));
            var response = Post(user.PostingKeys, false, op, op2);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        [Test]
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

        [Test]
        public void RuPostTest()
        {
            var user = User;

            var op = new PostOperation("test", user.Login, "Тест с русскими буквами", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", GetMeta(null));
            var response = Post(user.PostingKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        [Test]
        public void ReplyTest()
        {
            var user = User;

            var op = new ReplyOperation("steepshot", "Тест с русскими буквами", user.Login, "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", GetMeta(null));
            Assert.IsTrue(ReplyOperation.TimePostfix.IsMatch(op.Permlink));
            var response = Post(user.PostingKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        [Test]
        public void RepostTest()
        {
            var user = User;

            var op = new RePostOperation(user.Login, "joseph.kalu", "fkkl", user.Login);
            var response = Post(user.PostingKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        [Test]
        public void VerifyAuthoritySuccessTest()
        {
            var user = User;

            var op = new FollowOperation(user.Login, "steepshot", FollowType.Blog, user.Login);
            var response = Post(user.PostingKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        [Test]
        public void VerifyAuthorityFallTest()
        {
            var user = User;

            var op = new FollowOperation(user.Login, "steepshot", FollowType.Blog, "StubLogin");
            var response = Post(user.PostingKeys, false, op);
            Assert.IsTrue(response.IsError);
        }
    }
}