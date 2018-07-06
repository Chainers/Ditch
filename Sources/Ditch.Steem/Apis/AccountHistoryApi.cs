using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Models;

namespace Ditch.Steem
{
    /// <summary>
    /// account_history_api
    /// libraries\plugins\apis\account_history_api\include\steem\plugins\account_history_api\account_history_api.hpp
    /// </summary>
    public partial class OperationManager
    {

        /// <summary>
        /// API name: get_ops_in_block
        /// 
        /// </summary>
        /// <param name="args">API type: get_ops_in_block_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_ops_in_block_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetOpsInBlockReturn> GetOpsInBlock(GetOpsInBlockArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetOpsInBlockReturn>(KnownApiNames.AccountHistoryApi, "get_ops_in_block", args, token);
        }

        /// <summary>
        /// API name: get_transaction
        /// 
        /// </summary>
        /// <param name="args">API type: get_transaction_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_transaction_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetTransactionReturn> GetTransaction(GetTransactionArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetTransactionReturn>(KnownApiNames.AccountHistoryApi, "get_transaction", args, token);
        }

        /// <summary>
        /// API name: get_account_history
        /// 
        /// </summary>
        /// <param name="args">API type: get_account_history_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_account_history_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetAccountHistoryReturn> GetAccountHistory(GetAccountHistoryArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetAccountHistoryReturn>(KnownApiNames.AccountHistoryApi, "get_account_history", args, token);
        }

        /// <summary>
        /// API name: enum_virtual_ops
        /// 
        /// </summary>
        /// <param name="args">API type: enum_virtual_ops_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: enum_virtual_ops_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<EnumVirtualOpsReturn> EnumVirtualOps(EnumVirtualOpsArgs args, CancellationToken token)
        {
            return CustomGetRequest<EnumVirtualOpsReturn>(KnownApiNames.AccountHistoryApi, "enum_virtual_ops", args, token);
        }
    }
}
