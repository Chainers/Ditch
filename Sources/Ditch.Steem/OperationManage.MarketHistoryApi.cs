using System;
using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Operations.Enums;
using Ditch.Steem.Operations.Get;

namespace Ditch.Steem
{
    /// <summary>
    /// market_history_api
    /// \libraries\plugins\market_history\include\steemit\market_history\market_history_api.hpp
    /// </summary>
    public partial class OperationManager
    {
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


        ///**
        // * @brief Returns the market ticker for the internal SBD:STEEM market
        // */
        ///// <summary>
        ///// API name: get_ticker
        ///// 
        ///// </summary>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: market_ticker</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<MarketTicker> GetTicker(CancellationToken token)
        //{
        //    return CustomGetRequest<MarketTicker>("get_ticker", token);
        //}


        ///**
        // * @brief Returns the market volume for the past 24 hours
        // */
        ///// <summary>
        ///// API name: get_volume
        ///// 
        ///// </summary>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: market_volume</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<MarketVolume> GetVolume(CancellationToken token)
        //{
        //    return CustomGetRequest<MarketVolume>("get_volume", token);
        //}


        ///**
        // * @brief Returns the current order book for the internal SBD:STEEM market.
        // * @param limit The number of orders to have on each side of the order book. Maximum is 500
        // */
        ///// <summary>
        ///// API name: get_order_book
        ///// 
        ///// </summary>
        ///// <param name="limit">API type: uint32_t</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: order_book</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<OrderBook> GetOrderBook(UInt32 limit, CancellationToken token)
        //{
        //    return CustomGetRequest<OrderBook>("get_order_book", token, limit);
        //}


        ///**
        // * @brief Returns the trade history for the internal SBD:STEEM market.
        // * @param start The start time of the trade history.
        // * @param end The end time of the trade history.
        // * @param limit The number of trades to return. Maximum is 1000.
        // * @return A list of completed trades.
        // */
        ///// <summary>
        ///// API name: get_trade_history
        ///// 
        ///// </summary>
        ///// <param name="start">API type: time_point_sec</param>
        ///// <param name="end">API type: time_point_sec</param>
        ///// <param name="limit">API type: uint32_t</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: market_trade</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<MarketTrade[]> GetTradeHistory(DateTime start, DateTime end, UInt32 limit, CancellationToken token)
        //{
        //    return CustomGetRequest<MarketTrade[]>("get_trade_history", token, start, end, limit);
        //}


        ///**
        // * @brief Returns the N most recent trades for the internal SBD:STEEM market.
        // * @param limit The number of recent trades to return. Maximum is 1000.
        // * @returns A list of completed trades.
        // */
        ///// <summary>
        ///// API name: get_recent_trades
        ///// 
        ///// </summary>
        ///// <param name="limit">API type: uint32_t</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: market_trade</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<MarketTrade[]> GetRecentTrades(UInt32 limit, CancellationToken token)
        //{
        //    return CustomGetRequest<MarketTrade[]>("get_recent_trades", token, limit);
        //}


        ///**
        // * @brief Returns the market history for the internal SBD:STEEM market.
        // * @param bucket_seconds The size of buckets the history is broken into. The bucket size must be configured in the plugin options.
        // * @param start The start time to get market history.
        // * @param end The end time to get market history
        // * @return A list of market history buckets.
        // */
        ///// <summary>
        ///// API name: get_market_history
        ///// 
        ///// </summary>
        ///// <param name="bucketSeconds">API type: uint32_t</param>
        ///// <param name="start">API type: time_point_sec</param>
        ///// <param name="end">API type: time_point_sec</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: bucket_object</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<BucketObject[]> GetMarketHistory(UInt32 bucketSeconds, DateTime start, DateTime end, CancellationToken token)
        //{
        //    return CustomGetRequest<BucketObject[]>("get_market_history", token, bucketSeconds, start, end);
        //}


        ///**
        // * @brief Returns the bucket seconds being tracked by the plugin.
        // */
        ///// <summary>
        ///// API name: get_market_history_buckets
        ///// 
        ///// </summary>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: flat_set</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<FlatSet<UInt32>> GetMarketHistoryBuckets(CancellationToken token)
        //{
        //    return CustomGetRequest<FlatSet<UInt32>>("get_market_history_buckets", token);
        //}
    }
}
