using System;
using Ditch.Golos.Models.Other;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.ApiObject
{
    /// <summary>
    /// account_recovery_request_api_object
    /// plugins\database_api\include\golos\plugins\database_api\api_objects\account_recovery_request_api_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class AccountRecoveryRequestApiObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: account_recovery_request_object::id_type</returns>
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
        public DateTime Expires {get; set;}
    }
}
