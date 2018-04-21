using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// shard_lock
    /// libraries\chain\include\eosio\chain\block.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ShardLock
    {

        /// <summary>
        /// API name: account
        /// 
        /// </summary>
        /// <returns>API type: account_name</returns>
        [JsonProperty("account")]
        public string Account { get; set; }

        /// <summary>
        /// API name: scope
        /// 
        /// </summary>
        /// <returns>API type: scope_name</returns>
        [JsonProperty("scope")]
        public string Scope { get; set; }
    }
}
