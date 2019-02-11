using Newtonsoft.Json;

namespace Ditch.Ethereum.Models
{
    public class GetLogsArgs
    {
        /// <summary>
        /// [optional] - a string representing the address (20 bytes) to check for balance
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public HexAddress Address { get; set; }

        /// <summary>
        /// [optional, default is "earliest"] - an integer block number, or the string "latest", "earliest" or "pending"
        /// </summary>
        [JsonProperty("fromBlock", NullValueHandling = NullValueHandling.Ignore)]
        public HexULong FromBlock { get; set; }

        /// <summary>
        /// [optional, default is "latest"] - an integer block number, or the string "latest", "earliest" or "pending"
        /// </summary>
        [JsonProperty("toBlock", NullValueHandling = NullValueHandling.Ignore)]
        public HexULong ToBlock { get; set; }

        /// <summary>
        /// [optional] - Array of 32 Bytes DATA topics.Topics are order-dependent.
        /// </summary>
        [JsonProperty("topics", NullValueHandling = NullValueHandling.Ignore)]
        public HexULong Topics { get; set; }

        /// <summary>
        /// [optional] With the addition of EIP-234, blockHash restricts the logs returned to the single block with the 32-byte hash blockHash.
        /// Using blockHash is equivalent to fromBlock = toBlock = the block number with hash blockHash.
        /// If blockHash is present in in the filter criteria, then neither fromBlock nor toBlock are allowed.
        /// </summary>
        [JsonProperty("blockhash", NullValueHandling = NullValueHandling.Ignore)]
        public HexULong Blockhash { get; set; }
    }
}