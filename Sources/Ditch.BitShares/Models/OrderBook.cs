using Ditch.Core;
using System;
using System.Collections.Generic;
using Ditch.BitShares.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// order_book
    /// libraries\app\include\graphene\app\database_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class OrderBook
    {

        /// <summary>
        /// API name: base
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("base")]
        public string Base { get; set; }

        /// <summary>
        /// API name: quote
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("quote")]
        public string Quote { get; set; }

        /// <summary>
        /// API name: bids
        /// 
        /// </summary>
        /// <returns>API type: order</returns>
        [JsonProperty("bids")]
        public Order[] Bids { get; set; }

        /// <summary>
        /// API name: asks
        /// 
        /// </summary>
        /// <returns>API type: order</returns>
        [JsonProperty("asks")]
        public Order[] Asks { get; set; }
    }
}
