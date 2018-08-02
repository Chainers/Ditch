using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_abi_params
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetAbiParams
    {

        /// <summary>
        /// API name: account_name
        /// 
        /// </summary>
        /// <returns>API type: name</returns>
        [JsonProperty("account_name", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountName { get; set; }
    }
}