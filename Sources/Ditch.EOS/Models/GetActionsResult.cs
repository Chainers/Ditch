using System;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_actions_result
    /// plugins\history_plugin\include\eosio\history_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetActionsResult
    {

        /// <summary>
        /// API name: actions
        /// 
        /// </summary>
        /// <returns>API type: ordered_action_result</returns>
        [JsonProperty("actions")]
        public OrderedActionResult[] Actions { get; set; }

        /// <summary>
        /// API name: last_irreversible_block
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("last_irreversible_block")]
        public UInt32 LastIrreversibleBlock { get; set; }

        /// <summary>
        /// API name: time_limit_exceeded_error
        /// 
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("time_limit_exceeded_error", NullValueHandling = NullValueHandling.Ignore)]
        public bool TimeLimitExceededError { get; set; }
    }
}
