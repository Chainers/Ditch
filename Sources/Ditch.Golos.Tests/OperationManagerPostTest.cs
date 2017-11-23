using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.Errors;
using Ditch.Core.JsonRpc;
using Ditch.Golos.Helpers;
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
        private const bool IsVerify = true;

        private JsonRpcResponse Post(List<byte[]> postingKeys, bool isNeedBroadcast, params BaseOperation[] op)
        {
            if (!IsVerify || isNeedBroadcast)
                return Api.BroadcastOperations(postingKeys, CancellationToken.None, op);

            return Api.VerifyAuthority(postingKeys, CancellationToken.None, op);
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
                Assert.IsTrue(isFollow != isFollow2);
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
                Assert.IsTrue(isFollow != isFollow2);
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
                Assert.IsTrue(isFollow != isFollow2);
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
                Assert.IsTrue(isFollow != isFollow2);
            }
        }

        private bool IsFollow(string author)
        {
            var resp = Api.GetFollowing(User.Login, author, FollowType.Blog, 1, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            return resp.Result.Length > 0 && resp.Result[0].Following == author;
        }


        [Test]
        public async Task VoteTest()
        {
            var user = User;
            var autor = "joseph.kalu";
            var permlink = "test-s-russkimi-bukvami-2017-11-16-17-12-05";

            var voteState = GetVoteState(autor, permlink, user);

            for (int i = 0; i < 3; i++)
            {
                var op = voteState < 0
                      ? new VoteOperation(user.Login, autor, permlink, VoteOperation.MaxUpVote)
                      : voteState > 0
                      ? new VoteOperation(user.Login, autor, permlink, VoteOperation.MaxFlagVote)
                      : new VoteOperation(user.Login, autor, permlink, VoteOperation.NoneVote);

                var response = Post(user.PostingKeys, false, op);
                Assert.IsFalse(response.IsError, response.GetErrorMessage());

                if (!IsVerify)
                {
                    await Task.Delay(3000);
                    var voteState2 = GetVoteState(autor, permlink, user);
                    Assert.IsTrue(op.Weight == voteState2);
                }

                if (voteState == 0)
                    voteState = VoteOperation.MaxUpVote;
                else if (voteState > 0)
                    voteState = VoteOperation.MaxFlagVote;
                else
                    voteState = 0;
            }
        }

        private int GetVoteState(string author, string permlink, UserInfo user)
        {
            var resp = Api.GetContent(author, permlink, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            var vote = resp.Result.ActiveVotes.FirstOrDefault(i => i.Voter.Equals(user.Login));
            return vote?.Percent ?? 0;
        }


        [Test]
        public void PostWithBeneficiariesTest()
        {
            var manager = Api;
            var user = User;

            var op = new PostOperation("test", user.Login, "Тест с русскими буквами и бенефитами", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", GetMeta(null));
            var op2 = new BeneficiariesOperation(user.Login, op.Permlink, manager.SbdSymbol, new Beneficiary("steepshot", 1000));

            var response = VersionHelper.GetHardfork(Api.Version) > 16
                ? Post(user.PostingKeys, false, op, op2)
                : Post(user.PostingKeys, false, op);

            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }


        [Ignore("NotSupported")]
        [Test]
        public void DeleteCommentTest()
        {
            var user = User;

            var op = new PostOperation("test", user.Login, "Test post for delete", "Test post for delete", GetMeta(null));
            var response = Post(user.PostingKeys, false, op);
            Console.WriteLine(response.Error);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());


            var op2 = new DeleteCommentOperation(op.Author, op.Permlink);
            response = Post(user.PostingKeys, false, op2);
            Console.WriteLine(response.Error);
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