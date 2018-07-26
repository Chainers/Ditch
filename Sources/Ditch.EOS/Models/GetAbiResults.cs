using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_abi_results
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetAbiResults
    {
        /// <summary>
        /// API name: account_name
        /// 
        /// </summary>
        /// <returns>API type: name</returns>
        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        /// <summary>
        /// API name: abi
        /// 
        /// </summary>
        /// <returns>API type: abi_def</returns>
        [JsonProperty("abi", NullValueHandling = NullValueHandling.Ignore)]
        public AbiDef Abi { get; set; }
    }
}