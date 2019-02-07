using Newtonsoft.Json;

namespace Ditch.Ethereum.Models
{
    public class GetTransactionReceiptResult
    {
        [JsonProperty("blockHash")]
        public HexValue BlockHash { get; set; }

        [JsonProperty("blockNumber")]
        public HexULong BlockNumber { get; set; }

        [JsonProperty("contractAddress")]
        public HexAddress ContractAddress { get; set; }

        [JsonProperty("cumulativeGasUsed")]
        public HexULong CumulativeGasUsed { get; set; }

        [JsonProperty("from")]
        public HexAddress From { get; set; }

        [JsonProperty("gasUsed")]
        public HexULong GasUsed { get; set; }

        [JsonProperty("logs")]
        public Log[] Logs { get; set; }

        [JsonProperty("logsBloom")]
        public HexValue LogsBloom { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public HexTransactionStatus Status { get; set; }

        [JsonProperty("root", NullValueHandling = NullValueHandling.Ignore)]
        public HexValue Root { get; set; }

        [JsonProperty("to")]
        public HexAddress To { get; set; }

        [JsonProperty("transactionHash")]
        public HexValue TransactionHash { get; set; }

        [JsonProperty("transactionIndex")]
        public HexULong TransactionIndex { get; set; }
    }

    public class Log
    {
        [JsonProperty("address")]
        public HexAddress Address { get; set; }

        [JsonProperty("blockHash")]
        public HexValue BlockHash { get; set; }

        [JsonProperty("blockNumber")]
        public HexLong BlockNumber { get; set; }

        [JsonProperty("data")]
        public HexValue Data { get; set; }

        [JsonProperty("logIndex")]
        public string LogIndex { get; set; }

        [JsonProperty("removed")]
        public bool Removed { get; set; }

        [JsonProperty("topics")]
        public HexValue[] Topics { get; set; }

        [JsonProperty("transactionHash")]
        public HexValue TransactionHash { get; set; }

        [JsonProperty("transactionIndex")]
        public HexValue TransactionIndex { get; set; }
    }
}