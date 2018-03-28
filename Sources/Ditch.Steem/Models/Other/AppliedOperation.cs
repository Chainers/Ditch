using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Other
{
    /// <summary>
    /// applied_operation
    /// steem-0.19.1\libraries\app\include\steemit\app\applied_operation.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class AppliedOperation
    {

        // bdType : transaction_id_type
        [JsonProperty("trx_id")]
        public string TrxId { get; set; }

        // bdType : uint32_t | = 0;
        [JsonProperty("block")]
        public UInt32 Block { get; set; }

        // bdType : uint32_t | = 0;
        [JsonProperty("trx_in_block")]
        public UInt32 TrxInBlock { get; set; }

        // bdType : uint16_t | = 0;
        [JsonProperty("op_in_trx")]
        public UInt16 OpInTrx { get; set; }

        // bdType : uint64_t | = 0;
        [JsonProperty("virtual_op")]
        public UInt64 VirtualOp { get; set; }

        // bdType : time_point_sec
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("op")]
        public object[] Op { get; set; }
    }
}
