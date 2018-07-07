using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     * @class withdraw_permission_object
     * @brief Grants another account authority to withdraw a limited amount of funds per interval
     *
     * The primary purpose of this object is to enable recurring payments on the blockchain. An account which wishes to
     * process a recurring payment may use a @ref withdraw_permission_claim_operation to reference an object of this type
     * and withdraw up to @ref withdrawal_limit from @ref withdraw_from_account. Only @ref authorized_account may do
     * this. Any number of withdrawals may be made so long as the total amount withdrawn per period does not exceed the
     * limit for any given period.
     */

    /// <summary>
    /// withdraw_permission_object
    /// libraries\chain\include\graphene\chain\withdraw_permission_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class WithdrawPermissionObject
    {

        /// <summary>
        /// API name: space_id
        /// = protocol_ids;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("space_id")]
        public byte SpaceId { get; set; }

        /// <summary>
        /// API name: type_id
        /// = withdraw_permission_object_type;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("type_id")]
        public byte TypeId { get; set; }


        /// The account authorizing @ref authorized_account to withdraw from it

        /// <summary>
        /// API name: withdraw_from_account
        /// 
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [JsonProperty("withdraw_from_account")]
        public AccountIdType WithdrawFromAccount { get; set; }

        /// The account authorized to make withdrawals from @ref withdraw_from_account

        /// <summary>
        /// API name: authorized_account
        /// 
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [JsonProperty("authorized_account")]
        public AccountIdType AuthorizedAccount { get; set; }

        /// The maximum amount which may be withdrawn per period. All withdrawals must be of this asset type

        /// <summary>
        /// API name: withdrawal_limit
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("withdrawal_limit")]
        public object WithdrawalLimit { get; set; }

        /// The duration of a withdrawal period in seconds

        /// <summary>
        /// API name: withdrawal_period_sec
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("withdrawal_period_sec")]
        public uint WithdrawalPeriodSec { get; set; }

        /***
 * The beginning of the next withdrawal period
 * WARNING: Due to caching, this value does not always represent the start of the next or current period (because it is only updated after a withdrawal operation such as claim).  For the latest current period, use current_period().
 */

        /// <summary>
        /// API name: period_start_time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("period_start_time")]
        public TimePointSec PeriodStartTime { get; set; }

        /// The time at which this withdraw permission expires

        /// <summary>
        /// API name: expiration
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("expiration")]
        public TimePointSec Expiration { get; set; }


        /***
         * Tracks the total amount
         * WARNING: Due to caching, this value does not always represent the total amount claimed during the current period; it may represent what was claimed during the last claimed period (because it is only updated after a withdrawal operation such as claim).  For the latest current period, use current_period().
         */

        /// <summary>
        /// API name: claimed_this_period
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("claimed_this_period")]
        public object ClaimedThisPeriod { get; set; }
    }
}
