using Ditch.EOS.Models.Enums;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// packed_transaction
    /// libraries\chain\include\eosio\chain\transaction.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class PackedTransaction
    {

        /// <summary>
        /// API name: signatures
        /// 
        /// </summary>
        /// <returns>API type: signature_type</returns>
        [JsonProperty("signatures")]
        public object[] Signatures { get; set; }

        /// <summary>
        /// API name: compression
        /// 
        /// </summary>
        /// <returns>API type: enum_type</returns>
        [JsonProperty("compression")]
        public CompressionType Compression { get; set; }

        /// <summary>
        /// API name: packed_context_free_data
        /// 
        /// </summary>
        /// <returns>API type: bytes</returns>
        [JsonProperty("packed_context_free_data")]
        public char PackedContextFreeData { get; set; }

        /// <summary>
        /// API name: packed_trx
        /// 
        /// </summary>
        /// <returns>API type: bytes</returns>
        [JsonProperty("packed_trx")]
        public char PackedTrx { get; set; }
    }
}
