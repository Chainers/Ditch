using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
    public class CondenserOperationsTest : BaseTest
    {
        protected const bool IsNeedBroadcast = false;

        [OneTimeSetUp]
        protected override void OneTimeSetUp()
        {
            base.OneTimeSetUp();
            JsonSerializerSettings = Api.CondenserJsonSerializerSettings;
        }

        protected virtual async Task Post(IList<byte[]> postingKeys, bool isNeedBroadcast, params BaseOperation[] op)
        {
            JsonRpcResponse response;
            if (isNeedBroadcast | IsNeedBroadcast)
                response = await Api.CondenserBroadcastOperationsSynchronousAsync(postingKeys, op, CancellationToken.None).ConfigureAwait(false);
            else
                response = await Api.CondenserVerifyAuthorityAsync(postingKeys, op, CancellationToken.None).ConfigureAwait(false);

            WriteLine(response);
            Assert.IsFalse(response.IsError);
        }

        #region Vote

        [Test]
        public async Task VoteTest()
        {
            var user = User;
            var autor = User.Login;
            var permlink = "test-2018-09-26-12-55-19";

            var voteState = await GetVoteState(autor, permlink, user).ConfigureAwait(false);

            for (var i = 0; i < 3; i++)
            {
                var op = voteState < 0
                    ? new VoteOperation(user.Login, autor, permlink, VoteOperation.NoneVote)
                    : voteState > 0
                        ? new VoteOperation(user.Login, autor, permlink, VoteOperation.MaxFlagVote)
                        : new VoteOperation(user.Login, autor, permlink, VoteOperation.MaxUpVote);

                await Post(user.PostingKeys, false, op).ConfigureAwait(false);

                if (voteState == 0)
                    voteState = VoteOperation.MaxUpVote;
                else if (voteState > 0)
                    voteState = VoteOperation.MaxFlagVote;
                else
                    voteState = 0;
            }
        }

        private async Task<int> GetVoteState(string author, string permlink, UserInfo user)
        {
            var args = new GetDiscussionArgs
            {
                Author = author,
                Permlink = permlink
            };
            var resp = await Api.GetDiscussionAsync(args, CancellationToken.None).ConfigureAwait(false);
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
        public async Task PostTest()
        {
            var user = User;
            var op = new PostOperation("test", user.Login, "test", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg", GetMeta(null));
            await Post(user.PostingKeys, false, op).ConfigureAwait(false);
        }

        [Test]
        public async Task RuPostTest()
        {
            var user = User;

            var op = new PostOperation("test", user.Login, "Тест с русскими буквами", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", GetMeta(null));
            await Post(user.PostingKeys, false, op).ConfigureAwait(false);
        }

        [Test]
        public async Task ReplyTest()
        {
            var user = User;

            var op = new ReplyOperation("steepshot", "Тест с русскими буквами", user.Login, "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", GetMeta(null));
            Assert.IsTrue(OperationHelper.TimePostfix.IsMatch(op.Permlink));
            await Post(user.PostingKeys, false, op).ConfigureAwait(false);
        }

        #endregion

        #region Transfer

        [Test]
        public async Task TransferOperationTest()
        {
            var op = new TransferOperation(User.Login, User.Login, new Asset(1, Config.SteemAssetNumSbd), "Hi, it`s test transfer from Ditch (https://github.com/Chainers/Ditch).");
            await Post(User.ActiveKeys, false, op).ConfigureAwait(false);
        }

        #endregion
        #region TransferToVesting

        [Test]
        public async Task TransferToVestingOperationTest()
        {
            var op = new TransferToVestingOperation(User.Login, User.Login, new Asset(1, Config.SteemAssetNumSteem));
            await Post(User.ActiveKeys, false, op).ConfigureAwait(false);
        }

        #endregion
        #region WithdrawVesting

        [Test]
        public async Task WithdrawVestingOperationTest()
        {
            var op = new WithdrawVestingOperation(User.Login, new Asset(1, Config.SteemAssetNumVests));
            await Post(User.ActiveKeys, false, op).ConfigureAwait(false);
        }

        #endregion

        //LimitOrderCreate,
        //LimitOrderCancel,

        //FeedPublish,
        //Convert,

        #region AccountCreate

        [Test]
        public async Task AccountCreateTest()
        {
            string name = User.Login + DateTime.Now.Ticks;

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

            await Post(User.ActiveKeys, false, op).ConfigureAwait(false);
        }


        #endregion AccountCreate
        #region AccountUpdate

        [Test]
        public async Task AccountUpdateTest()
        {
            var args = new FindAccountsArgs
            {
                Accounts = new[] { User.Login }
            };
            var resp = await Api.FindAccountsAsync(args, CancellationToken.None).ConfigureAwait(false);
            var acc = resp.Result.Accounts[0];

            var op = new AccountUpdateOperation(User.Login, acc.MemoKey, acc.JsonMetadata);
            await Post(User.ActiveKeys, false, op).ConfigureAwait(false);
        }

        #endregion AccountUpdate

        #region WitnessUpdate

        [Test]
        public async Task WitnessUpdateTest()
        {
            var accountCreationFee = new Asset(1, Config.SteemAssetNumSteem);
            var fee = new Asset(1, Config.SteemAssetNumSteem);

            var op = new WitnessUpdateOperation(User.Login, string.Empty, new PublicKeyType(Config.KeyPrefix + "1111111111111111111111111111111114T1Anm"), new LegacyChainProperties(1000, accountCreationFee, 131072), fee);
            await Post(User.ActiveKeys, false, op).ConfigureAwait(false);
        }

        #endregion
        //AccountWitnessVote,
        //AccountWitnessProxy,

        //Pow,

        //Custom,

        //ReportOverProduction,

        #region DeleteComment

        [Test]
        public async Task DeleteCommentTest()
        {
            var user = User;
            var op = new PostOperation("test", user.Login, "Test post for delete", "Test post for delete", GetMeta(null));
            await Post(user.PostingKeys, false, op).ConfigureAwait(false);

            var op2 = new DeleteCommentOperation(op.Author, op.Permlink);
            await Post(user.PostingKeys, false, op2).ConfigureAwait(false);
        }

        #endregion DeleteComment
        #region CustomJson

        [Test]
        public async Task FollowUnfollowTest()
        {
            var user = User;
            const string autor = "steepshot";


            var isFollow = await IsFollow(autor).ConfigureAwait(false);

            var op = isFollow
                ? new UnfollowOperation(user.Login, autor, user.Login)
                : new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            await Post(user.PostingKeys, false, op).ConfigureAwait(false);

            isFollow = !isFollow;

            op = isFollow
                ? new UnfollowOperation(user.Login, autor, user.Login)
                : new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            await Post(user.PostingKeys, false, op).ConfigureAwait(false);

            isFollow = !isFollow;

            var fType = isFollow ? new FollowType[0] : new[] { FollowType.Blog };
            op = new FollowOperation(user.Login, autor, fType, user.Login);
            await Post(user.PostingKeys, false, op).ConfigureAwait(false);

            isFollow = !isFollow;

            fType = isFollow ? new FollowType[0] : new[] { FollowType.Blog };
            op = new FollowOperation(user.Login, autor, fType, user.Login);
            await Post(user.PostingKeys, false, op).ConfigureAwait(false);
        }

        private async Task<bool> IsFollow(string autor)
        {
            var args = new GetFollowingArgs
            {
                Account = User.Login,
                Start = autor,
                Limit = 1,
                Type = FollowType.Blog
            };
            var resp = await Api.GetFollowingAsync(args, CancellationToken.None).ConfigureAwait(false);
            if (resp.IsError)
            {
                WriteLine(resp);
                Assert.IsFalse(resp.IsError);
            }
            return resp.Result.Following.Length > 0 && resp.Result.Following[0].Following == autor;
        }

        [Test]
        public async Task RepostTest()
        {
            var user = User;

            var op = new RePostOperation(user.Login, "joseph.kalu", "fkkl", user.Login);
            await Post(user.PostingKeys, false, op).ConfigureAwait(false);
        }

        [Test]
        public async Task VerifyAuthoritySuccessTest()
        {
            var user = User;

            var op = new FollowOperation(user.Login, "steepshot", FollowType.Blog, user.Login);
            await Post(user.PostingKeys, false, op).ConfigureAwait(false);
        }

        #endregion CustomJson
        #region CommentOptions

        [Test]
        public async Task PostWithBeneficiariesTest()
        {
            var user = User;
            var op = new PostOperation("test", user.Login, "test", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg", GetMeta(null));
            var popt = new BeneficiariesOperation(user.Login, op.Permlink, new Asset(1000000000, Config.SteemAssetNumSbd), new Beneficiary("steepshot", 1000));
            await Post(user.PostingKeys, false, op, popt).ConfigureAwait(false);
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
        public async Task ClaimRewardBalanceOperationTest()
        {
            var steem = new Asset(1, Config.SteemAssetNumSteem);
            var sbd = new Asset(1, Config.SteemAssetNumSbd);
            var vest = new Asset(1, Config.SteemAssetNumVests);
            var op = new ClaimRewardBalanceOperation(User.Login, steem, sbd, vest);
            await Post(User.PostingKeys, false, op).ConfigureAwait(false);
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
        //// virtual operations below this point
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