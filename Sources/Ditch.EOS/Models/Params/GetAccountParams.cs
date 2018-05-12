using Newtonsoft.Json;

namespace Ditch.EOS.Models.Params
{
    /// <summary>
    /// get_account_params
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GetAccountParams
    {

        /// <summary>
        /// API name: account_name
        /// 
        /// </summary>
        /// <returns>API type: name</returns>
        [JsonProperty("account_name")]
        public string AccountName {get; set;}
    }
}
