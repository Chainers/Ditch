using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Models.Args;
using Ditch.Steem.Models.Return;

namespace Ditch.Steem
{
    /**
    * @brief The database_api class implements the RPC API for the chain database.
    *
    * This API exposes accessors on the database which query state tracked by a blockchain validating node. This API is
    * read-only; all modifications to the database must be performed via transactions. Transactions are broadcast via
    * the @ref network_broadcast_api.
    */

    /// <summary>
    /// database_api
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api.hpp
    /// </summary>
    public partial class OperationManager
    {

        /////////////
        // Globals //
        /////////////

        /// <summary>
        /// API name: get_config
        /// Retrieve compile-time constants
        ///
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_config_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<object> GetConfig(CancellationToken token)
        {
            return CustomGetRequest<object>(KnownApiNames.DatabaseApi, "get_config", token);
        }

        /// <summary>
        /// API name: get_dynamic_global_properties
        /// Retrieve the current @ref dynamic_global_property_object
        ///
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_dynamic_global_properties_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetDynamicGlobalPropertiesReturn> GetDynamicGlobalProperties(CancellationToken token)
        {
            return CustomGetRequest<GetDynamicGlobalPropertiesReturn>(KnownApiNames.DatabaseApi, "get_dynamic_global_properties", token);
        }

        /// <summary>
        /// API name: get_witness_schedule
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_witness_schedule_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetWitnessScheduleReturn> GetWitnessSchedule(CancellationToken token)
        {
            return CustomGetRequest<GetWitnessScheduleReturn>(KnownApiNames.DatabaseApi, "get_witness_schedule", token);
        }

        /// <summary>
        /// API name: get_hardfork_properties
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_hardfork_properties_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetHardforkPropertiesReturn> GetHardforkProperties(CancellationToken token)
        {
            return CustomGetRequest<GetHardforkPropertiesReturn>(KnownApiNames.DatabaseApi, "get_hardfork_properties", token);
        }

        /// <summary>
        /// API name: get_reward_funds
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_reward_funds_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetRewardFundsReturn> GetRewardFunds(CancellationToken token)
        {
            return CustomGetRequest<GetRewardFundsReturn>(KnownApiNames.DatabaseApi, "get_reward_funds", token);
        }

        /// <summary>
        /// API name: get_current_price_feed
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_current_price_feed_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetCurrentPriceFeedReturn> GetCurrentPriceFeed(CancellationToken token)
        {
            return CustomGetRequest<GetCurrentPriceFeedReturn>(KnownApiNames.DatabaseApi, "get_current_price_feed", token);
        }

        /// <summary>
        /// API name: get_feed_history
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_feed_history_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetFeedHistoryReturn> GetFeedHistory(CancellationToken token)
        {
            return CustomGetRequest<GetFeedHistoryReturn>(KnownApiNames.DatabaseApi, "get_feed_history", token);
        }


        ///////////////
        // Witnesses //
        ///////////////

        /// <summary>
        /// API name: list_witnesses
        /// 
        /// </summary>
        /// <param name="args">API type: list_witnesses_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: list_witnesses_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ListWitnessesReturn> ListWitnesses(ListWitnessesArgs args, CancellationToken token)
        {
            return CustomGetRequest<ListWitnessesReturn>(KnownApiNames.DatabaseApi, "list_witnesses", args, token);
        }

        /// <summary>
        /// API name: find_witnesses
        /// 
        /// </summary>
        /// <param name="args">API type: find_witnesses_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: find_witnesses_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FindWitnessesReturn> FindWitnesses(FindWitnessesArgs args, CancellationToken token)
        {
            return CustomGetRequest<FindWitnessesReturn>(KnownApiNames.DatabaseApi, "find_witnesses", args, token);
        }

        /// <summary>
        /// API name: list_witness_votes
        /// 
        /// </summary>
        /// <param name="args">API type: list_witness_votes_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: list_witness_votes_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ListWitnessVotesReturn> ListWitnessVotes(ListWitnessVotesArgs args, CancellationToken token)
        {
            return CustomGetRequest<ListWitnessVotesReturn>(KnownApiNames.DatabaseApi, "list_witness_votes", args, token);
        }

        /// <summary>
        /// API name: get_active_witnesses
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_active_witnesses_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetActiveWitnessesReturn> GetActiveWitnesses(CancellationToken token)
        {
            return CustomGetRequest<GetActiveWitnessesReturn>(KnownApiNames.DatabaseApi, "get_active_witnesses", token);
        }

