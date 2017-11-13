using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ditch.Steem.Operations.Enums
{
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
