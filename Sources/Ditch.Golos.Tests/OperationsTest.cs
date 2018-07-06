using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Cryptography.ECDSA;
using Ditch.Core;
using Ditch.Core.JsonRpc;
using Ditch.Golos.Models;
using Ditch.Golos.Operations;
using NUnit.Framework;
using Base58 = Ditch.Core.Base58;

namespace Ditch.Golos.Tests
{
    [TestFixture]
    public class OperationsTest : BaseTest
    {
        private void Post(IList<byte[]> postingKeys, bool isNeedBroadcast, params BaseOperation[] op)
        {
            var response = isNeedBroadcast
                ? (JsonRpcResponse)Api.BroadcastOperations(postingKeys, op, CancellationToken.None)
                : Api.VerifyAuthority(postingKeys, op, CancellationToken.None);
            WriteLine(response);

            Assert.IsFalse(response.IsError);
        }

        #region Vote

        [Test]
        public void VoteTest()
        {
            var user = User;
            const string autor = "joseph.kalu";
            const string permlink = "test-s-russkimi-bukvami-2017-11-16-17-12-05";

            var voteState = GetVoteState(autor, permlink, user);

            for (var i = 0; i < 3; i++)
            {
                var op = voteState < 0
                    ? new VoteOperation(user.Login, autor, permlink, VoteOperation.MaxUpVote)
                    : voteState > 0
                        ? new VoteOperation(user.Login, autor, permlink, VoteOperation.MaxFlagVote)
                        : new VoteOperation(user.Login, autor, permlink, VoteOperation.NoneVote);

                Post(user.PostingKeys, false, op);

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
            var resp = Api.GetContent(author, permlink, 100, CancellationToken.None);
            WriteLine(resp);

            Assert.IsFalse(resp.IsError);
            var vote = resp.Result.ActiveVotes.FirstOrDefault(i => i.Voter.Equals(user.Login));
            return vote?.Percent ?? 0;
        }

        #endregion
        #region Comment

        [Test]
        public void ReplyTest()
        {
            var user = User;

            var op = new ReplyOperation("steepshot", "Тест с русскими буквами", user.Login, "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", GetMeta(null));
            Assert.IsTrue(OperationHelper.TimePostfix.IsMatch(op.Permlink));
            Post(user.PostingKeys, false, op);
        }

        #endregion

        #region Transfer

        [Test]
        public void TransferOperationTest()
        {
            var op = new TransferOperation(User.Login, User.Login, new Asset("0.001 GBG"), "Hi, it`s test transfer from Ditch (https://github.com/Chainers/Ditch).");
            Post(User.ActiveKeys, false, op);
        }

        #endregion
        #region TransferToVesting

        [Test]
        public void TransferToVestingOperationTest()
        {
            var op = new TransferToVestingOperation(User.Login, User.Login, new Asset("0.001 GOLOS"));
            Post(User.ActiveKeys, false, op);
        }

        #endregion
        #region WithdrawVesting

        [Test]
        public void WithdrawVestingOperationTest()
        {
            var op = new WithdrawVestingOperation(User.Login, new Asset("0.001 GESTS"));
            Post(User.ActiveKeys, false, op);
        }

        #endregion


        //LimitOrderCreate,
        //LimitOrderCancel,

        //FeedPublish,
        //Convert,

        #region AccountCreate

        [Test]
        public void AccountCreateTest()
        {
            const string name = "userlogin";

            var op = new AccountCreateOperation
            {
                Fee = new Asset(3000, 3, "GBG"),
                Creator = User.Login,
                NewAccountName = User.Login,
                JsonMetadata = ""
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

            Post(User.ActiveKeys, false, op);
        }

        #endregion AccountCreate
        #region AccountUpdate

        [Test]
        public void AccountUpdateTest()
        {
            var resp = Api.LookupAccountNames(new[] { User.Login }, CancellationToken.None);
            var acc = resp.Result[0];

            var op = new AccountUpdateOperation(User.Login, acc.MemoKey, acc.JsonMetadata);
            Post(User.ActiveKeys, false, op);
        }

        #endregion AccountUpdate


        #region WitnessUpdate

        [Test]
        public void WitnessUpdateTest()
        {
            var op = new WitnessUpdateOperation(User.Login, "https://golos.io/ru--golos/@steepshot/steepshot-zapuskaet-delegatskuyu-nodu", new PublicKeyType("GLS1111111111111111111111111111111114T1Anm"), new ChainProperties17(1000, new Asset("1.000 GOLOS"), 131072), new Asset("0.000 GOLOS"));
            Post(User.ActiveKeys, false, op);
        }

        #endregion
        
        //AccountWitnessVote,
        //AccountWitnessProxy,

        //Pow,

        //Custom,

        //ReportOverProduction,

        #region DeleteComment

        [Test]
        public void DeleteCommentTest()
        {
            var user = User;
            var op = new PostOperation("test", user.Login, "Test post for delete", "Test post for delete", GetMeta(null));
            Post(user.PostingKeys, false, op);

            var op2 = new DeleteCommentOperation(user.Login, "");
            Post(user.PostingKeys, false, op2);
        }

        #endregion DeleteComment
        #region CustomJson

        [Test]
        public void FollowUnfollowTest()
        {
            var user = User;
            const string autor = "steepshot";


            var isFollow = IsFollow(autor);

            var op = isFollow
                ? new UnfollowOperation(user.Login, autor, user.Login)
                : new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            Post(user.PostingKeys, false, op);

            isFollow = !isFollow;

            op = isFollow
                ? new UnfollowOperation(user.Login, autor, user.Login)
                : new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            Post(user.PostingKeys, false, op);

            isFollow = !isFollow;

            var fType = isFollow ? new FollowType[0] : new[] { FollowType.Blog };
            op = new FollowOperation(user.Login, autor, fType, user.Login);
            Post(user.PostingKeys, false, op);

            isFollow = !isFollow;

            fType = isFollow ? new FollowType[0] : new[] { FollowType.Blog };
            op = new FollowOperation(user.Login, autor, fType, user.Login);
            Post(user.PostingKeys, false, op);
        }

        private bool IsFollow(string author)
        {
            var resp = Api.GetFollowing(User.Login, author, FollowType.Blog, 1, CancellationToken.None);
            return resp.Result.Length > 0 && resp.Result[0].Following == author;
        }

        [Test]
        public void RepostTest()
        {
            var user = User;

            var op = new RePostOperation(user.Login, "joseph.kalu", "fkkl", user.Login);
            Post(user.PostingKeys, false, op);
        }
        
        [Test]
        public void VerifyAuthoritySuccessTest()
        {
            var user = User;

            var op = new FollowOperation(user.Login, "steepshot", FollowType.Blog, user.Login);
            Post(user.PostingKeys, false, op);
        }

        [Test]
        public void VerifyAuthorityFallTest()
        {
            var user = User;

            var op = new FollowOperation(user.Login, "steepshot", FollowType.Blog, "StubLogin");
            Post(user.PostingKeys, false, op);
        }

        #endregion CustomJson
        #region CommentOptions


        [Test]
        public void PostWithBeneficiariesTest()
        {
            var user = User;
            var op = new PostOperation("test", user.Login, "Тест с русскими буквами и бенефитами", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", GetMeta(null));
            var op2 = new BeneficiariesOperation(user.Login, op.Permlink, new Asset(1000000000, 3, "GBG"), new Beneficiary("steepshot", 1000));

            Post(user.PostingKeys, false, op, op2);
        }

        #endregion CommentOptions
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
        //DelegateVestingShares,
        //AccountCreateWithDelegation,
        //AccountMetadata,
        #region ProposalCreate

        [Test]
        public void ProposalCreateOperationTest()
        {
            var user = User;
            const string autor = "joseph.kalu";
            const string permlink = "test-s-russkimi-bukvami-2017-11-16-17-12-05";

            var vop = new VoteOperation(user.Login, autor, permlink, VoteOperation.MaxUpVote);

            var op = new ProposalCreateOperation(User.Login, "test title", "test memo", DateTime.Now.AddSeconds(30))
            {
                ReviewPeriodTime = DateTime.Now.AddSeconds(55),
                ProposedOperations = new[]
                {
                    new OperationWrapper
                    {
                        Op = vop
                    }
                }
            };

            Post(User.ActiveKeys, false, op);
        }

        #endregion ProposalCreate
        #region ProposalUpdate

        [Test]
        public void ProposalUpdateOperationTest()
        {
            var op = new ProposalUpdateOperation()
            {
                Title = "test title",
                Author = User.Login,
                PostingApprovalsToAdd = new[] { User.Login },

            };

            Post(User.PostingKeys, false, op);
        }

        #endregion ProposalUpdate
        //ProposalDelete,
        //ChainPropertiesUpdate,

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
        //CommentBenefactorReward,
        //ReturnVestingDelegation

     



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
    }
}