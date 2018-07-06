using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// get_key_references_return
    /// libraries\plugins\apis\account_by_key_api\include\steem\plugins\account_by_key_api\account_by_key_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetKeyReferencesReturn
    {

        /// <summary>
        /// API name: accounts
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("accounts")]
        public string[][] Accounts {get; set;}
    }
}