        //////////////
        // Accounts //
        //////////////

        /// <summary>
        /// API name: list_accounts
        /// List accounts ordered by specified key
        ///
        /// 
        /// </summary>
        /// <param name="args">API type: list_accounts_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: list_accounts_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ListAccountsReturn> ListAccounts(ListAccountsArgs args, CancellationToken token)
        {
            return CustomGetRequest<ListAccountsReturn>(KnownApiNames.DatabaseApi, "list_accounts", args, token);
        }

        /// <summary>
        /// API name: find_accounts
        /// Find accounts by primary key (account name)
        ///
        /// 
        /// </summary>
        /// <param name="args">API type: find_accounts_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: find_accounts_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FindAccountsReturn> FindAccounts(FindAccountsArgs args, CancellationToken token)
        {
            return CustomGetRequest<FindAccountsReturn>(KnownApiNames.DatabaseApi, "find_accounts", args, token);
        }

        /// <summary>
        /// API name: list_owner_histories
        /// 
        /// </summary>
        /// <param name="args">API type: list_owner_histories_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: list_owner_histories_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ListOwnerHistoriesReturn> ListOwnerHistories(ListOwnerHistoriesArgs args, CancellationToken token)
        {
            return CustomGetRequest<ListOwnerHistoriesReturn>(KnownApiNames.DatabaseApi, "list_owner_histories", args, token);
        }

        /// <summary>
        /// API name: find_owner_histories
        /// 
        /// </summary>
        /// <param name="args">API type: find_owner_histories_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: find_owner_histories_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FindOwnerHistoriesReturn> FindOwnerHistories(FindOwnerHistoriesArgs args, CancellationToken token)
        {
            return CustomGetRequest<FindOwnerHistoriesReturn>(KnownApiNames.DatabaseApi, "find_owner_histories", args, token);
        }

        /// <summary>
        /// API name: list_account_recovery_requests
        /// 
        /// </summary>
        /// <param name="args">API type: list_account_recovery_requests_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: list_account_recovery_requests_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ListAccountRecoveryRequestsReturn> ListAccountRecoveryRequests(ListAccountRecoveryRequestsArgs args, CancellationToken token)
        {
            return CustomGetRequest<ListAccountRecoveryRequestsReturn>(KnownApiNames.DatabaseApi, "list_account_recovery_requests", args, token);
        }

        /// <summary>
        /// API name: find_account_recovery_requests
        /// 
        /// </summary>
        /// <param name="args">API type: find_account_recovery_requests_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: find_account_recovery_requests_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FindAccountRecoveryRequestsReturn> FindAccountRecoveryRequests(FindAccountRecoveryRequestsArgs args, CancellationToken token)
        {
            return CustomGetRequest<FindAccountRecoveryRequestsReturn>(KnownApiNames.DatabaseApi, "find_account_recovery_requests", args, token);
        }

        /// <summary>
        /// API name: list_change_recovery_account_requests
        /// 
        /// </summary>
        /// <param name="args">API type: list_change_recovery_account_requests_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: list_change_recovery_account_requests_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ListChangeRecoveryAccountRequestsReturn> ListChangeRecoveryAccountRequests(ListChangeRecoveryAccountRequestsArgs args, CancellationToken token)
        {
            return CustomGetRequest<ListChangeRecoveryAccountRequestsReturn>(KnownApiNames.DatabaseApi, "list_change_recovery_account_requests", args, token);
        }

        /// <summary>
        /// API name: find_change_recovery_account_requests
        /// 
        /// </summary>
        /// <param name="args">API type: find_change_recovery_account_requests_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: find_change_recovery_account_requests_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FindChangeRecoveryAccountRequestsReturn> FindChangeRecoveryAccountRequests(FindChangeRecoveryAccountRequestsArgs args, CancellationToken token)
        {
            return CustomGetRequest<FindChangeRecoveryAccountRequestsReturn>(KnownApiNames.DatabaseApi, "find_change_recovery_account_requests", args, token);
        }

        /// <summary>
        /// API name: list_escrows
        /// 
        /// </summary>
        /// <param name="args">API type: list_escrows_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: list_escrows_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ListEscrowsReturn> ListEscrows(ListEscrowsArgs args, CancellationToken token)
        {
            return CustomGetRequest<ListEscrowsReturn>(KnownApiNames.DatabaseApi, "list_escrows", args, token);
        }

