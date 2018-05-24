using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// order
    /// libraries\app\include\graphene\app\database_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Order
    {

        /// <summary>
        /// API name: price
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("price")]
        public string Price { get; set; }

        /// <summary>
        /// API name: quote
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("quote")]
        public string Quote { get; set; }

        /// <summary>
        /// API name: base
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("base")]
        public string Base { get; set; }
    }
}
