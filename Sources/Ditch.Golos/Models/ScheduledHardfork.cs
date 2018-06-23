using System;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// scheduled_hardfork
    /// plugins\database_api\include\golos\plugins\database_api\plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ScheduledHardfork
    {

        /// <summary>
        /// API name: hf_version
        /// 
        /// </summary>
        /// <returns>API type: hardfork_version</returns>
        [JsonProperty("hf_version")]
        public string HfVersion { get; set; }

        /// <summary>
        /// API name: live_time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("live_time")]
        public DateTime LiveTime { get; set; }
    }
}
