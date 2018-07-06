using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// get_account_bandwidth_args
    /// libraries\plugins\apis\witness_api\include\steem\plugins\witness_api\witness_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetAccountBandwidthArgs
    {

        /// <summary>
        /// API name: account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("account")]
        public string Account {get; set;}

        /// <summary>
        /// API name: type
        /// 
        /// </summary>
        /// <returns>API type: bandwidth_type</returns>
        [JsonProperty("type")]
        public BandwidthType Type {get; set;}
    }
}
