using System;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// ordered_action_result
    /// plugins\history_plugin\include\eosio\history_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class OrderedActionResult
    {

        /// <summary>
        /// API name: global_action_seq
        /// = 0;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("global_action_seq")]
        public UInt64 GlobalActionSeq { get; set; }

        /// <summary>
        /// API name: account_action_seq
        /// = 0;
        /// </summary>
        /// <returns>API type: int32_t</returns>
        [JsonProperty("account_action_seq")]
        public Int32 AccountActionSeq { get; set; }

        /// <summary>
        /// API name: block_num
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("block_num")]
        public UInt32 BlockNum { get; set; }

        /// <summary>
        /// API name: block_time
        /// 
        /// </summary>
        /// <returns>API type: block_timestamp_type</returns>
        [JsonProperty("block_time")]
        public BlockTimestampType BlockTime { get; set; }

        /// <summary>
        /// API name: action_trace
        /// 
        /// </summary>
        /// <returns>API type: variant</returns>
        [JsonProperty("action_trace")]
        public object ActionTrace { get; set; }
    }
}
