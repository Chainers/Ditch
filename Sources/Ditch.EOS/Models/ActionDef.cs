using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// action_def
    /// libraries\chain\include\eosio\chain\contracts\types.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ActionDef
    {

        /// <summary>
        /// API name: name
        /// 
        /// </summary>
        /// <returns>API type: action_name</returns>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// API name: type
        /// 
        /// </summary>
        /// <returns>API type: type_name</returns>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// API name: ricardian_contract
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("ricardian_contract")]
        public string RicardianContract { get; set; }
    }
}
