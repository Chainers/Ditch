using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// get_ops_in_block_return
    /// libraries\plugins\apis\account_history_api\include\steem\plugins\account_history_api\account_history_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetOpsInBlockReturn
    {

        /// <summary>
        /// API name: ops
        /// 
        /// </summary>
        /// <returns>API type: multiset</returns>
        [JsonProperty("ops")]
        public ApiOperationObject[] Ops { get; set; }
    }
}
