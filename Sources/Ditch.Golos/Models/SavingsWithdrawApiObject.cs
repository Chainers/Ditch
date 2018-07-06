using System;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// savings_withdraw_api_object
    /// plugins\database_api\include\golos\plugins\database_api\api_objects\savings_withdraw_api_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SavingsWithdrawApiObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: savings_withdraw_object::id_type</returns>
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
        public UInt32 RequestId {get; set;}

        /// <summary>
        /// API name: amount
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("amount")]
        public Asset Amount {get; set;}

        /// <summary>
        /// API name: complete
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("complete")]
        public TimePointSec Complete {get; set;}
    }
}
