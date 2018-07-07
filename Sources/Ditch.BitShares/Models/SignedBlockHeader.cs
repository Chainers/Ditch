using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <inheritdoc />
    /// <summary>
    /// signed_block_header
    /// libraries\chain\include\graphene\chain\protocol\block.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SignedBlockHeader : BlockHeader
    {

        /// <summary>
        /// API name: witness_signature
        /// 
        /// </summary>
        /// <returns>API type: signature_type</returns>
        [JsonProperty("witness_signature")]
        public byte[] WitnessSignature { get; set; }
    }
}
