using System;
using System.Collections.Generic;
using System.Threading;
using Cryptography.ECDSA;
using Ditch.Core;
using Ditch.Core.Helpers;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Helpers;
using Ditch.Steem.JsonRpc;
using Ditch.Steem.Models.Args;
using Ditch.Steem.Models.Objects;
using Ditch.Steem.Models.Return;
using Ditch.Steem.Operations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ditch.Steem
{
    public partial class OperationManager
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private readonly IConnectionManager _connectionManager;
        private List<string> _urls;

        public byte[] ChainId { get; private set; }
        public string SbdSymbol { get; private set; }
        public int Version { get; private set; }
        public bool IsConnected => _connectionManager.IsConnected;

        #region Constructors

        public OperationManager(IConnectionManager connectionManage, JsonSerializerSettings jsonSerializerSettings)
        {
            _jsonSerializerSettings = jsonSerializerSettings;
            _connectionManager = connectionManage;
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

                    if (TryLoadConfig(token))
                        return url;
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
        public JsonRpcResponse BroadcastOperations(IEnumerable<byte[]> userPrivateKeys, CancellationToken token, params BaseOperation[] operations)
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
        public JsonRpcResponse BroadcastOperationsSynchronous(IEnumerable<byte[]> userPrivateKeys, CancellationToken token, params BaseOperation[] operations)
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
        public JsonRpcResponse<VerifyAuthorityReturn> VerifyAuthority(IEnumerable<byte[]> userPrivateKeys, CancellationToken token, params BaseOperation[] testOps)
        {
            var prop = DynamicGlobalPropertyApiObj.Default;
            var transaction = CreateTransaction(prop, userPrivateKeys, token, testOps);
            var args = new VerifyAuthorityArgs()
            {
                Trx = transaction
            };
            return VerifyAuthority(args, token);
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
        public JsonRpcResponse<T> CustomGetRequest<T>(string api, string method, object data, CancellationToken token)
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
        public JsonRpcResponse CustomGetRequest(string api, string method, object data, CancellationToken token)
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
        public SignedTransaction CreateTransaction(DynamicGlobalPropertyObject propertyApiObj, IEnumerable<byte[]> userPrivateKeys, CancellationToken token, params BaseOperation[] operations)
        {
            var transaction = new SignedTransaction
            {
                ChainId = ChainId,
                RefBlockNum = (ushort)(propertyApiObj.HeadBlockNumber & 0xffff),
                RefBlockPrefix = (uint)BitConverter.ToInt32(Hex.HexToBytes(propertyApiObj.HeadBlockId), 4),
                Expiration = propertyApiObj.Time.AddSeconds(30),
                BaseOperations = operations
            };

            var msg = SerializeHelper.TransactionToMessage(transaction, Version);
            var data = Secp256k1Manager.GetMessageHash(msg);

            foreach (var userPrivateKey in userPrivateKeys)
            {
                token.ThrowIfCancellationRequested();
                var sig = Secp256k1Manager.SignCompressedCompact(data, userPrivateKey);
                transaction.Signatures.Add(sig);
            }

            return transaction;
        }


        public virtual bool TryLoadConfig(CancellationToken token)
        {
            var resp = GetConfig(token);
            if (!resp.IsError)
            {
                dynamic conf = resp.Result;
                var scid = conf.STEEM_CHAIN_ID as JValue;
                var smpsbd = conf.STEEM_MIN_PAYOUT_SBD as JArray;

                var sbhv = conf.STEEM_BLOCKCHAIN_VERSION as JValue;
                //var sbv = conf.STEEMIT_BLOCKCHAIN_VERSION as JValue;
                if (scid != null && smpsbd != null && smpsbd.Count == 3 && sbhv != null)
                {
                    var str = scid.Value<string>();
                    var hfvs = sbhv.Value<string>();
                    if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(hfvs))
                    {
                        SbdSymbol = smpsbd[2].Value<string>();
                        ChainId = Hex.HexToBytes(str);
                        Version = VersionHelper.ToInteger(hfvs);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
