using Ditch.Steem.Models.Objects;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// get_following_return
    /// libraries\plugins\apis\follow_api\include\steem\plugins\follow_api\follow_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GetFollowingReturn
    {

        /// <summary>
        /// API name: following
        /// 
        /// </summary>
        /// <returns>API type: api_follow_object</returns>
        [JsonProperty("following")]
        public ApiFollowObject[] Following {get; set;}
    }
}
