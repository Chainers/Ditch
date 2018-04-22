using System;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_table_rows_params
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GetTableRowsParams
    {

        /// <summary>
        /// API name: json
        /// = false;
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("json")]
        public bool Json { get; set; }

        /// <summary>
        /// API name: code
        /// 
        /// </summary>
        /// <returns>API type: name</returns>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// API name: scope
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// API name: table
        /// 
        /// </summary>
        /// <returns>API type: name</returns>
        [JsonProperty("table")]
        public string Table { get; set; }

        //      string      table_type;

        /// <summary>
        /// API name: table_key
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("table_key")]
        public string TableKey { get; set; }

        /// <summary>
        /// API name: lower_bound
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("lower_bound")]
        public string LowerBound { get; set; }

        /// <summary>
        /// API name: upper_bound
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("upper_bound")]
        public string UpperBound { get; set; }

        /// <summary>
        /// API name: limit
        /// = 10;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("limit")]
        public UInt32 Limit { get; set; }
    }
}
