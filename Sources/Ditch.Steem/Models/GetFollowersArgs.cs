using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// get_followers_args
    /// libraries\plugins\apis\follow_api\include\steem\plugins\follow_api\follow_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetFollowersArgs
    {

        /// <summary>
        /// API name: account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("account")]
        public string Account {get; set;}

        /// <summary>
        /// API name: start
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("start")]
        public string Start {get; set;}

        /// <summary>
        /// API name: type
        /// 
        /// </summary>
        /// <returns>API type: follow_type</returns>
        [JsonProperty("type")]
        public FollowType Type {get; set;}

        /// <summary>
        /// API name: limit
        /// = 1000;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("limit")]
        public uint Limit {get; set;}
    }
}
