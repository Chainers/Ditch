using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// get_account_history_return
    /// libraries\plugins\apis\account_history_api\include\steem\plugins\account_history_api\account_history_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetAccountHistoryReturn
    {

        /// <summary>
        /// API name: history
        /// 
        /// </summary>
        /// <returns>API type: map&lt;uint32_t,api_operation_object></returns>
        [JsonProperty("history")]
        public object History {get; set;}
    }
}
