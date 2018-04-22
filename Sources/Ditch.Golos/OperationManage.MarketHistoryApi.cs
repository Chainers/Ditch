using System;
using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Golos.Models.Objects;
using Ditch.Golos.Models.Other;

namespace Ditch.Golos
{
    /// <summary>
    /// market_history_api
    /// libraries\plugins\market_history\include\golos\market_history\market_history_api.hpp
    /// </summary>
    public partial class OperationManager
    {
        /// <summary>
        /// API name: get_market_history
        /// Returns the market history for the internal SBD:STEEM market.
        ///
        /// *Returns the market history for the internal market.
        /// 
        /// </summary>
        /// <param name="bucketSeconds">API type: uint32_t The size of buckets the history is broken into. The bucket size must be configured in the plugin options.</param>
        /// <param name="start">API type: fc::time_point_sec The start time to get market history.</param>
        /// <param name="end">API type: fc::time_point_sec The end time to get market history</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: bucket_object A list of market history buckets.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<BucketObject[]> GetMarketHistory(UInt32 bucketSeconds, DateTime start, DateTime end, CancellationToken token)
        {
            return CustomGetRequest<BucketObject[]>(KnownApiNames.MarketHistory, "get_market_history", new object[] { bucketSeconds, start, end }, token);
        }

        /// <summary>
        /// API name: get_market_history_buckets
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: flat_set</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<UInt32[]> GetMarketHistoryBuckets(CancellationToken token)
        {
            return CustomGetRequest<UInt32[]>(KnownApiNames.MarketHistory, "get_market_history_buckets", new object[] { }, token);
        }

        /// <summary>
        /// API name: get_open_orders
        /// 
        /// </summary>
        /// <param name="owner">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: limit_order</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<LimitOrder[]> GetOpenOrders(string owner, CancellationToken token)
        {
            return CustomGetRequest<LimitOrder[]>(KnownApiNames.MarketHistory, "get_open_orders", new object[] { owner }, token);
        }

        /// <summary>
        /// Gets the current order book for STEEM:SBD market
        /// </summary>
        /// <param name="limit">Maximum number of orders for each side of the spread to return -- Must not exceed 1000</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: order_book</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<OrderBook> GetOrderBook(UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<OrderBook>(KnownApiNames.MarketHistory, "get_order_book", new object[] { limit }, token);
        }

        /// <summary>
        /// API name: get_recent_trades
        /// 
        /// </summary>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: market_trade</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<MarketTrade[]> GetRecentTrades(UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<MarketTrade[]>(KnownApiNames.MarketHistory, "get_recent_trades", new object[] { limit }, token);
        }

        /// <summary>
        /// API name: get_ticker
        /// Returns the ticker for the market assetA:assetB
        ///
        /// *Returns the market ticker for the internal market
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: market_ticker The market ticker for the past 24 hours.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<MarketTicker> GetTicker(CancellationToken token)
        {
            return CustomGetRequest<MarketTicker>(KnownApiNames.MarketHistory, "get_ticker", token);
        }

        /// <summary>
        /// API name: get_trade_history
        /// Returns recent trades for the market assetA:assetB
        /// Note: Currently, timezone offsets are not supported. The time must be UTC.
        ///
        /// *Returns the trade history for the internal market.
        /// 
        /// </summary>
        /// <param name="start">API type: fc::time_point_sec Start time as a UNIX timestamp</param>
        /// <param name="stop">API type: fc::time_point_sec Stop time as a UNIX timestamp</param>
        /// <param name="limit">API type: unsigned Number of transactions to retrieve, capped at 100</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: market_trade Recent transactions in the market</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<MarketTrade[]> GetTradeHistory(DateTime start, DateTime stop, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<MarketTrade[]>(KnownApiNames.MarketHistory, "get_trade_history", new object[] { start, stop, limit }, token);
        }

        /// <summary>
        /// API name: get_volume
        /// Returns the 24 hour volume for the market assetA:assetB
        ///
        /// *Returns the market volume for the past 24 hours
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: market_volume The market volume over the past 24 hours</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<MarketVolume> GetVolume(CancellationToken token)
        {
            return CustomGetRequest<MarketVolume>(KnownApiNames.MarketHistory, "get_volume", token);
        }
    }
}
