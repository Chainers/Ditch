using Newtonsoft.Json;

namespace Ditch.Ethereum.Models
{
    public class GetBlockResult
    {
        //Difficulty  *big.Int       `json:"difficulty"       gencodec:"required"`
        [JsonProperty("difficulty")]
        public HexBigInt Difficulty { get; set; }

        //Extra       []byte         `json:"extraData"        gencodec:"required"`
        [JsonProperty("extraData")]
        public HexValue Extra { get; set; }

        //GasLimit    uint64         `json:"gasLimit"         gencodec:"required"`
        [JsonProperty("gasLimit")]
        public HexULong GasLimit { get; set; }

        //GasUsed     uint64         `json:"gasUsed"          gencodec:"required"`
        [JsonProperty("gasUsed")]
        public HexULong GasUsed { get; set; }

        [JsonProperty("hash")]
        public HexValue Hash { get; set; }

        //Bloom       Bloom          `json:"logsBloom"        gencodec:"required"`
        [JsonProperty("logsBloom")]
        public HexValue Bloom { get; set; }

        //Coinbase    common.Address `json:"miner"            gencodec:"required"`
        [JsonProperty("miner")]
        public HexValue Coinbase { get; set; }

        //MixDigest   common.Hash    `json:"mixHash"`
        [JsonProperty("mixHash")]
        public HexValue MixDigest { get; set; }

        //Nonce       BlockNonce     `json:"nonce"`
        [JsonProperty("nonce")]
        public HexValue Nonce { get; set; }

        //Number      *big.Int       `json:"number"           gencodec:"required"`
        [JsonProperty("number")]
        public HexLong Number { get; set; }

        //ParentHash  common.Hash    `json:"parentHash"       gencodec:"required"`
        [JsonProperty("parentHash")]
        public HexValue ParentHash { get; set; }

        //ReceiptHash common.Hash    `json:"receiptsRoot"     gencodec:"required"`
        [JsonProperty("receiptsRoot")]
        public HexValue ReceiptHash { get; set; }


        //UncleHash   common.Hash    `json:"sha3Uncles"       gencodec:"required"`
        [JsonProperty("sha3Uncles")]
        public HexValue UncleHash { get; set; }

        [JsonProperty("size")]
        public HexLong Size { get; set; }

        //Root        common.Hash    `json:"stateRoot"        gencodec:"required"`
        [JsonProperty("stateRoot")]
        public HexValue Root { get; set; }

        //Time        *big.Int       `json:"timestamp"        gencodec:"required"`
        [JsonProperty("timestamp")]
        public HexTimeStamp Timestamp { get; set; }

        [JsonProperty("totalDifficulty")]
        public HexLong TotalDifficulty { get; set; }

        [JsonProperty("transactions")]
        public Transaction[] Transactions { get; set; }

        //TxHash      common.Hash    `json:"transactionsRoot" gencodec:"required"`
        [JsonProperty("transactionsRoot")]
        public HexValue TxHash { get; set; }

        [JsonProperty("uncles")]
        public HexValue[] Uncles { get; set; }
    }
}
