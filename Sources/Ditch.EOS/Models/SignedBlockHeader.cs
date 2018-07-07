using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <inheritdoc />
    /// <summary>
    /// signed_block_header
    /// libraries\chain\include\eosio\chain\block_header.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SignedBlockHeader : BlockHeader
    {

        /// <summary>
        /// API name: producer_signature
        /// 
        /// </summary>
        /// <returns>API type: signature_type</returns>
        [JsonProperty("producer_signature")]
        public string ProducerSignature { get; set; }
    }
}
