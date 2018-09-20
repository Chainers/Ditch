using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cryptography.ECDSA;
using Ditch.Core;
using Ditch.Core.Interfaces;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Converters;
using Ditch.Steem.JsonRpc;
using Ditch.Steem.Models;
using Ditch.Steem.Operations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ditch.Steem
{
    public partial class OperationManager
    {
        public JsonSerializerSettings NewJsonSerializerSettings { get; set; }

        public MessageSerializer MessageSerializer { get; }
        public IConnectionManager ConnectionManager { get; }
        public byte[] ChainId { get; set; } = new byte[32];

        public bool IsConnected => ConnectionManager.IsConnected;

        #region Constructors

        public OperationManager(IConnectionManager connectionManage)
        {
            MessageSerializer = new MessageSerializer();
            ConnectionManager = connectionManage;
            NewJsonSerializerSettings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                Culture = CultureInfo.InvariantCulture,
                Converters = new JsonConverter[] { new NewJsonConverter(), }
            };
            CondenserJsonSerializerSettings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                Culture = CultureInfo.InvariantCulture,
                Converters = new JsonConverter[] { new CondenserJsonConverter(), }
            };
        }

        #endregion Constructors

        public async Task<bool> ConnectToAsync(string endpoin, CancellationToken token)
        {
            return await ConnectionManager.ConnectToAsync(endpoin, token).ConfigureAwait(false);
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
        public async Task<JsonRpcResponse<VoidResponse>> BroadcastOperationsAsync(IList<byte[]> userPrivateKeys, BaseOperation[] operations, CancellationToken token)
        {
            var prop = await GetDynamicGlobalPropertiesAsync(token).ConfigureAwait(false);
            if (prop.IsError)
                return new JsonRpcResponse<VoidResponse>(prop);

            var transaction = await CreateTransactionAsync(prop.Result, userPrivateKeys, operations, token).ConfigureAwait(false);
            var args = new BroadcastTransactionArgs
            {
                Trx = transaction
            };
            return await BroadcastTransactionAsync(args, token).ConfigureAwait(false);
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
        public async Task<JsonRpcResponse<VoidResponse>> BroadcastOperationsLikeSteemitAsync(IList<byte[]> userPrivateKeys, BaseOperation[] operations, CancellationToken token)
        {
            var prop = await GetDynamicGlobalPropertiesAsync(token).ConfigureAwait(false);
            if (prop.IsError)
                return new JsonRpcResponse<VoidResponse>(prop);

            var transaction = await CreateTransactionAsync(prop.Result, userPrivateKeys, operations, token).ConfigureAwait(false);
            var args = new BroadcastTransactionArgs
            {
                Trx = transaction
            };
            return await BroadcastTransactionLikeSteemitAsync(args, token).ConfigureAwait(false);
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
        public async Task<JsonRpcResponse<BroadcastTransactionSynchronousReturn>> BroadcastOperationsSynchronousAsync(IList<byte[]> userPrivateKeys, BaseOperation[] operations, CancellationToken token)
        {
            var prop = await GetDynamicGlobalPropertiesAsync(token).ConfigureAwait(false);
            if (prop.IsError)
                return new JsonRpcResponse<BroadcastTransactionSynchronousReturn>(prop);

            var transaction = await CreateTransactionAsync(prop.Result, userPrivateKeys, operations, token).ConfigureAwait(false);
            var args = new BroadcastTransactionSynchronousArgs
            {
                Trx = transaction
            };
            return await BroadcastTransactionSynchronousAsync(args, token).ConfigureAwait(false);
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
        public async Task<JsonRpcResponse<BroadcastTransactionSynchronousReturn>> BroadcastOperationsSynchronousLikeSteemitAsync(IList<byte[]> userPrivateKeys, BaseOperation[] operations, CancellationToken token)
        {
            var prop = await GetDynamicGlobalPropertiesAsync(token).ConfigureAwait(false);
            if (prop.IsError)
                return new JsonRpcResponse<BroadcastTransactionSynchronousReturn>(prop);

            var transaction = await CreateTransactionAsync(prop.Result, userPrivateKeys, operations, token).ConfigureAwait(false);
            var args = new BroadcastTransactionSynchronousArgs
            {
                Trx = transaction
            };
            return await BroadcastTransactionSynchronousLikeSteemitAsync(args, token).ConfigureAwait(false);
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
        public async Task<JsonRpcResponse<VerifyAuthorityReturn>> VerifyAuthorityAsync(IList<byte[]> userPrivateKeys, BaseOperation[] testOps, CancellationToken token)
        {
            var prop = DynamicGlobalPropertyApiObj.Default;
            var transaction = await CreateTransactionAsync(prop, userPrivateKeys, testOps, token).ConfigureAwait(false);
            var args = new VerifyAuthorityArgs
            {
                Trx = transaction
            };
            return await VerifyAuthorityAsync(args, token).ConfigureAwait(false);
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
        public Task<JsonRpcResponse<T>> CustomBroadcastRequestAsync<T>(string api, string method, object data, CancellationToken token)
        {
            var jsonRpc = JsonRpcRequest.Request(NewJsonSerializerSettings, api, method, data);
            return ConnectionManager.ExecuteAsync<T>(jsonRpc, NewJsonSerializerSettings, token);
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
        public Task<JsonRpcResponse<T>> CustomGetRequestAsync<T>(string api, string method, object data, CancellationToken token)
        {
            var jsonRpc = JsonRpcRequest.Request(NewJsonSerializerSettings, api, method, data);
            return ConnectionManager.RepeatExecuteAsync<T>(jsonRpc, NewJsonSerializerSettings, token);
        }

        /// <summary>
        /// Create and execute custom json-rpc method
        /// </summary>
        /// <typeparam name="T">Custom type. JsonConvert will try to convert json-response to you custom object</typeparam>
        /// <param name="api">Api name</param>
        /// <param name="method">Sets json-rpc "method" field</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public Task<JsonRpcResponse<T>> CustomGetRequestAsync<T>(string api, string method, CancellationToken token)
        {
            var jsonRpc = JsonRpcRequest.Request(api, method);
            return ConnectionManager.RepeatExecuteAsync<T>(jsonRpc, NewJsonSerializerSettings, token);
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
        public Task<SignedTransaction> CreateTransactionAsync(DynamicGlobalPropertyObject propertyApiObj, IList<byte[]> userPrivateKeys, BaseOperation[] operations, CancellationToken token)
        {
            return Task.Run(() =>
            {
                var transaction = new SignedTransaction
                {
                    ChainId = ChainId,
                    RefBlockNum = (ushort)(propertyApiObj.HeadBlockNumber & 0xffff),
                    RefBlockPrefix = (uint)BitConverter.ToInt32(Hex.HexToBytes(propertyApiObj.HeadBlockId), 4),
                    Expiration = propertyApiObj.Time.Value.AddSeconds(30),
                    Operations = operations.Select(o => new Operation(o)).ToArray()
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

        public Task<SignedTransaction> CreateTransactionAsync(DynamicGlobalPropertyObject propertyApiObj, IList<byte[]> userPrivateKeys, BaseOperation operation, CancellationToken token)
        {
            return CreateTransactionAsync(propertyApiObj, userPrivateKeys, new[] { operation }, token);
        }

        public async Task<byte[]> TryLoadChainIdAsync(string[] chainFieldName, CancellationToken token)
        {
            var resp = await GetConfigAsync<JObject>(token).ConfigureAwait(false);
            if (resp.IsError)
                return new byte[0];

            var conf = resp.Result;
            JToken jToken = null;

            foreach (var name in chainFieldName)
            {
                conf.TryGetValue(name, out jToken);
                if (jToken != null)
                    break;
            }

            if (jToken == null)
                return new byte[0];

            var str = jToken.Value<string>();
            return Hex.HexToBytes(str);
        }

        public async Task<string> TryLoadBlockchainVersionAsync(string[] fieldName, CancellationToken token)
        {
            var resp = await GetConfigAsync<JObject>(token).ConfigureAwait(false);
            if (resp.IsError)
                return string.Empty;

            var conf = resp.Result;
            JToken jToken = null;

            foreach (var name in fieldName)
            {
                conf.TryGetValue(name, out jToken);
                if (jToken != null)
                    break;
            }

            if (jToken == null)
                return string.Empty;

            return jToken.Value<string>();
        }

    }
}
