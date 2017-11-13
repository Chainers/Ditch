using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Cryptography.ECDSA;
using Ditch.Core;
using Ditch.Core.Helpers;
using Ditch.Core.JsonRpc;
using Ditch.Golos.Helpers;
using Ditch.Golos.Operations;
using Ditch.Golos.Operations.Get;
using Ditch.Golos.Operations.Post;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ditch.Golos
{
    public partial class OperationManager
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private List<string> _urls;
        private WebSocketManager _webSocketManager;
        private byte[] _chainId;
        private string _sbdSymbol;

        public byte[] ChainId
        {
            get
            {
                if (_webSocketManager == null)
                    RetryConnect();
                return _chainId;
            }
        }

        public string SbdSymbol
        {
            get
            {
                if (_webSocketManager == null)
                    RetryConnect();
                return _sbdSymbol;
            }
        }

        private WebSocketManager WebSocketManager
        {
            get
            {
                if (_webSocketManager == null)
                    RetryConnect();
                return _webSocketManager;
            }
        }

        #region Constructors

        [Obsolete]
        public OperationManager(string url, byte[] chainId, JsonSerializerSettings jsonSerializerSettings)
        {
            _urls = new List<string>
            {
                url
            };
            _chainId = chainId;
            _jsonSerializerSettings = jsonSerializerSettings;
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
        }

        public OperationManager(List<string> wssUrls)
            : this(wssUrls, GetJsonSerializerSettings(CultureInfo.InvariantCulture))
        {
        }

        public OperationManager(JsonSerializerSettings jsonSerializerSettings)
        {
            _jsonSerializerSettings = jsonSerializerSettings;
        }

        public OperationManager()
        {
            _jsonSerializerSettings = GetJsonSerializerSettings(CultureInfo.InvariantCulture);
        }

        #endregion Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="urls"></param>
        /// <returns></returns>
        public string TryConnectTo(List<string> urls)
        {
            return TryConnectTo(urls, CancellationToken.None);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="urls"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public string TryConnectTo(List<string> urls, CancellationToken token)
        {
            if (_urls != urls)
                _urls = urls;

            _webSocketManager?.Dispose();

            foreach (var url in urls)
            {
                _webSocketManager = new WebSocketManager(url, _jsonSerializerSettings);
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
                            _sbdSymbol = new Money(cur).Currency;
                            _chainId = Hex.HexToBytes(str);
                            return url;
                        }
                    }
                }
                _webSocketManager.Dispose();
            }

            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string RetryConnect()
        {
            return RetryConnect(CancellationToken.None);
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
        /// <param name="userPrivateKeys"></param>
        /// <param name="operations"></param>
        /// <returns></returns>
        public JsonRpcResponse BroadcastOperations(IEnumerable<byte[]> userPrivateKeys, params BaseOperation[] operations)
        {
            return BroadcastOperations(userPrivateKeys, CancellationToken.None, operations);
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

            var transaction = CreateTransaction(prop.Result, userPrivateKeys, operations);
            var resp = WebSocketManager.Call(KnownApiNames.NetworkBroadcastApi, Transaction.OperationName, token, transaction);
            return resp;
        }

        /// <summary>
        /// Get user accounts by user names
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<ExtendedAccount[]> GetAccounts(params string[] userList)
        {
            return GetAccounts(CancellationToken.None, userList);
        }

        /// <summary>
        /// Get user accounts by user names
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="userList"></param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ExtendedAccount[]> GetAccounts(CancellationToken token, params string[] userList)
        {
            return WebSocketManager.GetRequest<ExtendedAccount[]>("get_accounts", $"[[\"{string.Join("\",\"", userList)}\"]]", token);
        }

        /// <summary>
        /// Execute custom user method
        /// Возвращает TRUE если транзакция подписана правильно
        /// </summary>
        /// <param name="userPrivateKeys"></param>
        /// <param name="testOps"></param>
        /// <returns></returns>
        public JsonRpcResponse<bool> VerifyAuthority(IEnumerable<byte[]> userPrivateKeys, params BaseOperation[] testOps)
        {
            return VerifyAuthority(userPrivateKeys, CancellationToken.None, testOps);
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
            var transaction = CreateTransaction(prop, userPrivateKeys, testOps);
            return WebSocketManager.GetRequest<bool>("verify_authority", token, transaction);
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
            return CustomPostRequest<T>(method, transaction, CancellationToken.None);
        }

        /// <summary>
        /// Create and execute custom json-rpc method
        /// </summary>
        /// <typeparam name="T">Custom type. JsonConvert will try to convert json-response to you custom object</typeparam>
        /// <param name="method">Sets json-rpc "method" field</param>
        /// <param name="transaction">Sets to json-rpc params field. JsonConvert use`s for convert array of data to string.</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<T> CustomPostRequest<T>(string method, Transaction transaction, CancellationToken token)
        {
            return WebSocketManager.GetRequest<T>(method, token, transaction);
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
            return CustomGetRequest<T>(method, CancellationToken.None, data);
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
            return WebSocketManager.GetRequest<T>(method, token, data);
        }

        /// <summary>
        /// Get post by author and permlink
        /// </summary>
        /// <param name="author"></param>
        /// <param name="permlink"></param>
        /// <returns></returns>
        public JsonRpcResponse<Discussion> GetContent(string author, string permlink)
        {
            return GetContent(author, permlink, CancellationToken.None);
        }

        /// <summary>
        /// Get post by author and permlink
        /// </summary>
        /// <param name="author"></param>
        /// <param name="permlink"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion> GetContent(string author, string permlink, CancellationToken token)
        {
            return WebSocketManager.Call<Discussion>(KnownApiNames.DatabaseApi, "get_content", token, author, permlink);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyApiObj"></param>
        /// <param name="userPrivateKeys"></param>
        /// <param name="operations"></param>
        /// <returns></returns>
        public Transaction CreateTransaction(DynamicGlobalPropertyApiObj propertyApiObj, IEnumerable<byte[]> userPrivateKeys, params BaseOperation[] operations)
        {
            return CreateTransaction(propertyApiObj, userPrivateKeys, CancellationToken.None, operations);
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
    }
}