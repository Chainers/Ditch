using System;
using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Golos.Operations.Enums;
using Ditch.Golos.Operations.Get;

namespace Ditch.Golos
{
    /// <summary>
    /// market_history_api
    /// \libraries\plugins\market_history\include\golos\market_history\market_history_Api.hpp
    /// </summary>
    public partial class OperationManager
    {
        /// <summary>
        /// API name: on_api_startup
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: void</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse OnApiStartup(CancellationToken token)
        //{
        //    return CustomGetRequest("on_api_startup", token);
        //}


        ///////////////////
        // Subscriptions //
        ///////////////////

        /// <summary>
        /// API name: set_subscribe_callback
        /// 
        /// </summary>
        /// <param name="cb">API type: std::function&lt;void</param>
        /// <param name="clearFilter">API type: bool</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: void</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse SetSubscribeCallback(Function<Voi> cb, bool clearFilter, CancellationToken token)
        //{
        //    return CustomGetRequest("set_subscribe_callback", token, cb, clearFilter);
        //}

        /// <summary>
        /// API name: set_pending_transaction_callback
        /// 
        /// </summary>
        /// <param name="cb">API type: std::function&lt;void</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: void</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse SetPendingTransactionCallback(Function<Voi> cb, CancellationToken token)
        //{
        //    return CustomGetRequest("set_pending_transaction_callback", token, cb);
        //}

        /// <summary>
        /// API name: set_block_applied_callback
        /// 
        /// </summary>
        /// <param name="cb">API type: std::function&lt;void</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: void</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse SetBlockAppliedCallback(Function<Voi> cb, CancellationToken token)
        //{
        //    return CustomGetRequest("set_block_applied_callback", token, cb);
        //}


        /**
         * @brief Stop receiving any notifications
         *
         * This unsubscribes from all subscribed markets and objects.
         */
        /// <summary>
        /// API name: cancel_all_subscriptions
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: void</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse CancelAllSubscriptions(CancellationToken token)
        {
            return CustomGetRequest("cancel_all_subscriptions", token);
        }


        /**
         * @brief Request notification when the active orders in the market between two assets changes
         * @param callback Callback method which is called when the market changes
         * @param a First asset ID
         * @param b Second asset ID
         *
         * Callback will be passed a variant containing a vector<pair<operation, operation_result>>. The vector will
         * contain, in order, the operations which changed the market, and their results.
         */
        /// <summary>
        /// API name: subscribe_to_market
        /// 
        /// </summary>
        /// <param name="callback">API type: std::function&lt;void</param>
        /// <param name="a">API type: string</param>
        /// <param name="b">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: void</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse SubscribeToMarket(Function<Voi> callback, string a, string b, CancellationToken token)
        //{
        //    return CustomGetRequest("subscribe_to_market", token, callback, a, b);
        //}


        /**
         * @brief Unsubscribe from updates to a given market
         * @param a First asset ID
         * @param b Second asset ID
         */
        /// <summary>
        /// API name: unsubscribe_from_market
        /// 
        /// </summary>
        /// <param name="a">API type: string</param>
        /// <param name="b">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: void</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse UnsubscribeFromMarket(string a, string b, CancellationToken token)
        {
            return CustomGetRequest("unsubscribe_from_market", token, a, b);
        }

        /// <summary>
        /// API name: get_limit_orders_by_owner
        /// 
        /// </summary>
        /// <param name="owner">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: extended_limit_order</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ExtendedLimitOrder[]> GetLimitOrdersByOwner(string owner, CancellationToken token)
        {
            return CustomGetRequest<ExtendedLimitOrder[]>("get_limit_orders_by_owner", token, owner);
        }

        /// <summary>
        /// API name: get_call_orders_by_owner
        /// 
        /// </summary>
        /// <param name="owner">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: call_order_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<CallOrderObject[]> GetCallOrdersByOwner(string owner, CancellationToken token)
        //{
        //    return CustomGetRequest<CallOrderObject[]>("get_call_orders_by_owner", token, owner);
        //}

