using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Models;

namespace Ditch.Steem
{
    /// <summary>
    /// network_broadcast_api
    /// libraries\plugins\apis\network_broadcast_api\include\steem\plugins\network_broadcast_api\network_broadcast_api.hpp
    /// </summary>
    public partial class OperationManager
    {

        /// <summary>
        /// API name: broadcast_transaction
        /// 
        /// </summary>
        /// <param name="args">API type: broadcast_transaction_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<VoidResponse>> BroadcastTransactionAsync(BroadcastTransactionArgs args, CancellationToken token)
        {
            return CustomBroadcastRequestAsync<VoidResponse>(KnownApiNames.NetworkBroadcastApi, "broadcast_transaction", args, token);
        }

        /// <summary>
        /// API name: broadcast_transaction_synchronous
        /// 
        /// </summary>
        /// <param name="args">API type: broadcast_transaction_synchronous_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: broadcast_transaction_synchronous_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<BroadcastTransactionSynchronousReturn>> BroadcastTransactionSynchronousAsync(BroadcastTransactionSynchronousArgs args, CancellationToken token)
        {
            return CustomBroadcastRequestAsync<BroadcastTransactionSynchronousReturn>(KnownApiNames.NetworkBroadcastApi, "broadcast_transaction_synchronous", args, token);
        }

        /// <summary>
        /// API name: broadcast_block
        /// 
        /// </summary>
        /// <param name="args">API type: broadcast_block_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<VoidResponse>> BroadcastBlockAsync(BroadcastBlockArgs args, CancellationToken token)
        {
            return CustomBroadcastRequestAsync<VoidResponse>(KnownApiNames.NetworkBroadcastApi, "broadcast_block", args, token);
        }

        /// <summary>
        /// API name: broadcast_transaction
        /// 
        /// </summary>
        /// <param name="args">API type: broadcast_transaction_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<VoidResponse>> BroadcastTransactionLikeSteemitAsync(BroadcastTransactionArgs args, CancellationToken token)
        {
            return CondenserBroadcastRequestAsync<VoidResponse>(KnownApiNames.NetworkBroadcastApi, "broadcast_transaction", args, token);
        }

        /// <summary>
        /// API name: broadcast_transaction_synchronous
        /// 
        /// </summary>
        /// <param name="args">API type: broadcast_transaction_synchronous_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: broadcast_transaction_synchronous_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<BroadcastTransactionSynchronousReturn>> BroadcastTransactionSynchronousLikeSteemitAsync(BroadcastTransactionSynchronousArgs args, CancellationToken token)
        {
            return CondenserBroadcastRequestAsync<BroadcastTransactionSynchronousReturn>(KnownApiNames.NetworkBroadcastApi, "broadcast_transaction_synchronous", args, token);
        }

        /// <summary>
        /// API name: broadcast_block
        /// 
        /// </summary>
        /// <param name="args">API type: broadcast_block_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<VoidResponse>> BroadcastBlockLikeSteemitAsync(BroadcastBlockArgs args, CancellationToken token)
        {
            return CondenserBroadcastRequestAsync<VoidResponse>(KnownApiNames.NetworkBroadcastApi, "broadcast_block", args, token);
        }
    }
}
