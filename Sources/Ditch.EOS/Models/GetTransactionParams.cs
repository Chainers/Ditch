using System;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_transaction_params
    /// plugins\history_plugin\include\eosio\history_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetTransactionParams
    {

        /// <summary>
        /// API name: transaction_id
        /// 
        /// </summary>
        /// <returns>API type: transaction_id_type</returns>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public object Id { get; set; }

        [JsonProperty("block_num_hint", NullValueHandling = NullValueHandling.Ignore)]
        public UInt32? BlockNumHint { get; set; }
    }
}
