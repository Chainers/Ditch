using Ditch.Steem.Models.Objects;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// list_withdraw_vesting_routes_return
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ListWithdrawVestingRoutesReturn
    {

        /// <summary>
        /// API name: routes
        /// 
        /// </summary>
        /// <returns>API type: api_withdraw_vesting_route_object</returns>
        [JsonProperty("routes")]
        public ApiWithdrawVestingRouteObject[] Routes {get; set;}
    }
}
