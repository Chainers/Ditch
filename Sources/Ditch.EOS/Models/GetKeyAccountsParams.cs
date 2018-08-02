using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_key_accounts_params
    /// plugins\history_plugin\include\eosio\history_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetKeyAccountsParams
    {

        /// <summary>
        /// API name: public_key
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [JsonProperty("public_key", NullValueHandling = NullValueHandling.Ignore)]
        public PublicKeyType PublicKey {get; set;}
    }
}