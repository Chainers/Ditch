using Newtonsoft.Json;

namespace Ditch.EOS.Models.Results
{
    /// <summary>
    /// get_code_results
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GetCodeResults
    {

        /// <summary>
        /// API name: account_name
        /// 
        /// </summary>
        /// <returns>API type: name</returns>
        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        /// <summary>
        /// API name: wast
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("wast")]
        public string Wast { get; set; }

        /// <summary>
        /// API name: code_hash
        /// 
        /// </summary>
        /// <returns>API type: sha256</returns>
        [JsonProperty("code_hash")]
        public object CodeHash { get; set; }

        /// <summary>
        /// API name: abi
        /// 
        /// </summary>
        /// <returns>API type: abi_def</returns>
        [JsonProperty("abi", NullValueHandling = NullValueHandling.Ignore)]
        public AbiDef Abi { get; set; }
    }
}
