using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    [JsonConverter(typeof(EnumConverter))]
    public enum WithdrawRouteType
    {
        Incoming,
        Outgoing,
        All
    }
}
