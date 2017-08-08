using System;
using Newtonsoft.Json;

namespace Ditch.Operations.Get
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ScheduledHardfork
    {
        [JsonProperty("hf_version")]
        public string HfVersion { get; set; }

        [JsonProperty("live_time")]
        public DateTime LiveTime { get; set; }
    }
}
