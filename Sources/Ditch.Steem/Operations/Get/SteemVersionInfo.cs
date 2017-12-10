using Newtonsoft.Json;

namespace Ditch.Steem.Operations.Get
{
    /// <summary>
    /// steem_version_info
    /// libraries\app\include\steemit\app\api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class SteemVersionInfo
    {

        /// <summary>
        /// API name: blockchain_version
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("blockchain_version")]
        public string BlockchainVersion {get; set;}

        /// <summary>
        /// API name: steem_revision
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("steem_revision")]
        public string SteemRevision {get; set;}

        /// <summary>
        /// API name: fc_revision
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("fc_revision")]
        public string FcRevision {get; set;}
    }
}
