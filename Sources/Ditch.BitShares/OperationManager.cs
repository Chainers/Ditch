using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Cryptography.ECDSA;
using Ditch.BitShares.JsonRpc;
using Ditch.BitShares.Models;
using Ditch.BitShares.Operations;
using Ditch.Core;
using Ditch.Core.Interfaces;
using Ditch.Core.JsonRpc;
using Newtonsoft.Json;

namespace Ditch.BitShares
{
    public partial class OperationManager
    {
        private byte[] _chainId;
        public JsonSerializerSettings JsonSerializerSettings { get; }
        public MessageSerializer MessageSerializer { get; }
        public IConnectionManager ConnectionManager { get; }

        public byte[] ChainId
        {
            get => _chainId ?? (_chainId = TryLoadChainId(CancellationToken.None).Result);
            set => _chainId = value;
        }

        public bool IsConnected => ConnectionManager.IsConnected;


        #region Constructors

        public OperationManager(IConnectionManager connectionManage)
        {
            MessageSerializer = new MessageSerializer();
            ConnectionManager = connectionManage;
            JsonSerializerSettings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                Culture = CultureInfo.InvariantCulture
            };
        }

        #endregion Constructors


        public bool ConnectTo(string endpoin, CancellationToken token)
        {
            return ConnectionManager.ConnectTo(endpoin, token);
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
        public async Task<JsonRpcResponse<VoidResponse>> BroadcastOperations(IList<byte[]> userPrivateKeys, BaseOperation[] operations, CancellationToken token)
        {
            var prop = await GetDynamicGlobalProperties(token);
            if (prop.IsError)
                return new JsonRpcResponse<VoidResponse>(prop);

            var transaction = await CreateTransaction(prop.Result, userPrivateKeys, token, operations);
            return await BroadcastTransaction(transaction, token);
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
        public async Task<JsonRpcResponse<object>> BroadcastOperationsSynchronous(IList<byte[]> userPrivateKeys, BaseOperation[] operations, CancellationToken token)
        {
            var prop = await GetDynamicGlobalProperties(token);
            if (prop.IsError)
                return new JsonRpcResponse<object>(prop);

            var transaction = await CreateTransaction(prop.Result, userPrivateKeys, token, operations);
            return await BroadcastTransactionSynchronous(transaction, token);
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
        public async Task<JsonRpcResponse<bool>> VerifyAuthority(IList<byte[]> userPrivateKeys, BaseOperation[] testOps, CancellationToken token)
        {
            var prop = await GetDynamicGlobalProperties(token);
            if (prop.IsError)
                return new JsonRpcResponse<bool>(prop);

            var transaction = await CreateTransaction(prop.Result, userPrivateKeys, token, testOps);
            return await VerifyAuthority(transaction, token);
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
        public Task<JsonRpcResponse<T>> CustomGetRequest<T>(string api, string method, object[] data, CancellationToken token)
        {
            var jsonRpc = new JsonRpcRequest(JsonSerializerSettings, api, method, data);
            return ConnectionManager.ExecuteAsync<T>(jsonRpc, JsonSerializerSettings, token);
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
        public Task<JsonRpcResponse<T>> CustomGetRequest<T>(string api, string method, CancellationToken token)
        {
            var jsonRpc = new JsonRpcRequest(api, method);
            return ConnectionManager.ExecuteAsync<T>(jsonRpc, JsonSerializerSettings, token);
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
        public Task<SignedTransaction> CreateTransaction(DynamicGlobalPropertyObject propertyApiObj, IList<byte[]> userPrivateKeys, CancellationToken token, params BaseOperation[] operations)
        {
            return Task.Run(() =>
            {
                var transaction = new SignedTransaction
                {
                    ChainId = ChainId,
                    RefBlockNum = (ushort)(propertyApiObj.HeadBlockNumber & 0xffff),
                    RefBlockPrefix = (uint)BitConverter.ToInt32(Hex.HexToBytes(propertyApiObj.HeadBlockId), 4),
                    Expiration = propertyApiObj.Time.Value.AddSeconds(30),
                    BaseOperations = operations
                };

                var msg = MessageSerializer.Serialize<SignedTransaction>(transaction);
                var data = Sha256Manager.GetHash(msg);

                transaction.Signatures = new string[userPrivateKeys.Count];
                for (var i = 0; i < userPrivateKeys.Count; i++)
                {
                    token.ThrowIfCancellationRequested();
                    var userPrivateKey = userPrivateKeys[i];
                    var sig = Secp256K1Manager.SignCompressedCompact(data, userPrivateKey);
                    transaction.Signatures[i] = Hex.ToString(sig);
                }

                return transaction;
            }, token);
        }

        public async Task<byte[]> TryLoadChainId(CancellationToken token)
        {
            var resp = await GetChainId(token);
            if (!resp.IsError)
            {
                return Hex.HexToBytes(resp.Result);
            }
            return new byte[0];
        }
    }
}
