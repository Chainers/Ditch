using System;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.ApiObj
{
    /// <summary>
    /// follow_count_api_obj
    /// plugins\follow\include\golos\plugins\follow\follow_api_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class FollowCountApiObj
    {

        /// <summary>
        /// API name: account
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("account")]
        public string Account {get; set;}

        /// <summary>
        /// API name: follower_count
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("follower_count")]
        public UInt32 FollowerCount {get; set;}

        /// <summary>
        /// API name: following_count
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("following_count")]
        public UInt32 FollowingCount {get; set;}

        [JsonProperty("limit")]
        public UInt32 Limit {get; set;}
    }
}
