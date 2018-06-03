using Newtonsoft.Json;

namespace Ditch.Steem.Models.Objects
{
       /**
        * @breif a route to send withdrawn vesting shares.
        */

    /// <summary>
    /// withdraw_vesting_route_object
    /// libraries\chain\include\steem\chain\steem_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class WithdrawVestingRouteObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: id_type</returns>
        [JsonProperty("id")]
        public object Id {get; set;}

        /// <summary>
        /// API name: from_account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("from_account")]
        public string FromAccount {get; set;}

        /// <summary>
        /// API name: to_account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("to_account")]
        public string ToAccount {get; set;}

        /// <summary>
        /// API name: percent
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("percent")]
        public ushort Percent {get; set;}

        /// <summary>
        /// API name: auto_vest
        /// = false;
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("auto_vest")]
        public bool AutoVest {get; set;}
    }
}
