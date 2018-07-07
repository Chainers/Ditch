using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <inheritdoc />
    /// <summary>
    /// api_signed_block_object
    /// libraries\plugins\apis\block_api\include\steem\plugins\block_api\block_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ApiSignedBlockObject : SignedBlock
    {

        /// <summary>
        /// API name: block_id
        /// 
        /// </summary>
        /// <returns>API type: block_id_type</returns>
        [JsonProperty("block_id")]
        public object BlockId {get; set;}

        /// <summary>
        /// API name: signing_key
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [JsonProperty("signing_key")]
        public PublicKeyType SigningKey {get; set;}

        /// <summary>
        /// API name: transaction_ids
        /// 
        /// </summary>
        /// <returns>API type: transaction_id_type</returns>
        [JsonProperty("transaction_ids")]
        public string[] TransactionIds {get; set;}
    }
}
