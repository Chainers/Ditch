using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// struct_def
    /// libraries\chain\include\eosio\chain\abi_def.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class StructDef
    {

        /// <summary>
        /// API name: name
        /// 
        /// </summary>
        /// <returns>API type: type_name</returns>
        [JsonProperty("name")]
        public string Name {get; set;}

        /// <summary>
        /// API name: base
        /// 
        /// </summary>
        /// <returns>API type: type_name</returns>
        [JsonProperty("base")]
        public string Base {get; set;}

        /// <summary>
        /// API name: fields
        /// 
        /// </summary>
        /// <returns>API type: field_def</returns>
        [JsonProperty("fields")]
        public FieldDef[] Fields {get; set;}
    }
}
