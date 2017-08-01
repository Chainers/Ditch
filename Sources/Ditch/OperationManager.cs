using System;
using System.Collections.Generic;
using Cryptography.ECDSA;
using Ditch.Helpers;
using Ditch.JsonRpc;
using Ditch.Operations.Get;
using Ditch.Operations.Post;
using Newtonsoft.Json;

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

        public OperationManager(string url, byte[] chainId) : this(url, chainId, GetJsonSerializerSettings())
        {
        }

        private static JsonSerializerSettings GetJsonSerializerSettings()
        {
            var rez = new JsonSerializerSettings
            {
                DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK"
            };
            return rez;
        }

        /// <summary>
        /// Create and broadcast transaction
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse BroadcastOperations(List<byte[]> userPrivateKeys, params BaseOperation[] operations)
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
        public JsonRpcResponse<List<Account>> GetAccounts(params string[] userList)
        {
            return _webSocketManager.GetRequest<List<Account>>(Account.OperationName, $"[[\"{string.Join("\",\"", userList)}\"]]");
        }

        /// <summary>
        /// Execute custom user method
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<bool> VerifyAuthority(List<byte[]> userPrivateKeys, params BaseOperation[] testOps)
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

        public Transaction CreateTransaction(DynamicGlobalProperties properties, List<byte[]> userPrivateKeys, params BaseOperation[] operations)
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

        public JsonRpcResponse<List<FollowInfo>> GetFollowers(string to, string start, FollowType followType, UInt16 limit = 10)
        {
            return _webSocketManager.GetRequest<List<FollowInfo>>("call", FollowInfo.Api, "get_followers", new object[] { to, start, followType.ToString().ToLower(), limit });
        }

        public JsonRpcResponse<List<FollowInfo>> GetFollowing(string to, string start, FollowType followType, UInt16 limit = 10)
        {
            return _webSocketManager.GetRequest<List<FollowInfo>>("call", FollowInfo.Api, "get_following", new object[] { to, start, followType.ToString().ToLower(), limit });
        }

        #endregion

        #region wallet api

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

        public JsonRpcResponse<List<Discussion>> GetDiscussionsByAuthorBeforeDate(string author, string startPermlink, DateTime beforeDate, UInt32 limit)
        {
            return _webSocketManager.GetRequest<List<Discussion>>("get_discussions_by_author_before_date", author, startPermlink, beforeDate, limit);
        }

        #endregion  database api


    }
}