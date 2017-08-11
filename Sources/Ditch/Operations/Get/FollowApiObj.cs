using Ditch.Operations.Enums;
using Newtonsoft.Json;

namespace Ditch.Operations.Get
{
    [JsonObject(MemberSerialization.OptIn)]
    public class FollowApiObj
    {
        public const string Api = "follow_api";

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