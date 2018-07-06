using System.Threading;
using Ditch.Steem.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Steem.Tests.Apis
{
    [TestFixture]
    public class DatabaseApiTest : BaseTest
    {
        [Test]
        public void get_config()
        {
            var resp = Api.GetConfig<JObject>(CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public void get_dynamic_global_properties()
        {
            var resp = Api.GetDynamicGlobalProperties(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_witness_schedule()
        {
            var resp = Api.GetWitnessSchedule(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_hardfork_properties()
        {
            var resp = Api.GetHardforkProperties(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_reward_funds()
        {
            var resp = Api.GetRewardFunds(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_current_price_feed()
        {
            var resp = Api.GetCurrentPriceFeed(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_feed_history()
        {
            var resp = Api.GetFeedHistory(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void list_witnesses()
        {
            var args = new ListWitnessesArgs();
            var resp = Api.ListWitnesses(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void find_witnesses()
        {
            var args = new FindWitnessesArgs
            {
                Owners = new[] { User.Login }
            };
            var resp = Api.FindWitnesses(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void list_witness_votes()
        {
            var args = new ListWitnessVotesArgs
            {
                Order = SortOrderType.ByAccountWitness,
                Start = new object[0],
                Limit = 3
            };
            var resp = Api.ListWitnessVotes(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_active_witnesses()
        {
            var resp = Api.GetActiveWitnesses(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void list_accounts()
        {
            var args = new ListAccountsArgs();
            var resp = Api.ListAccounts(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void find_accounts()
        {
            var args = new FindAccountsArgs
            {
                Accounts = new[] { User.Login }
            };
            var resp = Api.FindAccounts(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void list_owner_histories()
        {
            var args = new ListOwnerHistoriesArgs
            {
                Start = new object[0],
                Limit = 3
            };
            var resp = Api.ListOwnerHistories(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void find_owner_histories()
        {
            var args = new FindOwnerHistoriesArgs();
            var resp = Api.FindOwnerHistories(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void list_account_recovery_requests()
        {
            var args = new ListAccountRecoveryRequestsArgs
            {
                Start = User.Login,
                Limit = 3,
                Order = SortOrderType.ByAccount
            };
            var resp = Api.ListAccountRecoveryRequests(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void find_account_recovery_requests()
        {
            var args = new FindAccountRecoveryRequestsArgs
            {
                Accounts = new[] { User.Login }
            };
            var resp = Api.FindAccountRecoveryRequests(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void list_change_recovery_account_requests()
        {
            var args = new ListChangeRecoveryAccountRequestsArgs
            {
                Order = SortOrderType.ByAccount
            };
            var resp = Api.ListChangeRecoveryAccountRequests(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void find_change_recovery_account_requests()
        {
            var args = new FindChangeRecoveryAccountRequestsArgs
            {
                Accounts = new[] { User.Login }
            };
            var resp = Api.FindChangeRecoveryAccountRequests(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void list_escrows()
        {
            var args = new ListEscrowsArgs
            {
                Start = new object[0],
                Limit = 3,
                Order = SortOrderType.ByFromId
            };

            var resp = Api.ListEscrows(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void find_escrows()
        {
            var args = new FindEscrowsArgs();
            var resp = Api.FindEscrows(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void list_withdraw_vesting_routes()
        {
            var args = new ListWithdrawVestingRoutesArgs
            {
                Order = SortOrderType.ByWithdrawRoute,
                Start = new object[0],
                Limit = 3
            };
            var resp = Api.ListWithdrawVestingRoutes(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void find_withdraw_vesting_routes()
        {
            var args = new FindWithdrawVestingRoutesArgs
            {
                Account = User.Login,
                Order = SortOrderType.ByWithdrawRoute
            };
            var resp = Api.FindWithdrawVestingRoutes(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void list_savings_withdrawals()
        {
            var args = new ListSavingsWithdrawalsArgs
            {
                Start = new object[0],
                Limit = 3,
                Order = SortOrderType.ByFromId
            };

            var resp = Api.ListSavingsWithdrawals(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void find_savings_withdrawals()
        {
            var args = new FindSavingsWithdrawalsArgs();
            var resp = Api.FindSavingsWithdrawals(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void list_vesting_delegations()
        {
            var args = new ListVestingDelegationsArgs
            {
                Order = SortOrderType.ByDelegation,
                Start = new object[0],
                Limit = 3
            };
            var resp = Api.ListVestingDelegations(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void find_vesting_delegations()
        {
            var args = new FindVestingDelegationsArgs();
            var resp = Api.FindVestingDelegations(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void list_vesting_delegation_expirations()
        {
            var args = new ListVestingDelegationExpirationsArgs
            {
                Order = SortOrderType.ByExpiration,
                Start = new object[0],
                Limit = 3
            };
            var resp = Api.ListVestingDelegationExpirations(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void find_vesting_delegation_expirations()
        {
            var args = new FindVestingDelegationExpirationsArgs();
            var resp = Api.FindVestingDelegationExpirations(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void list_sbd_conversion_requests()
        {
            var args = new ListSbdConversionRequestsArgs
            {
                Order = SortOrderType.ByAccount,
                Start = new object[0],
                Limit = 3
            };
            var resp = Api.ListSbdConversionRequests(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void find_sbd_conversion_requests()
        {
            var args = new FindSbdConversionRequestsArgs();
            var resp = Api.FindSbdConversionRequests(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void list_decline_voting_rights_requests()
        {
            var args = new ListDeclineVotingRightsRequestsArgs
            {
                Order = SortOrderType.ByAccount
            };
            var resp = Api.ListDeclineVotingRightsRequests(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void find_decline_voting_rights_requests()
        {
            var args = new FindDeclineVotingRightsRequestsArgs
            {
                Accounts = new[] { User.Login }
            };
            var resp = Api.FindDeclineVotingRightsRequests(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void list_comments()
        {
            var args = new ListCommentsArgs
            {
                Start = new object[0],
                Limit = 3,
                Order = SortOrderType.ByPermlink
            };

            var resp = Api.ListComments(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void find_comments()
        {
            var args = new FindCommentsArgs
            {
                Comments = new[] { new[] { "steepshot", "steepshot-updates-join-ios-closed-beta-testing-full-screen-mode-for-desktops-sponsors-incentives-and-more" } }
            };
            var resp = Api.FindComments(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void list_votes()
        {
            var args = new ListVotesArgs
            {
                Order = SortOrderType.ByCommentVoter,
                Start = new object[]
                {
                    "joseph.kalu",
                    "quality-2018-02-22-08-12-47",
                    User.Login
                },
                Limit = 3
            };
            var resp = Api.ListVotes(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void find_votes()
        {
            var args = new FindVotesArgs
            {
                Author = "steepshot",
                Permlink = "let-s-make-steem-great-again-incentives-to-sponsors-announcement-from-steepshot"
            };
            var resp = Api.FindVotes(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void list_limit_orders()
        {
            var args = new ListLimitOrdersArgs
            {
                Start = new object[0],
                Limit = 3,
                Order = SortOrderType.ByAccount
            };
            var resp = Api.ListLimitOrders(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void find_limit_orders()
        {
            var args = new FindLimitOrdersArgs
            {
                Account = User.Login
            };
            var resp = Api.FindLimitOrders(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_transaction_hex()
        {
            var args = new GetTransactionHexArgs
            {
                Trx = GetSignedTransaction()
            };
            var resp = Api.GetTransactionHex(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_required_signatures()
        {
            var findAccountsArgs = new FindAccountsArgs
            {
                Accounts = new[] { User.Login }
            };
            var accounts = Api.FindAccounts(findAccountsArgs, CancellationToken.None);
            WriteLine(accounts);
            Assert.IsFalse(accounts.IsError);
            var pKey = accounts.Result.Accounts[0].Posting.KeyAuths[0].Key;

            var args = new GetRequiredSignaturesArgs
            {
                Trx = GetSignedTransaction(),
                AvailableKeys = new[] { pKey }
            };
            var resp = Api.GetRequiredSignatures(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_potential_signatures()
        {
            var args = new GetPotentialSignaturesArgs
            {
                Trx = GetSignedTransaction()
            };
            var resp = Api.GetPotentialSignatures(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void verify_authority()
        {
            var args = new VerifyAuthorityArgs
            {
                Trx = GetSignedTransaction()
            };
            var resp = Api.VerifyAuthority(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Ignore("It did not take off...")]
        public void verify_account_authority()
        {
            var args = new VerifyAccountAuthorityArgs
            {
                Account = User.Login,
                Signers = new PublicKeyType[0]
            };
            var resp = Api.VerifyAccountAuthority(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Ignore("It did not take off...")]
        public void verify_signatures()
        {
            var args = new VerifySignaturesArgs();
            var resp = Api.VerifySignatures(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_smt_next_identifier()
        {
            var confResp = Api.GetConfig<JObject>(CancellationToken.None);
            if (confResp.IsError)
                return;

            var conf = confResp.Result;

            JToken jToken;
            conf.TryGetValue("STEEM_ENABLE_SMT", out jToken);
            var isEnableSmt = jToken != null && jToken.Value<bool>();

            if (isEnableSmt)
            {
                var resp = Api.GetSmtNextIdentifier(CancellationToken.None);
                TestPropetries(resp);
            }
        }
    }
}
