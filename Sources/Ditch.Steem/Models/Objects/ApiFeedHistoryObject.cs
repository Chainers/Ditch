using Ditch.Steem.Models.Other;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Objects
{
    /// <summary>
    /// api_feed_history_object
    /// libraries\plugins\apis\condenser_api\include\steem\plugins\condenser_api\condenser_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ApiFeedHistoryObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: feed_history_id_type</returns>
        [JsonProperty("id")]
        public object Id {get; set;}

        /// <summary>
        /// API name: current_median_history
        /// 
        /// </summary>
        /// <returns>API type: legacy_price</returns>
        [JsonProperty("current_median_history")]
        public LegacyPrice CurrentMedianHistory {get; set;}

        /// <summary>
        /// API name: price_history
        /// 
        /// </summary>
        /// <returns>API type: legacy_price</returns>
        [JsonProperty("price_history")]
        public LegacyPrice[] PriceHistory {get; set;}
    }
}
