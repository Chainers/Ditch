using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// abi_bin_to_json_result
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AbiBinToJsonResult
    {

        /// <summary>
        /// API name: args
        /// 
        /// </summary>
        /// <returns>API type: variant</returns>
        [JsonProperty("args")]
        public object Args { get; set; }
    }
}
