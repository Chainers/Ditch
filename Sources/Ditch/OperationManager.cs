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

        public OperationManager()
        {
            _jsonSerializerSettings = GetJsonSerializerSettings(CultureInfo.InvariantCulture);
        }

        #endregion Constructors


        public string TryConnectTo(List<string> urls)
        {
            if (_urls != urls)
                _urls = urls;

            _webSocketManager?.Dispose();

            foreach (var url in urls)
            {
                _webSocketManager = new WebSocketManager(url, _jsonSerializerSettings);
                var resp = GetConfig();
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

        public string RetryConnect()
        {
            return TryConnectTo(_urls);
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
            var resp = WebSocketManager.Call(Transaction.Api, Transaction.OperationName, transaction);
            return resp;
        }

        /// <summary>
        /// Get user accounts by user names
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<ExtendedAccount[]> GetAccounts(params string[] userList)
        {
            return WebSocketManager.GetRequest<ExtendedAccount[]>("get_accounts", $"[[\"{string.Join("\",\"", userList)}\"]]");
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
            return WebSocketManager.GetRequest<bool>("verify_authority", transaction);
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
            return WebSocketManager.GetRequest<T>(method, transaction);
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
            return WebSocketManager.GetRequest<T>(method, data);
        }

        /// <summary>
        /// Get post by author and permlink
        /// </summary>
        /// <param name="author"></param>
        /// <param name="permlink"></param>
        /// <returns></returns>
        public JsonRpcResponse<Discussion> GetContent(string author, string permlink)
        {
            return WebSocketManager.Call<Discussion>((int)Api.DefaultApi, "get_content", author, permlink);
        }

        public Transaction CreateTransaction(DynamicGlobalPropertyApiObj propertyApiObj, IEnumerable<byte[]> userPrivateKeys, params BaseOperation[] operations)
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
                var sig = Secp256k1Manager.SignCompressedCompact(data, userPrivateKey);
                transaction.Signatures.Add(sig);
            }

            return transaction;
        }
    }
}