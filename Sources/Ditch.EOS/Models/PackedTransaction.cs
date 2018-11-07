using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// packed_transaction
    /// libraries\chain\include\eosio\chain\transaction.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class PackedTransaction
    {

        /// <summary>
        /// API name: signatures
        /// 
        /// </summary>
        /// <returns>API type: signature_type</returns>
        [JsonProperty("signatures")]
        public string[] Signatures { get; set; }

        /// <summary>
        /// API name: compression
        /// 
        /// </summary>
        /// <returns>API type: fc::enum_type&lt;uint8_t,compression_type></returns>
        [JsonProperty("compression")]
        public CompressionType Compression { get; set; }

        /// <summary>
        /// API name: packed_context_free_data
        /// 
        /// </summary>
        /// <returns>API type: bytes</returns>
        [JsonProperty("packed_context_free_data")]
        public Bytes PackedContextFreeData { get; set; }

        /// <summary>
        /// API name: packed_trx
        /// 
        /// </summary>
        /// <returns>API type: bytes</returns>
        [JsonProperty("packed_trx")]
        public Bytes PackedTrx { get; set; }

    }
}
