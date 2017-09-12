﻿using System;
using Newtonsoft.Json;

namespace Ditch.Operations.Get
{
    /// <summary>
    /// scheduled_hardfork
    /// golos-0.16.3\libraries\app\include\steemit\app\database_api.hpp
    /// steem-0.19.1\libraries\app\include\steemit\app\database_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ScheduledHardfork
    {

        // bdType : hardfork_version
        [JsonProperty("hf_version")]
        public string HfVersion { get; set; }

        // bdType : time_point_sec
        [JsonProperty("live_time")]
        public DateTime LiveTime { get; set; }
    }
}
