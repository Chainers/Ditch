using System;
using System.Collections.Generic;
using System.Globalization;
using Cryptography.ECDSA;
using Ditch.Helpers;
using Ditch.JsonRpc;
using Ditch.Operations;
using Ditch.Operations.Get;
using Ditch.Operations.Post;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ditch
{
    public class OperationManager
    {
        private readonly WebSocketManager _webSocketManager;
        private readonly byte[] _chainId;

        public OperationManager(string url, byte[] chainId, JsonSerializerSettings jsonSerializerSettings)
        {
            _webSocketManager = new WebSocketManager(url, jsonSerializerSettings);
            _chainId = chainId;
        }

        public OperationManager(string url, byte[] chainId) : this(url, chainId, GetJsonSerializerSettings(CultureInfo.InvariantCulture))
        {
        }

        public OperationManager(string url, byte[] chainId, CultureInfo cultureInfo) : this(url, chainId, GetJsonSerializerSettings(cultureInfo))
        {
        }

        private static JsonSerializerSettings GetJsonSerializerSettings(CultureInfo cultureInfo)
        {
            var rez = new JsonSerializerSettings
            {
                DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",
                Culture = cultureInfo
            };
            return rez;
        }

        /// <summary>
        /// Create and broadcast transaction
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse BroadcastOperations(IEnumerable<byte[]> userPrivateKeys, params BaseOperation[] operations)
        {
            var prop = GetDynamicGlobalProperties();
            if (prop.IsError)
            {
                return prop;
            }

            var transaction = CreateTransaction(prop.Result, userPrivateKeys, operations);
            var resp = _webSocketManager.Call(Transaction.Api, Transaction.OperationName, transaction);
            return resp;
        }

        /// <summary>
        /// Get user accounts by user names
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<Account[]> GetAccounts(params string[] userList)
        {
            return _webSocketManager.GetRequest<Account[]>(Account.OperationName, $"[[\"{string.Join("\",\"", userList)}\"]]");
        }

        /// <summary>
        /// Execute custom user method
        /// Возвращает TRUE если транзакция подписана правильно
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<bool> VerifyAuthority(IEnumerable<byte[]> userPrivateKeys, params BaseOperation[] testOps)
        {
            var prop = DynamicGlobalProperties.Default;
            var transaction = CreateTransaction(prop, userPrivateKeys, testOps);
            return _webSocketManager.GetRequest<bool>("verify_authority", transaction);
        }

        /// <summary>
        /// Create and execute custom json-rpc method
        /// </summary>
        /// <typeparam name="T">Custom type. JsonConvert will try to convert json-response to you custom object</typeparam>
        /// <param name="method">Sets json-rpc "method" field</param>
        /// <param name="transaction">Sets to json-rpc params field. JsonConvert use`s for convert array of data to string.</param>
        /// <returns></returns>
        public JsonRpcResponse<T> CustomPostRequest<T>(string method, Transaction transaction)
        {
            return _webSocketManager.GetRequest<T>(method, transaction);
        }

        /// <summary>
        /// Create and execute custom json-rpc method
        /// </summary>
        /// <typeparam name="T">Custom type. JsonConvert will try to convert json-response to you custom object</typeparam>
        /// <param name="method">Sets json-rpc "method" field</param>
        /// <param name="data">Sets to json-rpc params field. JsonConvert use`s for convert array of data to string.</param>
        /// <returns></returns>
        public JsonRpcResponse<T> CustomGetRequest<T>(string method, params object[] data)
        {
            return _webSocketManager.GetRequest<T>(method, data);
        }

         public JsonRpcResponse Call(Api api, string method, params object[] data) {
            return _webSocketManager.Call((int)api, method, data);
         }

         public JsonRpcResponse<T> Call<T>(Api api, string method, params object[] data) {
            return _webSocketManager.Call<T>((int)api, method, data);
         }


         /// <summary>
         /// Get post by author and permlink
         /// </summary>
         /// <param name="author"></param>
         /// <param name="permlink"></param>
         /// <returns></returns>
         public JsonRpcResponse<Content> GetContent(string author, string permlink)
        {
            return _webSocketManager.Call<Content>(Content.Api, Content.OperationName, author, permlink);
        }

        public Transaction CreateTransaction(DynamicGlobalProperties properties, IEnumerable<byte[]> userPrivateKeys, params BaseOperation[] operations)
        {
            var transaction = new Transaction
            {
                ChainId = _chainId,
                RefBlockNum = (ushort)(properties.HeadBlockNumber & 0xffff),
                RefBlockPrefix = (uint)BitConverter.ToInt32(Hex.HexToBytes(properties.HeadBlockId), 4),
                Expiration = properties.Time.AddSeconds(30),
                BaseOperations = operations
            };

            var msg = SerializeHelper.TransactionToMessage(transaction);
            var data = Secp256k1Manager.GetMessageHash(msg);

            foreach (var userPrivateKey in userPrivateKeys)
            {
                var sig = Secp256k1Manager.SignCompressedCompact(data, userPrivateKey);
                transaction.Signatures.Add(sig);
            }

            return transaction;
        }

        //https://github.com/steemit/steem/blob/master/libraries/wallet/include/steemit/wallet/wallet.hpp

        /// <summary>
        /// Returns the block chain's rapidly-changing properties.
        /// The returned object contains information that changes every block interval
        /// such as the head block number, the next witness, etc.
        /// @see \c get_global_properties() for less-frequently changing properties
        /// </summary>
        /// <returns>the dynamic global properties</returns>
        public JsonRpcResponse<DynamicGlobalProperties> GetDynamicGlobalProperties()
        {
            return _webSocketManager.GetRequest<DynamicGlobalProperties>(DynamicGlobalProperties.Reques);
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
        public JsonRpcResponse<FollowInfo[]> GetFollowers(string following, string startFollower, FollowType followType, UInt16 limit = 10)
        {
            return _webSocketManager.GetRequest<FollowInfo[]>("call", FollowInfo.Api, "get_followers", new object[] { following, startFollower, followType.ToString().ToLower(), limit });
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
        public JsonRpcResponse<FollowInfo[]> GetFollowing(string follower, string startFollowing, FollowType followType, UInt16 limit = 10)
        {
            return _webSocketManager.GetRequest<FollowInfo[]>("call", FollowInfo.Api, "get_following", new object[] { follower, startFollowing, followType.ToString().ToLower(), limit });
        }

        #endregion

        #region database_api

        /// <summary>
        /// 
        /// Возращает данные по заданным аккаунтам
        /// </summary>
        /// <param name="names"></param>
        /// <returns></returns>
        public JsonRpcResponse<Account[]> LookupAccountNames(params string[] names)
        {
            return _webSocketManager.GetRequest<Account[]>("lookup_account_names", $"[[\"{string.Join("\", \"", names)}\"]]");
        }

        /// <summary>
        /// 
        /// Возвращает имена пользователей близких к шаблону.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public JsonRpcResponse<string[]> LookupAccounts(string account, UInt32 limit)
        {
            return _webSocketManager.GetRequest<string[]>("lookup_accounts", account, limit);
        }

        /// <summary>
        /// 
        /// Возвращает количество зарегестрированных пользователей.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<UInt64> GetAccountCount()
        {
            return _webSocketManager.GetRequest<UInt64>("get_account_count");
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

        /// <summary>
        /// 
        /// Отображает действия пользователя в зависимости от типа
        /// </summary>
        /// <param name="account"></param>
        /// <param name="bandwidthType"></param>
        /// <returns></returns>
        public JsonRpcResponse<AccountBandwidth> GetAccountBandwidth(string account, BandwidthType bandwidthType)
        {
            return _webSocketManager.GetRequest<AccountBandwidth>("get_account_bandwidth", account, bandwidthType.ToString().ToLower());
        }

        /// <summary>
        /// 
        /// Отображает текущее состояние делегирования.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<WitnessSchedule> GetWitnessSchedule()
        {
            return _webSocketManager.GetRequest<WitnessSchedule>("get_witness_schedule");
        }

        /// <summary>
        /// 
        /// Отображает дату и версию HardFork
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<ScheduledHardfork> GetNextScheduledHardfork()
        {
            return _webSocketManager.GetRequest<ScheduledHardfork>("get_next_scheduled_hardfork");
        }

        /// <summary>
        /// 
        /// Находит и возвращает имена пользователей по публичному ключу
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public JsonRpcResponse<string[][]> GetKeyReferences(params string[][] keys)
        {
            return _webSocketManager.Call<string[][]>((int)Api.AccountByKeyApi, "get_key_references", keys);
        }

        /// <summary>
        /// 
        /// Отображает текущую версию сети.
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> GetHardforkVersion(params string[][] keys)
        {
            return _webSocketManager.GetRequest<string>("get_hardfork_version");
        }

        /// <summary>
        /// 
        /// Отображает историю конверсий.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<FeedHistory> GetFeedHistory()
        {
            return _webSocketManager.GetRequest<FeedHistory>("get_feed_history");
        }

        /// <summary>
        /// 
        /// Отображает текущую медианную цену конвертации.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<Price> GetCurrentMedianHistoryPrice()
        {
            return _webSocketManager.GetRequest<Price>("get_current_median_history_price");
        }

        /// <summary>
        /// 
        /// Отображает текущую конфигурацию узла.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<object> GetConfig()
        {
            return _webSocketManager.GetRequest<object>("get_config");
        }

        /// <summary>
        /// 
        /// Отображает комиссию за создание пользователя, максимальный размер блока и процентную ставку GBG.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<ChainProperties> GetChainProperties()
        {
            return _webSocketManager.GetRequest<ChainProperties>("get_chain_properties");
        }

        public JsonRpcResponse<object> GetAccountReferences(int accountId)
        {
            return _webSocketManager.GetRequest<object>("get_account_references", accountId);
        }


        /// <summary>
        /// 
        /// Возвращает текущие запросы на конвертацию указанным пользователем
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public JsonRpcResponse<ConvertRequest[]> GetConversionRequests(string owner)
        {
            return _webSocketManager.Call<ConvertRequest[]>((int)Api.DefaultApi, "get_conversion_requests", owner);
        }

        #endregion database_api

        #region wallet api

        /// <summary>
        /// 
        /// Отображает текущее состояние сети.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public JsonRpcResponse<State> GetState(string path)
        {
            return _webSocketManager.GetRequest<State>("get_state", $"[\"{path}\"]");
        }

        #endregion wallet api

        #region key api
        //(import_key)
        //(suggest_brain_key)
        //(list_keys)
        //(get_private_key)
        //(get_private_key_from_password)
        //(normalize_brain_key)
        #endregion key api

        #region query api
        //(info)
        //(list_my_accounts)
        //(list_accounts)
        //(list_witnesses)
        //(get_witness)
        //(get_account)
        //(get_block)
        //(get_ops_in_block)
        //(get_feed_history)
        //(get_conversion_requests)
        //(get_account_history)
        //(get_state)
        //(get_withdraw_routes)
        #endregion query api

        #region transaction api
        //(create_account)
        //(create_account_with_keys)
        //(create_account_delegated)
        //(create_account_with_keys_delegated)
        //(update_account)
        //(update_account_auth_key)
        //(update_account_auth_account)
        //(update_account_auth_threshold)
        //(update_account_meta)
        //(update_account_memo_key)
        //(delegate_vesting_shares)
        //(update_witness)
        //(set_voting_proxy)
        //(vote_for_witness)
        //(follow)
        //(transfer)
        //(escrow_transfer)
        //(escrow_approve)
        //(escrow_dispute)
        //(escrow_release)
        //(transfer_to_vesting)
        //(withdraw_vesting)
        //(set_withdraw_vesting_route)
        //(convert_sbd)
        //(publish_feed)
        //(get_order_book)
        //(get_open_orders)
        //(create_order)
        //(cancel_order)
        //(post_comment)
        //(vote)
        //(set_transaction_expiration)
        //(challenge)
        //(prove)
        //(request_account_recovery)
        //(recover_account)
        //(change_recovery_account)
        //(get_owner_history)
        //(transfer_to_savings)
        //(transfer_from_savings)
        //(cancel_transfer_from_savings)
        //(get_encrypted_memo)
        //(decrypt_memo)
        //(decline_voting_rights)
        //(claim_reward_balance)
        #endregion transaction api

        #region  private message api
        //(send_private_message)
        //(get_inbox)
        //(get_outbox)
        #endregion  private message api

        #region helper api
        //(get_prototype_operation)
        //(serialize_transaction)
        //(sign_transaction)

        //(network_add_nodes)
        //(network_get_connected_peers)

        //(get_active_witnesses)
        //(get_miner_queue)
        //(get_transaction)
        #endregion  helper api

        #region database api

        public JsonRpcResponse<Discussion[]> GetDiscussionsByAuthorBeforeDate(string author, string startPermlink, DateTime beforeDate, UInt32 limit)
        {
            return _webSocketManager.GetRequest<Discussion[]>("get_discussions_by_author_before_date", author, startPermlink, beforeDate, limit);
        }

        #endregion  database api


    }
}