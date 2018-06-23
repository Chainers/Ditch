using Newtonsoft.Json;

namespace Ditch.Steem.Models.Other
{
    /// <summary>
    /// annotated_signed_transaction
    /// libraries\protocol\include\steemit\protocol\transaction.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AnnotatedSignedTransaction : SignedTransaction
    {

        /// <summary>
        /// API name: transaction_id
        /// 
        /// </summary>
        /// <returns>API type: transaction_id_type</returns>
        [JsonProperty("transaction_id")]
        public string TransactionId {get; set;}

        /// <summary>
        /// API name: block_num
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("block_num")]
        public uint BlockNum {get; set;}

        /// <summary>
        /// API name: transaction_num
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("transaction_num")]
        public uint TransactionNum {get; set;}
    }
}
