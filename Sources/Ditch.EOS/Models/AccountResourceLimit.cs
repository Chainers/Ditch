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
        public long Used {get; set;}

        /// <summary>
        /// API name: available
        /// = 0; ///&lt; quantity available in current window (based upon fractional reserve)
        /// </summary>
        /// <returns>API type: int64_t</returns>
        [JsonProperty("available")]
        public long Available {get; set;}

        /// <summary>
        /// API name: max
        /// = 0; ///&lt; max per window under current congestion
        /// </summary>
        /// <returns>API type: int64_t</returns>
        [JsonProperty("max")]
        public long Max {get; set;}
    }
}
