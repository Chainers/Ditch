using System;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// market_trade
    /// libraries\app\include\graphene\app\database_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class MarketTrade
    {

        /// <summary>
        /// API name: sequence
        /// = 0;
        /// </summary>
        /// <returns>API type: int64_t</returns>
        [JsonProperty("sequence")]
        public Int64 Sequence { get; set; }

        /// <summary>
        /// API name: date
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// API name: price
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("price")]
        public string Price { get; set; }

        /// <summary>
        /// API name: amount
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// API name: value
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// API name: side1_account_id
        /// = GRAPHENE_NULL_ACCOUNT;
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [JsonProperty("side1_account_id")]
        public object Side1AccountId { get; set; }

        /// <summary>
        /// API name: side2_account_id
        /// = GRAPHENE_NULL_ACCOUNT;
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [JsonProperty("side2_account_id")]
        public object Side2AccountId { get; set; }
    }
}
