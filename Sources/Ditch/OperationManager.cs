using System;
using Cryptography.ECDSA;
using Ditch.Helpers;
using Ditch.Operations;
using System.Threading.Tasks;
using Ditch.JsonRpc;
using Ditch.Responses;

namespace Ditch
{
    public class OperationManager
    {
        private static readonly WebSocketManager WebSocketManager;

        static OperationManager()
        {
            WebSocketManager = new WebSocketManager();
        }

        private Transaction CreateTransaction(DynamicGlobalProperties properties, BaseOperation[] operations)
        {
            var transaction = new Transaction
            {
                ChainId = GlobalSettings.ChainInfo.ChainId,
                RefBlockNum = (ushort) (properties.HeadBlockNumber & 0xffff),
                RefBlockPrefix = (uint) BitConverter.ToInt32(Hex.HexToBytes(properties.HeadBlockId), 4),
                Expiration = properties.Time.AddSeconds(30),
                BaseOperations = operations
            };
            
            var msg = SerializeHelper.TransactionToMessage(transaction);
            var data = Secp256k1Manager.GetMessageHash(msg);
            var sig = Secp256k1Manager.SignCompressedCompact(data, GlobalSettings.Key);
            transaction.Signatures.Add(sig);

            return transaction;
        }

        #region Operations

        /// <summary>
        /// Get global dinamic properties
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<DynamicGlobalProperties>> GetDynamicGlobalProperties()
        {
            return WebSocketManager.GetRequest<DynamicGlobalProperties>(DynamicGlobalProperties.Reques);
        }

        /// <summary>
        /// Get post by author and permlink
        /// </summary>
        /// <param name="author"></param>
        /// <param name="permlink"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<Content>> GetContent(string author, string permlink)
        {
            return WebSocketManager.Call<Content>(Content.Api, Content.OperationName, author, permlink);
        }

        /// <summary>
        /// Vote up/down post
        /// </summary>
        /// <param name="autor">Post author</param>
        /// <param name="permlink">Post link</param>
        /// <param name="weight">An weignt from 0 to 10000</param>
        /// <returns>VoteResponse - contain NewTotalPayoutReward</returns>
        public async Task<JsonRpcResponse> Vote(string autor, string permlink, ushort weight)
        {
            var op = new VoteOperation
            {
                Author = autor,
                Voter = GlobalSettings.Login,
                Permlink = permlink,
                Weight = weight
            };

            var prop = await GetDynamicGlobalProperties();

            if (prop.IsError)
            {
                return prop;
            }

            var transaction = CreateTransaction(prop.Result, new BaseOperation[] { op });
            var resp = await WebSocketManager.Call(Transaction.Api, Transaction.OperationName, transaction);

            return resp;
        }

        #endregion Operations
    }
}