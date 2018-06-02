using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Cryptography.ECDSA;
using Ditch.BitShares.JsonRpc;
using Ditch.BitShares.Models;
using Ditch.BitShares.Models.Operations;
using Ditch.Core;
using Ditch.Core.Converters;
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

        public class RequiredFees
        {
            public ulong amount;
            public string asset_id;
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
                //ChainId = ChainId,
                RefBlockNum = (ushort)(propertyApiObj.HeadBlockNumber & 0xffff),
                RefBlockPrefix = (uint)BitConverter.ToInt32(Hex.HexToBytes(propertyApiObj.HeadBlockId), 4),
                Expiration = propertyApiObj.Time.AddSeconds(30),
                BaseOperations = operations
            };

            var reqRez = GetRequiredFees(transaction.BaseOperations, (operations[0] as AccountCreateOperation).Fee.AssetId, CancellationToken.None);
            if (!reqRez.IsError)
            {
                (operations[0] as AccountCreateOperation).Fee.Amount = JsonConvert.DeserializeObject<RequiredFees>(reqRez.Result[0].ToString()).amount;
            }

            VerifyAccountAuthority(
                "nano-blockchain", 
                new PublicKeyType[] {
                    new PublicKeyType("TEST6HWVwXazrgS3MsWZvvSV6qdRbc8GS7KpdfDw8mAcNug4RcPv3v"),
                    //new PublicKeyType("TEST7AX8Ewg85sudNVfwqGcCDEAGnhwyVMgvrWW6bkQT5aDm5fdELM")
                }, 
                CancellationToken.None
            );

            GetPotentialSignatures(transaction, CancellationToken.None);

            GetRequiredSignatures(
                transaction,
                new PublicKeyType[] {
                    new PublicKeyType("TEST6HWVwXazrgS3MsWZvvSV6qdRbc8GS7KpdfDw8mAcNug4RcPv3v"),
                    new PublicKeyType("TEST7AX8Ewg85sudNVfwqGcCDEAGnhwyVMgvrWW6bkQT5aDm5fdELM")
                },
                CancellationToken.None
            );

            var remoteHex = Hex.HexToBytes(GetTransactionHex(transaction, CancellationToken.None).Result);
            var localHex = MessageSerializer.Serialize<SignedTransaction>(transaction);

            string strRez = string.Empty;
            int limit;
            if (remoteHex.Length > localHex.Length)
            {
                limit = remoteHex.Length;
            } else
            {
                limit = localHex.Length;
            }

            for (int i=0; i < limit; i++)
            {
                if (i >= remoteHex.Length || i >= localHex.Length)
                {
                    if (remoteHex.Length > localHex.Length)
                    {
                        strRez += "[" + i.ToString() + "] " + Hex.HexToInteger(new byte[] { remoteHex[i] }).ToString() + "\n";
                    } else
                    {
                        strRez += "[" + i.ToString() + "]     " + Hex.HexToInteger(new byte[] { localHex[i] }).ToString() + "\n";
                    }
                } else
                {
                    strRez += "[" + i.ToString() + "] " + Hex.HexToInteger(new byte[] { remoteHex[i] }).ToString() + " " + Hex.HexToInteger(new byte[] { localHex[i] }).ToString() + "\n";
                }
            }

            UnityEngine.Debug.Log(strRez);
            UnityEngine.Debug.Log("LOCAL HEX =  " + Hex.ToString(localHex));
            UnityEngine.Debug.Log("REMOTE HEX = " + Hex.ToString(remoteHex));
            
            //for (int i=0; i < localHex.Length; i++)
            //{
            //    localHex[i] = 0;
            //}

            var data = Sha256Manager.GetHash(Hex.Join(ChainId, localHex));
            
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

        public static string ConvertHex(String hexString)
        {
            try
            {
                string ascii = string.Empty;

                for (int i = 0; i < hexString.Length; i += 2)
                {
                    String hs = string.Empty;

                    hs = hexString.Substring(i, 2);
                    uint decval = System.Convert.ToUInt32(hs, 16);
                    char character = System.Convert.ToChar(decval);
                    ascii += character;

                }

                return ascii;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return string.Empty;
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
