using Ditch.Steem.Dtos;
using Newtonsoft.Json;

namespace Ditch.Steem.Objects
{
    /// <summary>
    /// feed_history_api_obj
    /// steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FeedHistoryApiObj
    {

        // bdType : feed_history_id_type
        [JsonProperty("id")]
        public object Id { get; set; }

        // bdType : price
        [JsonProperty("current_median_history")]
        public Price CurrentMedianHistory { get; set; }

        // bdType : deque<price>
        [JsonProperty("price_history")]
        public Price[] PriceHistory { get; set; }
    }
}