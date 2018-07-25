using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_raw_code_and_abi_results
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetRawCodeAndAbiResults
    {

        /// <summary>
        /// API name: account_name
        /// 
        /// </summary>
        /// <returns>API type: name</returns>
        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        /// <summary>
        /// API name: wasm
        /// 
        /// </summary>
        /// <returns>API type: blob</returns>
        [JsonProperty("wasm")]
        public object Wasm { get; set; }

        /// <summary>
        /// API name: abi
        /// 
        /// </summary>
        /// <returns>API type: blob</returns>
        [JsonProperty("abi")]
        public object Abi { get; set; }
    }
}