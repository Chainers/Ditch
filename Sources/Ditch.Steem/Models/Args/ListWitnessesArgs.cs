using Ditch.Steem.Models.Enums;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Args
{
    /* Witnesses */

    /// <summary>
    /// list_witnesses_args
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ListWitnessesArgs
    {

        /// <summary>
        /// API name: start
        /// 
        /// </summary>
        /// <returns>API type: variant</returns>
        [JsonProperty("start")]
        public object Start {get; set;}

        /// <summary>
        /// API name: limit
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("limit")]
        public uint Limit {get; set;}

        /// <summary>
        /// API name: order
        /// 
        /// </summary>
        /// <returns>API type: sort_order_type</returns>
        [JsonProperty("order")]
        public SortOrderType Order {get; set;}
    }
}
