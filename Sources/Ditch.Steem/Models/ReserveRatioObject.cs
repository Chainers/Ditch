using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// reserve_ratio_object
    /// libraries\plugins\witness\include\steem\plugins\witness\witness_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ReserveRatioObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: id_type</returns>
        [JsonProperty("id")]
        public object Id { get; set; }


        /**
         *  Average block size is updated every block to be:
         *
         *     average_block_size = (99 * average_block_size + new_block_size) / 100
         *
         *  This property is used to update the current_reserve_ratio to maintain approximately
         *  50% or less utilization of network capacity.
         */

        /// <summary>
        /// API name: average_block_size
        /// = 0;
        /// </summary>
        /// <returns>API type: int32_t</returns>
        [JsonProperty("average_block_size")]
        public int AverageBlockSize { get; set; }


        /**
         *   Any time average_block_size <= 50% maximum_block_size this value grows by 1 until it
         *   reaches STEEM_MAX_RESERVE_RATIO.  Any time average_block_size is greater than
         *   50% it falls by 1%.  Upward adjustments happen once per round, downward adjustments
         *   happen every block.
         */

        /// <summary>
        /// API name: current_reserve_ratio
        /// = 1;
        /// </summary>
        /// <returns>API type: int64_t</returns>
        [JsonProperty("current_reserve_ratio")]
        public long CurrentReserveRatio { get; set; }


        /**
         * The maximum bandwidth the blockchain can support is:
         *
         *    max_bandwidth = maximum_block_size * STEEM_BANDWIDTH_AVERAGE_WINDOW_SECONDS / STEEM_BLOCK_INTERVAL
         *
         * The maximum virtual bandwidth is:
         *
         *    max_bandwidth * current_reserve_ratio
         */

        /// <summary>
        /// API name: max_virtual_bandwidth
        /// = 0;
        /// </summary>
        /// <returns>API type: uint128_t</returns>
        [JsonProperty("max_virtual_bandwidth")]
        public UInt128 MaxVirtualBandwidth { get; set; }
    }
}
