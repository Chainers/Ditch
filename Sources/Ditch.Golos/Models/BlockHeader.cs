using System;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// block_header
    /// libraries\protocol\include\golos\protocol\block_header.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class BlockHeader
    {

        /// <summary>
        /// API name: previous
        /// 
        /// </summary>
        /// <returns>API type: block_id_type</returns>
        [JsonProperty("previous")]
        public object Previous { get; set; }

        /// <summary>
        /// API name: timestamp
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("timestamp")]
        public TimePointSec Timestamp { get; set; }

        /// <summary>
        /// API name: witness
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("witness")]
        public string Witness { get; set; }

        /// <summary>
        /// API name: transaction_merkle_root
        /// 
        /// </summary>
        /// <returns>API type: checksum_type</returns>
        [JsonProperty("transaction_merkle_root")]
        public object TransactionMerkleRoot { get; set; }

        /// <summary>
        /// API name: extensions
        /// 
        /// </summary>
        /// <returns>API type: block_header_extensions_type</returns>
        [JsonProperty("extensions")]
        public object Extensions { get; set; }
    }
}
