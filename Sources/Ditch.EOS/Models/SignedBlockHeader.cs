using System;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// signed_block_header
    /// libraries\chain\include\eosio\chain\block.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class SignedBlockHeader : BlockHeader
    {
        /// <summary>
        /// API name: block_id_type
        /// 
        /// </summary>
        /// <returns>API type: block_id_type</returns>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// API name: block_id_type
        /// 
        /// </summary>
        /// <returns>API type: block_id_type</returns>
        [JsonProperty("ref_block_prefix")]
        public UInt32 RefBlockPrefix { get; set; }

        /// <summary>
        /// API name: producer_signature
        /// 
        /// </summary>
        /// <returns>API type: signature_type</returns>
        [JsonProperty("producer_signature")]
        public string ProducerSignature { get; set; }
    }
}
