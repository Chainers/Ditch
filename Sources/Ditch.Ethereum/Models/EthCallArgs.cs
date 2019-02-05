using Newtonsoft.Json;

namespace Ditch.Ethereum.Models
{
    public class EthCallArgs
    {
        /// <summary>
        /// [optional] 20 Bytes - The address the transaction is sent from.
        /// </summary>
        [JsonProperty("from", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public HexAddress From { get; set; }

        /// <summary>
        /// 20 Bytes - The address the transaction is directed to.
        /// </summary>
        [JsonProperty("to")]
        public HexAddress To { get; set; }

        /// <summary>
        /// [optional] Integer of the gas provided for the transaction execution.eth_call consumes zero gas, but this parameter may be needed by some executions.
        /// </summary>
        [JsonProperty("gas", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public HexValue Gas { get; set; }

        /// <summary>
        /// [optional] Integer of the gasPrice used for each paid gas
        /// </summary>
        [JsonProperty("gasPrice", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public HexValue GasPrice { get; set; }

        /// <summary>
        /// [optional] Integer of the value sent with this transaction
        /// </summary>
        [JsonProperty("value", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public HexValue Value { get; set; }

        /// <summary>
        /// [optional] Hash of the method signature and encoded parameters.For details see Ethereum Contract ABI
        /// </summary>
        [JsonProperty("data", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public HexValue Data { get; set; }
    }
}