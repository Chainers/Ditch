using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// legacy_price
    /// libraries\plugins\apis\condenser_api\include\steem\plugins\condenser_api\condenser_api_legacy_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class LegacyPrice
    {

        /// <summary>
        /// API name: base
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("base")]
        public Asset Base {get; set;}

        /// <summary>
        /// API name: quote
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("quote")]
        public Asset Quote {get; set;}
    }
}
