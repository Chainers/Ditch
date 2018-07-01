using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// abi_json_to_bin_result
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AbiJsonToBinResult
    {

        /// <summary>
        /// API name: binargs
        /// 
        /// </summary>
        /// <returns>API type: char</returns>
        [JsonProperty("binargs")]
        public Bytes Binargs {get; set;}
    }
}
