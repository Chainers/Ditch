using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Objects
{
    /// <summary>
    /// change_recovery_account_request_object
    /// libraries\chain\include\steem\chain\account_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ChangeRecoveryAccountRequestObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: id_type</returns>
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
        /// API name: recovery_account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("recovery_account")]
        public string RecoveryAccount {get; set;}

        /// <summary>
        /// API name: effective_on
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("effective_on")]
        public DateTime EffectiveOn {get; set;}
    }
}
