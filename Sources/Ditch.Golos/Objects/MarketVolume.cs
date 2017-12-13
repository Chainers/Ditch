using Newtonsoft.Json;

namespace Ditch.Golos.Objects
{
    /// <summary>
    /// market_volume
    /// libraries\plugins\market_history\include\golos\market_history\market_history_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class MarketVolume
    {

        /// <summary>
        /// API name: base
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("base")]
        public string Base {get; set;}

        /// <summary>
        /// API name: quote
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("quote")]
        public string Quote {get; set;}

        /// <summary>
        /// API name: base_volume
        /// 
        /// </summary>
        /// <returns>API type: double</returns>
        [JsonProperty("base_volume")]
        public double BaseVolume {get; set;}

        /// <summary>
        /// API name: quote_volume
        /// 
        /// </summary>
        /// <returns>API type: double</returns>
        [JsonProperty("quote_volume")]
        public double QuoteVolume {get; set;}
    }
}
