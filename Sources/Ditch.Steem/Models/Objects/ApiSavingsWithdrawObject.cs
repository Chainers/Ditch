using System;
using Ditch.Steem.Models.Other;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Objects
{
    /// <summary>
    /// api_savings_withdraw_object
    /// libraries\plugins\apis\condenser_api\include\steem\plugins\condenser_api\condenser_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ApiSavingsWithdrawObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: savings_withdraw_id_type</returns>
        [JsonProperty("id")]
        public object Id {get; set;}

        /// <summary>
        /// API name: from
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("from")]
        public string From {get; set;}

        /// <summary>
        /// API name: to
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("to")]
        public string To {get; set;}

        /// <summary>
        /// API name: memo
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("memo")]
        public string Memo {get; set;}

        /// <summary>
        /// API name: request_id
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("request_id")]
        public uint RequestId {get; set;}

        /// <summary>
        /// API name: amount
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("amount")]
        public LegacyAsset Amount {get; set;}

        /// <summary>
        /// API name: complete
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("complete")]
        public DateTime Complete {get; set;}
    }
}
