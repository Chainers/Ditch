using Ditch.Steem.Models.Objects;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// get_account_bandwidth_return
    /// libraries\plugins\apis\witness_api\include\steem\plugins\witness_api\witness_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetAccountBandwidthReturn
    {

        /// <summary>
        /// API name: bandwidth
        /// 
        /// </summary>
        /// <returns>API type: api_account_bandwidth_object</returns>
        [JsonProperty("bandwidth", NullValueHandling = NullValueHandling.Ignore)]
        public ApiAccountBandwidthObject Bandwidth {get; set;}
    }
}
