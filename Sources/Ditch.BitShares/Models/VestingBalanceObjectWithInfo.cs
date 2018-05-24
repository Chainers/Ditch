using System;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// vesting_balance_object_with_info
    /// libraries\wallet\include\graphene\wallet\wallet.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class VestingBalanceObjectWithInfo : VestingBalanceObject
    {


        /**
         * How much is allowed to be withdrawn.
         */

        /// <summary>
        /// API name: allowed_withdraw
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("allowed_withdraw")]
        public object AllowedWithdraw { get; set; }


        /**
         * The time at which allowed_withdrawal was calculated.
         */

        /// <summary>
        /// API name: allowed_withdraw_time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("allowed_withdraw_time")]
        public DateTime AllowedWithdrawTime { get; set; }
    }
}
