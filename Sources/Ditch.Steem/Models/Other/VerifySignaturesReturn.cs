using Newtonsoft.Json;

namespace Ditch.Steem.Models.Other
{
    /// <summary>
    /// verify_signatures_return
    /// libraries\app\include\steemit\app\database_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class VerifySignaturesReturn
    {

        /// <summary>
        /// API name: valid
        /// 
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("valid")]
        public bool Valid {get; set;}
    }
}
