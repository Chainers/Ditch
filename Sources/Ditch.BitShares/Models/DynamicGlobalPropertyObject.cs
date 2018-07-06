using System;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     * @class dynamic_global_property_object
     * @brief Maintains global state information (committee_member list, current fees)
     * @ingroup object
     * @ingroup implementation
     *
     * This is an implementation detail. The values here are calculated during normal chain operations and reflect the
     * current values of global blockchain properties.
     */

    /// <summary>
    /// dynamic_global_property_object
    /// libraries\chain\include\graphene\chain\global_property_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class DynamicGlobalPropertyObject : AbstractObject<DynamicGlobalPropertyObject>
    {

        /// <summary>
        /// API name: space_id
        /// = implementation_ids;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("space_id")]
        public byte SpaceId { get; set; }

        /// <summary>
        /// API name: type_id
        /// = impl_dynamic_global_property_object_type;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("type_id")]
        public byte TypeId { get; set; }

        /// <summary>
        /// API name: head_block_number
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("head_block_number")]
        public UInt32 HeadBlockNumber { get; set; }

        /// <summary>
        /// API name: head_block_id
        /// 
        /// </summary>
        /// <returns>API type: block_id_type</returns>
        [JsonProperty("head_block_id")]
        public string HeadBlockId { get; set; }

        /// <summary>
        /// API name: time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("time")]
        public TimePointSec Time { get; set; }

        /// <summary>
        /// API name: current_witness
        /// 
        /// </summary>
        /// <returns>API type: witness_id_type</returns>
        [JsonProperty("current_witness")]
        public object CurrentWitness { get; set; }

        /// <summary>
        /// API name: next_maintenance_time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("next_maintenance_time")]
        public TimePointSec NextMaintenanceTime { get; set; }

        /// <summary>
        /// API name: last_budget_time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("last_budget_time")]
        public TimePointSec LastBudgetTime { get; set; }

        /// <summary>
        /// API name: witness_budget
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("witness_budget")]
        public object WitnessBudget { get; set; }

        /// <summary>
        /// API name: accounts_registered_this_interval
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("accounts_registered_this_interval")]
        public UInt32 AccountsRegisteredThisInterval { get; set; }

        /**
 *  Every time a block is missed this increases by
 *  RECENTLY_MISSED_COUNT_INCREMENT,
 *  every time a block is found it decreases by
 *  RECENTLY_MISSED_COUNT_DECREMENT.  It is
 *  never less than 0.
 *
 *  If the recently_missed_count hits 2*UNDO_HISTORY then no new blocks may be pushed.
 */

        /// <summary>
        /// API name: recently_missed_count
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("recently_missed_count")]
        public UInt32 RecentlyMissedCount { get; set; }


        /**
         * The current absolute slot number.  Equal to the total
         * number of slots since genesis.  Also equal to the total
         * number of missed slots plus head_block_number.
         */

        /// <summary>
        /// API name: current_aslot
        /// = 0;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("current_aslot")]
        public UInt64 CurrentAslot { get; set; }


        /**
         * used to compute witness participation.
         */

        /// <summary>
        /// API name: recent_slots_filled
        /// 
        /// </summary>
        /// <returns>API type: uint128_t</returns>
        [JsonProperty("recent_slots_filled")]
        public string RecentSlotsFilled { get; set; }


        /**
         * dynamic_flags specifies chain state properties that can be
         * expressed in one bit.
         */

        /// <summary>
        /// API name: dynamic_flags
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("dynamic_flags")]
        public UInt32 DynamicFlags { get; set; }

        /// <summary>
        /// API name: last_irreversible_block_num
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("last_irreversible_block_num")]
        public UInt32 LastIrreversibleBlockNum { get; set; }
    }
}
