using System;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// block_header
    /// steem-0.19.1\libraries\protocol\include\steemit\protocol\block_header.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class BlockHeader
    {

        // bdType : block_id_type
        [JsonProperty("previous")]
        public object Previous { get; set; }

        // bdType : time_point_sec
        [JsonProperty("timestamp")]
        public TimePointSec Timestamp { get; set; }

        // bdType : string
        [JsonProperty("witness")]
        public string Witness { get; set; }

        // bdType : checksum_type
        [JsonProperty("transaction_merkle_root")]
        public object TransactionMerkleRoot { get; set; }

        // bdType : block_header_extensions_type
        [JsonProperty("extensions")]
        public object Extensions { get; set; }
    }
}
