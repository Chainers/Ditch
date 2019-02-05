using Newtonsoft.Json;

namespace Ditch.Ethereum.Models
{
    public class Transaction
    {
        [JsonProperty("blockHash")]
        public HexValue BlockHash { get; set; }

        [JsonProperty("blockNumber")]
        public HexLong BlockNumber { get; set; }

        [JsonProperty("from")]
        public HexAddress From { get; set; }

        //GasLimit     uint64          `json:"gas"      gencodec:"required"`
        [JsonProperty("gas")]
        public HexULong Gas { get; set; }

        //Price        *big.Int        `json:"gasPrice" gencodec:"required"`
        [JsonProperty("gasPrice")]
        public HexBigInt GasPrice { get; set; }

        //Hash* common.Hash `json:"hash" rlp:"-"`
        [JsonProperty("hash")]
        public HexValue Hash { get; set; }

        //Payload[] byte          `json:"input"    gencodec:"required"`
        [JsonProperty("input")]
        public HexValue Input { get; set; }

        //AccountNonce uint64          `json:"nonce"    gencodec:"required"`
        [JsonProperty("nonce")]
        public HexULong Nonce { get; set; }

        // R* big.Int `json:"r" gencodec:"required"`
        [JsonProperty("r")]
        public HexBigInt R { get; set; }

        //S* big.Int `json:"s" gencodec:"required"`
        [JsonProperty("s")]
        public HexBigInt S { get; set; }

        //Recipient    *common.Address `json:"to"       rlp:"nil"` // nil means contract creation
        [JsonProperty("to")]
        public HexAddress To { get; set; }

        [JsonProperty("transactionIndex")]
        public HexULong TransactionIndex { get; set; }

        //V* big.Int `json:"v" gencodec:"required"`
        [JsonProperty("v")]
        public HexBigInt V { get; set; }

        // Amount       *big.Int        `json:"value"    gencodec:"required"`
        [JsonProperty("value")]
        public HexDecimal Value { get; set; }

    }
}
