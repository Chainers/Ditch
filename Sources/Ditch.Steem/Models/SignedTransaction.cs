using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// signed_transaction
    /// libraries\protocol\include\steemit\protocol\transaction.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SignedTransaction : Transaction
    {
        /// <summary>
        /// API name: signatures
        /// 
        /// </summary>
        /// <returns>API type: signature_type (typedef fc::array&lt;unsigned char, 65> compact_signature;)</returns>
        [JsonProperty("signatures")]
        public string[] Signatures { get; set; } = new string[0];
    }
}
