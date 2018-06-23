using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// withdraw_route_type
    /// plugins\database_api\include\golos\plugins\database_api\plugin.hpp
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum WithdrawRouteType
    {

        /// <summary>
        /// API name: incoming
        /// all
        /// </summary>
        Incoming,
    }
}
