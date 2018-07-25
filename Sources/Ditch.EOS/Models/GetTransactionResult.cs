using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_transaction_result
    /// plugins\history_plugin\include\eosio\history_plugin\history_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetTransactionResult
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: transaction_id_type</returns>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// API name: trx
        /// 
        /// </summary>
        /// <returns>API type: variant</returns>
        [JsonProperty("trx")]
        public object Trx { get; set; }

        /// <summary>
        /// API name: block_time
        /// 
        /// </summary>
        /// <returns>API type: block_timestamp_type</returns>
        [JsonProperty("block_time")]
        public BlockTimestampType BlockTime { get; set; }

        /// <summary>
        /// API name: block_num
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("block_num")]
        public uint BlockNum { get; set; }

        /// <summary>
        /// API name: last_irreversible_block
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("last_irreversible_block")]
        public uint LastIrreversibleBlock { get; set; }

        /// <summary>
        /// API name: traces
        /// 
        /// </summary>
        /// <returns>API type: variant</returns>
        [JsonProperty("traces")]
        public object[] Traces { get; set; }
    }
}
