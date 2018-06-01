using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.Errors;
using Ditch.Core.JsonRpc;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Globalization;
using Ditch.Core;
using Ditch.Golos.Models.Enums;
using Ditch.Golos.Models.Operations;
using Ditch.Golos.Models.Other;
using Cryptography.ECDSA;
using Base58 = Ditch.Core.Base58;

namespace Ditch.Golos.Tests
{
    [TestFixture]
    public class OperationsTest : BaseTest
    {
        private readonly Regex _errorMsg = new Regex(@"(?<=[\w\s\(\)&|\.<>=]+:\s+)[a-z\s0-9.]*", RegexOptions.IgnoreCase);
        private const bool IsVerify = true;

        private JsonRpcResponse Post(List<byte[]> postingKeys, bool isNeedBroadcast, params BaseOperation[] op)
        {
            if (!IsVerify || isNeedBroadcast)
                return Api.BroadcastOperations(postingKeys, CancellationToken.None, op);

            return Api.VerifyAuthority(postingKeys, CancellationToken.None, op);
        }

        #region Vote

        [Test]
        public async Task VoteTest()
        {
            var user = User;
            var autor = "joseph.kalu";
            var permlink = "test-s-russkimi-bukvami-2017-11-16-17-12-05";

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
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
            var vote = resp.Result.ActiveVotes.FirstOrDefault(i => i.Voter.Equals(user.Login));
            return vote?.Percent ?? 0;
        }

        #endregion

        #region Comment

        [Test]
        public void DeleteCommentTest()
        {
            var user = User;
            var op = new PostOperation("test", user.Login, "Test post for delete", "Test post for delete", GetMeta(null));
            var resp = Post(user.PostingKeys, false, op);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError, resp.GetErrorMessage());

