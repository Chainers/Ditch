using System;
using Ditch.Golos.Models.Other;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.ApiObj
{
    /// <summary>
    /// category_api_obj
    /// golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class CategoryApiObj
    {

        // bdType : category_id_type
        [JsonProperty("id")]
        public object Id { get; set; }

        // bdType : string
        [JsonProperty("name")]
        public string Name { get; set; }

        // bdType : share_type
        [JsonProperty("abs_rshares")]
        public object AbsRshares { get; set; }

        // bdType : asset
        [JsonProperty("total_payouts")]
        public Asset TotalPayouts { get; set; }

        // bdType : uint32_t
        [JsonProperty("discussions")]
        public UInt32 Discussions { get; set; }

        // bdType : time_point_sec
        [JsonProperty("last_update")]
        public DateTime LastUpdate { get; set; }
    }

}
