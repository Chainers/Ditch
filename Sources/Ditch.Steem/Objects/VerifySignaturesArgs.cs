using Ditch.Steem.Enums;
using Newtonsoft.Json;

namespace Ditch.Steem.Objects
{
    /// <summary>
    /// verify_signatures_args
    /// libraries\app\include\steemit\app\database_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class VerifySignaturesArgs
    {

        /// <summary>
        /// API name: hash
        /// 
        /// </summary>
        /// <returns>API type: sha256</returns>
        [JsonProperty("hash")]
        public object Hash { get; set; }

        /// <summary>
        /// API name: signatures
        /// 
        /// </summary>
        /// <returns>API type: signature_type</returns>
        [JsonProperty("signatures")]
        public object[] Signatures { get; set; }

        /// <summary>
        /// API name: accounts
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("accounts")]
        public string[] Accounts { get; set; }

        /// <summary>
        /// API name: auth_level
        /// 
        /// </summary>
        /// <returns>API type: classification</returns>
        [JsonProperty("auth_level")]
        public Classification AuthLevel { get; set; }
    }
}
