using Ditch.Steem.Models.Other;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Args
{
    /// <summary>
    /// verify_account_authority_args
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class VerifyAccountAuthorityArgs
    {

        /// <summary>
        /// API name: account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("account")]
        public string Account {get; set;}

        /// <summary>
        /// API name: signers
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("signers")]
        public PublicKeyType[] Signers {get; set;}
    }
}
