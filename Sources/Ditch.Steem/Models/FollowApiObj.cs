using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// follow_api_obj
    /// steem-0.19.1\libraries\plugins\follow\include\steemit\follow\follow_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FollowApiObj
    {

        // bdType : string
        [JsonProperty("follower")]
        public string Follower { get; set; }

        // bdType : string
        [JsonProperty("following")]
        public string Following { get; set; }

        // bdType : vector<follow_type>
        [JsonProperty("what")]
        public FollowType[] What { get; set; }
    }
}