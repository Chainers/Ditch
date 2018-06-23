using System;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// feed_history_api_object
    /// plugins\witness_api\include\golos\plugins\witness_api\api_objects\feed_history_api_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FeedHistoryApiObject
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
        /// <returns>API type: price</returns>
        [JsonProperty("current_median_history")]
        public Price CurrentMedianHistory {get; set;}

        /// <summary>
        /// API name: price_history
        /// 
        /// </summary>
        /// <returns>API type: price</returns>
        [JsonProperty("price_history")]
        public Price[] PriceHistory {get; set;}
    }
}
