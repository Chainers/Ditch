using Newtonsoft.Json;

namespace Ditch.Steem.Objects
{
    /// <summary>
    /// account_bandwidth_api_obj
    /// steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class AccountBandwidthApiObj : AccountBandwidthObject
    {
    }
}