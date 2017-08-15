using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ditch.Operations.Enums
{
    /// <summary>
    /// withdraw_route_type
    /// golos-0.16.3\libraries\app\include\steemit\app\database_api.hpp
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WithdrawRouteType
    {
        //[EnumMember(Value = "incoming")]
        Incoming,
        //[EnumMember(Value = "outgoing")]
        Outgoing,
        //[EnumMember(Value = "all")]
        All
    }
}
