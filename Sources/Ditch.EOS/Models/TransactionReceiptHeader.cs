using System;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /**
     * When a transaction is referenced by a block it could imply one of several outcomes which
     * describe the state-transition undertaken by the block producer.
     */

    /// <summary>
    /// transaction_receipt_header
    /// libraries\chain\include\eosio\chain\block.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class TransactionReceiptHeader
    {

        /// <summary>
        /// API name: status
        /// 
        /// </summary>
        /// <returns>API type: enum_type</returns>
        [JsonProperty("status")]
        //public EnumType<byte, StatusEnum> Status { get; set; }
        public object Status { get; set; }


        /// <summary>
        /// API name: cpu_usage_us
        /// total billed CPU usage (microseconds)
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("cpu_usage_us")]
        public UInt32 CpuUsageUs { get; set; }

        /// <summary>
        /// API name: net_usage_words
        /// total billed NET usage, so we can reconstruct resource state when skipping context free data... hard failures...
        /// </summary>
        /// <returns>API type: unsigned_int</returns>
        [JsonProperty("net_usage_words")]
        public UInt32 NetUsageWords { get; set; }
    }
}
