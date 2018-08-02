using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_controlled_accounts_params
    /// plugins\history_plugin\include\eosio\history_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetControlledAccountsParams
    {

        /// <summary>
        /// API name: controlling_account
        /// 
        /// </summary>
        /// <returns>API type: account_name</returns>
        [JsonProperty("controlling_account", NullValueHandling = NullValueHandling.Ignore)]
        public AccountName ControllingAccount {get; set;}
    }
}
