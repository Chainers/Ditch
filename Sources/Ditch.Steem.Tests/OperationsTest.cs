using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cryptography.ECDSA;
using Ditch.Core;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Models;
using Ditch.Steem.Operations;
using NUnit.Framework;
using Base58 = Ditch.Core.Base58;

namespace Ditch.Steem.Tests
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
            const string permlink = "fkkl";

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
            var args = new GetDiscussionArgs
            {
                Author = author,
                Permlink = permlink
            };
            var resp = Api.GetDiscussion(args, CancellationToken.None);
            if (resp.IsError)
            {
                WriteLine(resp);
                Assert.IsFalse(resp.IsError);
            }
            var vote = resp.Result.ActiveVotes.FirstOrDefault(i => i.Voter.Equals(user.Login));
            return vote?.Percent ?? 0;
        }

        #endregion
        #region Comment

        [Test]
        public void PostTest()
        {
            var user = User;
            var op = new PostOperation("test", user.Login, "test", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg", GetMeta(null));
            Post(user.PostingKeys, false, op);
        }

        [Test]
        public void RuPostTest()
        {
            var user = User;

            var op = new PostOperation("test", user.Login, "Тест с русскими буквами", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", GetMeta(null));
            Post(user.PostingKeys, false, op);
        }

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
            var op = new TransferOperation(User.Login, User.Login, new Asset(1, Config.SteemAssetNumSbd), "Hi, it`s test transfer from Ditch (https://github.com/Chainers/Ditch).");
            Post(User.ActiveKeys, false, op);
        }

        #endregion
        #region TransferToVesting

        [Test]
        public void TransferToVestingOperationTest()
        {
            var op = new TransferToVestingOperation(User.Login, User.Login, new Asset(1, Config.SteemAssetNumSteem));
            Post(User.ActiveKeys, false, op);
        }

        #endregion
        #region WithdrawVesting

        [Test]
        public void WithdrawVestingOperationTest()
        {
            var op = new WithdrawVestingOperation(User.Login, new Asset(1, Config.SteemAssetNumVests));
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
                Fee = new Asset(3000, Config.SteemAssetNumSteem),
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
            var args = new FindAccountsArgs
            {
                Accounts = new[] { User.Login }
            };
            var resp = Api.FindAccounts(args, CancellationToken.None);
            var acc = resp.Result.Accounts[0];

            var op = new AccountUpdateOperation(User.Login, acc.MemoKey, acc.JsonMetadata);
            Post(User.ActiveKeys, false, op);
        }

        #endregion AccountUpdate

        #region WitnessUpdate

        [Test]
        public void WitnessUpdateTest()
        {
            var accountCreationFee = new Asset(1, Config.SteemAssetNumSteem);
            var fee = new Asset(1, Config.SteemAssetNumSteem);

            var op = new WitnessUpdateOperation(User.Login, string.Empty, new PublicKeyType("STM1111111111111111111111111111111114T1Anm"), new LegacyChainProperties(1000, accountCreationFee, 131072), fee);
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

            var op2 = new DeleteCommentOperation(op.Author, op.Permlink);
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

        private bool IsFollow(string autor)
        {
            var args = new GetFollowingArgs
            {
                Account = User.Login,
                Start = autor,
                Limit = 1,
                Type = FollowType.Blog
            };
            var resp = Api.GetFollowing(args, CancellationToken.None);
            if (resp.IsError)
            {
                WriteLine(resp);
                Assert.IsFalse(resp.IsError);
            }
            return resp.Result.Following.Length > 0 && resp.Result.Following[0].Following == autor;
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
            var op = new PostOperation("test", user.Login, "test", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg", GetMeta(null));
            var popt = new BeneficiariesOperation(user.Login, op.Permlink, new Asset(1000000000, Config.SteemAssetNumSbd), new Beneficiary("steepshot", 1000));
            Post(user.PostingKeys, false, op, popt);
        }

        #endregion CommentOptions
        //SetWithdrawVestingRoute,
        //LimitOrderCreate2,
        //ClaimAccount,
        //CreateClaimedAccount,
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
        #region ClaimRewardBalance

        [Test]
        public void ClaimRewardBalanceOperationTest()
        {
            var steem = new Asset(100000, Config.SteemAssetNumSteem);
            var sbd = new Asset(100000, Config.SteemAssetNumSbd);
            var vest = new Asset(10000000, Config.SteemAssetNumVests);
            var op = new ClaimRewardBalanceOperation(User.Login, steem, sbd, vest);
            Post(User.PostingKeys, false, op);
        }

        #endregion ClaimRewardBalance
        //DelegateVestingShares,
        //AccountCreateWithDelegation,
        //WitnessSetProperties,

        //# ifdef STEEM_ENABLE_SMT
        //        /// SMT operations
        //        ClaimRewardBalance2,

        //        SmtSetup,
        //        SmtCapReveal,
        //        SmtRefund,
        //        SmtSetupEmissions,
        //        SmtSetSetupParameters,
        //        SmtSetRuntimeParameters,
        //        SmtCreate,
        //#endif
        /// virtual operations below this point
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
        //ReturnVestingDelegation,
        //CommentBenefactorReward,
        //ProducerReward
    }
}