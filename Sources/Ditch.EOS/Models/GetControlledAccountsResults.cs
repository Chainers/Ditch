using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_controlled_accounts_results
    /// plugins\history_plugin\include\eosio\history_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetControlledAccountsResults
    {

        /// <summary>
        /// API name: controlled_accounts
        /// 
        /// </summary>
        /// <returns>API type: account_name</returns>
        [JsonProperty("controlled_accounts")]
        public AccountName[] ControlledAccounts {get; set;}
    }
}
