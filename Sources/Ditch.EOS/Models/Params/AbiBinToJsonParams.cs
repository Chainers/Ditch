using Newtonsoft.Json;

namespace Ditch.EOS.Models.Params
{
    /// <summary>
    /// abi_bin_to_json_params
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AbiBinToJsonParams
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
        /// API name: binargs
        /// 
        /// </summary>
        /// <returns>API type: char</returns>
        [JsonProperty("binargs")]
        public string Binargs { get; set; }
    }
}
