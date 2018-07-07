using Ditch.Core.Attributes;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /**
     * @defgroup transactioncppapi Transaction C++ API
     * @ingroup transactionapi
     * @brief Type-safe C++ wrappers for transaction C API
     *
     * @note There are some methods from the @ref transactioncapi that can be used directly from C++
     *
     * @{
     */

    /// <summary>
    /// transaction_header
    /// contracts\eosiolib\transaction.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class TransactionHeader
    {
        /// <summary>
        /// API name: expiration
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [MessageOrder(10)]
        [JsonProperty("expiration")]
        public TimePointSec Expiration { get; set; } = new TimePointSec();

        /// <summary>
        /// API name: ref_block_num
        /// 
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [MessageOrder(20)]
        [JsonProperty("ref_block_num")]
        public ushort RefBlockNum { get; set; }

        /// <summary>
        /// API name: ref_block_prefix
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [MessageOrder(30)]
        [JsonProperty("ref_block_prefix")]
        public uint RefBlockPrefix { get; set; }

        /// <summary>
        /// API name: max_net_usage_words
        /// = 0UL; /// number of 8 byte words this transaction can serialize into after compressions
        /// </summary>
        /// <returns>API type: unsigned_int</returns>
        [MessageOrder(40)]
        [JsonProperty("max_net_usage_words")]
        public UnsignedInt MaxNetUsageWords { get; set; } = new UnsignedInt();

        /// <summary>
        /// API name: max_cpu_usage_ms
        /// = 0UL; /// number of CPU usage units to bill transaction for
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [MessageOrder(50)]
        [JsonProperty("max_cpu_usage_ms")]
        public byte MaxCpuUsageMs { get; set; }

        /// <summary>
        /// API name: delay_sec
        /// = 0UL; /// number of CPU usage units to bill transaction for
        /// </summary>
        /// <returns>API type: unsigned_int</returns>
        [MessageOrder(60)]
        [JsonProperty("delay_sec")]
        public UnsignedInt DelaySec { get; set; } = new UnsignedInt();
    }
}
