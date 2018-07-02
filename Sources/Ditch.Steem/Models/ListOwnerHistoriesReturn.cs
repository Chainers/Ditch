using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// list_owner_histories_return
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ListOwnerHistoriesReturn
    {

        /// <summary>
        /// API name: owner_auths
        /// 
        /// </summary>
        /// <returns>API type: api_owner_authority_history_object</returns>
        [JsonProperty("owner_auths")]
        public ApiOwnerAuthorityHistoryObject[] OwnerAuths {get; set;}
    }
}
