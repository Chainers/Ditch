using System;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// market_volume
    /// libraries\app\include\graphene\app\database_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class MarketVolume
    {

        /// <summary>
        /// API name: time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("time")]
        public DateTime Time { get; set; }

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
