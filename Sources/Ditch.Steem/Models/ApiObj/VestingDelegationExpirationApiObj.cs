using Ditch.Steem.Models.Objects;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.ApiObj
{
    /// <summary>
    /// vesting_delegation_expiration_api_obj
    /// libraries\app\include\steemit\app\steem_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class VestingDelegationExpirationApiObj : VestingDelegationExpirationObject
    {
    }
}
