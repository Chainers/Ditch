using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_producers_params
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetProducersParams
    {

        /// <summary>
        /// API name: json
        /// = false;
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("json")]
        public bool Json { get; set; }

        /// <summary>
        /// API name: lower_bound
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("lower_bound", NullValueHandling = NullValueHandling.Ignore)]
        public string LowerBound { get; set; }

        /// <summary>
        /// API name: limit
        /// = 50;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("limit")]
        public uint Limit { get; set; }
    }
}