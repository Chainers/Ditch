using System;
using System.Collections.Generic;
using System.Threading;
using Cryptography.ECDSA;
using Ditch.BitShares.JsonRpc;
using Ditch.BitShares.Models;
using Ditch.BitShares.Models.Operations;
using Ditch.Core;
using Ditch.Core.Interfaces;
using Ditch.Core.JsonRpc;
using Newtonsoft.Json;

namespace Ditch.BitShares
{
    public partial class OperationManager
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        public readonly MessageSerializer MessageSerializer;
        private readonly IConnectionManager _connectionManager;
        private List<string> _urls;

        public byte[] ChainId { get; private set; }
        public bool IsConnected => _connectionManager.IsConnected;
        private readonly Config _config;

        #region Constructors

        public OperationManager(IConnectionManager connectionManage, JsonSerializerSettings jsonSerializerSettings, Config config)
        {
            _jsonSerializerSettings = jsonSerializerSettings;
            _connectionManager = connectionManage;
            _config = config;
            MessageSerializer = new MessageSerializer();
        }

        public OperationManager(IConnectionManager connectionManage, JsonSerializerSettings jsonSerializerSettings)
            : this(connectionManage, jsonSerializerSettings, new Config())
        {
        }

        #endregion Constructors


        /// <summary>
        /// 
        /// </summary>
        /// <param name="urls"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public string TryConnectTo(List<string> urls, CancellationToken token)
        {
            _urls = urls;

            foreach (var url in urls)
            {
                try
                {
                    var connectedTo = _connectionManager.ConnectTo(url, token);
                    if (string.IsNullOrEmpty(connectedTo))
                        continue;

                    if (TryLoadChainId(token))
                        return url;

                    if (_connectionManager.IsConnected)
                        _connectionManager.Disconnect();
                }
                catch
                {
                    //todo nothing
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public string RetryConnect(CancellationToken token)
        {
            return TryConnectTo(_urls, token);
        }

        /// <summary>
        /// Create and Broadcast a transaction to the network
        /// 
        /// The transaction will be checked for validity in the local database prior to broadcasting. If it fails to apply locally, an error will be thrown and the transaction will not be broadcast.
        /// </summary>
        /// <param name="userPrivateKeys"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="operations"></param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse BroadcastOperations(IList<byte[]> userPrivateKeys, CancellationToken token, params BaseOperation[] operations)
        {
            var prop = GetDynamicGlobalProperties(token);
            if (prop.IsError)
                return prop;

            var transaction = CreateTransaction(prop.Result, userPrivateKeys, token, operations);
            return BroadcastTransaction(transaction, token);
        }

        /// <summary>
        /// Create and Broadcast a transaction to the network
        /// 
        /// This call will not return until the transaction is included in a block. 
        /// </summary>
        /// <param name="userPrivateKeys"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="operations"></param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse BroadcastOperationsSynchronous(IList<byte[]> userPrivateKeys, CancellationToken token, params BaseOperation[] operations)
        {
            var prop = GetDynamicGlobalProperties(token);
            if (prop.IsError)
                return prop;

            var transaction = CreateTransaction(prop.Result, userPrivateKeys, token, operations);
            return BroadcastTransactionSynchronous(transaction, token);
        }

        /// <summary>
        /// Execute custom user method
        /// Возвращает TRUE если транзакция подписана правильно
        /// </summary>
        /// <param name="userPrivateKeys"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="testOps"></param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<bool> VerifyAuthority(IList<byte[]> userPrivateKeys, CancellationToken token, params BaseOperation[] testOps)
        {
            var prop = GetDynamicGlobalProperties(token);
            if (prop.IsError)
                return new JsonRpcResponse<bool>(prop.Error);

            var transaction = CreateTransaction(prop.Result, userPrivateKeys, token, testOps);
            return VerifyAuthority(transaction, token);
        }

        /// <summary>
        /// Create and execute custom json-rpc method
        /// </summary>
        /// <typeparam name="T">Custom type. JsonConvert will try to convert json-response to you custom object</typeparam>
        /// <param name="api">Api name</param>
        /// <param name="method">Sets json-rpc "method" field</param>
        /// <param name="data">Sets to json-rpc params field. JsonConvert use`s for convert array of data to string.</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<T> CustomGetRequest<T>(string api, string method, object[] data, CancellationToken token)
        {
            var jsonRpc = new JsonRpcRequest(_jsonSerializerSettings, api, method, data);
            return _connectionManager.Execute<T>(jsonRpc, token);
        }

        /// <summary>
        /// Create and execute custom json-rpc method
        /// </summary>
        /// <typeparam name="T">Custom type. JsonConvert will try to convert json-response to you custom object</typeparam>
        /// <param name="api">Api name</param>
        /// <param name="method">Sets json-rpc "method" field</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<T> CustomGetRequest<T>(string api, string method, CancellationToken token)
        {
            var jsonRpc = new JsonRpcRequest(api, method);
            return _connectionManager.Execute<T>(jsonRpc, token);
        }

        /// <summary>
        /// Create and execute custom json-rpc method
        /// </summary>
        /// <param name="api">Api name</param>
        /// <param name="method">Sets json-rpc "method" field</param>
        /// <param name="data">Sets to json-rpc params field. JsonConvert use`s for convert array of data to string.</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse CustomGetRequest(string api, string method, object[] data, CancellationToken token)
        {
            var jsonRpc = new JsonRpcRequest(_jsonSerializerSettings, api, method, data);
            return _connectionManager.Execute(jsonRpc, token);
        }

        /// <summary>
        /// Create and execute custom json-rpc method
        /// </summary>
        /// <param name="api">Api name</param>
        /// <param name="method">Sets json-rpc "method" field</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse CustomGetRequest(string api, string method, CancellationToken token)
        {
            var jsonRpc = new JsonRpcRequest(api, method);
            return _connectionManager.Execute(jsonRpc, token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyApiObj"></param>
        /// <param name="userPrivateKeys"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="operations"></param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public SignedTransaction CreateTransaction(DynamicGlobalPropertyObject propertyApiObj, IList<byte[]> userPrivateKeys, CancellationToken token, params BaseOperation[] operations)
        {
            var transaction = new SignedTransaction
            {
                ChainId = ChainId,
                RefBlockNum = (ushort)(propertyApiObj.HeadBlockNumber & 0xffff),
                RefBlockPrefix = (uint)BitConverter.ToInt32(Hex.HexToBytes(propertyApiObj.HeadBlockId), 4),
                Expiration = propertyApiObj.Time.AddSeconds(30),
                BaseOperations = operations
            };

            var msg = MessageSerializer.Serialize<SignedTransaction>(transaction);
            var data = Sha256Manager.GetHash(msg);

            transaction.Signatures = new string[userPrivateKeys.Count];
            for (int i = 0; i < userPrivateKeys.Count; i++)
            {
                token.ThrowIfCancellationRequested();
                var userPrivateKey = userPrivateKeys[i];
                var sig = Secp256K1Manager.SignCompressedCompact(data, userPrivateKey);
                transaction.Signatures[i] = Hex.ToString(sig);
            }

            return transaction;
        }

        public virtual bool TryLoadChainId(CancellationToken token)
        {
            var resp = GetChainId(token);
            if (!resp.IsError)
            {
                ChainId = Hex.HexToBytes(resp.Result);
                return true;
            }
            return false;
        }
    }
}
