using System;
using Ditch.Steem.Models.Other;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Objects
{
    /// <summary>
    /// api_vesting_delegation_object
    /// libraries\plugins\apis\condenser_api\include\steem\plugins\condenser_api\condenser_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ApiVestingDelegationObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: vesting_delegation_id_type</returns>
        [JsonProperty("id")]
        public object Id {get; set;}

        /// <summary>
        /// API name: delegator
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("delegator")]
        public string Delegator {get; set;}

        /// <summary>
        /// API name: delegatee
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("delegatee")]
        public string Delegatee {get; set;}

        /// <summary>
        /// API name: vesting_shares
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("vesting_shares")]
        public LegacyAsset VestingShares {get; set;}

        /// <summary>
        /// API name: min_delegation_time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("min_delegation_time")]
        public DateTime MinDelegationTime {get; set;}
    }
}
