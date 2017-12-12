using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Golos.Protocol;

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

        /**
         * @brief Broadcast a transaction to the network
         * @param trx The transaction to broadcast
         *
         * The transaction will be checked for validity in the local database prior to broadcasting. If it fails to
         * apply locally, an error will be thrown and the transaction will not be broadcast.
         */
        /// <summary>
        /// API name: broadcast_transaction
        /// 
        /// </summary>
        /// <param name="trx">API type: signed_transaction</param>
        /// <returns>API type: void</returns>
        public JsonRpcResponse BroadcastTransaction(SignedTransaction trx, CancellationToken token)
        {
            return CustomGetRequest("call", token, KnownApiNames.NetworkBroadcastApi, "broadcast_transaction", new[] { trx });
        }

        ///** this version of broadcast transaction registers a callback method that will be called when the transaction is
        // * included into a block.  The callback method includes the transaction id, block number, and transaction number in the
        // * block.
        // */
        ///// <summary>
        ///// API name: broadcast_transaction_with_callback
        ///// 
        ///// </summary>
        ///// <param name="cb">API type: confirmation_callback</param>
        ///// <param name="trx">API type: signed_transaction</param>
        ///// <returns>API type: void</returns>
        //public JsonRpcResponse<Void> BroadcastTransactionWithCallback(ConfirmationCallback cb, SignedTransaction trx)
        //{
        //    return ConnectionManager.GetRequest<Void>("broadcast_transaction_with_callback", cb, trx);
        //}


        ///**
        // * This call will not return until the transaction is included in a block.
        // */
        ///// <summary>
        ///// API name: broadcast_transaction_synchronous
        ///// 
        ///// </summary>
        ///// <param name="trx">API type: signed_transaction</param>
        ///// <returns>API type: variant</returns>
        //public JsonRpcResponse<Variant> BroadcastTransactionSynchronous(SignedTransaction trx)
        //{
        //    return ConnectionManager.GetRequest<Variant>("broadcast_transaction_synchronous", trx);
        //}

        ///// <summary>
        ///// API name: broadcast_block
        ///// 
        ///// </summary>
        ///// <param name="block">API type: signed_block</param>
        ///// <returns>API type: void</returns>
        //public JsonRpcResponse<Void> BroadcastBlock(SignedBlock block)
        //{
        //    return ConnectionManager.GetRequest<Void>("broadcast_block", block);
        //}

        ///// <summary>
        ///// API name: set_max_block_age
        ///// 
        ///// </summary>
        ///// <param name="maxBlockAge">API type: int32_t</param>
        ///// <returns>API type: void</returns>
        //public JsonRpcResponse<Void> SetMaxBlockAge(Int32 maxBlockAge)
        //{
        //    return ConnectionManager.GetRequest<Void>("set_max_block_age", maxBlockAge);
        //}


        //// implementation detail, not reflected
        ///// <summary>
        ///// API name: check_max_block_age
        ///// 
        ///// </summary>
        ///// <param name="maxBlockAge">API type: int32_t</param>
        ///// <returns>API type: bool</returns>
        //public JsonRpcResponse<bool> CheckMaxBlockAge(Int32 maxBlockAge)
        //{
        //    return ConnectionManager.GetRequest<bool>("check_max_block_age", maxBlockAge);
        //}


        ///**
        // * @brief Not reflected, thus not accessible to API clients.
        // *
        // * This function is registered to receive the applied_block
        // * signal from the chain database when a block is received.
        // * It then dispatches callbacks to clients who have requested
        // * to be notified when a particular txid is included in a block.
        // */
        ///// <summary>
        ///// API name: on_applied_block
        ///// 
        ///// </summary>
        ///// <param name="b">API type: signed_block</param>
        ///// <returns>API type: void</returns>
        //public JsonRpcResponse<Void> OnAppliedBlock(SignedBlock b)
        //{
        //    return ConnectionManager.GetRequest<Void>("on_applied_block", b);
        //}


        ///// internal method, not exposed via JSON RPC
        ///// <summary>
        ///// API name: on_api_startup
        ///// 
        ///// </summary>
        ///// <returns>API type: void</returns>
        //public JsonRpcResponse<Void> OnApiStartup()
        //{
        //    return ConnectionManager.GetRequest<Void>("on_api_startup");
        //}
    }
}