        /// <summary>
        /// API name: find_escrows
        /// 
        /// </summary>
        /// <param name="args">API type: find_escrows_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: find_escrows_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FindEscrowsReturn> FindEscrows(FindEscrowsArgs args, CancellationToken token)
        {
            return CustomGetRequest<FindEscrowsReturn>(KnownApiNames.DatabaseApi, "find_escrows", args, token);
        }

        /// <summary>
        /// API name: list_withdraw_vesting_routes
        /// 
        /// </summary>
        /// <param name="args">API type: list_withdraw_vesting_routes_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: list_withdraw_vesting_routes_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ListWithdrawVestingRoutesReturn> ListWithdrawVestingRoutes(ListWithdrawVestingRoutesArgs args, CancellationToken token)
        {
            return CustomGetRequest<ListWithdrawVestingRoutesReturn>(KnownApiNames.DatabaseApi, "list_withdraw_vesting_routes", args, token);
        }

        /// <summary>
        /// API name: find_withdraw_vesting_routes
        /// 
        /// </summary>
        /// <param name="args">API type: find_withdraw_vesting_routes_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: find_withdraw_vesting_routes_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FindWithdrawVestingRoutesReturn> FindWithdrawVestingRoutes(FindWithdrawVestingRoutesArgs args, CancellationToken token)
        {
            return CustomGetRequest<FindWithdrawVestingRoutesReturn>(KnownApiNames.DatabaseApi, "find_withdraw_vesting_routes", args, token);
        }

        /// <summary>
        /// API name: list_savings_withdrawals
        /// 
        /// </summary>
        /// <param name="args">API type: list_savings_withdrawals_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: list_savings_withdrawals_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ListSavingsWithdrawalsReturn> ListSavingsWithdrawals(ListSavingsWithdrawalsArgs args, CancellationToken token)
        {
            return CustomGetRequest<ListSavingsWithdrawalsReturn>(KnownApiNames.DatabaseApi, "list_savings_withdrawals", args, token);
        }

        /// <summary>
        /// API name: find_savings_withdrawals
        /// 
        /// </summary>
        /// <param name="args">API type: find_savings_withdrawals_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: find_savings_withdrawals_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FindSavingsWithdrawalsReturn> FindSavingsWithdrawals(FindSavingsWithdrawalsArgs args, CancellationToken token)
        {
            return CustomGetRequest<FindSavingsWithdrawalsReturn>(KnownApiNames.DatabaseApi, "find_savings_withdrawals", args, token);
        }

        /// <summary>
        /// API name: list_vesting_delegations
        /// 
        /// </summary>
        /// <param name="args">API type: list_vesting_delegations_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: list_vesting_delegations_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ListVestingDelegationsReturn> ListVestingDelegations(ListVestingDelegationsArgs args, CancellationToken token)
        {
            return CustomGetRequest<ListVestingDelegationsReturn>(KnownApiNames.DatabaseApi, "list_vesting_delegations", args, token);
        }

        /// <summary>
        /// API name: find_vesting_delegations
        /// 
        /// </summary>
        /// <param name="args">API type: find_vesting_delegations_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: find_vesting_delegations_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FindVestingDelegationsReturn> FindVestingDelegations(FindVestingDelegationsArgs args, CancellationToken token)
        {
            return CustomGetRequest<FindVestingDelegationsReturn>(KnownApiNames.DatabaseApi, "find_vesting_delegations", args, token);
        }

        /// <summary>
        /// API name: list_vesting_delegation_expirations
        /// 
        /// </summary>
        /// <param name="args">API type: list_vesting_delegation_expirations_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: list_vesting_delegation_expirations_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ListVestingDelegationExpirationsReturn> ListVestingDelegationExpirations(ListVestingDelegationExpirationsArgs args, CancellationToken token)
        {
            return CustomGetRequest<ListVestingDelegationExpirationsReturn>(KnownApiNames.DatabaseApi, "list_vesting_delegation_expirations", args, token);
        }

