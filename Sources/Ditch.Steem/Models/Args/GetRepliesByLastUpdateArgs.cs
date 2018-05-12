using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Args
{
    /// <summary>
    /// get_replies_by_last_update_args
    /// libraries\plugins\apis\tags_api\include\steem\plugins\tags_api\tags_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GetRepliesByLastUpdateArgs
    {

        /// <summary>
        /// API name: start_parent_author
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("start_parent_author")]
        public string StartParentAuthor {get; set;}

        /// <summary>
        /// API name: start_permlink
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("start_permlink")]
        public string StartPermlink {get; set;}

        /// <summary>
        /// API name: limit
        /// = 100;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("limit")]
        public UInt32 Limit {get; set;}
    }
}