            var op2 = new DeleteCommentOperation(op.Author, op.Permlink);
            resp = Post(user.PostingKeys, false, op2);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError, resp.GetErrorMessage());
        }

        [Test]
        public void PostWithBeneficiariesTest()
        {
            var user = User;
            var op = new PostOperation("test", user.Login, "Тест с русскими буквами и бенефитами", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", GetMeta(null));
            var op2 = new BeneficiariesOperation(user.Login, op.Permlink, new Asset(1000000000, 3, "GBG"), new Beneficiary("steepshot", 1000));

            var response = Post(user.PostingKeys, false, op, op2);

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

        #endregion

        #region Transfer

        [Test]
        public async Task TransferOperationTest()
        {
            var op = new TransferOperation(User.Login, User.Login, new Asset("0.001 GBG"), "Hi, it`s test transfer from Ditch (https://github.com/Chainers/Ditch).");
            var response = Post(User.ActiveKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        #endregion

        #region TransferToVesting

        [Test]
        public async Task TransferToVestingOperationTest()
        {
            var op = new TransferToVestingOperation(User.Login, User.Login, new Asset("0.001 GOLOS"));
            var response = Post(User.ActiveKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        #endregion

        #region WithdrawVesting

        [Test]
        public async Task WithdrawVestingOperationTest()
        {
            var op = new WithdrawVestingOperation(User.Login, new Asset("0.001 GESTS"));
            var response = Post(User.ActiveKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        #endregion


        //WithdrawVesting,

        //LimitOrderCreate,
        //LimitOrderCancel,

        //FeedPublish,
        //Convert,

        //AccountCreate,
        //AccountUpdate,

        #region WitnessUpdate

        [Test]
        public async Task WitnessUpdateTest()
        {
            var op = new WitnessUpdateOperation(User.Login, "https://golos.io/ru--golos/@steepshot/steepshot-zapuskaet-delegatskuyu-nodu", new PublicKeyType("GLS1111111111111111111111111111111114T1Anm"), new ChainProperties(1000, new Asset("1.000 GOLOS"), 131072), new Asset("0.000 GOLOS"));
            var response = Post(User.ActiveKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        #endregion



        //AccountWitnessVote,
        //AccountWitnessProxy,

        //Pow,

        //Custom,

        //ReportOverProduction,

        //DeleteComment,
        //CustomJson,
        //CommentOptions,
        //SetWithdrawVestingRoute,
        //LimitOrderCreate2,
        //ChallengeAuthority,
        //ProveAuthority,
        //RequestAccountRecovery,
        //RecoverAccount,
        //ChangeRecoveryAccount,
        //EscrowTransfer,
        //EscrowDispute,
        //EscrowRelease,
        //Pow2,
        //EscrowApprove,
        //TransferToSavings,
        //TransferFromSavings,
        //CancelTransferFromSavings,
        //CustomBinary,
        //DeclineVotingRights,
        //ResetAccount,
        //SetResetAccount,

        ///// virtual operations below this point
        //FillConvertRequest,
        //AuthorReward,
        //CurationReward,
        //CommentReward,
        //LiquidityReward,
        //Interest,
        //FillVestingWithdraw,
        //FillOrder,
        //ShutdownWitness,
        //FillTransferFromSavings,
        //Hardfork,
        //CommentPayoutUpdate,
        //CommentBenefactorReward

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
                await Task.Delay(1000);
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
                await Task.Delay(1000);
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
                await Task.Delay(1000);
                var isFollow2 = IsFollow(autor);
                Assert.IsTrue(isFollow != isFollow2);
            }
        }

        private bool IsFollow(string author)
        {
            var resp = Api.GetFollowing(User.Login, author, FollowType.Blog, 1, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
            return resp.Result.Length > 0 && resp.Result[0].Following == author;
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
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var acc = resp.Result[0];

            var op = new AccountUpdateOperation(User.Login, acc.MemoKey, acc.JsonMetadata);
            var response = Post(User.ActiveKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }

        [Test, Sequential]
        [TestCase("277.126 SBD", 277126, 3, "SBD")]
        [TestCase("0 SBD", 0, 0, "SBD")]
        [TestCase("0", 0, 0, "")]
        [TestCase("123 SBD", 123, 0, "SBD")]
        [TestCase("0.12345 SBD", 12345, 5, "SBD")]
        public void ParseTestTest(string test, long value, byte precision, string currency)
        {
            var asset = new Asset(test, CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator, CultureInfo.InvariantCulture.NumberFormat.NumberGroupSeparator);
            Assert.IsTrue(asset.Value == value);
            Assert.IsTrue(asset.Precision == precision);
            Assert.IsTrue(asset.Currency == currency);
            Assert.IsTrue(test.Equals(asset.ToString(CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator)));
        }

        [Test]
        public async Task AccountCreateTest()
        {
            var name = "userlogin";

            var op = new AccountCreateOperation
            {
                Fee = new Asset(3000, 3, "GBG"),
                Creator = User.Login,
                NewAccountName = User.Login,
                JsonMetadata = "",
            };

            var privateKey = Secp256K1Manager.GenerateRandomKey();
            var privateWif = "P" + Base58.EncodePrivateWif(privateKey);

            var subWif = Base58.GetSubWif(name, privateWif, "owner");
            var pk = Base58.DecodePrivateWif(subWif);
            var subPublicKey = Secp256K1Manager.GetPublicKey(pk, true);
            op.Owner.KeyAuths.Add(new KeyValuePair<PublicKeyType, ushort>(new PublicKeyType(subPublicKey), 1));

            subWif = Base58.GetSubWif(name, privateWif, "active");
            pk = Base58.DecodePrivateWif(subWif);
            subPublicKey = Secp256K1Manager.GetPublicKey(pk, true);
            op.Active.KeyAuths.Add(new KeyValuePair<PublicKeyType, ushort>(new PublicKeyType(subPublicKey), 1));

            subWif = Base58.GetSubWif(name, privateWif, "posting");
            pk = Base58.DecodePrivateWif(subWif);
            subPublicKey = Secp256K1Manager.GetPublicKey(pk, true);
            op.Posting.KeyAuths.Add(new KeyValuePair<PublicKeyType, ushort>(new PublicKeyType(subPublicKey), 1));

            subWif = Base58.GetSubWif(name, privateWif, "memo");
            pk = Base58.DecodePrivateWif(subWif);
            subPublicKey = Secp256K1Manager.GetPublicKey(pk, true);
            op.MemoKey = new PublicKeyType(subPublicKey);

            var response = Post(User.ActiveKeys, false, op);
            Assert.IsFalse(response.IsError, response.GetErrorMessage());
        }
    }
}