using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Args
{
    /// <summary>
    /// get_account_history_args
    /// libraries\plugins\apis\account_history_api\include\steem\plugins\account_history_api\account_history_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GetAccountHistoryArgs
    {

        /// <summary>
        /// API name: account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("account")]
        public string Account { get; set; }

        /// <summary>
        /// API name: start
        /// = -1;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("start")]
        public UInt64 Start { get; set; }

        /// <summary>
        /// API name: limit
        /// = 1000;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("limit")]
        public UInt32 Limit { get; set; }
    }
}
