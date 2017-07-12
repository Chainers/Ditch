using System;
using System.Collections.Generic;
using Cryptography.ECDSA;
using Ditch.Helpers;
using Ditch.JsonRpc;
using Ditch.Operations.Get;
using Ditch.Operations.Post;

namespace Ditch
{
    public class OperationManager
    {
        private static readonly WebSocketManager WebSocketManager;

        static OperationManager()
        {
            WebSocketManager = new WebSocketManager();
        }

        /// <summary>
        /// Create and broadcast transaction
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse BroadcastOberations(params BaseOperation[] operations)
        {
            var prop = GetDynamicGlobalProperties();
            if (prop.IsError)
            {
                return prop;
            }

            var transaction = CreateTransaction(prop.Result, operations);
            var resp = WebSocketManager.Call(Transaction.Api, Transaction.OperationName, transaction);
            return resp;
        }

        /// <summary>
        /// Get global dinamic properties
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<DynamicGlobalProperties> GetDynamicGlobalProperties()
        {
            return WebSocketManager.GetRequest<DynamicGlobalProperties>(DynamicGlobalProperties.Reques);
        }

        /// <summary>
        /// Get user accounts by user names
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<List<Account>> GetAccounts(params string[] userList)
        {
            return WebSocketManager.GetRequest<List<Account>>(Account.OperationName, $"[[\"{string.Join("\",\"", userList)}\"]]");
        }

        /// <summary>
        /// Execute custom user request
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<bool> VerifyAuthority(params BaseOperation[] testOps)
        {
            var prop = DynamicGlobalProperties.Default;
            var transaction = CreateTransaction(prop, testOps);
            return WebSocketManager.GetRequest<bool>("verify_authority", transaction);
        }

        /// <summary>
        /// Execute custom user request
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<T> GetCustomRequest<T>(string request, params object[] data)
        {
            return WebSocketManager.GetRequest<T>(request, data);
        }

        /// <summary>
        /// Get post by author and permlink
        /// </summary>
        /// <param name="author"></param>
        /// <param name="permlink"></param>
        /// <returns></returns>
        public JsonRpcResponse<Content> GetContent(string author, string permlink)
        {
            return WebSocketManager.Call<Content>(Content.Api, Content.OperationName, author, permlink);
        }

        private Transaction CreateTransaction(DynamicGlobalProperties properties, BaseOperation[] operations)
        {
            var transaction = new Transaction
            {
                ChainId = GlobalSettings.ChainInfo.ChainId,
                RefBlockNum = (ushort)(properties.HeadBlockNumber & 0xffff),
                RefBlockPrefix = (uint)BitConverter.ToInt32(Hex.HexToBytes(properties.HeadBlockId), 4),
                Expiration = properties.Time.AddSeconds(30),
                BaseOperations = operations
            };

            var msg = SerializeHelper.TransactionToMessage(transaction);
            var data = Secp256k1Manager.GetMessageHash(msg);
            var sig = Secp256k1Manager.SignCompressedCompact(data, GlobalSettings.Key);
            transaction.Signatures.Add(sig);

            return transaction;
        }
    }
}