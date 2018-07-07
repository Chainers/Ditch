using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_actions_params
    /// plugins\history_plugin\include\eosio\history_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetActionsParams
    {
        /// <summary>
        /// API name: account_name
        /// 
        /// </summary>
        /// <returns>API type: account_name</returns>
        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        /// <summary>
        /// API name: pos
        /// a absolute sequence positon -1 is the end/last action
        /// </summary>
        /// <returns>API type: int32_t</returns>
        [JsonProperty("pos", NullValueHandling = NullValueHandling.Ignore)]
        public int Pos { get; set; }

        /// <summary>
        /// API name: offset
        /// the number of actions relative to pos, negative numbers return [pos-offset,pos), positive numbers return [pos,pos+offset)
        /// </summary>
        /// <returns>API type: int32_t</returns>
        [JsonProperty("offset", NullValueHandling = NullValueHandling.Ignore)]
        public int Offset { get; set; }
    }
}