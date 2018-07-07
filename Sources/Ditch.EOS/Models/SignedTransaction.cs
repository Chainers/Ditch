using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <inheritdoc />
    /// <summary>
    /// signed_transaction
    /// libraries\chain\include\eosio\chain\transaction.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SignedTransaction : Transaction
    {
        /// <summary>
        /// API name: signatures
        /// 
        /// </summary>
        /// <returns>API type: signature_type</returns>
        [JsonProperty("signatures")]
        public string[] Signatures { get; set; } = new string[0];

        /// <summary>
        /// API name: context_free_data
        /// for each context-free action, there is an entry here
        /// </summary>
        /// <returns>API type: bytes</returns>
        [JsonProperty("context_free_data")]
        public Bytes[] ContextFreeData { get; set; } = new Bytes[0];
    }
}