        /// <summary>
        /// API name: find_vesting_delegation_expirations
        /// 
        /// </summary>
        /// <param name="args">API type: find_vesting_delegation_expirations_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: find_vesting_delegation_expirations_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FindVestingDelegationExpirationsReturn> FindVestingDelegationExpirations(FindVestingDelegationExpirationsArgs args, CancellationToken token)
        {
            return CustomGetRequest<FindVestingDelegationExpirationsReturn>(KnownApiNames.DatabaseApi, "find_vesting_delegation_expirations", args, token);
        }

        /// <summary>
        /// API name: list_sbd_conversion_requests
        /// 
        /// </summary>
        /// <param name="args">API type: list_sbd_conversion_requests_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: list_sbd_conversion_requests_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ListSbdConversionRequestsReturn> ListSbdConversionRequests(ListSbdConversionRequestsArgs args, CancellationToken token)
        {
            return CustomGetRequest<ListSbdConversionRequestsReturn>(KnownApiNames.DatabaseApi, "list_sbd_conversion_requests", args, token);
        }

        /// <summary>
        /// API name: find_sbd_conversion_requests
        /// 
        /// </summary>
        /// <param name="args">API type: find_sbd_conversion_requests_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: find_sbd_conversion_requests_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FindSbdConversionRequestsReturn> FindSbdConversionRequests(FindSbdConversionRequestsArgs args, CancellationToken token)
        {
            return CustomGetRequest<FindSbdConversionRequestsReturn>(KnownApiNames.DatabaseApi, "find_sbd_conversion_requests", args, token);
        }

        /// <summary>
        /// API name: list_decline_voting_rights_requests
        /// 
        /// </summary>
        /// <param name="args">API type: list_decline_voting_rights_requests_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: list_decline_voting_rights_requests_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ListDeclineVotingRightsRequestsReturn> ListDeclineVotingRightsRequests(ListDeclineVotingRightsRequestsArgs args, CancellationToken token)
        {
            return CustomGetRequest<ListDeclineVotingRightsRequestsReturn>(KnownApiNames.DatabaseApi, "list_decline_voting_rights_requests", args, token);
        }

        /// <summary>
        /// API name: find_decline_voting_rights_requests
        /// 
        /// </summary>
        /// <param name="args">API type: find_decline_voting_rights_requests_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: find_decline_voting_rights_requests_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FindDeclineVotingRightsRequestsReturn> FindDeclineVotingRightsRequests(FindDeclineVotingRightsRequestsArgs args, CancellationToken token)
        {
            return CustomGetRequest<FindDeclineVotingRightsRequestsReturn>(KnownApiNames.DatabaseApi, "find_decline_voting_rights_requests", args, token);
        }


        //////////////
        // Comments //
        //////////////

        /// <summary>
        /// API name: list_comments
        /// 
        /// </summary>
        /// <param name="args">API type: list_comments_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: list_comments_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ListCommentsReturn> ListComments(ListCommentsArgs args, CancellationToken token)
        {
            return CustomGetRequest<ListCommentsReturn>(KnownApiNames.DatabaseApi, "list_comments", args, token);
        }

        /// <summary>
        /// API name: find_comments
        /// 
        /// </summary>
        /// <param name="args">API type: find_comments_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: find_comments_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FindCommentsReturn> FindComments(FindCommentsArgs args, CancellationToken token)
        {
            return CustomGetRequest<FindCommentsReturn>(KnownApiNames.DatabaseApi, "find_comments", args, token);
        }

        /// <summary>
        /// API name: list_votes
        /// 
        /// </summary>
        /// <param name="args">API type: list_votes_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: list_votes_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ListVotesReturn> ListVotes(ListVotesArgs args, CancellationToken token)
        {
            return CustomGetRequest<ListVotesReturn>(KnownApiNames.DatabaseApi, "list_votes", args, token);
        }

        /// <summary>
        /// API name: find_votes
        /// 
        /// </summary>
        /// <param name="args">API type: find_votes_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: find_votes_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FindVotesReturn> FindVotes(FindVotesArgs args, CancellationToken token)
        {
            return CustomGetRequest<FindVotesReturn>(KnownApiNames.DatabaseApi, "find_votes", args, token);
        }


        ////////////
        // Market //
        ////////////

        /// <summary>
        /// API name: list_limit_orders
        /// 
        /// </summary>
        /// <param name="args">API type: list_limit_orders_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: list_limit_orders_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ListLimitOrdersReturn> ListLimitOrders(ListLimitOrdersArgs args, CancellationToken token)
        {
            return CustomGetRequest<ListLimitOrdersReturn>(KnownApiNames.DatabaseApi, "list_limit_orders", args, token);
        }

