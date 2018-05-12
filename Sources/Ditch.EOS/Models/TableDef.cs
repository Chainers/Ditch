using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// table_def
    /// libraries\chain\include\eosio\chain\contracts\types.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class TableDef
    {

        /// <summary>
        /// API name: name
        /// the name of the table
        /// </summary>
        /// <returns>API type: table_name</returns>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// API name: index_type
        /// the kind of index, i64, i128i128, etc
        /// </summary>
        /// <returns>API type: type_name</returns>
        [JsonProperty("index_type")]
        public string IndexType { get; set; }

        /// <summary>
        /// API name: key_names
        /// names for the keys defined by key_types
        /// </summary>
        /// <returns>API type: field_name</returns>
        [JsonProperty("key_names")]
        public string[] KeyNames { get; set; }

        /// <summary>
        /// API name: key_types
        /// the type of key parameters
        /// </summary>
        /// <returns>API type: type_name</returns>
        [JsonProperty("key_types")]
        public string[] KeyTypes { get; set; }

        /// <summary>
        /// API name: type
        /// type of binary data stored in this table
        /// </summary>
        /// <returns>API type: type_name</returns>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
