using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// producer_key
    /// contracts\eosiolib\privileged.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ProducerKey
    {

        /// <summary>
        /// API name: producer_name
        /// 
        /// </summary>
        /// <returns>API type: account_name</returns>
        [JsonProperty("producer_name")]
        public string ProducerName {get; set;}

        /// <summary>
        /// API name: block_signing_key
        /// 
        /// </summary>
        /// <returns>API type: public_key</returns>
        [JsonProperty("block_signing_key")]
        public PublicKey BlockSigningKey {get; set;}
    }
}
