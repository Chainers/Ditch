using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// market_trade
    /// libraries\plugins\market_history\include\steemit\market_history\market_history_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class MarketTrade
    {

        /// <summary>
        /// API name: date
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("date")]
        public TimePointSec Date {get; set;}

        /// <summary>
        /// API name: current_pays
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("current_pays")]
        public Asset CurrentPays {get; set;}

        /// <summary>
        /// API name: open_pays
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("open_pays")]
        public Asset OpenPays {get; set;}
    }
}
