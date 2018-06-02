using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Args
{
    /// <summary>
    /// get_ops_in_block_args
    /// libraries\plugins\apis\account_history_api\include\steem\plugins\account_history_api\account_history_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GetOpsInBlockArgs
    {

        /// <summary>
        /// API name: block_num
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("block_num")]
        public UInt32 BlockNum { get; set; }

        /// <summary>
        /// API name: only_virtual
        /// 
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("only_virtual")]
        public bool OnlyVirtual { get; set; }
    }
}
