using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// api_withdraw_vesting_route_object
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ApiWithdrawVestingRouteObject : WithdrawVestingRouteObject
    {
    }
}
