using System;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// memo_data
    /// libraries\chain\include\graphene\chain\protocol\confidential.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class MemoData
    {

        /// <summary>
        /// API name: from
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
        public PublicKeyType From { get; set; }

        /// <summary>
        /// API name: amount
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("amount")]
        public object Amount { get; set; }

        /// <summary>
        /// API name: blinding_factor
        /// 
        /// </summary>
        /// <returns>API type: sha256</returns>
        [JsonProperty("blinding_factor")]
        public object BlindingFactor { get; set; }

        /// <summary>
        /// API name: commitment
        /// 
        /// </summary>
        /// <returns>API type: commitment_type</returns>
        [JsonProperty("commitment")]
        public char Commitment { get; set; }

        /// <summary>
        /// API name: check
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("check")]
        public UInt32 Check { get; set; }
    }
}