        /// <summary>
        /// API name: get_settle_orders_by_owner
        /// 
        /// </summary>
        /// <param name="owner">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: force_settlement_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<ForceSettlementObject[]> GetSettleOrdersByOwner(string owner, CancellationToken token)
        //{
        //    return CustomGetRequest<ForceSettlementObject[]>("get_settle_orders_by_owner", token, owner);
        //}


        /**
         * @brief Returns the ticker for the market assetA:assetB
         * @param a String name of the first asset
         * @param b String name of the second asset
         * @return The market ticker for the past 24 hours.
         */
        /// <summary>
        /// API name: get_ticker
        /// 
        /// </summary>
        /// <param name="base">API type: string</param>
        /// <param name="quote">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: market_ticker</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<MarketTicker> GetTicker(string base, string quote, CancellationToken token)
        //{
        //    return CustomGetRequest<MarketTicker>("get_ticker", token, base, quote);
        //}


        /**
         * @brief Returns the 24 hour volume for the market assetA:assetB
         * @param a String name of the first asset
         * @param b String name of the second asset
         * @return The market volume over the past 24 hours
         */
        /// <summary>
        /// API name: get_volume
        /// 
        /// </summary>
        /// <param name="base">API type: string</param>
        /// <param name="quote">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: market_volume</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<MarketVolume> GetVolume(string base, string quote, CancellationToken token)
        //{
        //    return CustomGetRequest<MarketVolume>("get_volume", token, base, quote);
        //}


        /**
         * @brief Returns the order book for the market base:quote
         * @param base String name of the first asset
         * @param quote String name of the second asset
         * @param depth of the order book. Up to depth of each asks and bids, capped at 50. Prioritizes most moderate of each
         * @return Order book of the market
         */
        /// <summary>
        /// API name: get_order_book
        /// 
        /// </summary>
        /// <param name="base">API type: string</param>
        /// <param name="quote">API type: string</param>
        /// <param name="limit">API type: unsigned</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: order_book</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<OrderBook> GetOrderBook(string base, string quote, Unsigned limit, CancellationToken token)
        //{
        //    return CustomGetRequest<OrderBook>("get_order_book", token, base, quote, limit);
        //}


        ///**
        // * @brief Returns recent trades for the market assetA:assetB
        // * Note: Currently, timezone offsets are not supported. The time must be UTC.
        // * @param a String name of the first asset
        // * @param b String name of the second asset
        // * @param stop Stop time as a UNIX timestamp
        // * @param limit Number of transactions to retrieve, capped at 100
        // * @param start Start time as a UNIX timestamp
        // * @return Recent transactions in the market
        // */
        ///// <summary>
        ///// API name: get_trade_history
        ///// 
        ///// </summary>
        ///// <param name="base">API type: string</param>
        ///// <param name="quote">API type: string</param>
        ///// <param name="start">API type: fc::time_point_sec</param>
        ///// <param name="stop">API type: fc::time_point_sec</param>
        ///// <param name="limit">API type: unsigned</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: market_trade</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<MarketTrade[]> GetTradeHistory(string base, string quote, DateTime start, DateTime stop, Unsigned limit, CancellationToken token)
        //{
        //    return CustomGetRequest<MarketTrade[]>("get_trade_history", token, base, quote, start, stop, limit);
        //}

        ///// <summary>
        ///// API name: get_fill_order_history
        ///// 
        ///// </summary>
        ///// <param name="a">API type: string</param>
        ///// <param name="b">API type: string</param>
        ///// <param name="limit">API type: uint32_t</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: order_history_object</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<OrderHistoryObject[]> GetFillOrderHistory(string a, string b, UInt32 limit, CancellationToken token)
        //{
        //    return CustomGetRequest<OrderHistoryObject[]>("get_fill_order_history", token, a, b, limit);
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
        ///// <param name="a">API type: string</param>
        ///// <param name="b">API type: string</param>
        ///// <param name="bucketSeconds">API type: uint32_t</param>
        ///// <param name="start">API type: fc::time_point_sec</param>
        ///// <param name="end">API type: fc::time_point_sec</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: bucket_object</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<BucketObject[]> GetMarketHistory(string a, string b, UInt32 bucketSeconds, DateTime start, DateTime end, CancellationToken token)
        //{
        //    return CustomGetRequest<BucketObject[]>("get_market_history", token, a, b, bucketSeconds, start, end);
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


