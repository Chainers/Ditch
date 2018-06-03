using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// region_summary
    /// libraries\chain\include\eosio\chain\block.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class RegionSummary
    {

        /// <summary>
        /// API name: region
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("region")]
        public ushort Region { get; set; }

        /// <summary>
        /// API name: cycles_summary
        /// 
        /// </summary>
        /// <returns>API type: cycle</returns>
        [JsonProperty("cycles_summary")]
        public ShardSummary[][] CyclesSummary { get; set; }
    }
}
