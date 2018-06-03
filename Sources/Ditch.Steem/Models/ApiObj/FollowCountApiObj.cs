using Newtonsoft.Json;

namespace Ditch.Steem.Models.ApiObj
{
    /// <summary>
    /// follow_count_api_obj
    /// libraries\plugins\follow\include\steemit\follow\follow_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FollowCountApiObj
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
        public uint FollowerCount {get; set;}

        /// <summary>
        /// API name: following_count
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("following_count")]
        public uint FollowingCount {get; set;}
    }
}
