﻿using System;
using System.Collections.Generic;
using System.Threading;
using Cryptography.ECDSA;
using Ditch.Core;
using Ditch.Core.Interfaces;
using Ditch.Core.JsonRpc;
using Ditch.Steem.JsonRpc;
using Ditch.Steem.Models.ApiObj;
using Ditch.Steem.Models.Args;
using Ditch.Steem.Models.Objects;
using Ditch.Steem.Models.Operations;
using Ditch.Steem.Models.Other;
using Ditch.Steem.Models.Return;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ditch.Steem
{
    public partial class OperationManager
    {
        public JsonSerializerSettings JsonSerializerSettings { get; }
        public MessageSerializer MessageSerializer { get; }
        public IConnectionManager ConnectionManager { get; }
        public byte[] ChainId { get; set; } = new byte[32];

        public bool IsConnected => ConnectionManager.IsConnected;

        #region Constructors

        public OperationManager(IConnectionManager connectionManage, JsonSerializerSettings jsonSerializerSettings)
            : this(connectionManage, jsonSerializerSettings, new MessageSerializer()) { }

        public OperationManager(IConnectionManager connectionManage, JsonSerializerSettings jsonSerializerSettings, MessageSerializer serializer)
        {
            JsonSerializerSettings = jsonSerializerSettings;
            ConnectionManager = connectionManage;
            MessageSerializer = serializer;
        }

        public OperationManager()
        {
            MessageSerializer = new MessageSerializer();
            JsonSerializerSettings = new JsonSerializerSettings();
            ConnectionManager = new HttpManager(JsonSerializerSettings);
        }

        #endregion Constructors


        public bool TryConnectTo(string endpoin, CancellationToken token)
        {
            return ConnectionManager.TryConnectTo(endpoin, token);
        }

        public bool TryConnectTo(IEnumerable<string> urls, CancellationToken token)
        {
            return ConnectionManager.TryConnectTo(urls, token);
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
            var args = new BroadcastTransactionArgs
            {
                Trx = transaction
            };
            return BroadcastTransaction(args, token);
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
            var args = new BroadcastTransactionSynchronousArgs
            {
                Trx = transaction
            };
            return BroadcastTransactionSynchronous(args, token);
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
        public JsonRpcResponse<VerifyAuthorityReturn> VerifyAuthority(IList<byte[]> userPrivateKeys, CancellationToken token, params BaseOperation[] testOps)
        {
            var prop = DynamicGlobalPropertyApiObj.Default;
            var transaction = CreateTransaction(prop, userPrivateKeys, token, testOps);
            var args = new VerifyAuthorityArgs
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
            var jsonRpc = new JsonRpcRequest(JsonSerializerSettings, api, method, data);
            return ConnectionManager.Execute<T>(jsonRpc, token);
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
            return ConnectionManager.Execute<T>(jsonRpc, token);
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
            var jsonRpc = new JsonRpcRequest(JsonSerializerSettings, api, method, data);
            return ConnectionManager.Execute(jsonRpc, token);
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
            return ConnectionManager.Execute(jsonRpc, token);
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
            for (var i = 0; i < userPrivateKeys.Count; i++)
            {
                token.ThrowIfCancellationRequested();
                var userPrivateKey = userPrivateKeys[i];
                var sig = Secp256K1Manager.SignCompressedCompact(data, userPrivateKey);
                transaction.Signatures[i] = Hex.ToString(sig);
            }

            return transaction;
        }

        public byte[] TryLoadChainId(string[] chainFieldName, CancellationToken token)
        {
            var resp = GetConfig<JObject>(token);
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
    }
}
