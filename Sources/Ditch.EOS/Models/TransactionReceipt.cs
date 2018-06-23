using Ditch.EOS.Models.Enums;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /**
     * When a transaction is referenced by a block it could imply one of several outcomes which
     * describe the state-transition undertaken by the block producer.
     */

    /// <summary>
    /// transaction_receipt
    /// libraries\chain\include\eosio\chain\transaction.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class TransactionReceipt
    {

        /// <summary>
        /// API name: status
        /// 
        /// </summary>
        /// <returns>API type: enum_type</returns>
        [JsonProperty("status")]
        public StatusEnum Status { get; set; }

        /// <summary>
        /// API name: kcpu_usage
        /// 
        /// </summary>
        /// <returns>API type: unsigned_int</returns>
        [JsonProperty("kcpu_usage")]
        public uint KcpuUsage { get; set; }

        /// <summary>
        /// API name: net_usage_words
        /// 
        /// </summary>
        /// <returns>API type: unsigned_int</returns>
        [JsonProperty("net_usage_words")]
        public uint NetUsageWords { get; set; }

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: transaction_id_type</returns>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