        /// <summary>
        /// API name: find_limit_orders
        /// 
        /// </summary>
        /// <param name="args">API type: find_limit_orders_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: find_limit_orders_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FindLimitOrdersReturn> FindLimitOrders(FindLimitOrdersArgs args, CancellationToken token)
        {
            return CustomGetRequest<FindLimitOrdersReturn>(KnownApiNames.DatabaseApi, "find_limit_orders", args, token);
        }

        ////////////////////////////
        // Authority / validation //
        ////////////////////////////

        /// @brief Get a hexdump of the serialized binary form of a transaction

        /// <summary>
        /// API name: get_transaction_hex
        /// Get a hexdump of the serialized binary form of a transaction
        ///
        /// 
        /// </summary>
        /// <param name="args">API type: get_transaction_hex_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_transaction_hex_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetTransactionHexReturn> GetTransactionHex(GetTransactionHexArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetTransactionHexReturn>(KnownApiNames.DatabaseApi, "get_transaction_hex", args, token);
        }


        /**
        *  This API will take a partially signed transaction and a set of public keys that the owner has the ability to sign for
        *  and return the minimal subset of public keys that should add signatures to the transaction.
        */

        /// <summary>
        /// API name: get_required_signatures
        /// 
        /// </summary>
        /// <param name="args">API type: get_required_signatures_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_required_signatures_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetRequiredSignaturesReturn> GetRequiredSignatures(GetRequiredSignaturesArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetRequiredSignaturesReturn>(KnownApiNames.DatabaseApi, "get_required_signatures", args, token);
        }


        /**
        *  This method will return the set of all public keys that could possibly sign for a given transaction.  This call can
        *  be used by wallets to filter their set of public keys to just the relevant subset prior to calling @ref get_required_signatures
        *  to get the minimum subset.
        */

        /// <summary>
        /// API name: get_potential_signatures
        /// 
        /// </summary>
        /// <param name="args">API type: get_potential_signatures_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_potential_signatures_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetPotentialSignaturesReturn> GetPotentialSignatures(GetPotentialSignaturesArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetPotentialSignaturesReturn>(KnownApiNames.DatabaseApi, "get_potential_signatures", args, token);
        }

        /// <summary>
        /// API name: verify_authority
        /// 
        /// </summary>
        /// <param name="args">API type: verify_authority_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: verify_authority_return true of the @ref trx has all of the required signatures, otherwise throws an exception</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<VerifyAuthorityReturn> VerifyAuthority(VerifyAuthorityArgs args, CancellationToken token)
        {
            return CustomGetRequest<VerifyAuthorityReturn>(KnownApiNames.DatabaseApi, "verify_authority", args, token);
        }

        /// <summary>
        /// API name: verify_account_authority
        /// 
        /// </summary>
        /// <param name="args">API type: verify_account_authority_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: verify_account_authority_return true if the signers have enough authority to authorize an account</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<VerifyAccountAuthorityReturn> VerifyAccountAuthority(VerifyAccountAuthorityArgs args, CancellationToken token)
        {
            return CustomGetRequest<VerifyAccountAuthorityReturn>(KnownApiNames.DatabaseApi, "verify_account_authority", args, token);
        }


        /*
         * This is a general purpose API that checks signatures against accounts for an arbitrary sha256 hash
         * using the existing authority structures in Steem
         */

        /// <summary>
        /// API name: verify_signatures
        /// 
        /// </summary>
        /// <param name="args">API type: verify_signatures_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: verify_signatures_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<VerifySignaturesReturn> VerifySignatures(VerifySignaturesArgs args, CancellationToken token)
        {
            return CustomGetRequest<VerifySignaturesReturn>(KnownApiNames.DatabaseApi, "verify_signatures", args, token);
        }

        /// <summary>
        /// API name: get_smt_next_identifier
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_smt_next_identifier_return array of Numeric Asset Identifier (NAI) available to be used for new SMT to be created.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetSmtNextIdentifierReturn> GetSmtNextIdentifier(CancellationToken token)
        {
            return CustomGetRequest<GetSmtNextIdentifierReturn>(KnownApiNames.DatabaseApi, "get_smt_next_identifier", token);
        }
    }
}
