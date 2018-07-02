using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// market_ticker
    /// libraries\plugins\market_history\include\steemit\market_history\market_history_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class MarketTicker
    {
        /// <summary>
        /// API name: latest
        /// = 0;
        /// </summary>
        /// <returns>API type: double</returns>
        [JsonProperty("latest")]
        public double Latest {get; set;}

        /// <summary>
        /// API name: lowest_ask
        /// = 0;
        /// </summary>
        /// <returns>API type: double</returns>
        [JsonProperty("lowest_ask")]
        public double LowestAsk {get; set;}

        /// <summary>
        /// API name: highest_bid
        /// = 0;
        /// </summary>
        /// <returns>API type: double</returns>
        [JsonProperty("highest_bid")]
        public double HighestBid {get; set;}

        /// <summary>
        /// API name: percent_change
        /// = 0;
        /// </summary>
        /// <returns>API type: double</returns>
        [JsonProperty("percent_change")]
        public double PercentChange {get; set;}

        /// <summary>
        /// API name: steem_volume
        /// = asset( 0 , STEEM_SYMBOL );
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("steem_volume")]
        public Asset SteemVolume {get; set;}

        /// <summary>
        /// API name: sbd_volume
        /// = asset( 0, SBD_SYMBOL );
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("sbd_volume")]
        public Asset SbdVolume {get; set;}
    }
}
