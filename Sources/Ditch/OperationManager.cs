using System;
using Cryptography.ECDSA;
using Ditch.Helpers;
using Ditch.Operations;
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

        #region Operations

        private JsonRpcResponse BroadcastOberation(BaseOperation op)
        {
            var prop = GetDynamicGlobalProperties();
            if (prop.IsError)
            {
                return prop;
            }

            var transaction = CreateTransaction(prop.Result, new[] { op });
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
        /// Get post by author and permlink
        /// </summary>
        /// <param name="author"></param>
        /// <param name="permlink"></param>
        /// <returns></returns>
        public JsonRpcResponse<Content> GetContent(string author, string permlink)
        {
            return WebSocketManager.Call<Content>(Content.Api, Content.OperationName, author, permlink);
        }

        /// <summary>
        /// Vote up/down post
        /// </summary>
        /// <param name="autor">Post author</param>
        /// <param name="permlink">Post link</param>
        /// <param name="weight">An weignt from 0 to 10000. -10000 for flag</param>
        /// <returns>VoteResponse - contain NewTotalPayoutReward</returns>
        public JsonRpcResponse Vote(string autor, string permlink, short weight)
        {
            var op = new VoteOperation
            {
                Author = autor,
                Voter = GlobalSettings.Login,
                Permlink = permlink,
                Weight = weight
            };

            return BroadcastOberation(op);
        }


        /// <summary>
        /// Follow user
        /// </summary>
        /// <param name="name">User name</param>
        /// <returns></returns>
        public JsonRpcResponse Follow(string name)
        {
            var op = CustomJsonOperation.Follow(name, "blog");
            op.RequiredPostingAuths = new[] { GlobalSettings.Login };
            return BroadcastOberation(op);
        }

        /// <summary>
        /// Unfollow user
        /// </summary>
        /// <param name="name">User name</param>
        /// <returns></returns>
        public JsonRpcResponse UnFollow(string name)
        {
            var op = CustomJsonOperation.Follow(name, string.Empty);
            op.RequiredPostingAuths = new[] { GlobalSettings.Login };
            return BroadcastOberation(op);
        }

        /// <summary>
        /// Repost some post by author and permlink (loads all additional parameters from the blockchain)
        /// </summary>
        /// <param name="author">post author</param>
        /// <param name="permlink">post permlink</param>
        /// <returns></returns>
        public JsonRpcResponse RePost(string author, string permlink)
        {
            var op = CustomJsonOperation.ReBlog(author, permlink);
            op.RequiredPostingAuths = new[] { GlobalSettings.Login };
            return BroadcastOberation(op);
        }


        public JsonRpcResponse AddPost(string permlink, string title, string body, string jsonMetadata, string parentPermlink)
        {
            return AddComment(permlink, title, body, jsonMetadata, string.Empty, parentPermlink);
        }

        public JsonRpcResponse AddComment(string permlink, string title, string body, string jsonMetadata, string parentAuthor, string parentPermlink)
        {
            var op = new CommentOperation
            {
                Author = GlobalSettings.Login,
                ParentAuthor = parentAuthor,
                ParentPermlink = parentPermlink,
                Permlink = permlink,
                Title = title,
                Body = body,
                JsonMetadata = jsonMetadata
            };
            return BroadcastOberation(op);
        }

        #endregion Operations
    }
}