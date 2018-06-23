using Ditch.Steem.Models.Other;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// get_trade_history_return
    /// libraries\plugins\apis\market_history_api\include\steem\plugins\market_history_api\market_history_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetTradeHistoryReturn
    {

        /// <summary>
        /// API name: trades
        /// 
        /// </summary>
        /// <returns>API type: market_trade</returns>
        [JsonProperty("trades")]
        public MarketTrade[] Trades {get; set;}
    }
}
