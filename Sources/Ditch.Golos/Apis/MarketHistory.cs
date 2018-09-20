using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.JsonRpc;
using Ditch.Core.Models;
using Ditch.Golos.Models;

namespace Ditch.Golos
{
    /// <summary>
    /// market_history
    /// plugins\market_history\include\golos\plugins\market_history\market_history_plugin.hpp
    /// </summary>
    public partial class OperationManager
    {

        /// <summary>
        /// API name: get_market_history
        /// *Возвращает историю рынка для внутреннего рынка
        /// 
        /// </summary>
        /// <param name="bucketSeconds">API type: uint32_t The size of buckets the history is broken into. The bucket size must be configured in the plugin options.</param>
        /// <param name="start">API type: fc::time_point_sec The start time to get market history.</param>
        /// <param name="end">API type: fc::time_point_sec The end time to get market history</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: bucket_object A list of market history buckets.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<BucketObject[]>> GetMarketHistoryAsync(uint bucketSeconds, TimePointSec start, TimePointSec end, CancellationToken token)
        {
            return CustomGetRequestAsync<BucketObject[]>(KnownApiNames.MarketHistory, "get_market_history", new object[] { bucketSeconds, start, end }, token);
        }

        /// <summary>
        /// API name: get_market_history_buckets
        /// *Возвращает размер секунд стакана(среза), отслеживаемых плагином.
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: flat_set</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<uint[]>> GetMarketHistoryBucketsAsync(CancellationToken token)
        {
            return CustomGetRequestAsync<uint[]>(KnownApiNames.MarketHistory, "get_market_history_buckets", new object[] { }, token);
        }

        /// <summary>
        /// API name: get_open_orders
        /// *Отображает список заявок на внутренней бирже на покупку и продажу в сети для указанного пользователя.
        /// 
        /// </summary>
        /// <param name="owner">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: limit_order</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<LimitOrder[]>> GetOpenOrdersAsync(string owner, CancellationToken token)
        {
            return CustomGetRequestAsync<LimitOrder[]>(KnownApiNames.MarketHistory, "get_open_orders", new object[] { owner }, token);
        }

        /// <summary>
        /// API name: get_order_book
        /// *Отображает список заявок на внутренней бирже на покупку и продажу в сети
        /// 
        /// </summary>
        /// <param name="limit">Maximum number of orders for each side of the spread to return -- Must not exceed 1000</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: order_book</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<OrderBook>> GetOrderBookAsync(uint limit, CancellationToken token)
        {
            return CustomGetRequestAsync<OrderBook>(KnownApiNames.MarketHistory, "get_order_book", new object[] { limit }, token);
        }

        /// <summary>
        /// API name: get_order_book_extended
        /// 
        /// </summary>
        /// <param name="arg0">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: order_book_extended</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<OrderBookExtended>> GetOrderBookExtendedAsync(uint arg0, CancellationToken token)
        {
            return CustomGetRequestAsync<OrderBookExtended>(KnownApiNames.MarketHistory, "get_order_book_extended", new object[] { arg0 }, token);
        }

        /// <summary>
        /// API name: get_recent_trades
        /// *Возвращает N последних сделок для внутреннего рынка
        /// 
        /// </summary>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: market_trade</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<MarketTrade[]>> GetRecentTradesAsync(uint limit, CancellationToken token)
        {
            return CustomGetRequestAsync<MarketTrade[]>(KnownApiNames.MarketHistory, "get_recent_trades", new object[] { limit }, token);
        }

        /// <summary>
        /// API name: get_ticker
        /// *Возвращает рыночный тикет для внутреннего рынка
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: market_ticker The market ticker for the past 24 hours.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<MarketTicker>> GetTickerAsync(CancellationToken token)
        {
            return CustomGetRequestAsync<MarketTicker>(KnownApiNames.MarketHistory, "get_ticker", token);
        }

        /// <summary>
        /// API name: get_trade_history
        /// *Возвращает историю торговли для внутреннего рынка
        /// 
        /// </summary>
        /// <param name="start">API type: fc::time_point_sec Start time as a UNIX timestamp</param>
        /// <param name="stop">API type: fc::time_point_sec Stop time as a UNIX timestamp</param>
        /// <param name="limit">API type: unsigned Number of transactions to retrieve, capped at 100</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: market_trade Recent transactions in the market</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<MarketTrade[]>> GetTradeHistoryAsync(TimePointSec start, TimePointSec stop, uint limit, CancellationToken token)
        {
            return CustomGetRequestAsync<MarketTrade[]>(KnownApiNames.MarketHistory, "get_trade_history", new object[] { start, stop, limit }, token);
        }

        /// <summary>
        /// API name: get_volume
        /// *Возвращает объем рынка за последние 24 часа
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: market_volume The market volume over the past 24 hours</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<MarketVolume>> GetVolumeAsync(CancellationToken token)
        {
            return CustomGetRequestAsync<MarketVolume>(KnownApiNames.MarketHistory, "get_volume", token);
        }
    }
}
