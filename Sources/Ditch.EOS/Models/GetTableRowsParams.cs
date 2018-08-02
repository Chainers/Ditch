using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_table_rows_params
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetTableRowsParams
    {

        /// <summary>
        /// API name: json
        /// = false;
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("json", NullValueHandling = NullValueHandling.Ignore)]
        public bool Json { get; set; }

        /// <summary>
        /// API name: code
        /// 
        /// </summary>
        /// <returns>API type: name</returns>
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        /// <summary>
        /// API name: scope
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("scope", NullValueHandling = NullValueHandling.Ignore)]
        public string Scope { get; set; }

        /// <summary>
        /// API name: table
        /// 
        /// </summary>
        /// <returns>API type: name</returns>
        [JsonProperty("table", NullValueHandling = NullValueHandling.Ignore)]
        public string Table { get; set; }

        //      string      table_type;

        /// <summary>
        /// API name: table_key
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("table_key", NullValueHandling = NullValueHandling.Ignore)]
        public string TableKey { get; set; }

        /// <summary>
        /// API name: lower_bound
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("lower_bound", NullValueHandling = NullValueHandling.Ignore)]
        public string LowerBound { get; set; }

        /// <summary>
        /// API name: upper_bound
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("upper_bound", NullValueHandling = NullValueHandling.Ignore)]
        public string UpperBound { get; set; }

        /// <summary>
        /// API name: limit
        /// = 10;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public uint Limit { get; set; }
    }
}
