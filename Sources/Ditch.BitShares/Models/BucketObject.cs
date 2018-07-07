using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// bucket_object
    /// libraries\plugins\market_history\include\graphene\market_history\market_history_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class BucketObject
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
        /// = bucket_object_type;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("type_id")]
        public byte TypeId { get; set; }

        /// <summary>
        /// API name: key
        /// 
        /// </summary>
        /// <returns>API type: bucket_key</returns>
        [JsonProperty("key")]
        public BucketKey Key { get; set; }

        /// <summary>
        /// API name: high_base
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("high_base")]
        public object HighBase { get; set; }

        /// <summary>
        /// API name: high_quote
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("high_quote")]
        public object HighQuote { get; set; }

        /// <summary>
        /// API name: low_base
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("low_base")]
        public object LowBase { get; set; }

        /// <summary>
        /// API name: low_quote
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("low_quote")]
        public object LowQuote { get; set; }

        /// <summary>
        /// API name: open_base
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("open_base")]
        public object OpenBase { get; set; }

        /// <summary>
        /// API name: open_quote
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("open_quote")]
        public object OpenQuote { get; set; }

        /// <summary>
        /// API name: close_base
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("close_base")]
        public object CloseBase { get; set; }

        /// <summary>
        /// API name: close_quote
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("close_quote")]
        public object CloseQuote { get; set; }

        /// <summary>
        /// API name: base_volume
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("base_volume")]
        public object BaseVolume { get; set; }

        /// <summary>
        /// API name: quote_volume
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("quote_volume")]
        public object QuoteVolume { get; set; }
    }
}
