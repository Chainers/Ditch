using System;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// signed_transaction
    /// libraries\protocol\include\golos\protocol\transaction.hpp
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
        public string[] Signatures { get; set; }
    }
}