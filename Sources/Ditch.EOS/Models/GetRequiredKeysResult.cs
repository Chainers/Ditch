using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_required_keys_result
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetRequiredKeysResult
    {

        ///// <summary>
        ///// API name: required_keys
        ///// 
        ///// </summary>
        ///// <returns>API type: flat_set<public_key_type></returns>
        //[JsonProperty("required_keys")]
        //public PublicKeyType[] RequiredKeys { get; set; }
    }
}
