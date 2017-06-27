using System;
using Cryptography.ECDSA;
using Ditch.Helpers;
using Ditch.Operations;
using SuperSocket.ClientEngine;
using Ditch.Models;
using Ditch.Models.Responses;
using System.Threading.Tasks;
using Ditch.JsonRpc;
using Ditch.Responses;

namespace Ditch
{
    public class OperationManager
    {
        private static string _login;
        private static byte[] _key;
        private static ChainInfo _chainInfo;
        private static readonly WebSocketManager WebSocketManager;

        static OperationManager()
        {
            WebSocketManager = new WebSocketManager();
        }

        public void Init(ChainManager.KnownChains chain)
        {
            _chainInfo = ChainManager.GetChainInfo(chain);
            WebSocketManager.InitTransactionManager(_chainInfo.Url);
        }

        public void Init(ChainManager.KnownChains chain, string login, string wif)
        {
            _login = login;
            _key = Base58.GetBytes(wif);
            _chainInfo = ChainManager.GetChainInfo(chain);
            WebSocketManager.InitTransactionManager(_chainInfo.Url);
        }

        public void Init(ChainManager.KnownChains chain, string login, string wif, EventHandler<ErrorEventArgs> websocketError)
        {
            _login = login;
            _key = Base58.GetBytes(wif);
            _chainInfo = ChainManager.GetChainInfo(chain);
            WebSocketManager.InitTransactionManager(_chainInfo.Url, websocketError);
        }

        private Transaction CreateTransaction(DynamicGlobalProperties properties, BaseOperation[] operations)
        {
            var transaction = new Transaction
            {
                ChainId = _chainInfo.ChainId,
                RefBlockNum = (ushort)(properties.HeadBlockNumber & 0xffff),
                RefBlockPrefix = (uint)BitConverter.ToInt32(Hex.HexToBytes(properties.HeadBlockId), 4),
                Expiration = properties.Time.AddSeconds(30)
            };

            transaction.BaseOperations = operations;

            var msg = SerializeHelper.TransactionToMessage(transaction);
            var data = Secp256k1Manager.GetMessageHash(msg);
            var sig = Secp256k1Manager.SignCompressedCompact(data, _key);
            transaction.Signatures.Add(sig);

            return transaction;
        }

        #region

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
        public async Task<OperationResult<VoteResponse>> Vote(string autor, string permlink, ushort weight)
        {
            var rez = new OperationResult<VoteResponse>();
            var op = new VoteOperation
            {
                Author = autor,
                Voter = _login,
                Permlink = permlink,
                Weight = weight
            };

            var prop = await GetDynamicGlobalProperties();

            if (prop.IsError)
            {
                rez.Errors.Add(prop.GetErrorMessage());
                return rez;
            }

            var transaction = CreateTransaction(prop.Result, new BaseOperation[] { op });
            var resp = await WebSocketManager.Call(Transaction.Api, Transaction.OperationName, transaction);

            if (resp.IsError)
            {
                rez.Errors.Add(resp.GetErrorMessage());
                return rez;
            }

            var cont = await GetContent(autor, permlink);
            if (cont.IsError)
            {
                rez.Errors.Add(cont.GetErrorMessage());
                return rez;
            }
            rez.Result = new VoteResponse { NewTotalPayoutReward = cont.Result.NewTotalPayoutReward };
            return rez;
        }

        #endregion Operations

        public void Close()
        {
            _login = string.Empty;
            _key = null;
            _chainInfo = null;
            WebSocketManager.Close();
        }
    }
}