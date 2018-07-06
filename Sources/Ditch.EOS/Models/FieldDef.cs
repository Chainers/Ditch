using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// field_def
    /// libraries\chain\include\eosio\chain\abi_def.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FieldDef
    {

        /// <summary>
        /// API name: name
        /// 
        /// </summary>
        /// <returns>API type: field_name</returns>
        [JsonProperty("name")]
        public string Name {get; set;}

        /// <summary>
        /// API name: type
        /// 
        /// </summary>
        /// <returns>API type: type_name</returns>
        [JsonProperty("type")]
        public string Type {get; set;}
    }
}
