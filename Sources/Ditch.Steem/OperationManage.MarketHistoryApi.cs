using System;
using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Objects;

namespace Ditch.Steem
{
    /// <summary>
    /// market_history_api
    /// \libraries\plugins\market_history\include\steemit\market_history\market_history_api.hpp
    /// </summary>
    public partial class OperationManager
    {

        /// <summary>
        /// API name: get_ticker
        /// Returns the market ticker for the internal SBD:STEEM market
        ///
        /// *Returns the market ticker for the internal market
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: market_ticker</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<MarketTicker> GetTicker(CancellationToken token)
        {
            return CallRequest<MarketTicker>(KnownApiNames.MarketHistoryApi, "get_ticker", new object[] { }, token);
        }

        /// <summary>
        /// API name: get_volume
        /// Returns the market volume for the past 24 hours
        ///
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: market_volume</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<MarketVolume> GetVolume(CancellationToken token)
        {
            return CallRequest<MarketVolume>(KnownApiNames.MarketHistoryApi, "get_volume", new object[] { }, token);
        }

        /// <summary>
        /// API name: get_order_book
        /// Returns the current order book for the internal SBD:STEEM market.
        ///
        /// *Displays a list of applications on the internal exchange for the purchase and sale of the network
        /// 
        /// </summary>
        /// <param name="limit">API type: uint32_t The number of orders to have on each side of the order book. Maximum is 500</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: order_book</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<OrderBook> GetOrderBook2(UInt32 limit, CancellationToken token)
        {
            return CallRequest<OrderBook>(KnownApiNames.MarketHistoryApi, "get_order_book", new object[] { limit }, token);
        }

        /// <summary>
        /// API name: get_trade_history
        /// Returns the trade history for the internal SBD:STEEM market.
        ///
        /// *Returns the trade history for the internal market.
        /// 
        /// </summary>
        /// <param name="start">API type: time_point_sec The start time of the trade history.</param>
        /// <param name="end">API type: time_point_sec The end time of the trade history.</param>
        /// <param name="limit">API type: uint32_t The number of trades to return. Maximum is 1000.</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: market_trade A list of completed trades.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<MarketTrade[]> GetTradeHistory(DateTime start, DateTime end, UInt32 limit, CancellationToken token)
        {
            return CallRequest<MarketTrade[]>(KnownApiNames.MarketHistoryApi, "get_trade_history", new object[] { start, end, limit }, token);
        }

        /// <summary>
        /// API name: get_recent_trades
        /// Returns the N most recent trades for the internal SBD:STEEM market.
        ///
        /// *Returns the N most recent trades for the internal market.
        /// 
        /// </summary>
        /// <param name="limit">API type: uint32_t The number of recent trades to return. Maximum is 1000.
        /// @returns A list of completed trades.</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: market_trade</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<MarketTrade[]> GetRecentTrades(UInt32 limit, CancellationToken token)
        {
            return CallRequest<MarketTrade[]>(KnownApiNames.MarketHistoryApi, "get_recent_trades", new object[] { limit }, token);
        }

        /// <summary>
        /// API name: get_market_history
        /// Returns the market history for the internal SBD:STEEM market.
        ///
        /// *Returns the market history for the internal market.
        /// 
        /// </summary>
        /// <param name="bucketSeconds">API type: uint32_t The size of buckets the history is broken into. The bucket size must be configured in the plugin options.</param>
        /// <param name="start">API type: time_point_sec The start time to get market history.</param>
        /// <param name="end">API type: time_point_sec The end time to get market history</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: bucket_object A list of market history buckets.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<BucketObject[]> GetMarketHistory(UInt32 bucketSeconds, DateTime start, DateTime end, CancellationToken token)
        {
            return CallRequest<BucketObject[]>(KnownApiNames.MarketHistoryApi, "get_market_history", new object[] { bucketSeconds, start, end }, token);
        }

        /// <summary>
        /// API name: get_market_history_buckets
        /// Returns the bucket seconds being tracked by the plugin.
        ///
        /// *Returns the bucket seconds being tracked by the plugin
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: flat_set</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<UInt32[]> GetMarketHistoryBuckets(CancellationToken token)
        {
            return CallRequest<UInt32[]>(KnownApiNames.MarketHistoryApi, "get_market_history_buckets", new object[] { }, token);
        }
    }
}
