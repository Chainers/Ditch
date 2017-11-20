using System;
using Ditch.Golos.Helpers;
using Ditch.Golos.Operations.Post;
using Newtonsoft.Json;

namespace Ditch.Golos.Protocol
{
    /// <summary>
    /// transaction
    /// libraries\protocol\include\golos\protocol\transaction.hpp
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
        public UInt16 RefBlockNum { get; set; }

        /// <summary>
        /// API name: ref_block_prefix
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [MessageOrder(2)]
        [JsonProperty("ref_block_prefix")]
        public UInt32 RefBlockPrefix { get; set; }

        /// <summary>
        /// API name: expiration
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [MessageOrder(3)]
        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }

        /// <summary>
        /// API name: operations
        /// 
        /// </summary>
        /// <returns>API type: operation</returns>
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
