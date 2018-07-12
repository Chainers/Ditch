using Ditch.Core.JsonRpc;
using Ditch.BitShares.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Ditch.BitShares
{
    /**
     * @brief The network_broadcast_api class allows broadcasting of transactions.
     */

    /// <summary>
    /// network_broadcast_api
    /// libraries\app\include\graphene\app\api.hpp
    /// </summary>
    public partial class OperationManager
    {

        /// <summary>
        /// API name: broadcast_transaction
        /// Broadcast a transaction to the network
        ///
        /// 
        /// </summary>
        /// <param name="trx">API type: signed_transaction The transaction to broadcast
        /// 
        /// The transaction will be checked for validity in the local database prior to broadcasting. If it fails to
        /// apply locally, an error will be thrown and the transaction will not be broadcast.</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: void</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<VoidResponse>> BroadcastTransaction(SignedTransaction trx, CancellationToken token)
        {
            return CustomGetRequest<VoidResponse>(KnownApiNames.NetworkBroadcastApi, "broadcast_transaction", new object[] { trx }, token);
        }


        /** this version of broadcast transaction registers a callback method that will be called when the transaction is
         * included into a block.  The callback method includes the transaction id, block number, and transaction number in the
         * block.
         */

        /// <summary>
        /// API name: broadcast_transaction_synchronous
        /// 
        /// </summary>
        /// <param name="trx">API type: signed_transaction</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: variant</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<object>> BroadcastTransactionSynchronous(SignedTransaction trx, CancellationToken token)
        {
            return CustomGetRequest<object>(KnownApiNames.NetworkBroadcastApi, "broadcast_transaction_synchronous", new object[] { trx }, token);
        }

        /// <summary>
        /// API name: broadcast_block
        /// 
        /// </summary>
        /// <param name="block">API type: signed_block</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: void</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<VoidResponse>> BroadcastBlock(SignedBlock block, CancellationToken token)
        {
            return CustomGetRequest<VoidResponse>(KnownApiNames.NetworkBroadcastApi, "broadcast_block", new object[] { block }, token);
        }
    }
}
