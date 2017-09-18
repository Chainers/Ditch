using System;
using System.Collections.Generic;
using Ditch.JsonRpc;
using Ditch.Operations;
using Ditch.Operations.Enums;
using Ditch.Operations.Get;
using Newtonsoft.Json.Linq;

namespace Ditch
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
        /// <returns></returns>
        public JsonRpcResponse<TagApiObj[]> GetTrendingTags(string after, UInt32 limit)
        {
            return _webSocketManager.GetRequest<TagApiObj[]>("get_trending_tags", after, limit);
        }

        /// <summary>
        /// This API is a short-cut for returning all of the state required for a particular URL with a single query.
        /// Отображает текущее состояние сети.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public JsonRpcResponse<State> GetState(string path)
        {
            return _webSocketManager.GetRequest<State>("get_state", $"[\"{path}\"]");
        }

        /// <summary>
        /// Displays a list of all active delegates.
        /// Отображает список всех активных делегатов.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<string[]> GetActiveWitnesses()
        {
            return _webSocketManager.GetRequest<string[]>("get_active_witnesses");
        }

        /// <summary>
        /// Creates a list of the miners waiting to enter the DPOW chain to create the block.
        /// Создает список майнеров, ожидающих попасть в DPOW цепочку, чтобы создать блок.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<string[]> GetMinerQueue()
        {
            return _webSocketManager.GetRequest<string[]>("get_miner_queue");
        }


        /////////////////////////////
        // Blocks and transactions //
        /////////////////////////////


        /// <summary>
        /// Retrieve a block header
        /// Возвращает все данные о блоке
        /// </summary>
        /// <param name="blockNum">Height of the block whose header should be returned</param>
        /// <returns>header of the referenced block, or null if no matching block was found</returns>
        public JsonRpcResponse<BlockHeader> GetBlockHeader(UInt32 blockNum)
        {
            return _webSocketManager.GetRequest<BlockHeader>("get_block_header", blockNum);
        }

        /// <summary>
        /// Retrieve a full, signed block
        /// Возвращает все данные о блоке включая транзакции
        /// </summary>
        /// <param name="blockNum">Height of the block to be returned</param>
        /// <returns>the referenced block, or null if no matching block was found</returns>
        public JsonRpcResponse<SignedBlockApiObj> GetBlock(UInt32 blockNum)
        {
            return _webSocketManager.GetRequest<SignedBlockApiObj>("get_block", blockNum);
        }

        /// <summary>
        /// Get sequence of operations included/generated within a particular block
        /// Возвращает все операции в блоке, если параметр 'onlyVirtual' true то возвращает только виртуальные операции
        /// </summary>
        /// <param name="blockNum">Height of the block whose generated virtual operations should be returned</param>
        /// <param name="onlyVirtual">Whether to only include virtual operations in returned results (default: true)</param>
        /// <returns>sequence of operations included/generated within the block</returns>
        public JsonRpcResponse<AppliedOperation[]> GetOpsInBlock(UInt32 blockNum, bool onlyVirtual = true)
        {
            return _webSocketManager.GetRequest<AppliedOperation[]>("get_ops_in_block", blockNum, onlyVirtual);
        }


        /////////////
        // Globals //
        /////////////


        /// <summary>
        /// Displays the current node configuration.
        /// Отображает текущую конфигурацию узла.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<object> GetConfig()
        {
            return _webSocketManager.GetRequest<object>("get_config");
        }

        /// <summary>
        /// Return a JSON description of object representations
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<string> GetSchema()
        {
            return _webSocketManager.GetRequest<string>("get_schema");
        }

        /// <summary>
        /// Returns the block chain's rapidly-changing properties.
        /// The returned object contains information that changes every block interval
        /// such as the head block number, the next witness, etc.
        /// @see \c get_global_properties() for less-frequently changing properties
        /// </summary>
        /// <returns>the dynamic global properties</returns>
        public JsonRpcResponse<DynamicGlobalPropertyApiObj> GetDynamicGlobalProperties()
        {
            return _webSocketManager.GetRequest<DynamicGlobalPropertyApiObj>("get_dynamic_global_properties");
        }

        /// <summary>
        /// Displays the commission for creating the user, the maximum block size and the GBG interest rate
        /// Отображает комиссию за создание пользователя, максимальный размер блока и процентную ставку GBG.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<ChainProperties> GetChainProperties()
        {
            return _webSocketManager.GetRequest<ChainProperties>("get_chain_properties");
        }

        /// <summary>
        /// Displays the current median price of conversion
        /// Отображает текущую медианную цену конвертации.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<Price> GetCurrentMedianHistoryPrice()
        {
            return _webSocketManager.GetRequest<Price>("get_current_median_history_price");
        }

        /// <summary>
        /// Displays the conversion history
        /// Отображает историю конверсий.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<FeedHistoryApiObj> GetFeedHistory()
        {
            return _webSocketManager.GetRequest<FeedHistoryApiObj>("get_feed_history");
        }

        /// <summary>
        /// Displays the current delegation status.
        /// Отображает текущее состояние делегирования.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<WitnessScheduleApiObj> GetWitnessSchedule()
        {
            return _webSocketManager.GetRequest<WitnessScheduleApiObj>("get_witness_schedule");
        }

        /// <summary>
        /// Displays the current version of the network.
        /// Отображает текущую версию сети.
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> GetHardforkVersion(params string[][] keys)
        {
            return _webSocketManager.GetRequest<string>("get_hardfork_version");
        }

        /// <summary>
        /// Displays the date and version of HardFork
        /// Отображает дату и версию HardFork
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<ScheduledHardfork> GetNextScheduledHardfork()
        {
            return _webSocketManager.GetRequest<ScheduledHardfork>("get_next_scheduled_hardfork");
        }

        //get_reward_fund

        //////////
        // Keys //
        //////////

        /// <summary>
        /// 
        /// Находит и возвращает имена пользователей по публичному ключу
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public JsonRpcResponse<string[][]> GetKeyReferences(params object[][] keys)
        {
            return _webSocketManager.Call<string[][]>((int)Api.AccountByKeyApi, "get_key_references", keys);
        }


        //////////////
        // Accounts //
        //////////////

        //get_accounts


        /// <summary>
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>all accounts that referr to the key or account id in their owner or active authorities.</returns>
        public JsonRpcResponse<object> GetAccountReferences(UInt64 accountId)
        {
            return _webSocketManager.GetRequest<object>("get_account_references", accountId);
        }

        /// <summary>
        /// Get a list of accounts by name
        /// This function has semantics identical to @ref get_objects
        /// Возращает данные по заданным аккаунтам
        /// </summary>
        /// <param name="names">Names of the accounts to retrieve</param>
        /// <returns>The accounts holding the provided names</returns>
        public JsonRpcResponse<AccountApiObj[]> LookupAccountNames(params string[] names)
        {
            return _webSocketManager.GetRequest<AccountApiObj[]>("lookup_account_names", $"[[\"{string.Join("\", \"", names)}\"]]");
        }

        /// <summary>
        /// Returns the names of users close to the phrase.
        /// Возвращает имена пользователей близких к шаблону.
        /// </summary>
        /// <param name="account">Lower bound of the first name to return</param>
        /// <param name="limit">Maximum number of results to return -- must not exceed 1000</param>
        /// <returns>Map of account names to corresponding IDs</returns>
        public JsonRpcResponse<string[]> LookupAccounts(string account, UInt32 limit)
        {
            return _webSocketManager.GetRequest<string[]>("lookup_accounts", account, limit);
        }

        /// <summary>
        /// Get the total number of accounts registered with the blockchain
        /// Возвращает количество зарегестрированных пользователей.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<UInt64> GetAccountCount()
        {
            return _webSocketManager.GetRequest<UInt64>("get_account_count");
        }

        /// <summary>
        /// Displays the user name if he changed the ownership of the blockchain
        /// Отображает имя пользователя если он изменил право собственности на блокчейн
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public JsonRpcResponse<OwnerAuthorityHistoryApiObj[]> GetOwnerHistory(params string[] account)
        {
            return _webSocketManager.GetRequest<OwnerAuthorityHistoryApiObj[]>("get_owner_history", account);
        }

        /// <summary>
        /// Returns true if the user is in recovery status.
        /// Возвращает true если пользователь в статусе на восстановление.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public JsonRpcResponse<AccountRecoveryRequestApiObj[]> GetRecoveryRequest(params string[] account)
        {
            return _webSocketManager.GetRequest<AccountRecoveryRequestApiObj[]>("get_recovery_request", account);
        }

        /// <summary>
        /// Returns the operations implemented through mediation.
        /// Возвращает операции реализованные с помощью посредничества.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="escrowId"></param>
        /// <returns></returns>
        public JsonRpcResponse<EscrowApiObj> GetEscrow(string from, UInt32 escrowId)
        {
            return _webSocketManager.GetRequest<EscrowApiObj>("get_escrow", from, escrowId);
        }

        /// <summary>
        /// Returns all transfers to the user's account, depending on the type
        /// Возвращает все переводы на счету пользователя в зависимости от типа
        /// </summary>
        /// <param name="account"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public JsonRpcResponse<WithdrawRoute[]> GetWithdrawRoutes(string account, WithdrawRouteType type)
        {
            return _webSocketManager.GetRequest<WithdrawRoute[]>("get_withdraw_routes", account, type.ToString().ToLower());
        }

        /// <summary>
        /// Displays user actions based on type
        /// Отображает действия пользователя в зависимости от типа
        /// </summary>
        /// <param name="account"></param>
        /// <param name="bandwidthType"></param>
        /// <returns></returns>
        public JsonRpcResponse<AccountBandwidthApiObj> GetAccountBandwidth(string account, BandwidthType bandwidthType)
        {
            return _webSocketManager.GetRequest<AccountBandwidthApiObj>("get_account_bandwidth", account, bandwidthType.ToString().ToLower());
        }

        /// <summary>
        /// Returns the output data from 'SAFE' for this user
        /// Возвращает данные о выводах из 'СЕЙФА' для данного пользователя
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public JsonRpcResponse<SavingsWithdrawApiObj[]> GetSavingsWithdrawFrom(string account)
        {
            return _webSocketManager.GetRequest<SavingsWithdrawApiObj[]>("get_savings_withdraw_from", $"[\"{account}\"]");
        }

        /// <summary>
        /// Returns the output data from 'SAFE' for this user
        /// Возвращает данные о выводах из 'СЕЙФА' для данного пользователя
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public JsonRpcResponse<SavingsWithdrawApiObj[]> GetSavingsWithdrawTo(string account)
        {
            return _webSocketManager.GetRequest<SavingsWithdrawApiObj[]>("get_savings_withdraw_to", $"[\"{account}\"]");
        }

        //get_vesting_delegations
        //get_expiring_vesting_delegations


        ///////////////
        // Witnesses //
        ///////////////


        /// <summary>
        /// Get a list of witnesses by ID
        /// </summary>
        /// <param name="witnessIds">IDs of the witnesses to retrieve</param>
        /// <returns>The witnesses corresponding to the provided IDs</returns>
        public JsonRpcResponse<WitnessApiObj[]> GetWitnesses(params object[] witnessIds)
        {
            return _webSocketManager.GetRequest<WitnessApiObj[]>("get_witnesses", new object[1][] { witnessIds });
        }

        /// <summary>
        /// Returns the current requests for conversion by the specified user
        /// Возвращает текущие запросы на конвертацию указанным пользователем
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public JsonRpcResponse<ConvertRequestApiObj[]> GetConversionRequests(string owner)
        {
            return _webSocketManager.Call<ConvertRequestApiObj[]>((int)Api.DefaultApi, "get_conversion_requests", owner);
        }
        
        /// <summary>
        /// Get the witness owned by a given account
        /// </summary>
        /// <param name="account">The name of the account whose witness should be retrieved</param>
        /// <returns>The witness object, or null if the account does not have a witness</returns>
        public JsonRpcResponse<WitnessApiObj> GetWitnessByAccount(string account)
        {
            return _webSocketManager.GetRequest<WitnessApiObj>("get_witness_by_account", $"[\"{account}\"]");
        }

        /// <summary>
        /// This method is used to fetch witnesses with pagination.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="limit"></param>
        /// <returns>An array of `count` witnesses sorted by total votes after witness `from` with at most `limit' results.</returns>
        public JsonRpcResponse<WitnessApiObj[]> GetWitnessesByVote(string from, UInt32 limit)
        {
            return _webSocketManager.GetRequest<WitnessApiObj[]>("get_witnesses_by_vote", from, limit);
        }

        /// <summary>
        /// Get names and IDs for registered witnesses
        /// </summary>
        /// <param name="lowerBoundName">Lower bound of the first name to return</param>
        /// <param name="limit">Maximum number of results to return -- must not exceed 1000</param>
        /// <returns>Map of witness names to corresponding IDs</returns>
        public JsonRpcResponse<object[]> LookupWitnessAccounts(string lowerBoundName, UInt32 limit)
        {
            return _webSocketManager.GetRequest<object[]>("lookup_witness_accounts", lowerBoundName, limit);
        }

        /// <summary>
        /// Get the total number of witnesses registered with the blockchain
        /// </summary>
        public JsonRpcResponse<UInt64> GetWitnessCount()
        {
            return _webSocketManager.GetRequest<UInt64>("get_witness_count");
        }


        ////////////
        // Market //
        ////////////


        /// <summary>
        /// Gets the current order book for STEEM:SBD market
        /// </summary>
        /// <param name="limit">Maximum number of orders for each side of the spread to return -- Must not exceed 1000</param>
        /// <returns>API type: order_book</returns>
        public JsonRpcResponse<OrderBook> GetOrderBook(UInt32 limit)
        {
            return _webSocketManager.GetRequest<OrderBook>("get_order_book", limit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public JsonRpcResponse<ExtendedLimitOrder[]> GetOpenOrders(string owner)
        {
            return _webSocketManager.GetRequest<ExtendedLimitOrder[]>("get_open_orders", $"[\"{owner}\"]");
        }










        /// <summary>
        /// 
        /// Возвращает отсортированные по стоимости тэги начиная с заданного или близко к нему похожего.
        /// </summary>
        /// <param name="after"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public JsonRpcResponse<CategoryApiObj[]> GetTrendingCategories(string after, UInt32 limit)
        {
            return _webSocketManager.GetRequest<CategoryApiObj[]>("get_trending_categories", after, limit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="after"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public JsonRpcResponse<CategoryApiObj[]> GetBestCategories(string after, UInt32 limit)
        {
            return _webSocketManager.GetRequest<CategoryApiObj[]>("get_best_categories", after, limit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="after"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public JsonRpcResponse<CategoryApiObj[]> GetActiveCategories(string after, UInt32 limit)
        {
            return _webSocketManager.GetRequest<CategoryApiObj[]>("get_active_categories", after, limit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="after"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public JsonRpcResponse<CategoryApiObj[]> GetRecentCategories(string after, UInt32 limit)
        {
            return _webSocketManager.GetRequest<CategoryApiObj[]>("get_recent_categories", after, limit);
        }







        public JsonRpcResponse<Discussion[]> GetDiscussionsByAuthorBeforeDate(string author, string startPermlink, DateTime beforeDate, UInt32 limit)
        {
            return _webSocketManager.GetRequest<Discussion[]>("get_discussions_by_author_before_date", author, startPermlink, beforeDate, limit);
        }







        /// <summary>
        /// 
        /// История всех действий пользователя в сети в виде транзакций. При from = -1 будут показаны последние {limit+1} элементов истории. Параметр limit не должен превышать from (исключение from = -1), так как показываются предшествующие {from} элементы истории.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="from"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public JsonRpcResponse<KeyValuePair<UInt32, AppliedOperation>[]> GetAccountHistory(string account, UInt64 from, UInt32 limit)
        {
            var buf = _webSocketManager.GetRequest<JArray[]>("get_account_history", account, from, limit);

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
        /// <returns></returns>
        public JsonRpcResponse<FollowApiObj[]> GetFollowers(string following, string startFollower, FollowType followType, UInt16 limit = 10)
        {
            return _webSocketManager.GetRequest<FollowApiObj[]>("call", "follow_api", "get_followers", new object[] { following, startFollower, followType.ToString().ToLower(), limit });
        }

        /// <summary>
        /// 
        /// Aналогично GetFollowers только для подписок
        /// </summary>
        /// <param name="follower"></param>
        /// <param name="startFollowing"></param>
        /// <param name="followType"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public JsonRpcResponse<FollowApiObj[]> GetFollowing(string follower, string startFollowing, FollowType followType, UInt16 limit = 10)
        {
            return _webSocketManager.GetRequest<FollowApiObj[]>("call", "follow_api", "get_following", new object[] { follower, startFollowing, followType.ToString().ToLower(), limit });
        }

        #endregion


    }
}