using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// market_ticker
    /// libraries\app\include\graphene\app\database_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class MarketTicker
    {

        /// <summary>
        /// API name: time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("time")]
        public TimePointSec Time { get; set; }

        /// <summary>
        /// API name: base
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("base")]
        public string Base { get; set; }

        /// <summary>
        /// API name: quote
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("quote")]
        public string Quote { get; set; }

        /// <summary>
        /// API name: latest
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("latest")]
        public string Latest { get; set; }

        /// <summary>
        /// API name: lowest_ask
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("lowest_ask")]
        public string LowestAsk { get; set; }

        /// <summary>
        /// API name: highest_bid
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("highest_bid")]
        public string HighestBid { get; set; }

        /// <summary>
        /// API name: percent_change
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("percent_change")]
        public string PercentChange { get; set; }

        /// <summary>
        /// API name: base_volume
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("base_volume")]
        public string BaseVolume { get; set; }

        /// <summary>
        /// API name: quote_volume
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("quote_volume")]
        public string QuoteVolume { get; set; }
    }
}
