using System;
using System.Collections.Generic;
using System.Threading;
using Ditch.Steem.Models.Args;
using Ditch.Steem.Models.Enums;
using Ditch.Steem.Models.Objects;
using Newtonsoft.Json;
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
            var resp = Api.GetConfig(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_config", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_dynamic_global_properties()
        {
            var resp = Api.GetDynamicGlobalProperties(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_dynamic_global_properties", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_witness_schedule()
        {
            var resp = Api.GetWitnessSchedule(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_witness_schedule", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_hardfork_properties()
        {
            var resp = Api.GetHardforkProperties(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_hardfork_properties", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_reward_funds()
        {
            var resp = Api.GetRewardFunds(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_reward_funds", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_current_price_feed()
        {
            var resp = Api.GetCurrentPriceFeed(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_current_price_feed", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_feed_history()
        {
            var resp = Api.GetFeedHistory(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_feed_history", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void list_witnesses()
        {
            var args = new ListWitnessesArgs();
            var resp = Api.ListWitnesses(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "list_witnesses", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void find_witnesses()
        {
            var args = new FindWitnessesArgs()
            {
                Owners = new[] { User.Login }
            };
            var resp = Api.FindWitnesses(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "find_witnesses", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void list_witness_votes()
        {
            var args = new ListWitnessVotesArgs()
            {
                Order = SortOrderType.ByAccountWitness,
                Start = new object[0],
                Limit = 3
            };
            var resp = Api.ListWitnessVotes(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "list_witness_votes", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_active_witnesses()
        {
            var resp = Api.GetActiveWitnesses(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_active_witnesses", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void list_accounts()
        {
            var args = new ListAccountsArgs();
            var resp = Api.ListAccounts(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "list_accounts", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void find_accounts()
        {
            var args = new FindAccountsArgs()
            {
                Accounts = new[] { User.Login }
            };
            var resp = Api.FindAccounts(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "find_accounts", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void list_owner_histories()
        {
            var args = new ListOwnerHistoriesArgs()
            {
                Start = new object[0],
                Limit = 3
            };
            var resp = Api.ListOwnerHistories(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "list_owner_histories", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void find_owner_histories()
        {
            var args = new FindOwnerHistoriesArgs();
            var resp = Api.FindOwnerHistories(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "find_owner_histories", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void list_account_recovery_requests()
        {
            var args = new ListAccountRecoveryRequestsArgs()
            {
                Start = User.Login,
                Limit = 3,
                Order = SortOrderType.ByAccount
            };
            var resp = Api.ListAccountRecoveryRequests(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "list_account_recovery_requests", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void find_account_recovery_requests()
        {
            var args = new FindAccountRecoveryRequestsArgs()
            {
                Accounts = new[] { User.Login }
            };
            var resp = Api.FindAccountRecoveryRequests(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "find_account_recovery_requests", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void list_change_recovery_account_requests()
        {
            var args = new ListChangeRecoveryAccountRequestsArgs()
            {
                Order = SortOrderType.ByAccount
            };
            var resp = Api.ListChangeRecoveryAccountRequests(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "list_change_recovery_account_requests", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void find_change_recovery_account_requests()
        {
            var args = new FindChangeRecoveryAccountRequestsArgs()
            {
                Accounts = new[] { User.Login }
            };
            var resp = Api.FindChangeRecoveryAccountRequests(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "find_change_recovery_account_requests", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void list_escrows()
        {
            var args = new ListEscrowsArgs()
            {
                Start = new object[0],
                Limit = 3,
                Order = SortOrderType.ByFromId
            };

            var resp = Api.ListEscrows(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "list_escrows", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void find_escrows()
        {
            var args = new FindEscrowsArgs();
            var resp = Api.FindEscrows(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "find_escrows", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void list_withdraw_vesting_routes()
        {
            var args = new ListWithdrawVestingRoutesArgs()
            {
                Order = SortOrderType.ByWithdrawRoute,
                Start = new object[0],
                Limit = 3
            };
            var resp = Api.ListWithdrawVestingRoutes(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "list_withdraw_vesting_routes", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void find_withdraw_vesting_routes()
        {
            var args = new FindWithdrawVestingRoutesArgs()
            {
                Account = User.Login,
                Order = SortOrderType.ByWithdrawRoute
            };
            var resp = Api.FindWithdrawVestingRoutes(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "find_withdraw_vesting_routes", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void list_savings_withdrawals()
        {
            var args = new ListSavingsWithdrawalsArgs()
            {
                Start = new object[0],
                Limit = 3,
                Order = SortOrderType.ByFromId
            };

            var resp = Api.ListSavingsWithdrawals(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "list_savings_withdrawals", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void find_savings_withdrawals()
        {
            var args = new FindSavingsWithdrawalsArgs();
            var resp = Api.FindSavingsWithdrawals(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "find_savings_withdrawals", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void list_vesting_delegations()
        {
            var args = new ListVestingDelegationsArgs()
            {
                Order = SortOrderType.ByDelegation,
                Start = new object[0],
                Limit = 3
            };
            var resp = Api.ListVestingDelegations(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "list_vesting_delegations", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void find_vesting_delegations()
        {
            var args = new FindVestingDelegationsArgs();
            var resp = Api.FindVestingDelegations(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "find_vesting_delegations", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void list_vesting_delegation_expirations()
        {
            var args = new ListVestingDelegationExpirationsArgs()
            {
                Order = SortOrderType.ByExpiration,
                Start = new object[0],
                Limit = 3
            };
            var resp = Api.ListVestingDelegationExpirations(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "list_vesting_delegation_expirations", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void find_vesting_delegation_expirations()
        {
            var args = new FindVestingDelegationExpirationsArgs();
            var resp = Api.FindVestingDelegationExpirations(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "find_vesting_delegation_expirations", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void list_sbd_conversion_requests()
        {
            var args = new ListSbdConversionRequestsArgs()
            {
                Order = SortOrderType.ByAccount,
                Start = new object[0],
                Limit = 3
            };
            var resp = Api.ListSbdConversionRequests(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "list_sbd_conversion_requests", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void find_sbd_conversion_requests()
        {
            var args = new FindSbdConversionRequestsArgs();
            var resp = Api.FindSbdConversionRequests(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "find_sbd_conversion_requests", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void list_decline_voting_rights_requests()
        {
            var args = new ListDeclineVotingRightsRequestsArgs()
            {
                Order = SortOrderType.ByAccount
            };
            var resp = Api.ListDeclineVotingRightsRequests(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "list_decline_voting_rights_requests", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void find_decline_voting_rights_requests()
        {
            var args = new FindDeclineVotingRightsRequestsArgs()
            {
                Accounts = new[] { User.Login }
            };
            var resp = Api.FindDeclineVotingRightsRequests(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "find_decline_voting_rights_requests", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void list_comments()
        {
            var args = new ListCommentsArgs()
            {
                Start = new object[0],
                Limit = 3,
                Order = SortOrderType.ByPermlink
            };

            var resp = Api.ListComments(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "list_comments", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void find_comments()
        {
            var args = new FindCommentsArgs()
            {
                Comments = new[] { new KeyValuePair<string, string>("steepshot", ""), }
            };
            var resp = Api.FindComments(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "find_comments", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void list_votes()
        {
            var args = new ListVotesArgs()
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
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "list_votes", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void find_votes()
        {
            var args = new FindVotesArgs()
            {
                Author = "steepshot",
                Permlink = "let-s-make-steem-great-again-incentives-to-sponsors-announcement-from-steepshot"
            };
            var resp = Api.FindVotes(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "find_votes", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void list_limit_orders()
        {
            var args = new ListLimitOrdersArgs()
            {
                Start = new object[0],
                Limit = 3,
                Order = SortOrderType.ByAccount
            };
            var resp = Api.ListLimitOrders(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "list_limit_orders", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void find_limit_orders()
        {
            var args = new FindLimitOrdersArgs()
            {
                Account = User.Login
            };
            var resp = Api.FindLimitOrders(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "find_limit_orders", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_transaction_hex()
        {
            var args = new GetTransactionHexArgs()
            {
                Trx = GetSignedTransaction()
            };
            var resp = Api.GetTransactionHex(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_transaction_hex", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_required_signatures()
        {
            var args = new GetRequiredSignaturesArgs()
            {
                Trx = GetSignedTransaction()
            };
            var resp = Api.GetRequiredSignatures(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_required_signatures", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_potential_signatures()
        {
            var args = new GetPotentialSignaturesArgs()
            {
                Trx = GetSignedTransaction()
            };
            var resp = Api.GetPotentialSignatures(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_potential_signatures", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void verify_authority()
        {
            var args = new VerifyAuthorityArgs
            {
                Trx = GetSignedTransaction()
            };
            var resp = Api.VerifyAuthority(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "verify_authority", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void verify_account_authority()
        {
            var args = new VerifyAccountAuthorityArgs()
            {
                Account = User.Login,
                Signers = new PublicKeyType[0]
            };
            var resp = Api.VerifyAccountAuthority(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "verify_account_authority", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void verify_signatures()
        {
            var args = new VerifySignaturesArgs();
            var resp = Api.VerifySignatures(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "verify_signatures", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_smt_next_identifier()
        {
            var confResp = Api.GetConfig(CancellationToken.None);
            if (!confResp.IsError)
            {
                dynamic conf = confResp.Result;
                var isEnableSmt = (bool)conf.STEEM_ENABLE_SMT;

                if (isEnableSmt)
                {
                    var resp = Api.GetSmtNextIdentifier(CancellationToken.None);
                    Console.WriteLine(resp.Error);
                    Assert.IsFalse(resp.IsError);
                    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

                    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.DatabaseApi, "get_smt_next_identifier", CancellationToken.None);
                    TestPropetries(resp.Result.GetType(), obj.Result);
                    Console.WriteLine("----------------------------------------------------------------------------");
                    Console.WriteLine(JsonConvert.SerializeObject(obj));
                }
            }
        }
    }
}
