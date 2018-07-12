using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.JsonRpc;
using Ditch.Steem.JsonRpc;
using Ditch.Steem.Models;
using Ditch.Steem.Operations;
using Newtonsoft.Json;

namespace Ditch.Steem
{
    public partial class OperationManager
    {
        #region system

        public JsonSerializerSettings CondenserJsonSerializerSettings { get; set; }

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
        public Task<JsonRpcResponse<T>> CondenserCustomGetRequest<T>(string api, string method, object data, CancellationToken token)
        {
            var jsonRpc = JsonRpcRequest.CondenserRequest(CondenserJsonSerializerSettings, api, method, data);
            return ConnectionManager.ExecuteAsync<T>(jsonRpc, CondenserJsonSerializerSettings, token);
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
        public Task<JsonRpcResponse<T>> CondenserCustomGetRequest<T>(string api, string method, CancellationToken token)
        {
            var jsonRpc = JsonRpcRequest.CondenserRequest(api, method);
            return ConnectionManager.ExecuteAsync<T>(jsonRpc, CondenserJsonSerializerSettings, token);
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
        public async Task<JsonRpcResponse<VoidResponse>> CondenserBroadcastOperations(IList<byte[]> userPrivateKeys, BaseOperation[] operations, CancellationToken token)
        {
            var prop = await CondenserGetDynamicGlobalProperties(token);
            if (prop.IsError)
                return new JsonRpcResponse<VoidResponse>(prop);

            var transaction = await CreateTransaction(prop.Result, userPrivateKeys, operations, token);
            var args = new BroadcastTransactionArgs
            {
                Trx = transaction
            };
            return await CondenserBroadcastTransaction(args, token);
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
        public async Task<JsonRpcResponse<BroadcastTransactionSynchronousReturn>> CondenserBroadcastOperationsSynchronous(IList<byte[]> userPrivateKeys, BaseOperation[] operations, CancellationToken token)
        {
            var prop = await CondenserGetDynamicGlobalProperties(token);
            if (prop.IsError)
                return new JsonRpcResponse<BroadcastTransactionSynchronousReturn>(prop);

            var transaction = await CreateTransaction(prop.Result, userPrivateKeys, operations, token);
            var args = new BroadcastTransactionSynchronousArgs
            {
                Trx = transaction
            };
            return await CondenserBroadcastTransactionSynchronous(args, token);
        }

        public async Task<JsonRpcResponse<VerifyAuthorityReturn>> CondenserVerifyAuthority(IList<byte[]> userPrivateKeys, BaseOperation[] testOps, CancellationToken token)
        {
            var prop = DynamicGlobalPropertyApiObj.Default;
            var transaction = await CreateTransaction(prop, userPrivateKeys, testOps, token);
            var args = new VerifyAuthorityArgs
            {
                Trx = transaction
            };
            return await CondenserVerifyAuthority(args, token);
        }

        #endregion


        /// <summary>
        /// API name: broadcast_block
        /// 
        /// </summary>
        /// <param name="args">API type: broadcast_block_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<VoidResponse>> CondenserBroadcastBlock(BroadcastBlockArgs args, CancellationToken token)
        {
            var aargs = new object[] { args.Block };
            return CondenserCustomGetRequest<VoidResponse>(KnownApiNames.CondenserApi, "broadcast_block", aargs, token);
        }

        /// <summary>
        /// API name: broadcast_transaction
        /// 
        /// </summary>
        /// <param name="args">API type: broadcast_transaction_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<VoidResponse>> CondenserBroadcastTransaction(BroadcastTransactionArgs args, CancellationToken token)
        {
            var aargs = new object[] { args.Trx };
            return CondenserCustomGetRequest<VoidResponse>(KnownApiNames.CondenserApi, "broadcast_transaction", aargs, token);
        }

        /// <summary>
        /// API name: broadcast_transaction_synchronous
        /// 
        /// </summary>
        /// <param name="args">API type: broadcast_transaction_synchronous_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: broadcast_transaction_synchronous_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<BroadcastTransactionSynchronousReturn>> CondenserBroadcastTransactionSynchronous(BroadcastTransactionSynchronousArgs args, CancellationToken token)
        {
            var aargs = new object[] { args.Trx };
            return CondenserCustomGetRequest<BroadcastTransactionSynchronousReturn>(KnownApiNames.CondenserApi, "broadcast_transaction_synchronous", aargs, token);
        }

        /// <summary>
        /// API name: get_account_bandwidth
        /// 
        /// </summary>
        /// <param name="args">API type: get_account_bandwidth_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_account_bandwidth_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<AccountBandwidthApiObj>> CondenserGetAccountBandwidth(GetAccountBandwidthArgs args, CancellationToken token)
        {
            var aargs = new object[] { args.Account, args.Type };
            return CondenserCustomGetRequest<AccountBandwidthApiObj>(KnownApiNames.CondenserApi, "get_account_bandwidth", aargs, token);
        }

        public Task<JsonRpcResponse<long>> CondenserGetAccountCount(CancellationToken token)
        {
            return CondenserCustomGetRequest<long>(KnownApiNames.CondenserApi, "get_account_count", token);
        }

        /// <summary>
        /// API name: get_account_history
        /// 
        /// </summary>
        /// <param name="args">API type: get_account_history_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_account_history_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetAccountHistoryReturn>> CondenserGetAccountHistory(GetAccountHistoryArgs args, CancellationToken token)
        {
            var aargs = new object[] { args.Account, args.Start, args.Limit };
            return CondenserCustomGetRequest<GetAccountHistoryReturn>(KnownApiNames.CondenserApi, "get_account_history", aargs, token);
        }

        //  "condenser_api.get_account_references",
        //  "condenser_api.get_account_reputations",
        //  "condenser_api.get_account_votes",
        //  "condenser_api.get_accounts",
        //  "condenser_api.get_active_votes",
        //  "condenser_api.get_active_witnesses",
        //  "condenser_api.get_block",
        public Task<JsonRpcResponse<SignedBlockApiObj>> CondenserGetBlock(GetBlockArgs args, CancellationToken token)
        {
            var aargs = new object[] { args.BlockNum };
            return CondenserCustomGetRequest<SignedBlockApiObj>(KnownApiNames.CondenserApi, "get_block", aargs, token);
        }
        //  "condenser_api.get_block_header",
        //  "condenser_api.get_blog",
        //  "condenser_api.get_blog_authors",
        //  "condenser_api.get_blog_entries",
        //  "condenser_api.get_chain_properties",
        //  "condenser_api.get_comment_discussions_by_payout",
        //  "condenser_api.get_config",
        //  "condenser_api.get_content",
        //  "condenser_api.get_content_replies",
        //  "condenser_api.get_conversion_requests",
        //  "condenser_api.get_current_median_history_price",
        //  "condenser_api.get_discussions_by_active",
        //  "condenser_api.get_discussions_by_author_before_date",
        //  "condenser_api.get_discussions_by_blog",
        //  "condenser_api.get_discussions_by_cashout",
        //  "condenser_api.get_discussions_by_children",
        //  "condenser_api.get_discussions_by_comments",
        //  "condenser_api.get_discussions_by_created",
        //  "condenser_api.get_discussions_by_feed",
        //  "condenser_api.get_discussions_by_hot",
        //  "condenser_api.get_discussions_by_promoted",
        //  "condenser_api.get_discussions_by_trending",
        //  "condenser_api.get_discussions_by_votes",
        public Task<JsonRpcResponse<GetDynamicGlobalPropertiesReturn>> CondenserGetDynamicGlobalProperties(CancellationToken token)
        {
            return CondenserCustomGetRequest<GetDynamicGlobalPropertiesReturn>(KnownApiNames.CondenserApi, "get_dynamic_global_properties", token);
        }
        //  "condenser_api.get_escrow",
        //  "condenser_api.get_expiring_vesting_delegations",
        //  "condenser_api.get_feed",
        //  "condenser_api.get_feed_entries",
        //  "condenser_api.get_feed_history",
        //  "condenser_api.get_follow_count",
        //  "condenser_api.get_followers",
        //  "condenser_api.get_following",
        //  "condenser_api.get_hardfork_version",
        //  "condenser_api.get_key_references",
        //  "condenser_api.get_market_history",
        //  "condenser_api.get_market_history_buckets",
        //  "condenser_api.get_next_scheduled_hardfork",
        //  "condenser_api.get_open_orders",
        //  "condenser_api.get_ops_in_block",
        //  "condenser_api.get_order_book",
        //  "condenser_api.get_owner_history",
        //  "condenser_api.get_post_discussions_by_payout",
        //  "condenser_api.get_potential_signatures",
        //  "condenser_api.get_reblogged_by",
        //  "condenser_api.get_recent_trades",
        //  "condenser_api.get_recovery_request",
        //  "condenser_api.get_replies_by_last_update",
        //  "condenser_api.get_required_signatures",
        //  "condenser_api.get_reward_fund",
        //  "condenser_api.get_savings_withdraw_from",
        //  "condenser_api.get_savings_withdraw_to",
        //  "condenser_api.get_state",
        //  "condenser_api.get_tags_used_by_author",
        //  "condenser_api.get_ticker",
        //  "condenser_api.get_trade_history",
        //  "condenser_api.get_transaction",
        //  "condenser_api.get_transaction_hex",
        //  "condenser_api.get_trending_tags",
        public Task<JsonRpcResponse<ApiTagObject[]>> CondenserGetTrendingTags(GetTrendingTagsArgs args, CancellationToken token)
        {
            var aargs = new object[] { args.StartTag, args.Limit };
            return CondenserCustomGetRequest<ApiTagObject[]>(KnownApiNames.CondenserApi, "get_trending_tags", aargs, token);
        }
        //  "condenser_api.get_version",
        //  "condenser_api.get_vesting_delegations",
        //  "condenser_api.get_volume",
        //  "condenser_api.get_withdraw_routes",
        //  "condenser_api.get_witness_by_account",
        //  "condenser_api.get_witness_count",
        //  "condenser_api.get_witness_schedule",
        //  "condenser_api.get_witnesses",
        //  "condenser_api.get_witnesses_by_vote",
        //  "condenser_api.lookup_account_names",
        //  "condenser_api.lookup_accounts",
        //  "condenser_api.lookup_witness_accounts",
        //  "condenser_api.verify_account_authority",

        /// <summary>
        /// API name: verify_authority
        /// 
        /// </summary>
        /// <param name="args">API type: verify_authority_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: verify_authority_return true of the @ref trx has all of the required signatures, otherwise throws an exception</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<VerifyAuthorityReturn>> CondenserVerifyAuthority(VerifyAuthorityArgs args, CancellationToken token)
        {
            return CondenserCustomGetRequest<VerifyAuthorityReturn>(KnownApiNames.CondenserApi, "verify_authority", args, token);
        }
    }
}
