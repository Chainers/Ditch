using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Cryptography.ECDSA;
using Ditch.Core;
using Ditch.Core.Helpers;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Helpers;
using Ditch.Steem.Operations;
using Ditch.Steem.Operations.Get;
using Ditch.Steem.Operations.Post;
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

        [Obsolete]
        public OperationManager(string url, byte[] chainId, JsonSerializerSettings jsonSerializerSettings)
        {
            _urls = new List<string>
            {
                url
            };
            ChainId = chainId;
            _jsonSerializerSettings = jsonSerializerSettings;
            _connectionManager = new WebSocketManager(_jsonSerializerSettings);
        }

        [Obsolete]
        public OperationManager(string url, byte[] chainId) : this(url, chainId, GetJsonSerializerSettings(CultureInfo.InvariantCulture))
        {
        }

        [Obsolete]
        public OperationManager(string url, byte[] chainId, CultureInfo cultureInfo) : this(url, chainId, GetJsonSerializerSettings(cultureInfo))
        {
        }

        public OperationManager(List<string> wssUrls, JsonSerializerSettings jsonSerializerSettings)
        {
            _urls = wssUrls;
            _jsonSerializerSettings = jsonSerializerSettings;
            _connectionManager = new WebSocketManager(_jsonSerializerSettings);
        }

        public OperationManager(List<string> wssUrls)
            : this(wssUrls, GetJsonSerializerSettings(CultureInfo.InvariantCulture))
        {
        }

        public OperationManager(JsonSerializerSettings jsonSerializerSettings)
        {
            _jsonSerializerSettings = jsonSerializerSettings;
            _connectionManager = new WebSocketManager(_jsonSerializerSettings);
        }

        public OperationManager()
        {
            _jsonSerializerSettings = GetJsonSerializerSettings(CultureInfo.InvariantCulture);
            _connectionManager = new WebSocketManager(_jsonSerializerSettings);
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
                var connectedTo = _connectionManager.ConnectTo(url, token);
                if (string.IsNullOrEmpty(connectedTo))
                    continue;

                if (TryLoadChainId(token) && TryLoadHardPorkVersion(token))
                    return url;
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
        /// Create and broadcast transaction
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
            {
                return prop;
            }

            var transaction = CreateTransaction(prop.Result, userPrivateKeys, token, operations);
            var resp = CustomGetRequest("call", token, KnownApiNames.NetworkBroadcastApi, Transaction.OperationName, new[] { transaction });
            return resp;
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
        public JsonRpcResponse<bool> VerifyAuthority(IEnumerable<byte[]> userPrivateKeys, CancellationToken token, params BaseOperation[] testOps)
        {
            var prop = DynamicGlobalPropertyApiObj.Default;
            var transaction = CreateTransaction(prop, userPrivateKeys, token, testOps);
            return CustomGetRequest<bool>("verify_authority", token, new[] { transaction });
        }

        /// <summary>
        /// Create and execute custom json-rpc method
        /// </summary>
        /// <typeparam name="T">Custom type. JsonConvert will try to convert json-response to you custom object</typeparam>
        /// <param name="method">Sets json-rpc "method" field</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="data">Sets to json-rpc params field. JsonConvert use`s for convert array of data to string.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<T> CustomGetRequest<T>(string method, CancellationToken token, params object[] data)
        {
            var jsonRpc = new JsonRpcRequest(_jsonSerializerSettings, method, data);
            return _connectionManager.Execute<T>(jsonRpc, token);
        }

        /// <summary>
        /// Create and execute custom json-rpc method
        /// </summary>
        /// <param name="method">Sets json-rpc "method" field</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="data">Sets to json-rpc params field. JsonConvert use`s for convert array of data to string.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse CustomGetRequest(string method, CancellationToken token, params object[] data)
        {
            var jsonRpc = new JsonRpcRequest(_jsonSerializerSettings, method, data);
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
        public Transaction CreateTransaction(DynamicGlobalPropertyApiObj propertyApiObj, IEnumerable<byte[]> userPrivateKeys, CancellationToken token, params BaseOperation[] operations)
        {
            var transaction = new Transaction
            {
                ChainId = ChainId,
                RefBlockNum = (ushort)(propertyApiObj.HeadBlockNumber & 0xffff),
                RefBlockPrefix = (uint)BitConverter.ToInt32(Hex.HexToBytes(propertyApiObj.HeadBlockId), 4),
                Expiration = propertyApiObj.Time.AddSeconds(30),
                BaseOperations = operations
            };

            var msg = SerializeHelper.TransactionToMessage(transaction);
            var data = Secp256k1Manager.GetMessageHash(msg);

            foreach (var userPrivateKey in userPrivateKeys)
            {
                token.ThrowIfCancellationRequested();
                var sig = Secp256k1Manager.SignCompressedCompact(data, userPrivateKey);
                transaction.Signatures.Add(sig);
            }

            return transaction;
        }


        private bool TryLoadChainId(CancellationToken token)
        {
            var resp = GetConfig(token);
            if (!resp.IsError)
            {
                dynamic conf = resp.Result;
                var scid = conf.STEEMIT_CHAIN_ID as JValue;
                var smpsbd = conf.STEEMIT_MIN_PAYOUT_SBD as JValue;
                if (scid != null && smpsbd != null)
                {
                    var cur = smpsbd.Value<string>();
                    var str = scid.Value<string>();
                    if (!string.IsNullOrEmpty(cur) && !string.IsNullOrEmpty(str))
                    {
                        SbdSymbol = new Money(cur).Currency;
                        ChainId = Hex.HexToBytes(str);
                        return true;
                    }
                }
            }
            return false;
        }

        private bool TryLoadHardPorkVersion(CancellationToken token)
        {
            var resp = GetHardforkVersion(token);
            if (!resp.IsError)
            {
                Version = VersionHelper.ToInteger(resp.Result);
                if (Version > 0)
                    return true;
            }
            return false;
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
    }
}