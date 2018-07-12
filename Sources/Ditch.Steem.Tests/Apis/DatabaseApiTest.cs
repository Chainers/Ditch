using System.Threading;
using System.Threading.Tasks;
using Ditch.Steem.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Steem.Tests.Apis
{
    [TestFixture]
    public class DatabaseApiTest : BaseTest
    {
        [Test]
        [Parallelizable]
        public async Task get_config()
        {
            var resp = await Api.GetConfig<JObject>(CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public async Task get_dynamic_global_properties()
        {
            var resp = await Api.GetDynamicGlobalProperties(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public async Task get_witness_schedule()
        {
            var resp = await Api.GetWitnessSchedule(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_hardfork_properties()
        {
            var resp = await Api.GetHardforkProperties(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_reward_funds()
        {
            var resp = await Api.GetRewardFunds(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_current_price_feed()
        {
            var resp = await Api.GetCurrentPriceFeed(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_feed_history()
        {
            var resp = await Api.GetFeedHistory(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task list_witnesses()
        {
            var args = new ListWitnessesArgs();
            var resp = await Api.ListWitnesses(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task find_witnesses()
        {
            var args = new FindWitnessesArgs
            {
                Owners = new[] { User.Login }
            };
            var resp = await Api.FindWitnesses(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task list_witness_votes()
        {
            var args = new ListWitnessVotesArgs
            {
                Order = SortOrderType.ByAccountWitness,
                Start = new object[0],
                Limit = 3
            };
            var resp = await Api.ListWitnessVotes(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_active_witnesses()
        {
            var resp = await Api.GetActiveWitnesses(CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task list_accounts()
        {
            var args = new ListAccountsArgs();
            var resp = await Api.ListAccounts(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task find_accounts()
        {
            var args = new FindAccountsArgs
            {
                Accounts = new[] { User.Login }
            };
            var resp = await Api.FindAccounts(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task list_owner_histories()
        {
            var args = new ListOwnerHistoriesArgs
            {
                Start = new object[0],
                Limit = 3
            };
            var resp = await Api.ListOwnerHistories(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task find_owner_histories()
        {
            var args = new FindOwnerHistoriesArgs();
            var resp = await Api.FindOwnerHistories(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task list_account_recovery_requests()
        {
            var args = new ListAccountRecoveryRequestsArgs
            {
                Start = User.Login,
                Limit = 3,
                Order = SortOrderType.ByAccount
            };
            var resp = await Api.ListAccountRecoveryRequests(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task find_account_recovery_requests()
        {
            var args = new FindAccountRecoveryRequestsArgs
            {
                Accounts = new[] { User.Login }
            };
            var resp = await Api.FindAccountRecoveryRequests(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task list_change_recovery_account_requests()
        {
            var args = new ListChangeRecoveryAccountRequestsArgs
            {
                Order = SortOrderType.ByAccount
            };
            var resp = await Api.ListChangeRecoveryAccountRequests(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task find_change_recovery_account_requests()
        {
            var args = new FindChangeRecoveryAccountRequestsArgs
            {
                Accounts = new[] { User.Login }
            };
            var resp = await Api.FindChangeRecoveryAccountRequests(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task list_escrows()
        {
            var args = new ListEscrowsArgs
            {
                Start = new object[0],
                Limit = 3,
                Order = SortOrderType.ByFromId
            };

            var resp = await Api.ListEscrows(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task find_escrows()
        {
            var args = new FindEscrowsArgs();
            var resp = await Api.FindEscrows(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task list_withdraw_vesting_routes()
        {
            var args = new ListWithdrawVestingRoutesArgs
            {
                Order = SortOrderType.ByWithdrawRoute,
                Start = new object[0],
                Limit = 3
            };
            var resp = await Api.ListWithdrawVestingRoutes(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task find_withdraw_vesting_routes()
        {
            var args = new FindWithdrawVestingRoutesArgs
            {
                Account = User.Login,
                Order = SortOrderType.ByWithdrawRoute
            };
            var resp = await Api.FindWithdrawVestingRoutes(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task list_savings_withdrawals()
        {
            var args = new ListSavingsWithdrawalsArgs
            {
                Start = new object[0],
                Limit = 3,
                Order = SortOrderType.ByFromId
            };

            var resp = await Api.ListSavingsWithdrawals(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task find_savings_withdrawals()
        {
            var args = new FindSavingsWithdrawalsArgs();
            var resp = await Api.FindSavingsWithdrawals(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task list_vesting_delegations()
        {
            var args = new ListVestingDelegationsArgs
            {
                Order = SortOrderType.ByDelegation,
                Start = new object[0],
                Limit = 3
            };
            var resp = await Api.ListVestingDelegations(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task find_vesting_delegations()
        {
            var args = new FindVestingDelegationsArgs();
            var resp = await Api.FindVestingDelegations(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task list_vesting_delegation_expirations()
        {
            var args = new ListVestingDelegationExpirationsArgs
            {
                Order = SortOrderType.ByExpiration,
                Start = new object[0],
                Limit = 3
            };
            var resp = await Api.ListVestingDelegationExpirations(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task find_vesting_delegation_expirations()
        {
            var args = new FindVestingDelegationExpirationsArgs();
            var resp = await Api.FindVestingDelegationExpirations(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task list_sbd_conversion_requests()
        {
            var args = new ListSbdConversionRequestsArgs
            {
                Order = SortOrderType.ByAccount,
                Start = new object[0],
                Limit = 3
            };
            var resp = await Api.ListSbdConversionRequests(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task find_sbd_conversion_requests()
        {
            var args = new FindSbdConversionRequestsArgs();
            var resp = await Api.FindSbdConversionRequests(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task list_decline_voting_rights_requests()
        {
            var args = new ListDeclineVotingRightsRequestsArgs
            {
                Order = SortOrderType.ByAccount
            };
            var resp = await Api.ListDeclineVotingRightsRequests(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task find_decline_voting_rights_requests()
        {
            var args = new FindDeclineVotingRightsRequestsArgs
            {
                Accounts = new[] { User.Login }
            };
            var resp = await Api.FindDeclineVotingRightsRequests(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task list_comments()
        {
            var args = new ListCommentsArgs
            {
                Start = new object[0],
                Limit = 3,
                Order = SortOrderType.ByPermlink
            };

            var resp = await Api.ListComments(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task find_comments()
        {
            var args = new FindCommentsArgs
            {
                Comments = new[] { new[] { "steepshot", "steepshot-updates-join-ios-closed-beta-testing-full-screen-mode-for-desktops-sponsors-incentives-and-more" } }
            };
            var resp = await Api.FindComments(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task list_votes()
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
            var resp = await Api.ListVotes(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task find_votes()
        {
            var args = new FindVotesArgs
            {
                Author = "steepshot",
                Permlink = "let-s-make-steem-great-again-incentives-to-sponsors-announcement-from-steepshot"
            };
            var resp = await Api.FindVotes(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task list_limit_orders()
        {
            var args = new ListLimitOrdersArgs
            {
                Start = new object[0],
                Limit = 3,
                Order = SortOrderType.ByAccount
            };
            var resp = await Api.ListLimitOrders(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task find_limit_orders()
        {
            var args = new FindLimitOrdersArgs
            {
                Account = User.Login
            };
            var resp = await Api.FindLimitOrders(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_transaction_hex()
        {
            var args = new GetTransactionHexArgs
            {
                Trx = await GetSignedTransaction()
            };
            var resp = await Api.GetTransactionHex(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_required_signatures()
        {
            var findAccountsArgs = new FindAccountsArgs
            {
                Accounts = new[] { User.Login }
            };
            var accounts = await Api.FindAccounts(findAccountsArgs, CancellationToken.None);
            if (accounts.IsError)
                WriteLine(accounts);
            Assert.IsFalse(accounts.IsError);
            var pKey = accounts.Result.Accounts[0].Posting.KeyAuths[0].Key;

            var args = new GetRequiredSignaturesArgs
            {
                Trx = await GetSignedTransaction(),
                AvailableKeys = new[] { pKey }
            };
            var resp = await Api.GetRequiredSignatures(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_potential_signatures()
        {
            var args = new GetPotentialSignaturesArgs
            {
                Trx = await GetSignedTransaction()
            };
            var resp = await Api.GetPotentialSignatures(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task verify_authority()
        {
            var args = new VerifyAuthorityArgs
            {
                Trx = await GetSignedTransaction()
            };
            var resp = await Api.VerifyAuthority(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        [Ignore("It did not take off...")]
        public async Task verify_account_authority()
        {
            var args = new VerifyAccountAuthorityArgs
            {
                Account = User.Login,
                Signers = new PublicKeyType[0]
            };
            var resp = await Api.VerifyAccountAuthority(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        [Ignore("It did not take off...")]
        public async Task verify_signatures()
        {
            var args = new VerifySignaturesArgs();
            var resp = await Api.VerifySignatures(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_smt_next_identifier()
        {
            var confResp = await Api.GetConfig<JObject>(CancellationToken.None);
            if (confResp.IsError)
                return;

            var conf = confResp.Result;

            JToken jToken;
            conf.TryGetValue("STEEM_ENABLE_SMT", out jToken);
            var isEnableSmt = jToken != null && jToken.Value<bool>();

            if (isEnableSmt)
            {
                var resp = await Api.GetSmtNextIdentifier(CancellationToken.None);
                TestPropetries(resp);
            }
        }
    }
}
