using System;
using System.Collections.Generic;
using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Operations;
using Ditch.Steem.Operations.Enums;
using Ditch.Steem.Operations.Get;
using Newtonsoft.Json.Linq;

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

        ///// <summary>
        ///// API name: set_block_applied_callback
        ///// 
        ///// </summary>
        ///// <param name="cb">API type: std::function&lt;void</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: void</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse SetBlockAppliedCallback(Function<Void> cb, CancellationToken token)
        //{
        //    return CustomGetRequest("set_block_applied_callback", token, cb);
        //}

        /// <summary>
        /// API name: get_trending_tags
        /// 
        /// Returns a list of tags (tags) that include word combinations
        /// Возращает список меток(тэгов) включающие словосочетания
        /// </summary>
        /// <param name="afterTag">API type: string</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: tag_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<TagApiObj[]> GetTrendingTags(string afterTag, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<TagApiObj[]>("get_trending_tags", token, afterTag, limit);
        }


        /**
        *  This API is a short-cut for returning all of the state required for a particular URL
        *  with a single query.
        */
        /// <summary>
        /// API name: get_state
        /// 
        /// This API is a short-cut for returning all of the state required for a particular URL with a single query.
        /// Отображает текущее состояние сети.
        /// </summary>
        /// <param name="path">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: state</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<State> GetState(string path, CancellationToken token)
        {
            return CustomGetRequest<State>("get_state", token, $"[\"{path}\"]");
        }

        /// <summary>
        /// API name: get_active_witnesses
        /// 
        /// Displays a list of all active delegates.
        /// Отображает список всех активных делегатов.
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_name_type</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string[]> GetActiveWitnesses(CancellationToken token)
        {
            return CustomGetRequest<string[]>("get_active_witnesses", token);
        }

        /// <summary>
        /// API name: get_miner_queue
        /// 
        /// Creates a list of the miners waiting to enter the DPOW chain to create the block.
        /// Создает список майнеров, ожидающих попасть в DPOW цепочку, чтобы создать блок.
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_name_type</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string[]> GetMinerQueue(CancellationToken token)
        {
            return CustomGetRequest<string[]>("get_miner_queue", token);
        }


        /////////////////////////////
        // Blocks and transactions //
        /////////////////////////////

        /**
        * @brief Retrieve a block header
        * @param block_num Height of the block whose header should be returned
        * @return header of the referenced block, or null if no matching block was found
        */
        /// <summary>
        /// API name: get_block_header
        /// 
        /// Retrieve a block header
        /// Возвращает все данные о блоке
        /// </summary>
        /// <param name="blockNum">Height of the block whose header should be returned (API type: uint32_t)</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>header of the referenced block, or null if no matching block was found (API type: block_header)</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<BlockHeader> GetBlockHeader(UInt32 blockNum, CancellationToken token)
        {
            return CustomGetRequest<BlockHeader>("get_block_header", token, blockNum);
        }


        /**
        * @brief Retrieve a full, signed block
        * @param block_num Height of the block to be returned
        * @return the referenced block, or null if no matching block was found
        */
        /// <summary>
        /// API name: get_block
        /// 
        /// Retrieve a full, signed block
        /// Возвращает все данные о блоке включая транзакции
        /// </summary>
        /// <param name="blockNum">Height of the block to be returned (API type: uint32_t)</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>the referenced block, or null if no matching block was found (API type: signed_block_api_obj)</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<SignedBlockApiObj> GetBlock(UInt32 blockNum, CancellationToken token)
        {
            return CustomGetRequest<SignedBlockApiObj>("get_block", token, blockNum);
        }


        /**
        *  @brief Get sequence of operations included/generated within a particular block
        *  @param block_num Height of the block whose generated virtual operations should be returned
        *  @param only_virtual Whether to only include virtual operations in returned results (default: true)
        *  @return sequence of operations included/generated within the block
        */
        /// <summary>
        /// API name: get_ops_in_block
        /// 
        /// Get sequence of operations included/generated within a particular block
        /// Возвращает все операции в блоке, если параметр 'onlyVirtual' true то возвращает только виртуальные операции
        /// </summary>
        /// <param name="blockNum">Height of the block whose generated virtual operations should be returned (API type: uint32_t)</param>
        /// <param name="onlyVirtual">Whether to only include virtual operations in returned results (default: true) (API type: bool)</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>sequence of operations included/generated within the block (API type: applied_operation)</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AppliedOperation[]> GetOpsInBlock(UInt32 blockNum, bool onlyVirtual, CancellationToken token)
        {
            return CustomGetRequest<AppliedOperation[]>("get_ops_in_block", token, blockNum, onlyVirtual);
        }


        /////////////
        // Globals //
        /////////////

        /**
        * @brief Retrieve compile-time constants
*/
        /// <summary>
        /// API name: get_config
        /// 
        /// Displays the current node configuration.
        /// Отображает текущую конфигурацию узла.
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: variant_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<object> GetConfig(CancellationToken token)
        {
            return CustomGetRequest<object>("get_config", token);
        }


        /**
        * @brief Return a JSON description of object representations
        */
        /// <summary>
        /// API name: get_schema
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: string</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string> GetSchema(CancellationToken token)
        {
            return CustomGetRequest<string>("get_schema", token);
        }


        /**
        * @brief Retrieve the current @ref dynamic_global_property_object
        */
        /// <summary>
        /// API name: get_dynamic_global_properties
        /// 
        /// Returns the block chain's rapidly-changing properties.
        /// The returned object contains information that changes every block interval
        /// such as the head block number, the next witness, etc.
        /// @see \c get_global_properties() for less-frequently changing properties
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>the dynamic global properties (API type: dynamic_global_property_api_obj)</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<DynamicGlobalPropertyApiObj> GetDynamicGlobalProperties(CancellationToken token)
        {
            return CustomGetRequest<DynamicGlobalPropertyApiObj>("get_dynamic_global_properties", token);
        }

        /// <summary>
        /// API name: get_chain_properties
        /// 
        /// Displays the commission for creating the user, the maximum block size and the GBG interest rate
        /// Отображает комиссию за создание пользователя, максимальный размер блока и процентную ставку GBG.
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: chain_properties</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ChainProperties> GetChainProperties(CancellationToken token)
        {
            return CustomGetRequest<ChainProperties>("get_chain_properties", token);
        }

        /// <summary>
        /// API name: get_current_median_history_price
        /// 
        /// Displays the current median price of conversion
        /// Отображает текущую медианную цену конвертации.
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: price</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Price> GetCurrentMedianHistoryPrice(CancellationToken token)
        {
            return CustomGetRequest<Price>("get_current_median_history_price", token);
        }

        /// <summary>
        /// API name: get_feed_history
        /// 
        /// Displays the conversion history
        /// Отображает историю конверсий.
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: feed_history_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FeedHistoryApiObj> GetFeedHistory(CancellationToken token)
        {
            return CustomGetRequest<FeedHistoryApiObj>("get_feed_history", token);
        }

        /// <summary>
        /// API name: get_witness_schedule
        /// 
        /// Displays the current delegation status.
        /// Отображает текущее состояние делегирования.
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: witness_schedule_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WitnessScheduleApiObj> GetWitnessSchedule(CancellationToken token)
        {
            return CustomGetRequest<WitnessScheduleApiObj>("get_witness_schedule", token);
        }

        /// <summary>
        /// API name: get_hardfork_version
        /// 
        /// Displays the current version of the network.
        /// Отображает текущую версию сети.
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: hardfork_version</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string> GetHardforkVersion(CancellationToken token)
        {
            return CustomGetRequest<string>("get_hardfork_version", token);
        }

        /// <summary>
        /// API name: get_next_scheduled_hardfork
        /// 
        /// Displays the date and version of HardFork
        /// Отображает дату и версию HardFork
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: scheduled_hardfork</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ScheduledHardfork> GetNextScheduledHardfork(CancellationToken token)
        {
            return CustomGetRequest<ScheduledHardfork>("get_next_scheduled_hardfork", token);
        }

        ///// <summary>
        ///// API name: get_reward_fund
        ///// 
        ///// </summary>
        ///// <param name="name">API type: string</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: reward_fund_api_obj</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<RewardFundApiObj> GetRewardFund(string name, CancellationToken token)
        //{
        //    return CustomGetRequest<RewardFundApiObj>("get_reward_fund", token, name);
        //}


        //////////
        // Keys //
        //////////

        /// <summary>
        /// API name: get_key_references
        /// 
        /// Находит и возвращает имена пользователей по публичному ключу
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="keys">API type: vector&lt;public_key_type></param>
        /// <returns>API type: string</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string[][]> GetKeyReferences(CancellationToken token, params object[] keys)
        {
            return CustomGetRequest<string[][]>("call", token, KnownApiNames.AccountByKeyApi, "get_key_references", new object[][] { keys });
        }


        //////////////
        // Accounts //
        //////////////

        /// <summary>
        /// API name: get_accounts
        /// 
        /// Get user accounts by user names
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="names">API type: vector&lt;string></param>
        /// <returns>API type: extended_account</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ExtendedAccount[]> GetAccounts(CancellationToken token, params string[] names)
        {
            return CustomGetRequest<ExtendedAccount[]>("get_accounts", token, new object[][] { names });
        }


        /**
        *  @return all accounts that referr to the key or account id in their owner or active authorities.
        */
        /// <summary>
        /// API name: get_account_references
        /// 
        /// </summary>
        /// <param name="accountId">API type: account_id_type</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>all accounts that referr to the key or account id in their owner or active authorities. (API type: account_id_type)</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<object> GetAccountReferences(UInt64 accountId, CancellationToken token)
        {
            return CustomGetRequest<object>("get_account_references", token, accountId);
        }


        /**
        * @brief Get a list of accounts by name
        * @param account_names Names of the accounts to retrieve
        * @return The accounts holding the provided names
        *
        * This function has semantics identical to @ref get_objects
        */
        /// <summary>
        /// API name: lookup_account_names
        /// 
        /// Get a list of accounts by name
        /// This function has semantics identical to @ref get_objects
        /// Возращает данные по заданным аккаунтам
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="accountNames">Names of the accounts to retrieve (API type: vector&lt;string>)</param>
        /// <returns>The accounts holding the provided names (API type: account_api_obj)</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountApiObj[]> LookupAccountNames(CancellationToken token, params string[] accountNames)
        {
            return CustomGetRequest<AccountApiObj[]>("lookup_account_names", token, new object[][] { accountNames });
        }


        /**
        * @brief Get names and IDs for registered accounts
        * @param lower_bound_name Lower bound of the first name to return
        * @param limit Maximum number of results to return -- must not exceed 1000
        * @return Map of account names to corresponding IDs
        */
        /// <summary>
        /// API name: lookup_accounts
        /// 
        /// Returns the names of users close to the phrase.
        /// Возвращает имена пользователей близких к шаблону.
        /// </summary>
        /// <param name="lowerBoundName">Lower bound of the first name to return (API type: string)</param>
        /// <param name="limit">Maximum number of results to return -- must not exceed 1000 (API type: uint32_t)</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>Map of account names to corresponding IDs (API type: string)</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string[]> LookupAccounts(string lowerBoundName, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<string[]>("lookup_accounts", token, lowerBoundName, limit);
        }


        /**
        * @brief Get the total number of accounts registered with the blockchain
        */
        /// <summary>
        /// API name: get_account_count
        /// 
        /// Get the total number of accounts registered with the blockchain
        /// Возвращает количество зарегестрированных пользователей.
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: uint64_t</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<UInt64> GetAccountCount(CancellationToken token)
        {
            return CustomGetRequest<UInt64>("get_account_count", token);
        }

        /// <summary>
        /// API name: get_owner_history
        /// 
        /// Displays the user name if he changed the ownership of the blockchain
        /// Отображает имя пользователя если он изменил право собственности на блокчейн
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="account">API type: string</param>
        /// <returns>API type: owner_authority_history_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<OwnerAuthorityHistoryApiObj[]> GetOwnerHistory(CancellationToken token, params string[] account)
        {
            return CustomGetRequest<OwnerAuthorityHistoryApiObj[]>("get_owner_history", token, account);
        }

        /// <summary>
        /// API name: get_recovery_request
        /// 
        /// Returns true if the user is in recovery status.
        /// Возвращает true если пользователь в статусе на восстановление.
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="account">API type: string</param>
        /// <returns>API type: account_recovery_request_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountRecoveryRequestApiObj[]> GetRecoveryRequest(CancellationToken token, params string[] account)
        {
            return CustomGetRequest<AccountRecoveryRequestApiObj[]>("get_recovery_request", token, account);
        }

        /// <summary>
        /// API name: get_escrow
        /// 
        /// Returns the operations implemented through mediation.
        /// Возвращает операции реализованные с помощью посредничества.
        /// </summary>
        /// <param name="from">API type: string</param>
        /// <param name="escrowId">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: escrow_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<EscrowApiObj> GetEscrow(string from, UInt32 escrowId, CancellationToken token)
        {
            return CustomGetRequest<EscrowApiObj>("get_escrow", token, from, escrowId);
        }

        /// <summary>
        /// API name: get_withdraw_routes
        /// 
        /// Returns all transfers to the user's account, depending on the type
        /// Возвращает все переводы на счету пользователя в зависимости от типа
        /// </summary>
        /// <param name="account">API type: string</param>
        /// <param name="type">API type: withdraw_route_type</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: withdraw_route</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WithdrawRoute[]> GetWithdrawRoutes(string account, WithdrawRouteType type, CancellationToken token)
        {
            return CustomGetRequest<WithdrawRoute[]>("get_withdraw_routes", token, account, type);
        }

        /// <summary>
        /// API name: get_account_bandwidth
        /// 
        /// Displays user actions based on type
        /// Отображает действия пользователя в зависимости от типа
        /// </summary>
        /// <param name="account">API type: string</param>
        /// <param name="type">API type: witness::bandwidth_type</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_bandwidth_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountBandwidthApiObj> GetAccountBandwidth(string account, BandwidthType type, CancellationToken token)
        {
            return CustomGetRequest<AccountBandwidthApiObj>("get_account_bandwidth", token, account, type);
        }

        /// <summary>
        /// API name: get_savings_withdraw_from
        /// 
        /// Returns the output data from 'SAFE' for this user
        /// Возвращает данные о выводах из 'СЕЙФА' для данного пользователя
        /// </summary>
        /// <param name="account">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: savings_withdraw_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<SavingsWithdrawApiObj[]> GetSavingsWithdrawFrom(string account, CancellationToken token)
        {
            return CustomGetRequest<SavingsWithdrawApiObj[]>("get_savings_withdraw_from", token, $"[\"{account}\"]");
        }

        /// <summary>
        /// API name: get_savings_withdraw_to
        /// 
        /// Returns the output data from 'SAFE' for this user
        /// Возвращает данные о выводах из 'СЕЙФА' для данного пользователя
        /// </summary>
        /// <param name="account">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: savings_withdraw_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<SavingsWithdrawApiObj[]> GetSavingsWithdrawTo(string account, CancellationToken token)
        {
            return CustomGetRequest<SavingsWithdrawApiObj[]>("get_savings_withdraw_to", token, $"[\"{account}\"]");
        }

        ///// <summary>
        ///// API name: get_vesting_delegations
        ///// 
        ///// </summary>
        ///// <param name="account">API type: string</param>
        ///// <param name="from">API type: string</param>
        ///// <param name="limit">API type: uint32_t</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: vesting_delegation_api_obj</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<VestingDelegationApiObj[]> GetVestingDelegations(string account, string from, UInt32 limit, CancellationToken token)
        //{
        //    return CustomGetRequest<VestingDelegationApiObj[]>("get_vesting_delegations", token, account, from, limit);
        //}

        ///// <summary>
        ///// API name: get_expiring_vesting_delegations
        ///// 
        ///// </summary>
        ///// <param name="account">API type: string</param>
        ///// <param name="from">API type: time_point_sec</param>
        ///// <param name="limit">API type: uint32_t</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: vesting_delegation_expiration_api_obj</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<VestingDelegationExpirationApiObj[]> GetExpiringVestingDelegations(string account, DateTime from, UInt32 limit, CancellationToken token)
        //{
        //    return CustomGetRequest<VestingDelegationExpirationApiObj[]>("get_expiring_vesting_delegations", token, account, from, limit);
        //}


        ///////////////
        // Witnesses //
        ///////////////

        /**
        * @brief Get a list of witnesses by ID
        * @param witness_ids IDs of the witnesses to retrieve
        * @return The witnesses corresponding to the provided IDs
        *
        * This function has semantics identical to @ref get_objects
        */
        /// <summary>
        /// API name: get_witnesses
        /// 
        /// Get a list of witnesses by ID
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="witnessIds">IDs of the witnesses to retrieve (API type: vector&lt;witness_id_type>)</param>
        /// <returns>The witnesses corresponding to the provided IDs (API type: witness_api_obj)</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WitnessApiObj[]> GetWitnesses(CancellationToken token, params object[] witnessIds)
        {
            return CustomGetRequest<WitnessApiObj[]>("get_witnesses", token, new object[1][] { witnessIds });
        }

        /// <summary>
        /// API name: get_conversion_requests
        /// 
        /// Returns the current requests for conversion by the specified user
        /// Возвращает текущие запросы на конвертацию указанным пользователем
        /// </summary>
        /// <param name="accountName">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: convert_request_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ConvertRequestApiObj[]> GetConversionRequests(string accountName, CancellationToken token)
        {
            return CustomGetRequest<ConvertRequestApiObj[]>("get_conversion_requests", token, accountName);
        }


        /**
        * @brief Get the witness owned by a given account
        * @param account The name of the account whose witness should be retrieved
        * @return The witness object, or null if the account does not have a witness
        */
        /// <summary>
        /// API name: get_witness_by_account
        /// 
        /// Get the witness owned by a given account
        /// </summary>
        /// <param name="accountName">The name of the account whose witness should be retrieved )API type: string(</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>The witness object, or null if the account does not have a witness (API type: witness_api_obj)</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WitnessApiObj> GetWitnessByAccount(string accountName, CancellationToken token)
        {
            return CustomGetRequest<WitnessApiObj>("get_witness_by_account", token, $"[\"{accountName}\"]");
        }


        /**
        *  This method is used to fetch witnesses with pagination.
        *
        *  @return an array of `count` witnesses sorted by total votes after witness `from` with at most `limit' results.
        */
        /// <summary>
        /// API name: get_witnesses_by_vote
        /// 
        /// This method is used to fetch witnesses with pagination.
        /// </summary>
        /// <param name="from">API type: string</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>An array of `count` witnesses sorted by total votes after witness `from` with at most `limit' results. (API type: witness_api_obj)</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WitnessApiObj[]> GetWitnessesByVote(string from, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<WitnessApiObj[]>("get_witnesses_by_vote", token, from, limit);
        }


        /**
        * @brief Get names and IDs for registered witnesses
        * @param lower_bound_name Lower bound of the first name to return
        * @param limit Maximum number of results to return -- must not exceed 1000
        * @return Map of witness names to corresponding IDs
        */
        /// <summary>
        /// API name: lookup_witness_accounts
        /// 
        /// Get names and IDs for registered witnesses
        /// </summary>
        /// <param name="lowerBoundName">Lower bound of the first name to return (API type: string)</param>
        /// <param name="limit">Maximum number of results to return -- must not exceed 1000 (API type: uint32_t)</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>Map of witness names to corresponding IDs (API type: account_name_type)</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<object[]> LookupWitnessAccounts(string lowerBoundName, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<object[]>("lookup_witness_accounts", token, lowerBoundName, limit);
        }


        /**
        * @brief Get the total number of witnesses registered with the blockchain
        */
        /// <summary>
        /// API name: get_witness_count
        /// 
        /// Get the total number of witnesses registered with the blockchain
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: uint64_t</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<UInt64> GetWitnessCount(CancellationToken token)
        {
            return CustomGetRequest<UInt64>("get_witness_count", token);
        }


        ////////////
        // Market //
        ////////////

        /**
        * @breif Gets the current order book for STEEM:SBD market
        * @param limit Maximum number of orders for each side of the spread to return -- Must not exceed 1000
        */
        /// <summary>
        /// API name: get_order_book
        /// 
        /// Gets the current order book for STEEM:SBD market
        /// </summary>
        /// <param name="limit">Maximum number of orders for each side of the spread to return -- Must not exceed 1000 (API type: uint32_t)</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: order_book</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<OrderBook> GetOrderBook(UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<OrderBook>("get_order_book", token, limit);
        }

        /// <summary>
        /// API name: get_open_orders
        /// 
        /// </summary>
        /// <param name="owner">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: extended_limit_order</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ExtendedLimitOrder[]> GetOpenOrders(string owner, CancellationToken token)
        {
            return CustomGetRequest<ExtendedLimitOrder[]>("get_open_orders", token, $"[\"{owner}\"]");
        }


        ///**
        //* @breif Gets the current liquidity reward queue.
        //* @param start_account The account to start the list from, or "" to get the head of the queue
        //* @param limit Maxmimum number of accounts to return -- Must not exceed 1000
        //*/
        ///// <summary>
        ///// API name: get_liquidity_queue
        ///// 
        ///// </summary>
        ///// <param name="startAccount">API type: string</param>
        ///// <param name="limit">API type: uint32_t</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: liquidity_balance</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<LiquidityBalance[]> GetLiquidityQueue(string startAccount, UInt32 limit, CancellationToken token)
        //{
        //    return CustomGetRequest<LiquidityBalance[]>("get_liquidity_queue", token, startAccount, limit);
        //}


        ////////////////////////////
        // Authority / validation //
        ////////////////////////////

        ///// @brief Get a hexdump of the serialized binary form of a transaction
        ///// <summary>
        ///// API name: get_transaction_hex
        ///// 
        ///// </summary>
        ///// <param name="trx">API type: signed_transaction</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: string</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<string> GetTransactionHex(SignedTransaction trx, CancellationToken token)
        //{
        //    return CustomGetRequest<string>("get_transaction_hex", token, trx);
        //}

        ///// <summary>
        ///// API name: get_transaction
        ///// 
        ///// </summary>
        ///// <param name="trxId">API type: transaction_id_type</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: annotated_signed_transaction</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<AnnotatedSignedTransaction> GetTransaction(TransactionIdType trxId, CancellationToken token)
        //{
        //    return CustomGetRequest<AnnotatedSignedTransaction>("get_transaction", token, trxId);
        //}


        /**
        *  This API will take a partially signed transaction and a set of public keys that the owner has the ability to sign for
        *  and return the minimal subset of public keys that should add signatures to the transaction.
        */
        ///// <summary>
        ///// API name: get_required_signatures
        ///// 
        ///// </summary>
        ///// <param name="trx">API type: signed_transaction</param>
        ///// <param name="availableKeys">API type: flat_set&lt;public_key_type></param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: public_key_type</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<PublicKeyType[]> GetRequiredSignatures(SignedTransaction trx, FlatSet<PublicKeyType> availableKeys, CancellationToken token)
        //{
        //    return CustomGetRequest<PublicKeyType[]>("get_required_signatures", token, trx, availableKeys);
        //}


        ///**
        //*  This method will return the set of all public keys that could possibly sign for a given transaction.  This call can
        //*  be used by wallets to filter their set of public keys to just the relevant subset prior to calling @ref get_required_signatures
        //*  to get the minimum subset.
        //*/
        ///// <summary>
        ///// API name: get_potential_signatures
        ///// 
        ///// </summary>
        ///// <param name="trx">API type: signed_transaction</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: public_key_type</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<PublicKeyType[]> GetPotentialSignatures(SignedTransaction trx, CancellationToken token)
        //{
        //    return CustomGetRequest<PublicKeyType[]>("get_potential_signatures", token, trx);
        //}


        ///**
        //* @return true of the @ref trx has all of the required signatures, otherwise throws an exception
        //*/
        ///// <summary>
        ///// API name: verify_authority
        ///// 
        ///// </summary>
        ///// <param name="trx">API type: signed_transaction</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: bool</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<bool> VerifyAuthority(SignedTransaction trx, CancellationToken token)
        //{
        //    return CustomGetRequest<bool>("verify_authority", token, trx);
        //}


        ///*
        //* @return true if the signers have enough authority to authorize an account
        //*/
        ///// <summary>
        ///// API name: verify_account_authority
        ///// 
        ///// </summary>
        ///// <param name="nameOrId">API type: string</param>
        ///// <param name="signers">API type: flat_set&lt;public_key_type></param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: bool</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<bool> VerifyAccountAuthority(string nameOrId, FlatSet<PublicKeyType> signers, CancellationToken token)
        //{
        //    return CustomGetRequest<bool>("verify_account_authority", token, nameOrId, signers);
        //}


        /**
        *  if permlink is "" then it will return all votes for author
        */
        /// <summary>
        /// API name: get_active_votes
        /// 
        /// </summary>
        /// <param name="author">API type: string</param>
        /// <param name="permlink">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: vote_state</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<VoteState[]> GetActiveVotes(string author, string permlink, CancellationToken token)
        {
            return CustomGetRequest<VoteState[]>("get_active_votes", token, author, permlink);
        }

        ///// <summary>
        ///// API name: get_account_votes
        ///// 
        ///// </summary>
        ///// <param name="voter">API type: string</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: account_vote</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<AccountVote[]> GetAccountVotes(string voter, CancellationToken token)
        //{
        //    return CustomGetRequest<AccountVote[]>("get_account_votes", token, voter);
        //}

        /// <summary>
        /// API name: get_content
        /// 
        /// Get post by author and permlink
        /// </summary>
        /// <param name="author">API type: string</param>
        /// <param name="permlink">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion> GetContent(string author, string permlink, CancellationToken token)
        {
            return CustomGetRequest<Discussion>("get_content", token, author, permlink);
        }

        /// <summary>
        /// API name: get_content_replies
        /// 
        /// </summary>
        /// <param name="parent">API type: string</param>
        /// <param name="parentPermlink">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetContentReplies(string parent, string parentPermlink, CancellationToken token)
        {
            return CustomGetRequest<Discussion[]>("get_content_replies", token, parent, parentPermlink);
        }


        ///@{ tags API
        /** This API will return the top 1000 tags used by an author sorted by most frequently used */
        /// <summary>
        /// API name: get_tags_used_by_author
        /// 
        /// </summary>
        /// <param name="author">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<KeyValuePair<string, UInt32>[]> GetTagsUsedByAuthor(string author, CancellationToken token)
        {
            return CustomGetRequest<KeyValuePair<string, UInt32>[]>("get_tags_used_by_author", token, author);
        }

        ///// <summary>
        ///// API name: get_discussions_by_payout
        ///// 
        ///// </summary>
        ///// <param name="query">API type: discussion_query</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: discussion</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<Discussion[]> GetDiscussionsByPayout(DiscussionQuery query, CancellationToken token)
        //{
        //    return CustomGetRequest<Discussion[]>("get_discussions_by_payout", token, query);
        //}

        ///// <summary>
        ///// API name: get_post_discussions_by_payout
        ///// 
        ///// </summary>
        ///// <param name="query">API type: discussion_query</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: discussion</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<Discussion[]> GetPostDiscussionsByPayout(DiscussionQuery query, CancellationToken token)
        //{
        //    return CustomGetRequest<Discussion[]>("get_post_discussions_by_payout", token, query);
        //}

        ///// <summary>
        ///// API name: get_comment_discussions_by_payout
        ///// 
        ///// </summary>
        ///// <param name="query">API type: discussion_query</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: discussion</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<Discussion[]> GetCommentDiscussionsByPayout(DiscussionQuery query, CancellationToken token)
        //{
        //    return CustomGetRequest<Discussion[]>("get_comment_discussions_by_payout", token, query);
        //}

        ///// <summary>
        ///// API name: get_discussions_by_trending
        ///// 
        ///// </summary>
        ///// <param name="query">API type: discussion_query</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: discussion</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<Discussion[]> GetDiscussionsByTrending(DiscussionQuery query, CancellationToken token)
        //{
        //    return CustomGetRequest<Discussion[]>("get_discussions_by_trending", token, query);
        //}

        ///// <summary>
        ///// API name: get_discussions_by_created
        ///// 
        ///// </summary>
        ///// <param name="query">API type: discussion_query</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: discussion</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<Discussion[]> GetDiscussionsByCreated(DiscussionQuery query, CancellationToken token)
        //{
        //    return CustomGetRequest<Discussion[]>("get_discussions_by_created", token, query);
        //}

        ///// <summary>
        ///// API name: get_discussions_by_active
        ///// 
        ///// </summary>
        ///// <param name="query">API type: discussion_query</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: discussion</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<Discussion[]> GetDiscussionsByActive(DiscussionQuery query, CancellationToken token)
        //{
        //    return CustomGetRequest<Discussion[]>("get_discussions_by_active", token, query);
        //}

        ///// <summary>
        ///// API name: get_discussions_by_cashout
        ///// 
        ///// </summary>
        ///// <param name="query">API type: discussion_query</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: discussion</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<Discussion[]> GetDiscussionsByCashout(DiscussionQuery query, CancellationToken token)
        //{
        //    return CustomGetRequest<Discussion[]>("get_discussions_by_cashout", token, query);
        //}

        ///// <summary>
        ///// API name: get_discussions_by_votes
        ///// 
        ///// </summary>
        ///// <param name="query">API type: discussion_query</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: discussion</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<Discussion[]> GetDiscussionsByVotes(DiscussionQuery query, CancellationToken token)
        //{
        //    return CustomGetRequest<Discussion[]>("get_discussions_by_votes", token, query);
        //}

        ///// <summary>
        ///// API name: get_discussions_by_children
        ///// 
        ///// </summary>
        ///// <param name="query">API type: discussion_query</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: discussion</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<Discussion[]> GetDiscussionsByChildren(DiscussionQuery query, CancellationToken token)
        //{
        //    return CustomGetRequest<Discussion[]>("get_discussions_by_children", token, query);
        //}

        ///// <summary>
        ///// API name: get_discussions_by_hot
        ///// 
        ///// </summary>
        ///// <param name="query">API type: discussion_query</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: discussion</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<Discussion[]> GetDiscussionsByHot(DiscussionQuery query, CancellationToken token)
        //{
        //    return CustomGetRequest<Discussion[]>("get_discussions_by_hot", token, query);
        //}

        ///// <summary>
        ///// API name: get_discussions_by_feed
        ///// 
        ///// </summary>
        ///// <param name="query">API type: discussion_query</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: discussion</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<Discussion[]> GetDiscussionsByFeed(DiscussionQuery query, CancellationToken token)
        //{
        //    return CustomGetRequest<Discussion[]>("get_discussions_by_feed", token, query);
        //}

        ///// <summary>
        ///// API name: get_discussions_by_blog
        ///// 
        ///// </summary>
        ///// <param name="query">API type: discussion_query</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: discussion</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<Discussion[]> GetDiscussionsByBlog(DiscussionQuery query, CancellationToken token)
        //{
        //    return CustomGetRequest<Discussion[]>("get_discussions_by_blog", token, query);
        //}

        ///// <summary>
        ///// API name: get_discussions_by_comments
        ///// 
        ///// </summary>
        ///// <param name="query">API type: discussion_query</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: discussion</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<Discussion[]> GetDiscussionsByComments(DiscussionQuery query, CancellationToken token)
        //{
        //    return CustomGetRequest<Discussion[]>("get_discussions_by_comments", token, query);
        //}

        ///// <summary>
        ///// API name: get_discussions_by_promoted
        ///// 
        ///// </summary>
        ///// <param name="query">API type: discussion_query</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: discussion</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<Discussion[]> GetDiscussionsByPromoted(DiscussionQuery query, CancellationToken token)
        //{
        //    return CustomGetRequest<Discussion[]>("get_discussions_by_promoted", token, query);
        //}


        ///@}

        /**
        *  For each of these filters:
        *     Get root content...
        *     Get any content...
        *     Get root content in category..
        *     Get any content in category...
        *
        *  Return discussions
        *     Total Discussion Pending Payout
        *     Last Discussion Update (or reply)... think
        *     Top Discussions by Total Payout
        *
        *  Return content (comments)
        *     Pending Payout Amount
        *     Pending Payout Time
        *     Creation Date
        *
        */
        ///@{



        /**
        *  Return the active discussions with the highest cumulative pending payouts without respect to category, total
        *  pending payout means the pending payout of all children as well.
        */
        ///// <summary>
        ///// API name: get_replies_by_last_update
        ///// 
        ///// </summary>
        ///// <param name="startAuthor">API type: account_name_type</param>
        ///// <param name="startPermlink">API type: string</param>
        ///// <param name="limit">API type: uint32_t</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: discussion</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<Discussion[]> GetRepliesByLastUpdate(AccountNameType startAuthor, string startPermlink, UInt32 limit, CancellationToken token)
        //{
        //    return CustomGetRequest<Discussion[]>("get_replies_by_last_update", token, startAuthor, startPermlink, limit);
        //}




        /**
        *  This method is used to fetch all posts/comments by start_author that occur after before_date and start_permlink with up to limit being returned.
        *
        *  If start_permlink is empty then only before_date will be considered. If both are specified the eariler to the two metrics will be used. This
        *  should allow easy pagination.
        */
        /// <summary>
        /// API name: get_discussions_by_author_before_date
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
            return CustomGetRequest<Discussion[]>("get_discussions_by_author_before_date", token, author, startPermlink, beforeDate, limit);
        }


        /**
        *  Account operations have sequence numbers from 0 to N where N is the most recent operation. This method
        *  returns operations in the range [from-limit, from]
        *
        *  @param from - the absolute sequence number, -1 means most recent, limit is the number of operations before from.
        *  @param limit - the maximum number of items that can be queried (0 to 1000], must be less than from
        */
        /// <summary>
        /// API name: get_account_history
        /// 
        /// 
        /// История всех действий пользователя в сети в виде транзакций. При from = -1 будут показаны последние {limit+1} элементов истории. Параметр limit не должен превышать from (исключение from = -1), так как показываются предшествующие {from} элементы истории.
        /// </summary>
        /// <param name="account">API type: string</param>
        /// <param name="from">API type: uint64_t</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: map&lt;uint32_t,applied_operation></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<KeyValuePair<UInt32, AppliedOperation>[]> GetAccountHistory(string account, UInt64 from, UInt32 limit, CancellationToken token)
        {
            var buf = CustomGetRequest<JArray[]>("get_account_history", token, account, from, limit);

            if (buf.IsError)
                return new JsonRpcResponse<KeyValuePair<uint, AppliedOperation>[]>(buf.Error);

            var rez = buf.Result;

            if (rez == null)
                return new JsonRpcResponse<KeyValuePair<uint, AppliedOperation>[]>();

            var typedTez = new KeyValuePair<UInt32, AppliedOperation>[rez.Length];
            for (int i = 0; i < typedTez.Length; i++)
            {
                var key = rez[i][0];
                var info = rez[i][1];

                typedTez[i] = new KeyValuePair<UInt32, AppliedOperation>(key.ToObject<UInt32>(), info.ToObject<AppliedOperation>());
            }

            return new JsonRpcResponse<KeyValuePair<uint, AppliedOperation>[]>(typedTez);
        }


        ////////////////////////////
        // Handlers - not exposed //
        ////////////////////////////
        /// <summary>
        /// API name: on_api_startup
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: void</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse OnApiStartup(CancellationToken token)
        {
            return CustomGetRequest("on_api_startup", token);
        }
    }
}
