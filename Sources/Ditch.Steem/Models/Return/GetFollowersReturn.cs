using Ditch.Steem.Models.Objects;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// get_followers_return
    /// libraries\plugins\apis\follow_api\include\steem\plugins\follow_api\follow_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetFollowersReturn
    {

        /// <summary>
        /// API name: followers
        /// 
        /// </summary>
        /// <returns>API type: api_follow_object</returns>
        [JsonProperty("followers")]
        public ApiFollowObject[] Followers {get; set;}
    }
}
