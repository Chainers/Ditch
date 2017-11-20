using Ditch.Core.Helpers;
using Newtonsoft.Json;

namespace Ditch.Steem.Operations.Enums
{
    [JsonConverter(typeof(EnumConverter))]
    public enum FollowType
    {
        Undefined,
        Blog,
        Ignore
    };
}