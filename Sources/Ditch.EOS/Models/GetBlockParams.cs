using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_block_params
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetBlockParams
    {

        /// <summary>
        /// API name: block_num_or_id
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("block_num_or_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BlockNumOrId {get; set;}
    }
}
