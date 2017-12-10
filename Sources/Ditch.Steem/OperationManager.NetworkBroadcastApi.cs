using System;
using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Operations.Enums;
using Ditch.Steem.Operations.Get;

namespace Ditch.Steem
{
    /**
        * @brief The network_broadcast_api class allows broadcasting of transactions.
        */

    /// <summary>
    /// network_broadcast_api
    /// \libraries\app\include\steemit\app\api.hpp
    /// </summary>
    public partial class OperationManager
    {

        ///**
        // * @brief Broadcast a transaction to the network
        // * @param trx The transaction to broadcast
        // *
        // * The transaction will be checked for validity in the local database prior to broadcasting. If it fails to
        // * apply locally, an error will be thrown and the transaction will not be broadcast.
        // */
        ///// <summary>
        ///// API name: broadcast_transaction
        ///// 
        ///// </summary>
        ///// <param name="trx">API type: signed_transaction</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: void</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse BroadcastTransaction(SignedTransaction trx, CancellationToken token)
        //{
        //    return CustomGetRequest("broadcast_transaction", token, trx);
        //}


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
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: void</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse BroadcastTransactionWithCallback(ConfirmationCallback cb, SignedTransaction trx, CancellationToken token)
        //{
        //    return CustomGetRequest("broadcast_transaction_with_callback", token, cb, trx);
        //}


        ///**
        // * This call will not return until the transaction is included in a block.
        // */
        ///// <summary>
        ///// API name: broadcast_transaction_synchronous
        ///// 
        ///// </summary>
        ///// <param name="trx">API type: signed_transaction</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: variant</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<Variant> BroadcastTransactionSynchronous(SignedTransaction trx, CancellationToken token)
        //{
        //    return CustomGetRequest<Variant>("broadcast_transaction_synchronous", token, trx);
        //}

        ///// <summary>
        ///// API name: broadcast_block
        ///// 
        ///// </summary>
        ///// <param name="block">API type: signed_block</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: void</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse BroadcastBlock(SignedBlock block, CancellationToken token)
        //{
        //    return CustomGetRequest("broadcast_block", token, block);
        //}

        ///// <summary>
        ///// API name: set_max_block_age
        ///// 
        ///// </summary>
        ///// <param name="maxBlockAge">API type: int32_t</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: void</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse SetMaxBlockAge(Int32 maxBlockAge, CancellationToken token)
        //{
        //    return CustomGetRequest("set_max_block_age", token, maxBlockAge);
        //}


        //// implementation detail, not reflected
        ///// <summary>
        ///// API name: check_max_block_age
        ///// 
        ///// </summary>
        ///// <param name="maxBlockAge">API type: int32_t</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: bool</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<bool> CheckMaxBlockAge(Int32 maxBlockAge, CancellationToken token)
        //{
        //    return CustomGetRequest<bool>("check_max_block_age", token, maxBlockAge);
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
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: void</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse OnAppliedBlock(SignedBlock b, CancellationToken token)
        //{
        //    return CustomGetRequest("on_applied_block", token, b);
        //}


        ///// internal method, not exposed via JSON RPC
        ///// <summary>
        ///// API name: on_api_startup
        ///// 
        ///// </summary>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: void</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse OnApiStartup(CancellationToken token)
        //{
        //    return CustomGetRequest("on_api_startup", token);
        //}

    }
}
