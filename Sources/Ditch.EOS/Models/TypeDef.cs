using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// type_def
    /// libraries\chain\include\eosio\chain\contracts\types.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class TypeDef
    {

        /// <summary>
        /// API name: new_type_name
        /// 
        /// </summary>
        /// <returns>API type: type_name</returns>
        [JsonProperty("new_type_name")]
        public string NewTypeName {get; set;}

        /// <summary>
        /// API name: type
        /// 
        /// </summary>
        /// <returns>API type: type_name</returns>
        [JsonProperty("type")]
        public string Type {get; set;}
    }
}
