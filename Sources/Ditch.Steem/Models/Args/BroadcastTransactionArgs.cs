using System;
using Ditch.Steem.Models.Other;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Args
{
    /// <summary>
    /// broadcast_transaction_args
    /// libraries\plugins\apis\network_broadcast_api\include\steem\plugins\network_broadcast_api\network_broadcast_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class BroadcastTransactionArgs
    {

        /// <summary>
        /// API name: trx
        /// 
        /// </summary>
        /// <returns>API type: signed_transaction</returns>
        [JsonProperty("trx")]
        public SignedTransaction Trx { get; set; }

        /// <summary>
        /// API name: max_block_age
        /// = -1;
        /// </summary>
        /// <returns>API type: int32_t</returns>
        [JsonProperty("max_block_age")]
        public Int32 MaxBlockAge { get; set; } = -1;
    }
}
