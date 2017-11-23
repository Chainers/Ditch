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
    public partial class OperationManager
    {
        /*
         * @brief The database_api class implements the RPC API for the chain database.
         *
         * This API exposes accessors on the database which query state tracked by a blockchain validating node. This API is
         * read-only; all modifications to the database must be performed via transactions. Transactions are broadcast via
         * the @ref network_broadcast_api.
         */

        /// <summary>
        /// Returns a list of tags (tags) that include word combinations
        /// Возращает список меток(тэгов) включающие словосочетания
        /// </summary>
        /// <param name="after"></param>
        /// <param name="limit"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<TagApiObj[]> GetTrendingTags(string after, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<TagApiObj[]>("get_trending_tags", token, after, limit);
        }

        /// <summary>
        /// This API is a short-cut for returning all of the state required for a particular URL with a single query.
        /// Отображает текущее состояние сети.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<State> GetState(string path, CancellationToken token)
        {
            return CustomGetRequest<State>("get_state", token, $"[\"{path}\"]");
        }

        /// <summary>
        /// Displays a list of all active delegates.
        /// Отображает список всех активных делегатов.
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string[]> GetActiveWitnesses(CancellationToken token)
        {
            return CustomGetRequest<string[]>("get_active_witnesses", token);
        }

        /// <summary>
        /// Creates a list of the miners waiting to enter the DPOW chain to create the block.
        /// Создает список майнеров, ожидающих попасть в DPOW цепочку, чтобы создать блок.
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string[]> GetMinerQueue(CancellationToken token)
        {
            return CustomGetRequest<string[]>("get_miner_queue", token);
        }


        /////////////////////////////
        // Blocks and transactions //
        /////////////////////////////


        /// <summary>
        /// Retrieve a block header
        /// Возвращает все данные о блоке
        /// </summary>
        /// <param name="blockNum">Height of the block whose header should be returned</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>header of the referenced block, or null if no matching block was found</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<BlockHeader> GetBlockHeader(UInt32 blockNum, CancellationToken token)
        {
            return CustomGetRequest<BlockHeader>("get_block_header", token, blockNum);
        }

        /// <summary>
        /// Retrieve a full, signed block
        /// Возвращает все данные о блоке включая транзакции
        /// </summary>
        /// <param name="blockNum">Height of the block to be returned</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>the referenced block, or null if no matching block was found</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<SignedBlockApiObj> GetBlock(UInt32 blockNum, CancellationToken token)
        {
            return CustomGetRequest<SignedBlockApiObj>("get_block", token, blockNum);
        }

        /// <summary>
        /// Get sequence of operations included/generated within a particular block
        /// Возвращает все операции в блоке, если параметр 'onlyVirtual' true то возвращает только виртуальные операции
        /// </summary>
        /// <param name="blockNum">Height of the block whose generated virtual operations should be returned</param>
        /// <param name="onlyVirtual">Whether to only include virtual operations in returned results (default: true)</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>sequence of operations included/generated within the block</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AppliedOperation[]> GetOpsInBlock(UInt32 blockNum, bool onlyVirtual, CancellationToken token)
        {
            return CustomGetRequest<AppliedOperation[]>("get_ops_in_block", token, blockNum, onlyVirtual);
        }


        /////////////
        // Globals //
        /////////////


        /// <summary>
        /// Displays the current node configuration.
        /// Отображает текущую конфигурацию узла.
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<object> GetConfig(CancellationToken token)
        {
            return CustomGetRequest<object>("get_config", token);
        }

        /// <summary>
        /// Returns the block chain's rapidly-changing properties.
        /// The returned object contains information that changes every block interval
        /// such as the head block number, the next witness, etc.
        /// @see \c get_global_properties() for less-frequently changing properties
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>the dynamic global properties</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<DynamicGlobalPropertyApiObj> GetDynamicGlobalProperties(CancellationToken token)
        {
            return CustomGetRequest<DynamicGlobalPropertyApiObj>("get_dynamic_global_properties", token);
        }

        /// <summary>
        /// Displays the commission for creating the user, the maximum block size and the GBG interest rate
        /// Отображает комиссию за создание пользователя, максимальный размер блока и процентную ставку GBG.
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ChainProperties> GetChainProperties(CancellationToken token)
        {
            return CustomGetRequest<ChainProperties>("get_chain_properties", token);
        }

        /// <summary>
        /// Displays the current median price of conversion
        /// Отображает текущую медианную цену конвертации.
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Price> GetCurrentMedianHistoryPrice(CancellationToken token)
        {
            return CustomGetRequest<Price>("get_current_median_history_price", token);
        }

        /// <summary>
        /// Displays the conversion history
        /// Отображает историю конверсий.
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FeedHistoryApiObj> GetFeedHistory(CancellationToken token)
        {
            return CustomGetRequest<FeedHistoryApiObj>("get_feed_history", token);
        }

        /// <summary>
        /// Displays the current delegation status.
        /// Отображает текущее состояние делегирования.
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WitnessScheduleApiObj> GetWitnessSchedule(CancellationToken token)
        {
            return CustomGetRequest<WitnessScheduleApiObj>("get_witness_schedule", token);
        }

        /// <summary>
        /// Displays the current version of the network.
        /// Отображает текущую версию сети.
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string> GetHardforkVersion(CancellationToken token)
        {
            return CustomGetRequest<string>("get_hardfork_version", token);
        }

        /// <summary>
        /// Displays the date and version of HardFork
        /// Отображает дату и версию HardFork
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ScheduledHardfork> GetNextScheduledHardfork(CancellationToken token)
        {
            return CustomGetRequest<ScheduledHardfork>("get_next_scheduled_hardfork", token);
        }

        //get_reward_fund

        //////////
        // Keys //
        //////////

        /// <summary>
        /// 
        /// Находит и возвращает имена пользователей по публичному ключу
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="keys"></param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string[][]> GetKeyReferences(CancellationToken token, params object[] keys)
        {
            return CustomGetRequest<string[][]>("call", token, KnownApiNames.AccountByKeyApi, "get_key_references", new object[][] { keys });
        }


        //////////////
        // Accounts //
        //////////////

        //get_accounts


        /// <summary>
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>all accounts that referr to the key or account id in their owner or active authorities.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<object> GetAccountReferences(UInt64 accountId, CancellationToken token)
        {
            return CustomGetRequest<object>("get_account_references", token, accountId);
        }

        /// <summary>
        /// Get a list of accounts by name
        /// This function has semantics identical to @ref get_objects
        /// Возращает данные по заданным аккаунтам
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="names">Names of the accounts to retrieve</param>
        /// <returns>The accounts holding the provided names</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountApiObj[]> LookupAccountNames(CancellationToken token, params string[] names)
        {
            return CustomGetRequest<AccountApiObj[]>("lookup_account_names", token, new object[][] { names });
        }

        /// <summary>
        /// Returns the names of users close to the phrase.
        /// Возвращает имена пользователей близких к шаблону.
        /// </summary>
        /// <param name="account">Lower bound of the first name to return</param>
        /// <param name="limit">Maximum number of results to return -- must not exceed 1000</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>Map of account names to corresponding IDs</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string[]> LookupAccounts(string account, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<string[]>("lookup_accounts", token, account, limit);
        }

        /// <summary>
        /// Get the total number of accounts registered with the blockchain
        /// Возвращает количество зарегестрированных пользователей.
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<UInt64> GetAccountCount(CancellationToken token)
        {
            return CustomGetRequest<UInt64>("get_account_count", token);
        }

        /// <summary>
        /// Displays the user name if he changed the ownership of the blockchain
        /// Отображает имя пользователя если он изменил право собственности на блокчейн
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="account"></param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<OwnerAuthorityHistoryApiObj[]> GetOwnerHistory(CancellationToken token, params string[] account)
        {
            return CustomGetRequest<OwnerAuthorityHistoryApiObj[]>("get_owner_history", token, account);
        }

        /// <summary>
        /// Returns true if the user is in recovery status.
        /// Возвращает true если пользователь в статусе на восстановление.
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="account"></param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountRecoveryRequestApiObj[]> GetRecoveryRequest(CancellationToken token, params string[] account)
        {
            return CustomGetRequest<AccountRecoveryRequestApiObj[]>("get_recovery_request", token, account);
        }

        /// <summary>
        /// Returns the operations implemented through mediation.
        /// Возвращает операции реализованные с помощью посредничества.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="escrowId"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<EscrowApiObj> GetEscrow(string from, UInt32 escrowId, CancellationToken token)
        {
            return CustomGetRequest<EscrowApiObj>("get_escrow", token, from, escrowId);
        }

        /// <summary>
        /// Returns all transfers to the user's account, depending on the type
        /// Возвращает все переводы на счету пользователя в зависимости от типа
        /// </summary>
        /// <param name="account"></param>
        /// <param name="type"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WithdrawRoute[]> GetWithdrawRoutes(string account, WithdrawRouteType type, CancellationToken token)
        {
            return CustomGetRequest<WithdrawRoute[]>("get_withdraw_routes", token, account, type.ToString().ToLower());
        }

        /// <summary>
        /// Displays user actions based on type
        /// Отображает действия пользователя в зависимости от типа
        /// </summary>
        /// <param name="account"></param>
        /// <param name="bandwidthType"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountBandwidthApiObj> GetAccountBandwidth(string account, BandwidthType bandwidthType, CancellationToken token)
        {
            return CustomGetRequest<AccountBandwidthApiObj>("get_account_bandwidth", token, account, bandwidthType.ToString().ToLower());
        }

        /// <summary>
        /// Returns the output data from 'SAFE' for this user
        /// Возвращает данные о выводах из 'СЕЙФА' для данного пользователя
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<SavingsWithdrawApiObj[]> GetSavingsWithdrawFrom(string account, CancellationToken token)
        {
            return CustomGetRequest<SavingsWithdrawApiObj[]>("get_savings_withdraw_from", token, $"[\"{account}\"]");
        }

        /// <summary>
        /// Returns the output data from 'SAFE' for this user
        /// Возвращает данные о выводах из 'СЕЙФА' для данного пользователя
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<SavingsWithdrawApiObj[]> GetSavingsWithdrawTo(string account, CancellationToken token)
        {
            return CustomGetRequest<SavingsWithdrawApiObj[]>("get_savings_withdraw_to", token, $"[\"{account}\"]");
        }

        //get_vesting_delegations
        //get_expiring_vesting_delegations


        ///////////////
        // Witnesses //
        ///////////////


        /// <summary>
        /// Get a list of witnesses by ID
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="witnessIds">IDs of the witnesses to retrieve</param>
        /// <returns>The witnesses corresponding to the provided IDs</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WitnessApiObj[]> GetWitnesses(CancellationToken token, params object[] witnessIds)
        {
            return CustomGetRequest<WitnessApiObj[]>("get_witnesses", token, new object[1][] { witnessIds });
        }

        /// <summary>
        /// Returns the current requests for conversion by the specified user
        /// Возвращает текущие запросы на конвертацию указанным пользователем
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ConvertRequestApiObj[]> GetConversionRequests(string owner, CancellationToken token)
        {
            return CustomGetRequest<ConvertRequestApiObj[]>("get_conversion_requests", token, owner);
            //return CustomGetRequest<ConvertRequestApiObj[]>("call", token, KnownApiNames.DatabaseApi, "get_conversion_requests", owner);
        }

        /// <summary>
        /// Get the witness owned by a given account
        /// </summary>
        /// <param name="account">The name of the account whose witness should be retrieved</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>The witness object, or null if the account does not have a witness</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WitnessApiObj> GetWitnessByAccount(string account, CancellationToken token)
        {
            return CustomGetRequest<WitnessApiObj>("get_witness_by_account", token, $"[\"{account}\"]");
        }

        /// <summary>
        /// This method is used to fetch witnesses with pagination.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="limit"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>An array of `count` witnesses sorted by total votes after witness `from` with at most `limit' results.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WitnessApiObj[]> GetWitnessesByVote(string from, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<WitnessApiObj[]>("get_witnesses_by_vote", token, from, limit);
        }

        /// <summary>
        /// Get names and IDs for registered witnesses
        /// </summary>
        /// <param name="lowerBoundName">Lower bound of the first name to return</param>
        /// <param name="limit">Maximum number of results to return -- must not exceed 1000</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>Map of witness names to corresponding IDs</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<object[]> LookupWitnessAccounts(string lowerBoundName, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<object[]>("lookup_witness_accounts", token, lowerBoundName, limit);
        }

        /// <summary>
        /// Get the total number of witnesses registered with the blockchain
        /// </summary>
        public JsonRpcResponse<UInt64> GetWitnessCount(CancellationToken token)
        {
            return CustomGetRequest<UInt64>("get_witness_count", token);
        }


        ////////////
        // Market //
        ////////////


        /// <summary>
        /// Gets the current order book for STEEM:SBD market
        /// </summary>
        /// <param name="limit">Maximum number of orders for each side of the spread to return -- Must not exceed 1000</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: order_book</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<OrderBook> GetOrderBook(UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<OrderBook>("get_order_book", token, limit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ExtendedLimitOrder[]> GetOpenOrders(string owner, CancellationToken token)
        {
            return CustomGetRequest<ExtendedLimitOrder[]>("get_open_orders", token, $"[\"{owner}\"]");
        }


        /// <summary>
        /// 
        /// Возвращает отсортированные по стоимости тэги начиная с заданного или близко к нему похожего.
        /// </summary>
        /// <param name="after"></param>
        /// <param name="limit"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<CategoryApiObj[]> GetTrendingCategories(string after, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<CategoryApiObj[]>("get_trending_categories", token, after, limit);
        }

        public JsonRpcResponse<Discussion[]> GetDiscussionsByAuthorBeforeDate(string author, string startPermlink, DateTime beforeDate, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<Discussion[]>("get_discussions_by_author_before_date", token, author, startPermlink, beforeDate, limit);
        }


        /// <summary>
        /// 
        /// История всех действий пользователя в сети в виде транзакций. При from = -1 будут показаны последние {limit+1} элементов истории. Параметр limit не должен превышать from (исключение from = -1), так как показываются предшествующие {from} элементы истории.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="from"></param>
        /// <param name="limit"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Get post by author and permlink
        /// </summary>
        /// <param name="author"></param>
        /// <param name="permlink"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion> GetContent(string author, string permlink, CancellationToken token)
        {
            return CustomGetRequest<Discussion>("get_content", token, author, permlink);
            //return CustomGetRequest<Discussion>("call", token, KnownApiNames.DatabaseApi, "get_content", author, permlink);
        }

        /// <summary>
        /// Get user accounts by user names
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="userList"></param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ExtendedAccount[]> GetAccounts(CancellationToken token, params string[] userList)
        {
            return CustomGetRequest<ExtendedAccount[]>("get_accounts", token, new object[][] { userList });
        }


        #region follow_api

        /// <summary>
        /// 
        /// Возвращает список: Либо всех подписчиков пользователя 'following'. 
        /// Либо если указано имя пользователя в параметре 'startFollower' возвращается список совпадающих подписчиков.
        /// </summary>
        /// <param name="following"></param>
        /// <param name="startFollower"></param>
        /// <param name="followType"></param>
        /// <param name="limit"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FollowApiObj[]> GetFollowers(string following, string startFollower, FollowType followType, UInt16 limit, CancellationToken token)
        {
            return CustomGetRequest<FollowApiObj[]>("call", token, "follow_api", "get_followers", new object[] { following, startFollower, followType.ToString().ToLower(), limit });
        }

        /// <summary>
        /// 
        /// Aналогично GetFollowers только для подписок
        /// </summary>
        /// <param name="follower"></param>
        /// <param name="startFollowing"></param>
        /// <param name="followType"></param>
        /// <param name="limit"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FollowApiObj[]> GetFollowing(string follower, string startFollowing, FollowType followType, UInt16 limit, CancellationToken token)
        {
            return CustomGetRequest<FollowApiObj[]>("call", token, "follow_api", "get_following", new object[] { follower, startFollowing, followType.ToString().ToLower(), limit });
        }

        #endregion
    }
}