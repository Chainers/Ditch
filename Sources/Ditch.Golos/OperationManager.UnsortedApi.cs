using System;
using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Golos.Dtos;

namespace Ditch.Golos
{
    public partial class OperationManager
    {
        ////////////
        // Market //
        ////////////


        /// <summary>
        /// Gets the current order book for STEEM:SBD market
        /// </summary>
        /// <param name="limit">Maximum number of orders for each side of the spread to return -- Must not exceed 1000</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: order_book</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<OrderBook> GetOrderBook(UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<OrderBook>("get_order_book", token, limit);
        }
    }
}