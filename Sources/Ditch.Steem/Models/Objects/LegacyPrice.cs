using Newtonsoft.Json;

namespace Ditch.Steem.Models.Objects
{
    /// <summary>
    /// legacy_price
    /// libraries\plugins\apis\condenser_api\include\steem\plugins\condenser_api\condenser_api_legacy_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class LegacyPrice
    {

        /// <summary>
        /// API name: base
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("base")]
        public LegacyAsset Base {get; set;}

        /// <summary>
        /// API name: quote
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("quote")]
        public LegacyAsset Quote {get; set;}
    }
}
