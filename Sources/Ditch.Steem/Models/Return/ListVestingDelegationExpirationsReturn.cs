using Ditch.Steem.Models.Objects;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// list_vesting_delegation_expirations_return
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ListVestingDelegationExpirationsReturn
    {

        /// <summary>
        /// API name: delegations
        /// 
        /// </summary>
        /// <returns>API type: api_vesting_delegation_expiration_object</returns>
        [JsonProperty("delegations")]
        public ApiVestingDelegationExpirationObject[] Delegations {get; set;}
    }
}
