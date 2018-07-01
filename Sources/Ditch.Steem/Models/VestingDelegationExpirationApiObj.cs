using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// vesting_delegation_expiration_api_obj
    /// libraries\app\include\steemit\app\steem_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class VestingDelegationExpirationApiObj : VestingDelegationExpirationObject
    {
    }
}
