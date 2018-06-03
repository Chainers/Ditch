using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// broadcast_transaction_synchronous_return
    /// libraries\plugins\apis\network_broadcast_api\include\steem\plugins\network_broadcast_api\network_broadcast_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class BroadcastTransactionSynchronousReturn
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: transaction_id_type</returns>
        [JsonProperty("id")]
        public string Id {get; set;}

        /// <summary>
        /// API name: block_num
        /// = 0;
        /// </summary>
        /// <returns>API type: int32_t</returns>
        [JsonProperty("block_num")]
        public int BlockNum {get; set;}

        /// <summary>
        /// API name: trx_num
        /// = 0;
        /// </summary>
        /// <returns>API type: int32_t</returns>
        [JsonProperty("trx_num")]
        public int TrxNum {get; set;}

        /// <summary>
        /// API name: expired
        /// = false;
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("expired")]
        public bool Expired {get; set;}
    }
}
