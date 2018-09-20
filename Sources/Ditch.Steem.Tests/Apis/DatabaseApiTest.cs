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
            var resp = await Api.GetConfigAsync<JObject>(CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        [Parallelizable]
        public async Task get_dynamic_global_properties()
        {
            var resp = await Api.GetDynamicGlobalPropertiesAsync(CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_witness_schedule()
        {
            var resp = await Api.GetWitnessScheduleAsync(CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_hardfork_properties()
        {
            var resp = await Api.GetHardforkPropertiesAsync(CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_reward_funds()
        {
            var resp = await Api.GetRewardFundsAsync(CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_current_price_feed()
        {
            var resp = await Api.GetCurrentPriceFeedAsync(CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_feed_history()
        {
            var resp = await Api.GetFeedHistoryAsync(CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task list_witnesses()
        {
            var args = new ListWitnessesArgs();
            var resp = await Api.ListWitnessesAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.FindWitnessesAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.ListWitnessVotesAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_active_witnesses()
        {
            var resp = await Api.GetActiveWitnessesAsync(CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task list_accounts()
        {
            var args = new ListAccountsArgs();
            var resp = await Api.ListAccountsAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.FindAccountsAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.ListOwnerHistoriesAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task find_owner_histories()
        {
            var args = new FindOwnerHistoriesArgs();
            var resp = await Api.FindOwnerHistoriesAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.ListAccountRecoveryRequestsAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.FindAccountRecoveryRequestsAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.ListChangeRecoveryAccountRequestsAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.FindChangeRecoveryAccountRequestsAsync(args, CancellationToken.None).ConfigureAwait(false);
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

            var resp = await Api.ListEscrowsAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task find_escrows()
        {
            var args = new FindEscrowsArgs();
            var resp = await Api.FindEscrowsAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.ListWithdrawVestingRoutesAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.FindWithdrawVestingRoutesAsync(args, CancellationToken.None).ConfigureAwait(false);
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

            var resp = await Api.ListSavingsWithdrawalsAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task find_savings_withdrawals()
        {
            var args = new FindSavingsWithdrawalsArgs();
            var resp = await Api.FindSavingsWithdrawalsAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.ListVestingDelegationsAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task find_vesting_delegations()
        {
            var args = new FindVestingDelegationsArgs();
            var resp = await Api.FindVestingDelegationsAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.ListVestingDelegationExpirationsAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task find_vesting_delegation_expirations()
        {
            var args = new FindVestingDelegationExpirationsArgs();
            var resp = await Api.FindVestingDelegationExpirationsAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.ListSbdConversionRequestsAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task find_sbd_conversion_requests()
        {
            var args = new FindSbdConversionRequestsArgs();
            var resp = await Api.FindSbdConversionRequestsAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.ListDeclineVotingRightsRequestsAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.FindDeclineVotingRightsRequestsAsync(args, CancellationToken.None).ConfigureAwait(false);
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

            var resp = await Api.ListCommentsAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.FindCommentsAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.ListVotesAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.FindVotesAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.ListLimitOrdersAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.FindLimitOrdersAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_transaction_hex()
        {
            var args = new GetTransactionHexArgs
            {
                Trx = await GetSignedTransaction().ConfigureAwait(false)
            };
            var resp = await Api.GetTransactionHexAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var accounts = await Api.FindAccountsAsync(findAccountsArgs, CancellationToken.None).ConfigureAwait(false);
            if (accounts.IsError)
                WriteLine(accounts);
            Assert.IsFalse(accounts.IsError);
            var pKey = accounts.Result.Accounts[0].Posting.KeyAuths[0].Key;

            var args = new GetRequiredSignaturesArgs
            {
                Trx = await GetSignedTransaction().ConfigureAwait(false),
                AvailableKeys = new[] { pKey }
            };
            var resp = await Api.GetRequiredSignaturesAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_potential_signatures()
        {
            var args = new GetPotentialSignaturesArgs
            {
                Trx = await GetSignedTransaction().ConfigureAwait(false)
            };
            var resp = await Api.GetPotentialSignaturesAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task verify_authority()
        {
            var args = new VerifyAuthorityArgs
            {
                Trx = await GetSignedTransaction().ConfigureAwait(false)
            };
            var resp = await Api.VerifyAuthorityAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.VerifyAccountAuthorityAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        [Ignore("It did not take off...")]
        public async Task verify_signatures()
        {
            var args = new VerifySignaturesArgs();
            var resp = await Api.VerifySignaturesAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Parallelizable]
        public async Task get_smt_next_identifier()
        {
            var confResp = await Api.GetConfigAsync<JObject>(CancellationToken.None).ConfigureAwait(false);
            if (confResp.IsError)
                return;

            var conf = confResp.Result;

            JToken jToken;
            conf.TryGetValue("STEEM_ENABLE_SMT", out jToken);
            var isEnableSmt = jToken != null && jToken.Value<bool>();

            if (isEnableSmt)
            {
                var resp = await Api.GetSmtNextIdentifierAsync(CancellationToken.None).ConfigureAwait(false);
                TestPropetries(resp);
            }
        }
    }
}
