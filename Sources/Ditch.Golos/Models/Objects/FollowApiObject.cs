using Ditch.Golos.Models.Enums;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.Objects
{
    /// <summary>
    /// follow_api_object
    /// plugins\follow\include\golos\plugins\follow\follow_api_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FollowApiObject
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