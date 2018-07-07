using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// applied_operation
    /// golos-0.16.3\libraries\app\include\steemit\app\applied_operation.hpp\
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AppliedOperation
    {

        // bdType : transaction_id_type
        [JsonProperty("trx_id")]
        public string TrxId { get; set; }

        // bdType : uint32_t | = 0;
        [JsonProperty("block")]
        public uint Block { get; set; }

        // bdType : uint32_t | = 0;
        [JsonProperty("trx_in_block")]
        public uint TrxInBlock { get; set; }

        // bdType : uint16_t | = 0;
        [JsonProperty("op_in_trx")]
        public ushort OpInTrx { get; set; }

        // bdType : uint64_t | = 0;
        [JsonProperty("virtual_op")]
        public ulong VirtualOp { get; set; }

        // bdType : time_point_sec
        [JsonProperty("timestamp")]
        public TimePointSec Timestamp { get; set; }

        [JsonProperty("op")]
        public Operation Op { get; set; }
    }
}
