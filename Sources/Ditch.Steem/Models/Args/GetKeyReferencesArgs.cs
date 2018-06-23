using Ditch.Steem.Models.Other;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Args
{
    /// <summary>
    /// get_key_references_args
    /// libraries\plugins\apis\account_by_key_api\include\steem\plugins\account_by_key_api\account_by_key_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetKeyReferencesArgs
    {

        /// <summary>
        /// API name: keys
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [JsonProperty("keys")]
        public PublicKeyType[] Keys {get; set;}
    }
}
