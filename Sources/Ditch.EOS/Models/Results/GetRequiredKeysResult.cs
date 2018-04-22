using Newtonsoft.Json;

namespace Ditch.EOS.Models.Results
{
    /// <summary>
    /// get_required_keys_result
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GetRequiredKeysResult
    {

        /// <summary>
        /// API name: required_keys
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("required_keys")]
        public string[] RequiredKeys { get; set; }
    }
}
