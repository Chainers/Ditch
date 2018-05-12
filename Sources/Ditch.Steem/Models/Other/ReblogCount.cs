using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Other
{
    /// <summary>
    /// reblog_count
    /// libraries\plugins\apis\follow_api\include\steem\plugins\follow_api\follow_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ReblogCount
    {

        /// <summary>
        /// API name: author
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("author")]
        public string Author {get; set;}

        /// <summary>
        /// API name: count
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("count")]
        public UInt32 Count {get; set;}
    }
}
