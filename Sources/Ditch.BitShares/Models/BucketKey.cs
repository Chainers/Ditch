using Ditch.Core;
using System;
using System.Collections.Generic;
using Ditch.BitShares.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// bucket_key
    /// libraries\plugins\market_history\include\graphene\market_history\market_history_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class BucketKey
    {

        /// <summary>
        /// API name: base
        /// 
        /// </summary>
        /// <returns>API type: asset_id_type</returns>
        [JsonProperty("base")]
        public object Base { get; set; }

        /// <summary>
        /// API name: quote
        /// 
        /// </summary>
        /// <returns>API type: asset_id_type</returns>
        [JsonProperty("quote")]
        public object Quote { get; set; }

        /// <summary>
        /// API name: seconds
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("seconds")]
        public UInt32 Seconds { get; set; }

        /// <summary>
        /// API name: open
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("open")]
        public DateTime Open { get; set; }
    }
}
