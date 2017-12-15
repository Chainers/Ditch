using Ditch.Core.Helpers;
using Newtonsoft.Json;

namespace Ditch.Golos.Enums
{
    /// <summary>
    /// withdraw_route_type
    /// golos-0.16.3\libraries\app\include\steemit\app\database_api.hpp
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum WithdrawRouteType
    {
        Incoming,
        Outgoing,
        All
    }
}
