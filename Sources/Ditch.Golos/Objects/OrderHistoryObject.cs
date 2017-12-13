using System;
using Newtonsoft.Json;

namespace Ditch.Golos.Objects
{
    /// <summary>
    /// order_history_object
    /// libraries\plugins\market_history\include\golos\market_history\order_history_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class OrderHistoryObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: id_type</returns>
        [JsonProperty("id")]
        public object Id {get; set;}

        /// <summary>
        /// API name: key
        /// 
        /// </summary>
        /// <returns>API type: history_key</returns>
        [JsonProperty("key")]
        public HistoryKey Key {get; set;}

        /// <summary>
        /// API name: time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("time")]
        public DateTime Time {get; set;}

        /// <summary>
        /// API name: op
        /// 
        /// </summary>
        /// <returns>API type: market_virtual_operations</returns>
        [JsonProperty("op")]
        public object Op {get; set;}
    }
}
