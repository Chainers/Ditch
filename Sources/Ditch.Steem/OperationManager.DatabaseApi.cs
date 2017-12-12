using System;
using System.Collections.Generic;
using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Enums;
using Ditch.Steem.Objects;

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
    /// libraries\app\include\steemit\app\database_api.hpp
    /// </summary>
    public partial class OperationManager
    {


        ///////////////////
        // Subscriptions //
        ///////////////////

        /*

        /// <summary>
        /// API name: set_block_applied_callback
        /// 
        /// </summary>
        /// <param name="cb">API type: std::function&lt;void(variant block_header)></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: void</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse SetBlockAppliedCallback(Function<object> cb, CancellationToken token)
        {
            return CallRequest(KnownApiNames.DatabaseApi, "set_block_applied_callback", new object[] {cb}, token);
        }

        */


        /// <summary>
        /// API name: get_trending_tags
        /// *Returns a list of tags (tags) that include word combinations
        /// 
        /// </summary>
        /// <param name="afterTag">API type: string</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: tag_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<TagApiObj[]> GetTrendingTags(string afterTag, UInt32 limit, CancellationToken token)
        {
            return CallRequest<TagApiObj[]>(KnownApiNames.DatabaseApi, "get_trending_tags", new object[] { afterTag, limit }, token);
        }

        /// <summary>
        /// API name: get_state
        /// This API is a short-cut for returning all of the state required for a particular URL
        /// with a single query.
        ///
        /// *Displays the current network status.
        /// 
        /// </summary>
        /// <param name="path">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: state</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<State> GetState(string path, CancellationToken token)
        {
            return CallRequest<State>(KnownApiNames.DatabaseApi, "get_state", new object[] { path }, token);
        }

        /// <summary>
        /// API name: get_active_witnesses
        /// *Displays a list of all active delegates.
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_name_type</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string[]> GetActiveWitnesses(CancellationToken token)
        {
            return CallRequest<string[]>(KnownApiNames.DatabaseApi, "get_active_witnesses", new object[] { }, token);
        }

        /// <summary>
        /// API name: get_miner_queue
        /// *Creates a list of the miners waiting to enter the DPOW chain to create the block.
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_name_type</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string[]> GetMinerQueue(CancellationToken token)
        {
            return CallRequest<string[]>(KnownApiNames.DatabaseApi, "get_miner_queue", new object[] { }, token);
        }

        /////////////////////////////
        // Blocks and transactions //
        /////////////////////////////

        /// <summary>
        /// API name: get_block_header
        /// Retrieve a block header
        ///
        /// *Returns block for given number
        /// 
        /// </summary>
        /// <param name="blockNum">API type: uint32_t Height of the block whose header should be returned</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: block_header header of the referenced block, or null if no matching block was found</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<BlockHeader> GetBlockHeader(UInt32 blockNum, CancellationToken token)
        {
            return CallRequest<BlockHeader>(KnownApiNames.DatabaseApi, "get_block_header", new object[] { blockNum }, token);
        }

        /// <summary>
        /// API name: get_block
        /// Retrieve a full, signed block
        ///
        /// *Returns block for given number
        /// 
        /// </summary>
        /// <param name="blockNum">API type: uint32_t Height of the block to be returned</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: signed_block_api_obj the referenced block, or null if no matching block was found</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<SignedBlockApiObj> GetBlock(UInt32 blockNum, CancellationToken token)
        {
            return CallRequest<SignedBlockApiObj>(KnownApiNames.DatabaseApi, "get_block", new object[] { blockNum }, token);
        }

        /// <summary>
        /// API name: get_ops_in_block
        /// Get sequence of operations included/generated within a particular block
        ///
        /// *Returns all operations in the block, if the parameter 'onlyVirtual' is true, then returns only the virtual operations
        /// 
        /// </summary>
        /// <param name="blockNum">API type: uint32_t Height of the block whose generated virtual operations should be returned</param>
        /// <param name="onlyVirtual">API type: bool Whether to only include virtual operations in returned results (default: true)</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: applied_operation sequence of operations included/generated within the block</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AppliedOperation[]> GetOpsInBlock(UInt32 blockNum, bool onlyVirtual, CancellationToken token)
        {
            return CallRequest<AppliedOperation[]>(KnownApiNames.DatabaseApi, "get_ops_in_block", new object[] { blockNum, onlyVirtual }, token);
        }

        /////////////
        // Globals //
        /////////////

        /// <summary>
        /// API name: get_config
        /// Retrieve compile-time constants
        ///
        /// *Displays the current node configuration.
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: variant_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<object> GetConfig(CancellationToken token)
        {
            return CallRequest<object>(KnownApiNames.DatabaseApi, "get_config", new object[] { }, token);
        }

        /// <summary>
        /// API name: get_dynamic_global_properties
        /// Retrieve the current @ref dynamic_global_property_object
        ///
        /// *Displays information about the current network status.
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: dynamic_global_property_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<DynamicGlobalPropertyApiObj> GetDynamicGlobalProperties(CancellationToken token)
        {
            return CallRequest<DynamicGlobalPropertyApiObj>(KnownApiNames.DatabaseApi, "get_dynamic_global_properties", new object[] { }, token);
        }

        /// <summary>
        /// API name: get_chain_properties
        /// *Displays the commission for creating the user, the maximum block size and the GBG interest rate.
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: chain_properties</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ChainProperties> GetChainProperties(CancellationToken token)
        {
            return CallRequest<ChainProperties>(KnownApiNames.DatabaseApi, "get_chain_properties", new object[] { }, token);
        }

        /// <summary>
        /// API name: get_current_median_history_price
        /// *Displays the current median price of conversion
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: price</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Price> GetCurrentMedianHistoryPrice(CancellationToken token)
        {
            return CallRequest<Price>(KnownApiNames.DatabaseApi, "get_current_median_history_price", new object[] { }, token);
        }

        /// <summary>
        /// API name: get_feed_history
        /// *Displays the conversion history
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: feed_history_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FeedHistoryApiObj> GetFeedHistory(CancellationToken token)
        {
            return CallRequest<FeedHistoryApiObj>(KnownApiNames.DatabaseApi, "get_feed_history", new object[] { }, token);
        }

        /// <summary>
        /// API name: get_witness_schedule
        /// *Displays the current delegation status.
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: witness_schedule_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WitnessScheduleApiObj> GetWitnessSchedule(CancellationToken token)
        {
            return CallRequest<WitnessScheduleApiObj>(KnownApiNames.DatabaseApi, "get_witness_schedule", new object[] { }, token);
        }

        /// <summary>
        /// API name: get_hardfork_version
        /// *Displays the current version of the network.
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: hardfork_version</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string> GetHardforkVersion(CancellationToken token)
        {
            return CallRequest<string>(KnownApiNames.DatabaseApi, "get_hardfork_version", new object[] { }, token);
        }

        /// <summary>
        /// API name: get_next_scheduled_hardfork
        /// *Displays the date and version of HardFork
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: scheduled_hardfork</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ScheduledHardfork> GetNextScheduledHardfork(CancellationToken token)
        {
            return CallRequest<ScheduledHardfork>(KnownApiNames.DatabaseApi, "get_next_scheduled_hardfork", new object[] { }, token);
        }

        /*

        /// <summary>
        /// API name: get_reward_fund
        /// 
        /// </summary>
        /// <param name="name">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: reward_fund_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<RewardFundApiObj> GetRewardFund(string name, CancellationToken token)
        {
            return CallRequest<RewardFundApiObj>(KnownApiNames.DatabaseApi, "get_reward_fund", new object[] {name}, token);
        }

        */


        //////////
        // Keys //
        //////////


        /// <summary>
        /// API name: get_key_references
        /// 
        /// </summary>
        /// <param name="key">API type: vector&lt;public_key_type></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: string</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string[]> GetKeyReferences(object[] key, CancellationToken token)
        {
            return CallRequest<string[]>(KnownApiNames.DatabaseApi, "get_key_references", new object[] { key }, token);
        }


        //////////////
        // Accounts //
        //////////////


        /// <summary>
        /// API name: get_accounts
        /// *Returns data for specified accounts
        /// 
        /// </summary>
        /// <param name="names">API type: vector&lt;string></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: extended_account</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ExtendedAccount[]> GetAccounts(string[] names, CancellationToken token)
        {
            return CallRequest<ExtendedAccount[]>(KnownApiNames.DatabaseApi, "get_accounts", new object[] { names }, token);
        }

        /// <summary>
        /// API name: get_account_references
        /// 
        /// </summary>
        /// <param name="accountId">API type: account_id_type</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_id_type all accounts that referr to the key or account id in their owner or active authorities.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<object> GetAccountReferences(object accountId, CancellationToken token)
        {
            return CallRequest<object>(KnownApiNames.DatabaseApi, "get_account_references", new object[] { accountId }, token);
        }

        /// <summary>
        /// API name: lookup_account_names
        /// Get a list of accounts by name
        ///
        /// *Returns data for specified accounts
        /// 
        /// </summary>
        /// <param name="accountNames">API type: vector&lt;string> Names of the accounts to retrieve</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_api_obj The accounts holding the provided names
        /// 
        /// This function has semantics identical to @ref get_objects</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountApiObj[]> LookupAccountNames(string[] accountNames, CancellationToken token)
        {
            return CallRequest<AccountApiObj[]>(KnownApiNames.DatabaseApi, "lookup_account_names", new object[] { accountNames }, token);
        }

        /// <summary>
        /// API name: lookup_accounts
        /// Get names and IDs for registered accounts
        ///
        /// *Returns the names of users close to the phrase.
        /// 
        /// </summary>
        /// <param name="lowerBoundName">API type: string Lower bound of the first name to return</param>
        /// <param name="limit">API type: uint32_t Maximum number of results to return -- must not exceed 1000</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: string Map of account names to corresponding IDs</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string[]> LookupAccounts(string lowerBoundName, UInt32 limit, CancellationToken token)
        {
            return CallRequest<string[]>(KnownApiNames.DatabaseApi, "lookup_accounts", new object[] { lowerBoundName, limit }, token);
        }

        /// <summary>
        /// API name: get_account_count
        /// Get the total number of accounts registered with the blockchain
        ///
        /// *Returns the number of registered users.
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: uint64_t</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<UInt64> GetAccountCount(CancellationToken token)
        {
            return CallRequest<UInt64>(KnownApiNames.DatabaseApi, "get_account_count", new object[] { }, token);
        }

        /// <summary>
        /// API name: get_owner_history
        /// *Displays the user name if he changed the ownership of the blockchain
        /// 
        /// </summary>
        /// <param name="account">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: owner_authority_history_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<OwnerAuthorityHistoryApiObj[]> GetOwnerHistory(string account, CancellationToken token)
        {
            return CallRequest<OwnerAuthorityHistoryApiObj[]>(KnownApiNames.DatabaseApi, "get_owner_history", new object[] { account }, token);
        }

        /// <summary>
        /// API name: get_recovery_request
        /// *Returns true if the user is in recovery status.
        /// 
        /// </summary>
        /// <param name="account">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_recovery_request_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountRecoveryRequestApiObj> GetRecoveryRequest(string account, CancellationToken token)
        {
            return CallRequest<AccountRecoveryRequestApiObj>(KnownApiNames.DatabaseApi, "get_recovery_request", new object[] { account }, token);
        }

        /// <summary>
        /// API name: get_escrow
        /// *Returns the operations implemented through mediation.
        /// 
        /// </summary>
        /// <param name="from">API type: string</param>
        /// <param name="escrowId">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: escrow_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<EscrowApiObj> GetEscrow(string from, UInt32 escrowId, CancellationToken token)
        {
            return CallRequest<EscrowApiObj>(KnownApiNames.DatabaseApi, "get_escrow", new object[] { from, escrowId }, token);
        }

        /// <summary>
        /// API name: get_withdraw_routes
        /// *Returns all transfers to the user's account, depending on the type
        /// 
        /// </summary>
        /// <param name="account">API type: string</param>
        /// <param name="type">API type: withdraw_route_type</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: withdraw_route</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WithdrawRoute[]> GetWithdrawRoutes(string account, WithdrawRouteType type, CancellationToken token)
        {
            return CallRequest<WithdrawRoute[]>(KnownApiNames.DatabaseApi, "get_withdraw_routes", new object[] { account, type }, token);
        }

        /// <summary>
        /// API name: get_account_bandwidth
        /// *Displays user actions based on type
        /// 
        /// </summary>
        /// <param name="account">API type: string</param>
        /// <param name="type">API type: witness::bandwidth_type</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_bandwidth_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountBandwidthApiObj> GetAccountBandwidth(string account, BandwidthType type, CancellationToken token)
        {
            return CallRequest<AccountBandwidthApiObj>(KnownApiNames.DatabaseApi, "get_account_bandwidth", new object[] { account, type }, token);
        }

        /// <summary>
        /// API name: get_savings_withdraw_from
        /// *Returns the output data from 'SAFE' for this user
        /// 
        /// </summary>
        /// <param name="account">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: savings_withdraw_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<SavingsWithdrawApiObj[]> GetSavingsWithdrawFrom(string account, CancellationToken token)
        {
            return CallRequest<SavingsWithdrawApiObj[]>(KnownApiNames.DatabaseApi, "get_savings_withdraw_from", new object[] { account }, token);
        }

        /// <summary>
        /// API name: get_savings_withdraw_to
        /// *Returns the output data from 'SAFE' for this user
        /// 
        /// </summary>
        /// <param name="account">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: savings_withdraw_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<SavingsWithdrawApiObj[]> GetSavingsWithdrawTo(string account, CancellationToken token)
        {
            return CallRequest<SavingsWithdrawApiObj[]>(KnownApiNames.DatabaseApi, "get_savings_withdraw_to", new object[] { account }, token);
        }

        /*

        /// <summary>
        /// API name: get_vesting_delegations
        /// 
        /// </summary>
        /// <param name="account">API type: string</param>
        /// <param name="from">API type: string</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: vesting_delegation_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<VestingDelegationApiObj[]> GetVestingDelegations(string account, string from, UInt32 limit, CancellationToken token)
        {
            return CallRequest<VestingDelegationApiObj[]>(KnownApiNames.DatabaseApi, "get_vesting_delegations", new object[] {account, from, limit}, token);
        }

        /// <summary>
        /// API name: get_expiring_vesting_delegations
        /// 
        /// </summary>
        /// <param name="account">API type: string</param>
        /// <param name="from">API type: time_point_sec</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: vesting_delegation_expiration_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<VestingDelegationExpirationApiObj[]> GetExpiringVestingDelegations(string account, DateTime from, UInt32 limit, CancellationToken token)
        {
            return CallRequest<VestingDelegationExpirationApiObj[]>(KnownApiNames.DatabaseApi, "get_expiring_vesting_delegations", new object[] {account, from, limit}, token);
        }

        */

        ///////////////
        // Witnesses //
        ///////////////

        /// <summary>
        /// API name: get_witnesses
        /// Get a list of witnesses by ID
        ///
        /// *Displays delegate data according to the specified ID
        /// 
        /// </summary>
        /// <param name="witnessIds">API type: vector&lt;witness_id_type> IDs of the witnesses to retrieve</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: witness_api_obj The witnesses corresponding to the provided IDs
        /// 
        /// This function has semantics identical to @ref get_objects</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WitnessApiObj[]> GetWitnesses(object[] witnessIds, CancellationToken token)
        {
            return CallRequest<WitnessApiObj[]>(KnownApiNames.DatabaseApi, "get_witnesses", new object[] { witnessIds }, token);
        }

        /// <summary>
        /// API name: get_conversion_requests
        /// *Returns the current requests for conversion by the specified user
        /// 
        /// </summary>
        /// <param name="accountName">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: convert_request_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ConvertRequestApiObj[]> GetConversionRequests(string accountName, CancellationToken token)
        {
            return CallRequest<ConvertRequestApiObj[]>(KnownApiNames.DatabaseApi, "get_conversion_requests", new object[] { accountName }, token);
        }

        /// <summary>
        /// API name: get_witness_by_account
        /// Get the witness owned by a given account
        ///
        /// *Displays data about the delegate (if it is) according to the data from the request
        /// 
        /// </summary>
        /// <param name="accountName">API type: string The name of the account whose witness should be retrieved</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: witness_api_obj The witness object, or null if the account does not have a witness</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WitnessApiObj> GetWitnessByAccount(string accountName, CancellationToken token)
        {
            return CallRequest<WitnessApiObj>(KnownApiNames.DatabaseApi, "get_witness_by_account", new object[] { accountName }, token);
        }

        /// <summary>
        /// API name: get_witnesses_by_vote
        /// This method is used to fetch witnesses with pagination.
        ///
        /// *Displays a limited list of delegates approving the vote.
        /// 
        /// </summary>
        /// <param name="from">API type: string</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: witness_api_obj an array of `count` witnesses sorted by total votes after witness `from` with at most `limit' results.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WitnessApiObj[]> GetWitnessesByVote(string from, UInt32 limit, CancellationToken token)
        {
            return CallRequest<WitnessApiObj[]>(KnownApiNames.DatabaseApi, "get_witnesses_by_vote", new object[] { from, limit }, token);
        }

        /// <summary>
        /// API name: lookup_witness_accounts
        /// Get names and IDs for registered witnesses
        ///
        /// *Displays a limited list of users who have announced their intention to work as a delegate.
        /// 
        /// </summary>
        /// <param name="lowerBoundName">API type: string Lower bound of the first name to return</param>
        /// <param name="limit">API type: uint32_t Maximum number of results to return -- must not exceed 1000</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_name_type Map of witness names to corresponding IDs</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<object[]> LookupWitnessAccounts(string lowerBoundName, UInt32 limit, CancellationToken token)
        {
            return CallRequest<object[]>(KnownApiNames.DatabaseApi, "lookup_witness_accounts", new object[] { lowerBoundName, limit }, token);
        }

        /// <summary>
        /// API name: get_witness_count
        /// Get the total number of witnesses registered with the blockchain
        ///
        /// *Displays the number of delegates.
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: uint64_t</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<UInt64> GetWitnessCount(CancellationToken token)
        {
            return CallRequest<UInt64>(KnownApiNames.DatabaseApi, "get_witness_count", new object[] { }, token);
        }

        ////////////
        // Market //
        ////////////

        /// <summary>
        /// API name: get_order_book
        /// Gets the current order book for STEEM:SBD market
        ///
        /// *Displays a list of applications on the internal exchange for the purchase and sale of the network
        /// 
        /// </summary>
        /// <param name="limit">API type: uint32_t Maximum number of orders for each side of the spread to return -- Must not exceed 1000</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: order_book</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<OrderBook> GetOrderBook(UInt32 limit, CancellationToken token)
        {
            return CallRequest<OrderBook>(KnownApiNames.DatabaseApi, "get_order_book", new object[] { limit }, token);
        }

        /// <summary>
        /// API name: get_open_orders
        /// *Displays a list of orders on the internal exchange for the purchase and sale on the network for the specified user.
        /// 
        /// </summary>
        /// <param name="owner">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: extended_limit_order</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ExtendedLimitOrder[]> GetOpenOrders(string owner, CancellationToken token)
        {
            return CallRequest<ExtendedLimitOrder[]>(KnownApiNames.DatabaseApi, "get_open_orders", new object[] { owner }, token);
        }

        /*

        /// <summary>
        /// API name: get_liquidity_queue
        /// Gets the current liquidity reward queue.
        ///
        /// 
        /// </summary>
        /// <param name="startAccount">API type: string The account to start the list from, or "" to get the head of the queue</param>
        /// <param name="limit">API type: uint32_t Maxmimum number of accounts to return -- Must not exceed 1000</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: liquidity_balance</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<LiquidityBalance[]> GetLiquidityQueue(string startAccount, UInt32 limit, CancellationToken token)
        {
            return CallRequest<LiquidityBalance[]>(KnownApiNames.DatabaseApi, "get_liquidity_queue", new object[] {startAccount, limit}, token);
        }

        */


        ////////////////////////////
        // Authority / validation //
        ////////////////////////////

        /*

        /// <summary>
        /// API name: get_transaction_hex
        /// Get a hexdump of the serialized binary form of a transaction
        ///
        /// *Displays the HEX transaction string.
        /// 
        /// </summary>
        /// <param name="trx">API type: signed_transaction</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: string</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string> GetTransactionHex(SignedTransaction trx, CancellationToken token)
        {
            return CallRequest<string>(KnownApiNames.DatabaseApi, "get_transaction_hex", new object[] {trx}, token);
        }

        /// <summary>
        /// API name: get_transaction
        /// *Displays transaction details for the specified transaction ID.
        /// 
        /// </summary>
        /// <param name="trxId">API type: transaction_id_type</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: annotated_signed_transaction</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AnnotatedSignedTransaction> GetTransaction(TransactionIdType trxId, CancellationToken token)
        {
            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.DatabaseApi, "get_transaction", new object[] {trxId}, token);
        }

        /// <summary>
        /// API name: get_required_signatures
        /// This API will take a partially signed transaction and a set of public keys that the owner has the ability to sign for
        /// and return the minimal subset of public keys that should add signatures to the transaction.
        ///
        /// 
        /// </summary>
        /// <param name="trx">API type: signed_transaction</param>
        /// <param name="availableKeys">API type: flat_set&lt;public_key_type></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: public_key_type</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<PublicKeyType[]> GetRequiredSignatures(SignedTransaction trx, FlatSet<PublicKeyType> availableKeys, CancellationToken token)
        {
            return CallRequest<PublicKeyType[]>(KnownApiNames.DatabaseApi, "get_required_signatures", new object[] {trx, availableKeys}, token);
        }

        /// <summary>
        /// API name: get_potential_signatures
        /// This method will return the set of all public keys that could possibly sign for a given transaction.  This call can
        /// be used by wallets to filter their set of public keys to just the relevant subset prior to calling @ref get_required_signatures
        /// to get the minimum subset.
        ///
        /// *Displays the potential key for this transaction.
        /// 
        /// </summary>
        /// <param name="trx">API type: signed_transaction</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: public_key_type</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<PublicKeyType[]> GetPotentialSignatures(SignedTransaction trx, CancellationToken token)
        {
            return CallRequest<PublicKeyType[]>(KnownApiNames.DatabaseApi, "get_potential_signatures", new object[] {trx}, token);
        }

        /// <summary>
        /// API name: verify_authority
        /// *Returns TRUE if the transaction is signed correctly
        /// 
        /// </summary>
        /// <param name="trx">API type: signed_transaction</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: bool true of the @ref trx has all of the required signatures, otherwise throws an exception</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<bool> VerifyAuthority(SignedTransaction trx, CancellationToken token)
        {
            return CallRequest<bool>(KnownApiNames.DatabaseApi, "verify_authority", new object[] {trx}, token);
        }

        /// <summary>
        /// API name: verify_account_authority
        /// *Return true if the signers have enough authority to authorize an account
        /// 
        /// </summary>
        /// <param name="nameOrId">API type: string</param>
        /// <param name="signers">API type: flat_set&lt;public_key_type></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: bool true if the signers have enough authority to authorize an account</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<bool> VerifyAccountAuthority(string nameOrId, FlatSet<PublicKeyType> signers, CancellationToken token)
        {
            return CallRequest<bool>(KnownApiNames.DatabaseApi, "verify_account_authority", new object[] {nameOrId, signers}, token);
        }

        /// <summary>
        /// API name: verify_signatures
        /// This is a general purpose API that checks signatures against accounts for an arbitrary sha256 hash
        /// using the existing authority structures in Steem
        ///
        /// 
        /// </summary>
        /// <param name="args">API type: verify_signatures_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: verify_signatures_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<VerifySignaturesReturn> VerifySignatures(VerifySignaturesArgs args, CancellationToken token)
        {
            return CallRequest<VerifySignaturesReturn>(KnownApiNames.DatabaseApi, "verify_signatures", new object[] {args}, token);
        }

        */

        /// <summary>
        /// API name: get_active_votes
        /// *Displays the list of users who voted for the specified entry
        /// 
        /// </summary>
        /// <param name="author">API type: string</param>
        /// <param name="permlink">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: vote_state if permlink is "" then it will return all votes for author</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<VoteState[]> GetActiveVotes(string author, string permlink, CancellationToken token)
        {
            return CallRequest<VoteState[]>(KnownApiNames.DatabaseApi, "get_active_votes", new object[] { author, permlink }, token);
        }

        /*

        /// <summary>
        /// API name: get_account_votes
        /// *Displays all the voices that are displayed by the specified user
        /// 
        /// </summary>
        /// <param name="voter">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_vote</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountVote[]> GetAccountVotes(string voter, CancellationToken token)
        {
            return CallRequest<AccountVote[]>(KnownApiNames.DatabaseApi, "get_account_votes", new object[] {voter}, token);
        }

        */

        /// <summary>
        /// API name: get_content
        /// *Gets information about the publication, with the exception of comments
        /// 
        /// </summary>
        /// <param name="author">API type: string</param>
        /// <param name="permlink">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion> GetContent(string author, string permlink, CancellationToken token)
        {
            return CallRequest<Discussion>(KnownApiNames.DatabaseApi, "get_content", new object[] { author, permlink }, token);
        }

        /// <summary>
        /// API name: get_content_replies
        /// *Displays a list of all comments for the selected publication
        /// 
        /// </summary>
        /// <param name="parent">API type: string</param>
        /// <param name="parentPermlink">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetContentReplies(string parent, string parentPermlink, CancellationToken token)
        {
            return CallRequest<Discussion[]>(KnownApiNames.DatabaseApi, "get_content_replies", new object[] { parent, parentPermlink }, token);
        }


        /// <summary>
        /// API name: get_tags_used_by_author
        /// Used to retrieve top 1000 tags list used by an author sorted by most frequently used
        ///
        /// 
        /// </summary>
        /// <param name="author">API type: string select tags of this author</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>vector of top 1000 tags used by an author sorted by most frequently used</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<KeyValuePair<string, UInt32>[]> GetTagsUsedByAuthor(string author, CancellationToken token)
        {
            return CallRequest<KeyValuePair<string, UInt32>[]>(KnownApiNames.DatabaseApi, "get_tags_used_by_author", new object[] { author }, token);
        }


        /*

        /// <summary>
        /// API name: get_discussions_by_payout
        /// Used to retrieve the list of discussions sorted by net rshares amount
        ///
        /// *Displays a limited number of publications sorted by payments
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query @ref discussion_query</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion vector of discussions sorted by net rshares amount</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByPayout(DiscussionQuery query, CancellationToken token)
        {
            return CallRequest<Discussion[]>(KnownApiNames.DatabaseApi, "get_discussions_by_payout", new object[] {query}, token);
        }

        /// <summary>
        /// API name: get_post_discussions_by_payout
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetPostDiscussionsByPayout(DiscussionQuery query, CancellationToken token)
        {
            return CallRequest<Discussion[]>(KnownApiNames.DatabaseApi, "get_post_discussions_by_payout", new object[] {query}, token);
        }

        /// <summary>
        /// API name: get_comment_discussions_by_payout
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetCommentDiscussionsByPayout(DiscussionQuery query, CancellationToken token)
        {
            return CallRequest<Discussion[]>(KnownApiNames.DatabaseApi, "get_comment_discussions_by_payout", new object[] {query}, token);
        }

        /// <summary>
        /// API name: get_discussions_by_trending
        /// Used to retrieve the list of first payout discussions sorted by rshares^2 amount
        ///
        /// *Displays a limited number of publications beginning with the most expensive of the award.
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query @ref discussion_query</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion vector of first payout mode discussions sorted by rshares^2 amount</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByTrending(DiscussionQuery query, CancellationToken token)
        {
            return CallRequest<Discussion[]>(KnownApiNames.DatabaseApi, "get_discussions_by_trending", new object[] {query}, token);
        }

        /// <summary>
        /// API name: get_discussions_by_created
        /// Used to retrieve the list of discussions sorted by created time
        ///
        /// *Displays a limited number of publications, starting with the newest one.
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query @ref discussion_query</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion vector of discussions sorted by created time</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByCreated(DiscussionQuery query, CancellationToken token)
        {
            return CallRequest<Discussion[]>(KnownApiNames.DatabaseApi, "get_discussions_by_created", new object[] {query}, token);
        }

        /// <summary>
        /// API name: get_discussions_by_active
        /// Used to retrieve the list of discussions sorted by last activity time
        ///
        /// *Displays a limited number of entries in which there was activity since the newest.
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query @ref discussion_query</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion vector of discussions sorted by last activity time</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByActive(DiscussionQuery query, CancellationToken token)
        {
            return CallRequest<Discussion[]>(KnownApiNames.DatabaseApi, "get_discussions_by_active", new object[] {query}, token);
        }

        /// <summary>
        /// API name: get_discussions_by_cashout
        /// Used to retrieve the list of discussions sorted by cashout time
        ///
        /// *Displays a limited number of publications, sorted by the time of payments
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query @ref discussion_query</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion vector of discussions sorted by last cashout time</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByCashout(DiscussionQuery query, CancellationToken token)
        {
            return CallRequest<Discussion[]>(KnownApiNames.DatabaseApi, "get_discussions_by_cashout", new object[] {query}, token);
        }

        /// <summary>
        /// API name: get_discussions_by_votes
        /// Used to retrieve the list of discussions sorted by direct votes amount
        ///
        /// *Displays a limited number of publications, sorted by votes.
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query @ref discussion_query</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion vector of discussions sorted by direct votes amount</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByVotes(DiscussionQuery query, CancellationToken token)
        {
            return CallRequest<Discussion[]>(KnownApiNames.DatabaseApi, "get_discussions_by_votes", new object[] {query}, token);
        }

        /// <summary>
        /// API name: get_discussions_by_children
        /// Used to retrieve the list of discussions sorted by children posts amount
        ///
        /// *Displays a limited number of publications sorted by the number of comments
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query @ref discussion_query</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion vector of discussions sorted by children posts amount</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByChildren(DiscussionQuery query, CancellationToken token)
        {
            return CallRequest<Discussion[]>(KnownApiNames.DatabaseApi, "get_discussions_by_children", new object[] {query}, token);
        }

        /// <summary>
        /// API name: get_discussions_by_hot
        /// Used to retrieve the list of discussions sorted by hot amount
        ///
        /// *Displays a limited number of publications, sorted by popularity.
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query @ref discussion_query</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion vector of discussions sorted by hot amount</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByHot(DiscussionQuery query, CancellationToken token)
        {
            return CallRequest<Discussion[]>(KnownApiNames.DatabaseApi, "get_discussions_by_hot", new object[] {query}, token);
        }

        /// <summary>
        /// API name: get_discussions_by_feed
        /// Used to retrieve the list of discussions from the feed of a specific author
        ///
        /// *Displays a limited number of conversion records for a specific author
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query @ref discussion_query
        /// @attention @ref discussion_query#select_authors must be set and must contain the @ref discussion_query#start_author param if the last one is not null</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion vector of discussions from the feed of authors in @ref discussion_query#select_authors</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByFeed(DiscussionQuery query, CancellationToken token)
        {
            return CallRequest<Discussion[]>(KnownApiNames.DatabaseApi, "get_discussions_by_feed", new object[] {query}, token);
        }

        /// <summary>
        /// API name: get_discussions_by_blog
        /// Used to retrieve the list of discussions from the blog of a specific author
        ///
        /// *Displays a limited number of publications, from a blog of a specific author.
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query @ref discussion_query
        /// @attention @ref discussion_query#select_authors must be set and must contain the @ref discussion_query#start_author param if the last one is not null</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion vector of discussions from the blog of authors in @ref discussion_query#select_authors</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByBlog(DiscussionQuery query, CancellationToken token)
        {
            return CallRequest<Discussion[]>(KnownApiNames.DatabaseApi, "get_discussions_by_blog", new object[] {query}, token);
        }

        /// <summary>
        /// API name: get_discussions_by_comments
        /// *Displays a limited number of publications, from the comments of a particular author.
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByComments(DiscussionQuery query, CancellationToken token)
        {
            return CallRequest<Discussion[]>(KnownApiNames.DatabaseApi, "get_discussions_by_comments", new object[] {query}, token);
        }

        /// <summary>
        /// API name: get_discussions_by_promoted
        /// Used to retrieve the list of discussions sorted by promoted balance amount
        ///
        /// *Displays a limited number of publications sorted by an increased balance amount
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query @ref discussion_query</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion vector of discussions sorted by promoted balance amount</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByPromoted(DiscussionQuery query, CancellationToken token)
        {
            return CallRequest<Discussion[]>(KnownApiNames.DatabaseApi, "get_discussions_by_promoted", new object[] {query}, token);
        }


        /// <summary>
        /// API name: get_replies_by_last_update
        /// Return the active discussions with the highest cumulative pending payouts without respect to category, total
        /// pending payout means the pending payout of all children as well.
        ///
        /// 
        /// </summary>
        /// <param name="startAuthor">API type: account_name_type</param>
        /// <param name="startPermlink">API type: string</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetRepliesByLastUpdate(AccountNameType startAuthor, string startPermlink, UInt32 limit, CancellationToken token)
        {
            return CallRequest<Discussion[]>(KnownApiNames.DatabaseApi, "get_replies_by_last_update", new object[] {startAuthor, startPermlink, limit}, token);
        }
            
        */

        /// <summary>
        /// API name: get_discussions_by_author_before_date
        /// This method is used to fetch all posts/comments by start_author that occur after before_date and start_permlink with up to limit being returned.
        /// 
        /// If start_permlink is empty then only before_date will be considered. If both are specified the eariler to the two metrics will be used. This
        /// should allow easy pagination.
        ///
        /// *Displays a limited number of user publications
        /// 
        /// </summary>
        /// <param name="author">API type: string</param>
        /// <param name="startPermlink">API type: string</param>
        /// <param name="beforeDate">API type: time_point_sec</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByAuthorBeforeDate(string author, string startPermlink, DateTime beforeDate, UInt32 limit, CancellationToken token)
        {
            return CallRequest<Discussion[]>(KnownApiNames.DatabaseApi, "get_discussions_by_author_before_date", new object[] { author, startPermlink, beforeDate, limit }, token);
        }

        /// <summary>
        /// API name: get_account_history
        /// Account operations have sequence numbers from 0 to N where N is the most recent operation. This method
        /// returns operations in the range [from-limit, from]
        /// 
        /// *The history of all user actions on the network in the form of transactions. If from = -1, then are last {limit+1} history elements are shown. Parameter limit should be less or equals {from} (except from = -1). This is because elements preceding {from} are shown.
        /// 
        /// </summary>
        /// <param name="account">API type: string</param>
        /// <param name="from">API type: uint64_t - the absolute sequence number, -1 means most recent, limit is the number of operations before from.</param>
        /// <param name="limit">API type: uint32_t - the maximum number of items that can be queried (0 to 1000], must be less than from</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: map&lt;uint32_t,applied_operation></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<object[]> GetAccountHistory(string account, UInt64 from, UInt32 limit, CancellationToken token)
        {
            return CallRequest<object[]>(KnownApiNames.DatabaseApi, "get_account_history", new object[] { account, from, limit }, token);
        }
    }
}
