using Newtonsoft.Json;

namespace Ditch.Golos.Models.Objects
{
    /// <summary>
    /// signed_block_api_obj
    /// golos-0.16.3\libraries\protocol\include\steemit\protocol\block.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class SignedBlockApiObj : SignedBlock
    {

        // bdType : block_id_type
        [JsonProperty("block_id")]
        public object BlockId { get; set; }

        // bdType : public_key_type
        [JsonProperty("signing_key")]
        public PublicKeyType SigningKey { get; set; }

        // bdType : vector<transaction_id_type>
        [JsonProperty("transaction_ids")]
        public string[] TransactionIds { get; set; }
    }
}