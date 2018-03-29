using System;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.Objects
{
    /// <summary>
    /// market_trade
    /// plugins\market_history\include\golos\plugins\market_history\market_history_objects.hpp
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
