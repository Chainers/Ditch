using Newtonsoft.Json;

namespace Ditch.Steem.Models.Args
{
    /// <summary>
    /// find_vesting_delegation_expirations_args
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FindVestingDelegationExpirationsArgs
    {

        /// <summary>
        /// API name: account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("account")]
        public string Account {get; set;}
    }
}
