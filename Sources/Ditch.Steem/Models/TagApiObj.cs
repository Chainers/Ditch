using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// tag_api_obj
    /// steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class TagApiObj
    {

        // bdType : string
        [JsonProperty("name")]
        public string Name { get; set; }

        // bdType : uint128_t
        [JsonProperty("total_children_rshares2")]
        public UInt128 TotalChildrenRshares2 { get; set; }

        // bdType : asset
        [JsonProperty("total_payouts")]
        public Asset TotalPayouts { get; set; }

        // bdType : int32_t | = 0;
        [JsonProperty("net_votes")]
        public int NetVotes { get; set; }

        // bdType : uint32_t | = 0;
        [JsonProperty("top_posts")]
        public uint TopPosts { get; set; }

        // bdType : uint32_t | = 0;
        [JsonProperty("comments")]
        public uint Comments { get; set; }

        // bdType : uint128 | = 0;
        [JsonProperty("trending")]
        public UInt128 Trending { get; set; }
    }

}
