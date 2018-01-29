using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Objects
{
    /// <summary>
    /// scheduled_hardfork
    /// steem-0.19.1\libraries\app\include\steemit\app\database_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ScheduledHardfork
    {

        // bdType : hardfork_version
        [JsonProperty("hf_version")]
        public string HfVersion { get; set; }

        // bdType : time_point_sec
        [JsonProperty("live_time")]
        public DateTime LiveTime { get; set; }
    }
}
