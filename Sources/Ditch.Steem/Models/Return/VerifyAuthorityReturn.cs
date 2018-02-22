using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// verify_authority_return
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class VerifyAuthorityReturn
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
