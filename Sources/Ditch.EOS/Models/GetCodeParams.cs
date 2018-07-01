using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_code_params
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetCodeParams
    {

        /// <summary>
        /// API name: account_name
        /// 
        /// </summary>
        /// <returns>API type: name</returns>
        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        /// <summary>
        /// API name: code_as_wasm
        /// = false;
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("code_as_wasm")]
        public bool CodeAsWasm { get; set; }
    }
}
