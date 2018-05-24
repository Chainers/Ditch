using System;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     * @brief Linear vesting balance with cliff
     *
     * This vesting balance type is used to mimic traditional stock vesting contracts where
     * each day a certain amount vests until it is fully matured.
     *
     * @note New funds may not be added to a linear vesting balance.
     */

    /// <summary>
    /// linear_vesting_policy
    /// libraries\chain\include\graphene\chain\vesting_balance_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class LinearVestingPolicy
    {

        /// This is the time at which funds begin vesting.

        /// <summary>
        /// API name: begin_timestamp
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("begin_timestamp")]
        public DateTime BeginTimestamp { get; set; }

        /// No amount may be withdrawn before this many seconds of the vesting period have elapsed.

        /// <summary>
        /// API name: vesting_cliff_seconds
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("vesting_cliff_seconds")]
        public UInt32 VestingCliffSeconds { get; set; }

        /// Duration of the vesting period, in seconds. Must be greater than 0 and greater than vesting_cliff_seconds.

        /// <summary>
        /// API name: vesting_duration_seconds
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("vesting_duration_seconds")]
        public UInt32 VestingDurationSeconds { get; set; }

        /// The total amount of asset to vest.

        /// <summary>
        /// API name: begin_balance
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("begin_balance")]
        public object BeginBalance { get; set; }
    }
}
