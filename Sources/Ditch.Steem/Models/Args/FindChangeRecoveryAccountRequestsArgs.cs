using Newtonsoft.Json;

namespace Ditch.Steem.Models.Args
{
    /// <summary>
    /// find_change_recovery_account_requests_args
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class FindChangeRecoveryAccountRequestsArgs
    {

        /// <summary>
        /// API name: accounts
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("accounts")]
        public string[] Accounts {get; set;}
    }
}
