using Newtonsoft.Json;

namespace Ditch.Golos.Models.Objects
{
    /// <summary>
    /// signed_block_header
    /// golos-0.16.3\libraries\protocol\include\steemit\protocol\block_header.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class SignedBlockHeader : BlockHeader
    {
        // bdType : signature_type
        [JsonProperty("witness_signature")]
        public object WitnessSignature { get; set; }
    }
}