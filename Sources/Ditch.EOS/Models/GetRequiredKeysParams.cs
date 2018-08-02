using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_required_keys_params
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetRequiredKeysParams
    {

        /// <summary>
        /// API name: transaction
        /// 
        /// </summary>
        /// <returns>API type: variant</returns>
        [JsonProperty("transaction", NullValueHandling = NullValueHandling.Ignore)]
        public object Transaction { get; set; }

        ///// <summary>
        ///// API name: available_keys
        ///// 
        ///// </summary>
        ///// <returns>API type: flat_set<public_key_type></returns>
        //[JsonProperty("available_keys")]
        //public PublicKeyType[] AvailableKeys { get; set; }
    }
}
