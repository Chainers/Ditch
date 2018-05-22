using Ditch.Core;
using System;
using System.Collections.Generic;
using Ditch.BitShares.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// block_header
    /// libraries\chain\include\graphene\chain\protocol\block.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class BlockHeader
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
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// API name: witness
        /// 
        /// </summary>
        /// <returns>API type: witness_id_type</returns>
        [JsonProperty("witness")]
        public object Witness { get; set; }

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
        /// <returns>API type: extensions_type</returns>
        [JsonProperty("extensions")]
        public object Extensions { get; set; }
    }
}