        ///**
        // * @brief Get limit orders in a given market
        // * @param a ID of asset being sold
        // * @param b ID of asset being purchased
        // * @param limit Maximum number of orders to retrieve
        // * @return The limit orders, ordered from least price to greatest
        // */
        ///// <summary>
        ///// API name: get_limit_orders
        ///// 
        ///// </summary>
        ///// <param name="a">API type: string</param>
        ///// <param name="b">API type: string</param>
        ///// <param name="limit">API type: uint32_t</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: limit_order_object</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<LimitOrderObject[]> GetLimitOrders(string a, string b, UInt32 limit, CancellationToken token)
        //{
        //    return CustomGetRequest<LimitOrderObject[]>("get_limit_orders", token, a, b, limit);
        //}


        ///**
        // * @brief Get call orders in a given asset
        // * @param a ID of asset being called
        // * @param limit Maximum number of orders to retrieve
        // * @return The call orders, ordered from earliest to be called to latest
        // */
        ///// <summary>
        ///// API name: get_call_orders
        ///// 
        ///// </summary>
        ///// <param name="a">API type: string</param>
        ///// <param name="limit">API type: uint32_t</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: call_order_object</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<CallOrderObject[]> GetCallOrders(string a, UInt32 limit, CancellationToken token)
        //{
        //    return CustomGetRequest<CallOrderObject[]>("get_call_orders", token, a, limit);
        //}


        ///**
        // * @brief Get forced settlement orders in a given asset
        // * @param a ID of asset being settled
        // * @param limit Maximum number of orders to retrieve
        // * @return The settle orders, ordered from earliest settlement date to latest
        // */
        ///// <summary>
        ///// API name: get_settle_orders
        ///// 
        ///// </summary>
        ///// <param name="a">API type: string</param>
        ///// <param name="limit">API type: uint32_t</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: force_settlement_object</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<ForceSettlementObject[]> GetSettleOrders(string a, UInt32 limit, CancellationToken token)
        //{
        //    return CustomGetRequest<ForceSettlementObject[]>("get_settle_orders", token, a, limit);
        //}


        ///**
        // * @brief Get collateral_bid_objects for a given asset
        // * @param a ID of asset
        // * @param limit Maximum number of objects to retrieve
        // * @param start skip that many results
        // * @return The settle orders, ordered from earliest settlement date to latest
        // */
        ///// <summary>
        ///// API name: get_collateral_bids
        ///// 
        ///// </summary>
        ///// <param name="asset">API type: asset_name_type</param>
        ///// <param name="limit">API type: uint32_t</param>
        ///// <param name="start">API type: uint32_t</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: collateral_bid_object</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<CollateralBidObject[]> GetCollateralBids(AssetNameType asset, UInt32 limit, UInt32 start, CancellationToken token)
        //{
        //    return CustomGetRequest<CollateralBidObject[]>("get_collateral_bids", token, asset, limit, start);
        //}


        ///**
        // *  @return all open margin positions for a given account id.
        // */
        ///// <summary>
        ///// API name: get_margin_positions
        ///// 
        ///// </summary>
        ///// <param name="name">API type: string</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: call_order_object</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<CallOrderObject[]> GetMarginPositions(string name, CancellationToken token)
        //{
        //    return CustomGetRequest<CallOrderObject[]>("get_margin_positions", token, name);
        //}


        ///**
        // * @breif Gets the current liquidity reward queue.
        // * @param start_account The account to start the list from, or "" to get the head of the queue
        // * @param limit Maxmimum number of accounts to return -- Must not exceed 1000
        // */
        ///// <summary>
        ///// API name: get_liquidity_queue
        ///// 
        ///// </summary>
        ///// <param name="startAccount">API type: string</param>
        ///// <param name="limit">API type: uint32_t</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: liquidity_balance</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<LiquidityBalance[]> GetLiquidityQueue(string startAccount, UInt32 limit, CancellationToken token)
        //{
        //    return CustomGetRequest<LiquidityBalance[]>("get_liquidity_queue", token, startAccount, limit);
        //}

    }
}