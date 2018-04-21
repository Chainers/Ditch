using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_account_results
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GetAccountResults
    {

        /// <summary>
        /// API name: account_name
        /// 
        /// </summary>
        /// <returns>API type: name</returns>
        [JsonProperty("account_name")]
        public string AccountName {get; set;}

        /// <summary>
        /// API name: permissions
        /// 
        /// </summary>
        /// <returns>API type: permission</returns>
        [JsonProperty("permissions")]
        public Permission[] Permissions {get; set;}
    }
}
