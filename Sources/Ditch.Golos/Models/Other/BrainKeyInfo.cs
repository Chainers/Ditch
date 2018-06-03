using Newtonsoft.Json;

namespace Ditch.Golos.Models.Other
{
    /// <summary>
    /// brain_key_info
    /// libraries\wallet\include\golos\wallet\wallet.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class BrainKeyInfo
    {

        /// <summary>
        /// API name: brain_priv_key
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("brain_priv_key")]
        public string BrainPrivKey { get; set; }

        /// <summary>
        /// API name: pub_key
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [JsonProperty("pub_key")]
        public PublicKeyType PubKey { get; set; }

        /// <summary>
        /// API name: wif_priv_key
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("wif_priv_key")]
        public string WifPrivKey { get; set; }
    }
}
