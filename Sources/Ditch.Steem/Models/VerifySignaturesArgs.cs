using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// verify_signatures_args
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class VerifySignaturesArgs
    {

        /// <summary>
        /// API name: hash
        /// 
        /// </summary>
        /// <returns>API type: sha256</returns>
        [JsonProperty("hash")]
        public object Hash {get; set;}

        /// <summary>
        /// API name: signatures
        /// 
        /// </summary>
        /// <returns>API type: signature_type</returns>
        [JsonProperty("signatures")]
        public string[] Signatures {get; set;}

        /// <summary>
        /// API name: required_owner
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("required_owner")]
        public string[] RequiredOwner {get; set;}

        /// <summary>
        /// API name: required_active
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("required_active")]
        public string[] RequiredActive {get; set;}

        /// <summary>
        /// API name: required_posting
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("required_posting")]
        public string[] RequiredPosting {get; set;}

        /// <summary>
        /// API name: required_other
        /// 
        /// </summary>
        /// <returns>API type: authority</returns>
        [JsonProperty("required_other")]
        public Authority[] RequiredOther {get; set;}
    }
}
