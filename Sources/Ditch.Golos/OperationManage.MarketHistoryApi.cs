using System;
using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Golos.Objects;

namespace Ditch.Golos
{
    /// <summary>
    /// market_history_api
    /// libraries\plugins\market_history\include\golos\market_history\market_history_api.hpp
    /// </summary>
    public partial class OperationManager
    {


        ///////////////////
        // Subscriptions //
        ///////////////////


        /// <summary>
        /// API name: set_subscribe_callback
        /// 
        /// </summary>
        /// <param name="cb">API type: std::function&lt;void(variant )></param>
        /// <param name="clearFilter">API type: bool</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: void</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse SetSubscribeCallback(object cb, bool clearFilter, CancellationToken token)
        {
            return CallRequest(KnownApiNames.MarketHistoryApi, "set_subscribe_callback", new object[] { cb, clearFilter }, token);
        }

        /// <summary>
        /// API name: set_pending_transaction_callback
        /// 
        /// </summary>
        /// <param name="cb">API type: std::function&lt;void(variant )></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: void</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse SetPendingTransactionCallback(object cb, CancellationToken token)
        {
            return CallRequest(KnownApiNames.MarketHistoryApi, "set_pending_transaction_callback", new object[] { cb }, token);
        }

        /// <summary>
        /// API name: set_block_applied_callback
        /// 
        /// </summary>
        /// <param name="cb">API type: std::function&lt;void(variant block_id)></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: void</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse SetBlockAppliedCallback(object cb, CancellationToken token)
        {
            return CallRequest(KnownApiNames.MarketHistoryApi, "set_block_applied_callback", new object[] { cb }, token);
        }

        /// <summary>
        /// API name: cancel_all_subscriptions
        /// Stop receiving any notifications
        /// 
        /// This unsubscribes from all subscribed markets and objects.
        ///
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: void</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse CancelAllSubscriptions(CancellationToken token)
        {
            return CallRequest(KnownApiNames.MarketHistoryApi, "cancel_all_subscriptions", new object[] { }, token);
        }

        /// <summary>
        /// API name: subscribe_to_market
        /// Request notification when the active orders in the market between two assets changes
        ///
        /// 
        /// </summary>
        /// <param name="callback">API type: std::function&lt;void(variant )> Callback method which is called when the market changes</param>
        /// <param name="a">API type: string First asset ID</param>
        /// <param name="b">API type: string Second asset ID
        /// 
        /// Callback will be passed a variant containing a vector<pair<operation, operation_result>>. The vector will
        /// contain, in order, the operations which changed the market, and their results.</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: void</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse SubscribeToMarket(object callback, string a, string b, CancellationToken token)
        {
            return CallRequest(KnownApiNames.MarketHistoryApi, "subscribe_to_market", new object[] { callback, a, b }, token);
        }

        /// <summary>
        /// API name: unsubscribe_from_market
        /// Unsubscribe from updates to a given market
        ///
        /// 
        /// </summary>
        /// <param name="a">API type: string First asset ID</param>
        /// <param name="b">API type: string Second asset ID</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: void</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse UnsubscribeFromMarket(string a, string b, CancellationToken token)
        {
            return CallRequest(KnownApiNames.MarketHistoryApi, "unsubscribe_from_market", new object[] { a, b }, token);
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
            return CallRequest<ExtendedLimitOrder[]>(KnownApiNames.MarketHistoryApi, "get_limit_orders_by_owner", new object[] { owner }, token);
        }

        /// <summary>
        /// API name: get_settle_orders_by_owner
        /// 
        /// </summary>
        /// <param name="owner">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: force_settlement_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ForceSettlementObject[]> GetSettleOrdersByOwner(string owner, CancellationToken token)
        {
            return CallRequest<ForceSettlementObject[]>(KnownApiNames.MarketHistoryApi, "get_settle_orders_by_owner", new object[] { owner }, token);
        }

        /// <summary>
        /// API name: get_ticker
        /// Returns the ticker for the market assetA:assetB
        ///
        /// *Returns the market ticker for the internal market
        /// 
        /// </summary>
        /// <param name="base">API type: string</param>
        /// <param name="quote">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: market_ticker The market ticker for the past 24 hours.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<MarketTicker> GetTicker(string @base, string quote, CancellationToken token)
        {
            return CallRequest<MarketTicker>(KnownApiNames.MarketHistoryApi, "get_ticker", new object[] { @base, quote }, token);
        }

        /// <summary>
        /// API name: get_volume
        /// Returns the 24 hour volume for the market assetA:assetB
        ///
        /// *Returns the market volume for the past 24 hours
        /// 
        /// </summary>
        /// <param name="base">API type: string</param>
        /// <param name="quote">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: market_volume The market volume over the past 24 hours</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<MarketVolume> GetVolume(string @base, string quote, CancellationToken token)
        {
            return CallRequest<MarketVolume>(KnownApiNames.MarketHistoryApi, "get_volume", new object[] { @base, quote }, token);
        }

        /// <summary>
        /// API name: get_order_book
        /// Returns the order book for the market base:quote
        ///
        /// *Displays a list of applications on the internal exchange for the purchase and sale of the network
        /// 
        /// </summary>
        /// <param name="base">API type: string String name of the first asset</param>
        /// <param name="quote">API type: string String name of the second asset</param>
        /// <param name="limit">API type: unsigned</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: order_book Order book of the market</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<OrderBook> GetOrderBook(string @base, string quote, byte limit, CancellationToken token)
        {
            return CallRequest<OrderBook>(KnownApiNames.MarketHistoryApi, "get_order_book", new object[] { @base, quote, limit }, token);
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
            return CustomGetRequest<OrderBook>("get_order_book", token, limit);
        }

