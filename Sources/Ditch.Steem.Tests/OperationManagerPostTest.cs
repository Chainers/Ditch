using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.Errors;
using Ditch.Core.Helpers;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Models.Enums;
using Ditch.Steem.Operations;
using Newtonsoft.Json;
using NUnit.Framework;
using Ditch.Steem.Models.Objects;
using Ditch.Steem.Models;
using Ditch.Steem.Models.Args;

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
                await Task.Delay(1000);
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
                await Task.Delay(1000);
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
                await Task.Delay(1000);
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
                await Task.Delay(1000);
                var isFollow2 = IsFollow(autor);
                Assert.IsTrue(IsVerify | isFollow != isFollow2);
            }
        }

        private bool IsFollow(string autor)
        {
            var args = new GetFollowingArgs()
            {
                Account = User.Login,
                Start = autor,
                Limit = 1,
                Type = FollowType.Blog
            };
            var resp = Api.GetFollowing(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            return resp.Result.Following.Length > 0 && resp.Result.Following[0].Following == autor;
        }

        [Test]
        public async Task VoteTest()
        {
            var user = User;
            var autor = "joseph.kalu";
            var permlink = "fkkl";

            var voteState = GetVoteState(autor, permlink, user);

            for (var i = 0; i < 3; i++)
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
        public void PostTest()
        {
            var manager = Api;
            var user = User;
            var op = new PostOperation("test", user.Login, "test", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg", GetMeta(null));
            var popt = new BeneficiariesOperation(user.Login, op.Permlink, new Beneficiary("steepshot", 1000));
            var response = Post(user.PostingKeys, false, op, popt);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

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
            Assert.IsTrue(OperationHelper.TimePostfix.IsMatch(op.Permlink));
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

        [Test]
        public async Task AccountUpdateTest()
        {
            var resp = Api.LookupAccountNames(new[] { User.Login }, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var acc = resp.Result[0];

            var op = new AccountUpdateOperation(User.Login, acc.MemoKey, acc.JsonMetadata);
            var response = Post(User.ActiveKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        [Test]
        public async Task TransferOperationTest()
        {
            var op = new TransferOperation(User.Login, User.Login, new Asset(1, Config.STEEM_ASSET_NUM_SBD), "ditch test transfer");
            var response = Post(User.ActiveKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }
    }
}