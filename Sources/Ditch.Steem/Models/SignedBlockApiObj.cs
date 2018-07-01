using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// signed_block_api_obj
    /// steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SignedBlockApiObj : SignedBlock
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