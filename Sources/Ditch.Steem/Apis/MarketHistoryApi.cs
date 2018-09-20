using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Models;

namespace Ditch.Steem
{
    /// <summary>
    /// market_history_api
    /// libraries\plugins\apis\market_history_api\include\steem\plugins\market_history_api\market_history_api.hpp
    /// </summary>
    public partial class OperationManager
    {

        /// <summary>
        /// API name: get_ticker
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_ticker_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetTickerReturn>> GetTickerAsync(CancellationToken token)
        {
            return CustomGetRequestAsync<GetTickerReturn>(KnownApiNames.MarketHistoryApi, "get_ticker", token);
        }

        /// <summary>
        /// API name: get_volume
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_volume_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetVolumeReturn>> GetVolumeAsync(CancellationToken token)
        {
            return CustomGetRequestAsync<GetVolumeReturn>(KnownApiNames.MarketHistoryApi, "get_volume", token);
        }

        /// <summary>
        /// API name: get_order_book
        /// 
        /// </summary>
        /// <param name="args">API type: get_order_book_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_order_book_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetOrderBookReturn>> GetOrderBookAsync(GetOrderBookArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetOrderBookReturn>(KnownApiNames.MarketHistoryApi, "get_order_book", args, token);
        }

        /// <summary>
        /// API name: get_trade_history
        /// 
        /// </summary>
        /// <param name="args">API type: get_trade_history_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_trade_history_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetTradeHistoryReturn>> GetTradeHistoryAsync(GetTradeHistoryArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetTradeHistoryReturn>(KnownApiNames.MarketHistoryApi, "get_trade_history", args, token);
        }

        /// <summary>
        /// API name: get_recent_trades
        /// 
        /// </summary>
        /// <param name="args">API type: get_recent_trades_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_recent_trades_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetRecentTradesReturn>> GetRecentTradesAsync(GetRecentTradesArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetRecentTradesReturn>(KnownApiNames.MarketHistoryApi, "get_recent_trades", args, token);
        }

        /// <summary>
        /// API name: get_market_history
        /// 
        /// </summary>
        /// <param name="args">API type: get_market_history_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_market_history_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetMarketHistoryReturn>> GetMarketHistoryAsync(GetMarketHistoryArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetMarketHistoryReturn>(KnownApiNames.MarketHistoryApi, "get_market_history", args, token);
        }

        /// <summary>
        /// API name: get_market_history_buckets
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_market_history_buckets_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetMarketHistoryBucketsReturn>> GetMarketHistoryBucketsAsync(CancellationToken token)
        {
            return CustomGetRequestAsync<GetMarketHistoryBucketsReturn>(KnownApiNames.MarketHistoryApi, "get_market_history_buckets", token);
        }
    }
}
