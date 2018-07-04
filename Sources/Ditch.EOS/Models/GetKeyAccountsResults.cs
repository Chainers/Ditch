using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_key_accounts_results
    /// plugins\history_plugin\include\eosio\history_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetKeyAccountsResults
    {
        /// <summary>
        /// API name: account_names
        /// 
        /// </summary>
        /// <returns>API type: account_name</returns>
        [JsonProperty("account_names")]
        public AccountName[] AccountNames { get; set; }
    }
}