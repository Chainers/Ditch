using System;
using Newtonsoft.Json;

namespace Ditch.Golos.Objects
{
    /// <summary>
    /// market_trade
    /// libraries\plugins\market_history\include\golos\market_history\market_history_api.hpp
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
        /// API name: price
        /// 
        /// </summary>
        /// <returns>API type: double</returns>
        [JsonProperty("price")]
        public double Price {get; set;}

        /// <summary>
        /// API name: amount
        /// 
        /// </summary>
        /// <returns>API type: double</returns>
        [JsonProperty("amount")]
        public double Amount {get; set;}

        /// <summary>
        /// API name: value
        /// 
        /// </summary>
        /// <returns>API type: double</returns>
        [JsonProperty("value")]
        public double Value {get; set;}

        /// <summary>
        /// API name: side1_account_name
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("side1_account_name")]
        public string Side1AccountName {get; set;}

        /// <summary>
        /// API name: side2_account_name
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("side2_account_name")]
        public string Side2AccountName {get; set;}
    }
}
