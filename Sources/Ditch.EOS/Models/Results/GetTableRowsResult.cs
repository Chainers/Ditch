using Newtonsoft.Json;

namespace Ditch.EOS.Models.Results
{
    /// <summary>
    /// get_table_rows_result
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GetTableRowsResult
    {

        /// <summary>
        /// API name: rows
        /// one row per item, either encoded as hex String or JSON object
        /// </summary>
        /// <returns>API type: variant</returns>
        [JsonProperty("rows")]
        public object[] Rows { get; set; }

        /// <summary>
        /// API name: more
        /// = false; ///&lt; true if last element in data is not the end and sizeof data()&lt; limit
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("more")]
        public bool More { get; set; }
    }
}
