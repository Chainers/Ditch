using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Objects
{
    /// <summary>
    /// api_tag_object
    /// libraries\plugins\apis\condenser_api\include\steem\plugins\condenser_api\condenser_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ApiTagObject
    {

        /// <summary>
        /// API name: name
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("name")]
        public string Name {get; set;}

        /// <summary>
        /// API name: total_payouts
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("total_payouts")]
        public LegacyAsset TotalPayouts {get; set;}

        /// <summary>
        /// API name: net_votes
        /// = 0;
        /// </summary>
        /// <returns>API type: int32_t</returns>
        [JsonProperty("net_votes")]
        public Int32 NetVotes {get; set;}

        /// <summary>
        /// API name: top_posts
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("top_posts")]
        public UInt32 TopPosts {get; set;}

        /// <summary>
        /// API name: comments
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("comments")]
        public UInt32 Comments {get; set;}

        /// <summary>
        /// API name: trending
        /// = 0;
        /// </summary>
        /// <returns>API type: uint128</returns>
        [JsonProperty("trending")]
        public string Trending {get; set;}
    }
}
