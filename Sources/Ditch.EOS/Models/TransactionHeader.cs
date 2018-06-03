using System;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /**
    *  The transaction header contains the fixed-sized data
    *  associated with each transaction. It is separated from
    *  the transaction body to facilitate partial parsing of
    *  transactions without requiring dynamic memory allocation.
    *
    *  All transactions have an expiration time after which they
    *  may no longer be included in the blockchain. Once a block
    *  with a block_header::timestamp greater than expiration is
    *  deemed irreversible, then a user can safely trust the transaction
    *  will never be included.
    *
    *  Each region is an independent blockchain, it is included as routing
    *  information for inter-blockchain communication. A contract in this
    *  region might generate or authorize a transaction intended for a foreign
    *  region.
    */

    /// <summary>
    /// transaction_header
    /// libraries\chain\include\eosio\chain\transaction.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class TransactionHeader
    {

        /// <summary>
        /// API name: expiration
        /// the time at which a transaction expires
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }

        /// <summary>
        /// API name: region
        /// = 0U; ///&lt; the computational memory region this transaction applies to.
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("region")]
        public ushort Region { get; set; }

        /// <summary>
        /// API name: ref_block_num
        /// = 0U; ///&lt; specifies a block num in the last 2^16 blocks.
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("ref_block_num")]
        public ushort RefBlockNum { get; set; }

        /// <summary>
        /// API name: ref_block_prefix
        /// = 0UL; ///&lt; specifies the lower 32 bits of the blockid at get_ref_blocknum
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("ref_block_prefix")]
        public uint RefBlockPrefix { get; set; }

        /// <summary>
        /// API name: max_net_usage_words
        /// = 0UL; /// upper limit on total network bandwidth (in 8 byte words) billed for this transaction
        /// </summary>
        /// <returns>API type: unsigned_int</returns>
        [JsonProperty("max_net_usage_words")]
        public uint MaxNetUsageWords { get; set; }

        /// <summary>
        /// API name: max_kcpu_usage
        /// = 0UL; /// upper limit on the total number of kilo CPU usage units billed for this transaction
        /// </summary>
        /// <returns>API type: unsigned_int</returns>
        [JsonProperty("max_kcpu_usage")]
        public uint MaxKcpuUsage { get; set; }

        /// <summary>
        /// API name: delay_sec
        /// = 0UL; /// number of seconds to delay this transaction for during which it may be canceled.
        /// </summary>
        /// <returns>API type: unsigned_int</returns>
        [JsonProperty("delay_sec")]
        public uint DelaySec { get; set; }
    }
}
