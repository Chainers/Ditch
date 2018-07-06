using System;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// account_resource_limit
    /// libraries\chain\include\eosio\chain\resource_limits.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AccountResourceLimit
    {

        /// <summary>
        /// API name: used
        /// = 0; ///&lt; quantity used in current window
        /// </summary>
        /// <returns>API type: int64_t</returns>
        [JsonProperty("used")]
        public Int64 Used {get; set;}

        /// <summary>
        /// API name: available
        /// = 0; ///&lt; quantity available in current window (based upon fractional reserve)
        /// </summary>
        /// <returns>API type: int64_t</returns>
        [JsonProperty("available")]
        public Int64 Available {get; set;}

        /// <summary>
        /// API name: max
        /// = 0; ///&lt; max per window under current congestion
        /// </summary>
        /// <returns>API type: int64_t</returns>
        [JsonProperty("max")]
        public Int64 Max {get; set;}
    }
}
