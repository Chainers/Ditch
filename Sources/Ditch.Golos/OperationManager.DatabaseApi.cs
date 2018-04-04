using System;
using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Golos.Models.ApiObject;
using Ditch.Golos.Models.Enums;
using Ditch.Golos.Models.Objects;
using Ditch.Golos.Models.Other;

namespace Ditch.Golos
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
    /// libraries\application\include\golos\application\database_api.hpp
    /// </summary>
    public partial class OperationManager
    {
        /// <summary>
        /// API name: get_account_bandwidth
        /// *Displays user actions based on type
        /// 
        /// </summary>
        /// <param name="account">API type: std::string</param>
        /// <param name="type">API type: bandwidth_type</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_bandwidth_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountBandwidthApiObject> GetAccountBandwidth(string account, BandwidthType type, CancellationToken token)
        {
            return CustomGetRequest<AccountBandwidthApiObject>(KnownApiNames.DatabaseApi, "get_account_bandwidth", new object[] { account, type }, token);
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
            return CustomGetRequest<UInt64>(KnownApiNames.DatabaseApi, "get_account_count", token);
        }

        /// <summary>
        /// API name: get_account_history
        /// Account operations have sequence numbers from 0 to N where N is the most recent operation.
        ///
        /// *The history of all user actions on the network in the form of transactions. If from = -1, then are last {limit+1} history elements are shown. Parameter limit should be less or equals {from} (except from = -1). This is because elements preceding {from} are shown.
        /// 
        /// </summary>
        /// <param name="account">API type: std::string</param>
        /// <param name="from">API type: uint64_t - the absolute sequence number, -1 means most recent, limit is the number of operations before from.</param>
        /// <param name="limit">API type: uint32_t - the maximum number of items that can be queried (0 to 1000], must be less than from</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_account_history_return_type</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetAccountHistoryReturnType> GetAccountHistory(string account, UInt64 from, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<GetAccountHistoryReturnType>(KnownApiNames.DatabaseApi, "get_account_history", new object[] { account, from, limit }, token);
        }

        /// <summary>
        /// API name: get_accounts
        /// *Returns data for specified accounts
        /// 
        /// </summary>
        /// <param name="names">API type: std::vector&lt;std::string></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: extended_account</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ExtendedAccount[]> GetAccounts(string[] names, CancellationToken token)
        {
            return CustomGetRequest<ExtendedAccount[]>(KnownApiNames.DatabaseApi, "get_accounts", new object[] { names }, token);
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
            return CustomGetRequest<string[]>(KnownApiNames.DatabaseApi, "get_active_witnesses", token);
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
        /// <returns>API type: signed_block the referenced block, or null if no matching block was found</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<SignedBlock> GetBlock(UInt32 blockNum, CancellationToken token)
        {
            return CustomGetRequest<SignedBlock>(KnownApiNames.DatabaseApi, "get_block", new object[] { blockNum }, token);
        }

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
            return CustomGetRequest<BlockHeader>(KnownApiNames.DatabaseApi, "get_block_header", new object[] { blockNum }, token);
        }

        /// <summary>
        /// API name: get_chain_properties
        /// *Displays the commission for creating the user, the maximum block size and the GBG interest rate.
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: chain_properties_17</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ChainProperties> GetChainProperties(CancellationToken token)
        {
            return CustomGetRequest<ChainProperties>(KnownApiNames.DatabaseApi, "get_chain_properties", token);
        }

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
        public JsonRpcResponse<T> GetConfig<T>(CancellationToken token)
        {
            return CustomGetRequest<T>(KnownApiNames.DatabaseApi, "get_config", token);
        }

        /// <summary>
        /// API name: get_conversion_requests
        /// *Returns the current requests for conversion by the specified user
        /// 
        /// </summary>
        /// <param name="accountName">API type: std::string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: convert_request_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ConvertRequestApiObject[]> GetConversionRequests(string accountName, CancellationToken token)
        {
            return CustomGetRequest<ConvertRequestApiObject[]>(KnownApiNames.DatabaseApi, "get_conversion_requests", new object[] { accountName }, token);
        }

        /// <summary>
        /// API name: get_current_median_history_price
        /// *Displays the current median price of conversion
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: price_17</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Price> GetCurrentMedianHistoryPrice(CancellationToken token)
        {
            return CustomGetRequest<Price>(KnownApiNames.DatabaseApi, "get_current_median_history_price", token);
        }

        /// <summary>
        /// API name: get_dynamic_global_properties
        /// Retrieve the current @ref dynamic_global_property_object
        ///
        /// *Displays information about the current network status.
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: dynamic_global_property_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<DynamicGlobalPropertyApiObject> GetDynamicGlobalProperties(CancellationToken token)
        {
            return CustomGetRequest<DynamicGlobalPropertyApiObject>(KnownApiNames.DatabaseApi, "get_dynamic_global_properties", token);
        }

        /// <summary>
        /// API name: get_escrow
        /// *Returns the operations implemented through mediation.
        /// 
        /// </summary>
        /// <param name="from">API type: std::string</param>
        /// <param name="escrowId">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: escrow_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<EscrowApiObject> GetEscrow(string from, UInt32 escrowId, CancellationToken token)
        {
            return CustomGetRequest<EscrowApiObject>(KnownApiNames.DatabaseApi, "get_escrow", new object[] { from, escrowId }, token);
        }

        /// <summary>
        /// API name: get_feed_history
        /// *Displays the conversion history
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: feed_history_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FeedHistoryApiObject> GetFeedHistory(CancellationToken token)
        {
            return CustomGetRequest<FeedHistoryApiObject>(KnownApiNames.DatabaseApi, "get_feed_history", token);
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
            return CustomGetRequest<string>(KnownApiNames.DatabaseApi, "get_hardfork_version", token);
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
            return CustomGetRequest<string[]>(KnownApiNames.DatabaseApi, "get_miner_queue", token);
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
            return CustomGetRequest<ScheduledHardfork>(KnownApiNames.DatabaseApi, "get_next_scheduled_hardfork", token);
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
            return CustomGetRequest<AppliedOperation[]>(KnownApiNames.DatabaseApi, "get_ops_in_block", new object[] { blockNum, onlyVirtual }, token);
        }

        /// <summary>
        /// API name: get_owner_history
        /// *Displays the user name if he changed the ownership of the blockchain
        /// 
        /// </summary>
        /// <param name="account">API type: std::string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: owner_authority_history_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<OwnerAuthorityHistoryApiObject[]> GetOwnerHistory(string account, CancellationToken token)
        {
            return CustomGetRequest<OwnerAuthorityHistoryApiObject[]>(KnownApiNames.DatabaseApi, "get_owner_history", new object[] { account }, token);
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
            return CustomGetRequest<PublicKeyType[]>(KnownApiNames.DatabaseApi, "get_potential_signatures", new object[] { trx }, token);
        }

        /// <summary>
        /// API name: get_recovery_request
        /// *Returns true if the user is in recovery status.
        /// 
        /// </summary>
        /// <param name="account">API type: std::string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_recovery_request_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountRecoveryRequestApiObject> GetRecoveryRequest(string account, CancellationToken token)
        {
            return CustomGetRequest<AccountRecoveryRequestApiObject>(KnownApiNames.DatabaseApi, "get_recovery_request", new object[] { account }, token);
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
        public JsonRpcResponse<PublicKeyType[]> GetRequiredSignatures(SignedTransaction trx, PublicKeyType[] availableKeys, CancellationToken token)
        {
            return CustomGetRequest<PublicKeyType[]>(KnownApiNames.DatabaseApi, "get_required_signatures", new object[] { trx, availableKeys }, token);
        }

        /// <summary>
        /// API name: get_savings_withdraw_from
        /// *Returns the output data from 'SAFE' for this user
        /// 
        /// </summary>
        /// <param name="account">API type: std::string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: savings_withdraw_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<SavingsWithdrawApiObject[]> GetSavingsWithdrawFrom(string account, CancellationToken token)
        {
            return CustomGetRequest<SavingsWithdrawApiObject[]>(KnownApiNames.DatabaseApi, "get_savings_withdraw_from", new object[] { account }, token);
        }

        /// <summary>
        /// API name: get_savings_withdraw_to
        /// *Returns the output data from 'SAFE' for this user
        /// 
        /// </summary>
        /// <param name="account">API type: std::string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: savings_withdraw_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<SavingsWithdrawApiObject[]> GetSavingsWithdrawTo(string account, CancellationToken token)
        {
            return CustomGetRequest<SavingsWithdrawApiObject[]>(KnownApiNames.DatabaseApi, "get_savings_withdraw_to", new object[] { account }, token);
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
        public JsonRpcResponse<AnnotatedSignedTransaction> GetTransaction(string trxId, CancellationToken token)
        {
            return CustomGetRequest<AnnotatedSignedTransaction>(KnownApiNames.DatabaseApi, "get_transaction", new object[] { trxId }, token);
        }

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
            return CustomGetRequest<string>(KnownApiNames.DatabaseApi, "get_transaction_hex", new object[] { trx }, token);
        }

        /// <summary>
        /// API name: get_withdraw_routes
        /// *Returns all transfers to the user's account, depending on the type
        /// 
        /// </summary>
        /// <param name="account">API type: std::string</param>
        /// <param name="type">API type: withdraw_route_type</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: withdraw_route</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WithdrawRoute[]> GetWithdrawRoutes(string account, WithdrawRouteType type, CancellationToken token)
        {
            return CustomGetRequest<WithdrawRoute[]>(KnownApiNames.DatabaseApi, "get_withdraw_routes", new object[] { account, type }, token);
        }

        /// <summary>
        /// API name: get_witness_by_account
        /// Get the witness owned by a given account
        ///
        /// *Displays data about the delegate (if it is) according to the data from the request
        /// 
        /// </summary>
        /// <param name="accountName">API type: std::string The name of the account whose witness should be retrieved</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: witness_api_object The witness object, or null if the account does not have a witness</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WitnessApiObject> GetWitnessByAccount(string accountName, CancellationToken token)
        {
            return CustomGetRequest<WitnessApiObject>(KnownApiNames.DatabaseApi, "get_witness_by_account", new object[] { accountName }, token);
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
            return CustomGetRequest<UInt64>(KnownApiNames.DatabaseApi, "get_witness_count", token);
        }

        /// <summary>
        /// API name: get_witness_schedule
        /// *Displays the current delegation status.
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: witness_schedule_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WitnessScheduleApiObject> GetWitnessSchedule(CancellationToken token)
        {
            return CustomGetRequest<WitnessScheduleApiObject>(KnownApiNames.DatabaseApi, "get_witness_schedule", token);
        }

        /// <summary>
        /// API name: get_witnesses
        /// Get a list of witnesses by ID
        ///
        /// *Displays delegate data according to the specified ID
        /// 
        /// </summary>
        /// <param name="witnessIds">API type: std::vector&lt;witness_object::id_type> IDs of the witnesses to retrieve</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: witness_api_object The witnesses corresponding to the provided IDs
        /// 
        /// This function has semantics identical to @ref get_objects</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WitnessApiObject[]> GetWitnesses(object[] witnessIds, CancellationToken token)
        {
            return CustomGetRequest<WitnessApiObject[]>(KnownApiNames.DatabaseApi, "get_witnesses", new object[] { witnessIds }, token);
        }

        /// <summary>
        /// API name: get_witnesses_by_vote
        /// This method is used to fetch witnesses with pagination.
        ///
        /// *Displays a limited list of delegates approving the vote.
        /// 
        /// </summary>
        /// <param name="from">API type: std::string</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: witness_api_object an array of `count` witnesses sorted by total votes after witness `from` with at most `limit' results.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WitnessApiObject[]> GetWitnessesByVote(string from, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<WitnessApiObject[]>(KnownApiNames.DatabaseApi, "get_witnesses_by_vote", new object[] { from, limit }, token);
        }

        /// <summary>
        /// API name: lookup_account_names
        /// Get a list of accounts by name
        ///
        /// *Returns data for specified accounts
        /// 
        /// </summary>
        /// <param name="accountNames">API type: std::vector&lt;std::string> Names of the accounts to retrieve</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_api_object The accounts holding the provided names
        /// 
        /// This function has semantics identical to @ref get_objects</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountApiObject[]> LookupAccountNames(string[] accountNames, CancellationToken token)
        {
            return CustomGetRequest<AccountApiObject[]>(KnownApiNames.DatabaseApi, "lookup_account_names", new object[] { accountNames }, token);
        }

        /// <summary>
        /// API name: lookup_accounts
        /// Get names and IDs for registered accounts
        ///
        /// *Returns the names of users close to the phrase.
        /// 
        /// </summary>
        /// <param name="lowerBoundName">API type: std::string Lower bound of the first name to return</param>
        /// <param name="limit">API type: uint32_t Maximum number of results to return -- must not exceed 1000</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: string Map of account names to corresponding IDs</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string[]> LookupAccounts(string lowerBoundName, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<string[]>(KnownApiNames.DatabaseApi, "lookup_accounts", new object[] { lowerBoundName, limit }, token);
        }

        /// <summary>
        /// API name: lookup_witness_accounts
        /// Get names and IDs for registered witnesses
        ///
        /// *Displays a limited list of users who have announced their intention to work as a delegate.
        /// 
        /// </summary>
        /// <param name="lowerBoundName">API type: std::string Lower bound of the first name to return</param>
        /// <param name="limit">API type: uint32_t Maximum number of results to return -- must not exceed 1000</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_name_type Map of witness names to corresponding IDs</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string[]> LookupWitnessAccounts(string lowerBoundName, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<string[]>(KnownApiNames.DatabaseApi, "lookup_witness_accounts", new object[] { lowerBoundName, limit }, token);
        }

        /// <summary>
        /// API name: set_block_applied_callback
        /// Set callback which is triggered on each generated block
        ///
        /// 
        /// </summary>
        /// <param name="args">API type: object</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: void_type</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse SetBlockAppliedCallback(Object args, CancellationToken token)
        {
            return CustomGetRequest(KnownApiNames.DatabaseApi, "set_block_applied_callback", new object[] { args }, token);
        }

        /// <summary>
        /// API name: verify_account_authority
        /// *Return true if the signers have enough authority to authorize an account
        /// 
        /// </summary>
        /// <param name="name">API type: std::string</param>
        /// <param name="signers">API type: flat_set&lt;public_key_type></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: bool true if the signers have enough authority to authorize an account</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<bool> VerifyAccountAuthority(string name, PublicKeyType[] signers, CancellationToken token)
        {
            return CustomGetRequest<bool>(KnownApiNames.DatabaseApi, "verify_account_authority", new object[] { name, signers }, token);
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
            return CustomGetRequest<bool>(KnownApiNames.DatabaseApi, "verify_authority", new object[] { trx }, token);
        }
    }
}
