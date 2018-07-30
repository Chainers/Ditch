using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_account_params
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetAccountParams
    {

        /// <summary>
        /// API name: account_name
        /// 
        /// </summary>
        /// <returns>API type: name</returns>
        [JsonProperty("account_name")]
        public string AccountName { get; set; }


        public GetAccountParams() { }

        public GetAccountParams(string accountName)
        {
            AccountName = accountName;
        }
    }
}
