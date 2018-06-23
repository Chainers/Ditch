using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// abi_def
    /// libraries\chain\include\eosio\chain\contracts\types.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AbiDef
    {

        /// <summary>
        /// API name: types
        /// 
        /// </summary>
        /// <returns>API type: type_def</returns>
        [JsonProperty("types")]
        public TypeDef[] Types { get; set; }

        /// <summary>
        /// API name: structs
        /// 
        /// </summary>
        /// <returns>API type: struct_def</returns>
        [JsonProperty("structs")]
        public StructDef[] Structs { get; set; }

        /// <summary>
        /// API name: actions
        /// 
        /// </summary>
        /// <returns>API type: action_def</returns>
        [JsonProperty("actions")]
        public ActionDef[] Actions { get; set; }

        /// <summary>
        /// API name: tables
        /// 
        /// </summary>
        /// <returns>API type: table_def</returns>
        [JsonProperty("tables")]
        public TableDef[] Tables { get; set; }

        /// <summary>
        /// API name: ricardian_clauses
        /// 
        /// </summary>
        /// <returns>API type: clause_pair</returns>
        [JsonProperty("ricardian_clauses")]
        public ClausePair[] RicardianClauses { get; set; }
    }
}
