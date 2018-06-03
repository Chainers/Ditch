using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// get_market_history_buckets_return
    /// libraries\plugins\apis\market_history_api\include\steem\plugins\market_history_api\market_history_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetMarketHistoryBucketsReturn
    {

        /// <summary>
        /// API name: bucket_sizes
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("bucket_sizes")]
        public uint[] BucketSizes {get; set;}
    }
}
