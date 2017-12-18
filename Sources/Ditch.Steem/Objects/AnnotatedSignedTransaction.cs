using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Objects
{
    /// <summary>
    /// annotated_signed_transaction
    /// libraries\protocol\include\steemit\protocol\transaction.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class AnnotatedSignedTransaction : SignedTransaction
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
        public UInt32 BlockNum {get; set;}

        /// <summary>
        /// API name: transaction_num
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("transaction_num")]
        public UInt32 TransactionNum {get; set;}
    }
}
