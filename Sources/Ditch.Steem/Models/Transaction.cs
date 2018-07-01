using System;
using Ditch.Core.Attributes;
using Ditch.Core.Models;
using Ditch.Steem.Operations;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// transaction
    /// libraries\protocol\include\steemit\protocol\transaction.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Transaction
    {
        [MessageOrder(0)]
        public byte[] ChainId { get; set; } = new byte[0]; //64

        /// <summary>
        /// API name: ref_block_num
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [MessageOrder(1)]
        [JsonProperty("ref_block_num")]
        public ushort RefBlockNum { get; set; }

        /// <summary>
        /// API name: ref_block_prefix
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [MessageOrder(2)]
        [JsonProperty("ref_block_prefix")]
        public uint RefBlockPrefix { get; set; }

        /// <summary>
        /// API name: expiration
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [MessageOrder(3)]
        [JsonProperty("expiration")]
        public TimePointSec Expiration { get; set; }

        /// <summary>
        /// API name: operations
        /// 
        /// </summary>
        /// <returns>API type: operation</returns>
        [JsonProperty("operations")]
        [MessageOrder(4)]
        public BaseOperation[] BaseOperations { get; set; }

        /// <summary>
        /// API name: extensions
        /// 
        /// </summary>
        /// <returns>API type: extensions_type</returns>
        [JsonProperty("extensions")]
        [MessageOrder(5)]
        public object[] Extensions { get; set; } = new object[0];
    }
}