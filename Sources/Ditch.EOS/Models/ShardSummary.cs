using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// shard_summary
    /// libraries\chain\include\eosio\chain\block.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ShardSummary
    {

        /// <summary>
        /// API name: read_locks
        /// 
        /// </summary>
        /// <returns>API type: shard_lock</returns>
        [JsonProperty("read_locks")]
        public ShardLock[] ReadLocks { get; set; }

        /// <summary>
        /// API name: write_locks
        /// 
        /// </summary>
        /// <returns>API type: shard_lock</returns>
        [JsonProperty("write_locks")]
        public ShardLock[] WriteLocks { get; set; }

        /// <summary>
        /// API name: transactions
        /// new or generated transactions
        /// </summary>
        /// <returns>API type: transaction_receipt</returns>
        [JsonProperty("transactions")]
        public TransactionReceipt[] Transactions { get; set; }
    }
}
