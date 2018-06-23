using Newtonsoft.Json;

namespace Ditch.EOS.Models.Results
{
    /// <summary>
    /// push_transaction_results
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class PushTransactionResults
    {

        /// <summary>
        /// API name: transaction_id
        /// 
        /// </summary>
        /// <returns>API type: transaction_id_type</returns>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// API name: processed
        /// 
        /// </summary>
        /// <returns>API type: variant</returns>
        [JsonProperty("processed")]
        public object Processed { get; set; }
    }
}
