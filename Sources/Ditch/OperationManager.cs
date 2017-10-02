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

namespace Ditch
{
    public partial class OperationManager
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
        public JsonRpcResponse<ExtendedAccount[]> GetAccounts(params string[] userList)
        {
            return _webSocketManager.GetRequest<ExtendedAccount[]>("get_accounts", $"[[\"{string.Join("\",\"", userList)}\"]]");
        }

        /// <summary>
        /// Execute custom user method
        /// Возвращает TRUE если транзакция подписана правильно
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<bool> VerifyAuthority(IEnumerable<byte[]> userPrivateKeys, params BaseOperation[] testOps)
        {
            var prop = DynamicGlobalPropertyApiObj.Default;
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
        public JsonRpcResponse<Discussion> GetContent(string author, string permlink)
        {
            return _webSocketManager.Call<Discussion>((int)Api.DefaultApi, "get_content", author, permlink);
        }

        public Transaction CreateTransaction(DynamicGlobalPropertyApiObj propertyApiObj, IEnumerable<byte[]> userPrivateKeys, params BaseOperation[] operations)
        {
            var transaction = new Transaction
            {
                ChainId = _chainId,
                RefBlockNum = (ushort)(propertyApiObj.HeadBlockNumber & 0xffff),
                RefBlockPrefix = (uint)BitConverter.ToInt32(Hex.HexToBytes(propertyApiObj.HeadBlockId), 4),
                Expiration = propertyApiObj.Time.AddSeconds(30),
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
    }
}