using Newtonsoft.Json;

namespace Ditch.EOS.Models.Results
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
