using System;
using Newtonsoft.Json;
using Ditch.Steem.Models.Enums;

namespace Ditch.Steem.Models.Args
{
    /* Vesting Withdraw Routes */

    /// <summary>
    /// list_withdraw_vesting_routes_args
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ListWithdrawVestingRoutesArgs
    {

        /// <summary>
        /// API name: start
        /// 
        /// </summary>
        /// <returns>API type: variant</returns>
        [JsonProperty("start")]
        public object Start {get; set;}

        /// <summary>
        /// API name: limit
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("limit")]
        public UInt32 Limit {get; set;}

        /// <summary>
        /// API name: order
        /// 
        /// </summary>
        /// <returns>API type: sort_order_type</returns>
        [JsonProperty("order")]
        public SortOrderType Order {get; set;}
    }
}
