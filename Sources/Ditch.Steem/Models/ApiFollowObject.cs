using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// api_follow_object
    /// libraries\plugins\apis\follow_api\include\steem\plugins\follow_api\follow_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ApiFollowObject
    {

        /// <summary>
        /// API name: follower
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("follower")]
        public string Follower {get; set;}

        /// <summary>
        /// API name: following
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("following")]
        public string Following {get; set;}

        /// <summary>
        /// API name: what
        /// 
        /// </summary>
        /// <returns>API type: follow_type</returns>
        [JsonProperty("what")]
        public FollowType[] What {get; set;}
    }
}
