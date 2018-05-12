using Newtonsoft.Json;

namespace Ditch.Steem.Models.Objects
{
    /// <summary>
    /// api_account_bandwidth_object
    /// libraries\plugins\apis\witness_api\include\steem\plugins\witness_api\witness_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ApiAccountBandwidthObject : AccountBandwidthObject
    {
    }
}
