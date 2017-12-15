using System.Threading;
using Ditch.Core.JsonRpc;
using System;
using Ditch.Golos.Objects;

namespace Ditch.Golos
{
    /**
     * @brief The network_broadcast_api class allows broadcasting of transactions.
     */

    /// <summary>
    /// network_broadcast_api
    /// libraries\application\include\golos\application\api.hpp
    /// </summary>
    public partial class OperationManager
    {

        /// <summary>
        /// API name: broadcast_transaction
        /// Broadcast a transaction to the network
        ///
        /// *The transaction will be checked for validity in the local database prior to broadcasting. If it fails to apply locally, an error will be thrown and the transaction will not be broadcast.
        /// 
        /// </summary>
        /// <param name="trx">API type: signed_transaction The transaction to broadcast
        /// 
        /// The transaction will be checked for validity in the local database prior to broadcasting. If it fails to
        /// apply locally, an error will be thrown and the transaction will not be broadcast.</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: void</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse BroadcastTransaction(SignedTransaction trx, CancellationToken token)
        {
            return CallRequest(KnownApiNames.NetworkBroadcastApi, "broadcast_transaction", new object[] { trx }, token);
        }

        /// <summary>
        /// API name: broadcast_transaction_with_callback
        /// this version of broadcast transaction registers a callback method that will be called when the transaction is
        /// included into a block.  The callback method includes the transaction id, block number, and transaction number in the
        /// block.
        ///
        /// 
        /// </summary>
        /// <param name="cb">API type: confirmation_callback</param>
        /// <param name="trx">API type: signed_transaction</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: void</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse BroadcastTransactionWithCallback(object cb, SignedTransaction trx, CancellationToken token)
        {
            return CallRequest(KnownApiNames.NetworkBroadcastApi, "broadcast_transaction_with_callback", new object[] { cb, trx }, token);
        }

        /// <summary>
        /// API name: broadcast_transaction_synchronous
        /// This call will not return until the transaction is included in a block.
        ///
        /// 
        /// </summary>
        /// <param name="trx">API type: signed_transaction</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: variant</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<object> BroadcastTransactionSynchronous(SignedTransaction trx, CancellationToken token)
        {
            return CallRequest<object>(KnownApiNames.NetworkBroadcastApi, "broadcast_transaction_synchronous", new object[] { trx }, token);
        }

        /// <summary>
        /// API name: broadcast_block
        /// 
        /// </summary>
        /// <param name="block">API type: signed_block</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: void</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse BroadcastBlock(SignedBlock block, CancellationToken token)
        {
            return CallRequest(KnownApiNames.NetworkBroadcastApi, "broadcast_block", new object[] { block }, token);
        }

        /// <summary>
        /// API name: set_max_block_age
        /// 
        /// </summary>
        /// <param name="maxBlockAge">API type: int32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: void</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse SetMaxBlockAge(Int32 maxBlockAge, CancellationToken token)
        {
            return CallRequest(KnownApiNames.NetworkBroadcastApi, "set_max_block_age", new object[] { maxBlockAge }, token);
        }
    }
}