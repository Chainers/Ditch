using Newtonsoft.Json;

namespace Ditch.EOS.Models.Params
{
    /// <summary>
    /// abi_json_to_bin_params
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AbiJsonToBinParams
    {

        /// <summary>
        /// API name: code
        /// 
        /// </summary>
        /// <returns>API type: name</returns>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// API name: action
        /// 
        /// </summary>
        /// <returns>API type: name</returns>
        [JsonProperty("action")]
        public string Action { get; set; }

        /// <summary>
        /// API name: args
        /// 
        /// </summary>
        /// <returns>API type: variant</returns>
        [JsonProperty("args")]
        public object Args { get; set; }
    }
}
