using Newtonsoft.Json;

namespace Ditch.Golos.Dtos
{
    /// <summary>
    /// signed_block_header
    /// golos-0.16.3\libraries\protocol\include\steemit\protocol\block_header.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SignedBlockHeader : BlockHeader
    {
        // bdType : signature_type
        [JsonProperty("witness_signature")]
        public object WitnessSignature { get; set; }
    }
}