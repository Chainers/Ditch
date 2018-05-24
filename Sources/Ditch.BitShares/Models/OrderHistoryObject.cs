using Ditch.Core;
using System;
using System.Collections.Generic;
using Ditch.BitShares.Models;
using Ditch.BitShares.Models.Operations;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// order_history_object
    /// libraries\plugins\market_history\include\graphene\market_history\market_history_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class OrderHistoryObject : AbstractObject<OrderHistoryObject>
    {

        /// <summary>
        /// API name: space_id
        /// = MARKET_HISTORY_SPACE_ID;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("space_id")]
        public byte SpaceId { get; set; }

        /// <summary>
        /// API name: type_id
        /// = order_history_object_type;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("type_id")]
        public byte TypeId { get; set; }

        /// <summary>
        /// API name: key
        /// 
        /// </summary>
        /// <returns>API type: history_key</returns>
        [JsonProperty("key")]
        public HistoryKey Key { get; set; }

        /// <summary>
        /// API name: time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("time")]
        public DateTime Time { get; set; }

        /// <summary>
        /// API name: op
        /// 
        /// </summary>
        /// <returns>API type: fill_order_operation</returns>
        [JsonProperty("op")]
        public FillOrderOperation Op { get; set; }
    }
}
