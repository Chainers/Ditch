using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// follow_api_object
    /// plugins\follow\include\golos\plugins\follow\follow_api_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FollowApiObject
    {

        /// <summary>
        /// API name: follower
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("follower")]
        public string Follower { get; set; }

        /// <summary>
        /// API name: following
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("following")]
        public string Following { get; set; }

        /// <summary>
        /// API name: what
        /// 
        /// </summary>
        /// <returns>API type: follow_type</returns>
        [JsonProperty("what")]
        public FollowType[] What { get; set; }
    }
}