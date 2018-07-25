using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_producers_result
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetProducersResult
    {

        /// <summary>
        /// API name: rows
        /// one row per item, either encoded as hex string or JSON object
        /// </summary>
        /// <returns>API type: variant</returns>
        [JsonProperty("rows")]
        public object[] Rows { get; set; }

        /// <summary>
        /// API name: total_producer_vote_weight
        /// 
        /// </summary>
        /// <returns>API type: double</returns>
        [JsonProperty("total_producer_vote_weight")]
        public double TotalProducerVoteWeight { get; set; }

        /// <summary>
        /// API name: more
        /// fill lower_bound with this value to fetch more rows
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("more")]
        public string More { get; set; }
    }
}