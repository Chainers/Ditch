using System;
using Newtonsoft.Json;

namespace Ditch.Operations.Get
{
    [JsonObject(MemberSerialization.OptIn)]
    public class AppliedOperation
    {
        [JsonProperty("trx_id")]
        public string TrxId { get; set; }

        [JsonProperty("block")]
        public UInt32 Block { get; set; }

        [JsonProperty("trx_in_block")]
        public UInt32 TrxInBlock { get; set; }

        [JsonProperty("op_in_trx")]
        public UInt16 OpInTrx { get; set; }

        [JsonProperty("virtual_op")]
        public UInt64 VirtualOp { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("op")]
        public object[] Op { get; set; }
    }
}
