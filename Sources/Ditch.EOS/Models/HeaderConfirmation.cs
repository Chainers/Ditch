using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// header_confirmation
    /// libraries\chain\include\eosio\chain\block_header.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class HeaderConfirmation
    {

        /// <summary>
        /// API name: block_id
        /// 
        /// </summary>
        /// <returns>API type: block_id_type</returns>
        [JsonProperty("block_id")]
        public JObject BlockId { get; set; }

        /// <summary>
        /// API name: producer
        /// 
        /// </summary>
        /// <returns>API type: account_name</returns>
        [JsonProperty("producer")]
        public string Producer { get; set; }

        /// <summary>
        /// API name: producer_signature
        /// 
        /// </summary>
        /// <returns>API type: signature_type</returns>
        [JsonProperty("producer_signature")]
        public JObject ProducerSignature { get; set; }
    }
}