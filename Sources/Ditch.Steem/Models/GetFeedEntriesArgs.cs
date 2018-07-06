using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// get_feed_entries_args
    /// libraries\plugins\apis\follow_api\include\steem\plugins\follow_api\follow_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetFeedEntriesArgs
    {

        /// <summary>
        /// API name: account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("account")]
        public string Account {get; set;}

        /// <summary>
        /// API name: start_entry_id
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("start_entry_id")]
        public uint StartEntryId {get; set;}

        /// <summary>
        /// API name: limit
        /// = 500;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("limit")]
        public uint Limit {get; set;}
    }
}
