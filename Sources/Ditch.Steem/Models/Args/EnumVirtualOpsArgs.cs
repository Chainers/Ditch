using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Args
{
    /** Allows to specify range of blocks to retrieve virtual operations for.
     *  \param block_range_begin - starting block number (inclusive) to search for virtual operations
     *  \param block_range_end   - last block number (exclusive) to search for virtual operations
     */

    /// <summary>
    /// enum_virtual_ops_args
    /// libraries\plugins\apis\account_history_api\include\steem\plugins\account_history_api\account_history_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class EnumVirtualOpsArgs
    {

        /// <summary>
        /// API name: block_range_begin
        /// = 1;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("block_range_begin")]
        public UInt32 BlockRangeBegin { get; set; }

        /// <summary>
        /// API name: block_range_end
        /// = 2;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("block_range_end")]
        public UInt32 BlockRangeEnd { get; set; }
    }
}
