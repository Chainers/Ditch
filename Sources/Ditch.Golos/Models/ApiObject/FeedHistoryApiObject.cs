using Ditch.Golos.Models.Objects;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.ApiObject
{
    /// <summary>
    /// feed_history_api_object
    /// plugins\database_api\include\golos\plugins\database_api\api_objects\feed_history_api_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class FeedHistoryApiObject
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
