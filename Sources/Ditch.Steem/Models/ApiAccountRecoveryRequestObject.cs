using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// api_account_recovery_request_object
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ApiAccountRecoveryRequestObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: account_recovery_request_id_type</returns>
        [JsonProperty("id")]
        public object Id {get; set;}

        /// <summary>
        /// API name: account_to_recover
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("account_to_recover")]
        public string AccountToRecover {get; set;}

        /// <summary>
        /// API name: new_owner_authority
        /// 
        /// </summary>
        /// <returns>API type: authority</returns>
        [JsonProperty("new_owner_authority")]
        public Authority NewOwnerAuthority {get; set;}

        /// <summary>
        /// API name: expires
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("expires")]
        public TimePointSec Expires {get; set;}
    }
}
