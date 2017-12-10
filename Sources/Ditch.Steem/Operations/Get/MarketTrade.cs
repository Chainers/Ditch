using Ditch.Core;
using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Operations.Get
{
    /// <summary>
    /// market_trade
    /// libraries\plugins\market_history\include\steemit\market_history\market_history_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class MarketTrade
    {

        /// <summary>
        /// API name: date
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("date")]
        public DateTime Date {get; set;}

        /// <summary>
        /// API name: current_pays
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("current_pays")]
        public Money CurrentPays {get; set;}

        /// <summary>
        /// API name: open_pays
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("open_pays")]
        public Money OpenPays {get; set;}
    }
}
