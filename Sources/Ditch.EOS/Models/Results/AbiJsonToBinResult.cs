using Newtonsoft.Json;

namespace Ditch.EOS.Models.Results
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
        public string Binargs { get; set; }

        /// <summary>
        /// API name: required_scope
        /// 
        /// </summary>
        /// <returns>API type: name</returns>
        [JsonProperty("required_scope")]
        public string[] RequiredScope { get; set; }

        /// <summary>
        /// API name: required_auth
        /// 
        /// </summary>
        /// <returns>API type: name</returns>
        [JsonProperty("required_auth")]
        public string[] RequiredAuth { get; set; }
    }
}