        /// <summary>
        /// API name: get_trade_history
        /// Returns recent trades for the market assetA:assetB
        /// Note: Currently, timezone offsets are not supported. The time must be UTC.
        ///
        /// *Returns the trade history for the internal market.
        /// 
        /// </summary>
        /// <param name="base">API type: string</param>
        /// <param name="quote">API type: string</param>
        /// <param name="start">API type: fc::time_point_sec Start time as a UNIX timestamp</param>
        /// <param name="stop">API type: fc::time_point_sec Stop time as a UNIX timestamp</param>
        /// <param name="limit">API type: unsigned Number of transactions to retrieve, capped at 100</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: market_trade Recent transactions in the market</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<MarketTrade[]> GetTradeHistory(string @base, string quote, DateTime start, DateTime stop, byte limit, CancellationToken token)
        {
            return CallRequest<MarketTrade[]>(KnownApiNames.MarketHistoryApi, "get_trade_history", new object[] { @base, quote, start, stop, limit }, token);
        }

        /// <summary>
        /// API name: get_fill_order_history
        /// 
        /// </summary>
        /// <param name="a">API type: string</param>
        /// <param name="b">API type: string</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: order_history_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<OrderHistoryObject[]> GetFillOrderHistory(string a, string b, UInt32 limit, CancellationToken token)
        {
            return CallRequest<OrderHistoryObject[]>(KnownApiNames.MarketHistoryApi, "get_fill_order_history", new object[] { a, b, limit }, token);
        }

        /// <summary>
        /// API name: get_market_history
        /// Returns the market history for the internal SBD:STEEM market.
        ///
        /// *Returns the market history for the internal market.
        /// 
        /// </summary>
        /// <param name="a">API type: string</param>
        /// <param name="b">API type: string</param>
        /// <param name="bucketSeconds">API type: uint32_t The size of buckets the history is broken into. The bucket size must be configured in the plugin options.</param>
        /// <param name="start">API type: fc::time_point_sec The start time to get market history.</param>
        /// <param name="end">API type: fc::time_point_sec The end time to get market history</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: bucket_object A list of market history buckets.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<BucketObject[]> GetMarketHistory(string a, string b, UInt32 bucketSeconds, DateTime start, DateTime end, CancellationToken token)
        {
            return CallRequest<BucketObject[]>(KnownApiNames.MarketHistoryApi, "get_market_history", new object[] { a, b, bucketSeconds, start, end }, token);
        }

        /// <summary>
        /// API name: get_limit_orders
        /// Get limit orders in a given market
        ///
        /// 
        /// </summary>
        /// <param name="a">API type: string ID of asset being sold</param>
        /// <param name="b">API type: string ID of asset being purchased</param>
        /// <param name="limit">API type: uint32_t Maximum number of orders to retrieve</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: limit_order_object The limit orders, ordered from least price to greatest</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<LimitOrderObject[]> GetLimitOrders(string a, string b, UInt32 limit, CancellationToken token)
        {
            return CallRequest<LimitOrderObject[]>(KnownApiNames.MarketHistoryApi, "get_limit_orders", new object[] { a, b, limit }, token);
        }

        /// <summary>
        /// API name: get_call_orders
        /// Get call orders in a given asset
        ///
        /// 
        /// </summary>
        /// <param name="a">API type: string ID of asset being called</param>
        /// <param name="limit">API type: uint32_t Maximum number of orders to retrieve</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: call_order_object The call orders, ordered from earliest to be called to latest</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<CallOrderObject[]> GetCallOrders(string a, UInt32 limit, CancellationToken token)
        {
            return CallRequest<CallOrderObject[]>(KnownApiNames.MarketHistoryApi, "get_call_orders", new object[] { a, limit }, token);
        }

        /// <summary>
        /// API name: get_settle_orders
        /// Get forced settlement orders in a given asset
        ///
        /// 
        /// </summary>
        /// <param name="a">API type: string ID of asset being settled</param>
        /// <param name="limit">API type: uint32_t Maximum number of orders to retrieve</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: force_settlement_object The settle orders, ordered from earliest settlement date to latest</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ForceSettlementObject[]> GetSettleOrders(string a, UInt32 limit, CancellationToken token)
        {
            return CallRequest<ForceSettlementObject[]>(KnownApiNames.MarketHistoryApi, "get_settle_orders", new object[] { a, limit }, token);
        }

        /// <summary>
        /// API name: get_collateral_bids
        /// Get collateral_bid_objects for a given asset
        ///
        /// 
        /// </summary>
        /// <param name="asset">API type: asset_name_type</param>
        /// <param name="limit">API type: uint32_t Maximum number of objects to retrieve</param>
        /// <param name="start">API type: uint32_t skip that many results</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: collateral_bid_object The settle orders, ordered from earliest settlement date to latest</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<CollateralBidObject[]> GetCollateralBids(object asset, UInt32 limit, UInt32 start, CancellationToken token)
        {
            return CallRequest<CollateralBidObject[]>(KnownApiNames.MarketHistoryApi, "get_collateral_bids", new object[] { asset, limit, start }, token);
        }

        /// <summary>
        /// API name: get_margin_positions
        /// 
        /// </summary>
        /// <param name="name">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: call_order_object all open margin positions for a given account id.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<CallOrderObject[]> GetMarginPositions(string name, CancellationToken token)
        {
            return CallRequest<CallOrderObject[]>(KnownApiNames.MarketHistoryApi, "get_margin_positions", new object[] { name }, token);
        }
    }
}
