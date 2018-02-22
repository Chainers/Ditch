using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Objects
{
    /// <summary>
    /// api_hardfork_property_object
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ApiHardforkPropertyObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: hardfork_property_id_type</returns>
        [JsonProperty("id")]
        public object Id {get; set;}

        /// <summary>
        /// API name: processed_hardforks
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("processed_hardforks")]
        public DateTime[] ProcessedHardforks {get; set;}

        /// <summary>
        /// API name: last_hardfork
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("last_hardfork")]
        public UInt32 LastHardfork {get; set;}

        /// <summary>
        /// API name: current_hardfork_version
        /// 
        /// </summary>
        /// <returns>API type: hardfork_version</returns>
        [JsonProperty("current_hardfork_version")]
        public string CurrentHardforkVersion {get; set;}

        /// <summary>
        /// API name: next_hardfork
        /// 
        /// </summary>
        /// <returns>API type: hardfork_version</returns>
        [JsonProperty("next_hardfork")]
        public string NextHardfork {get; set;}

        /// <summary>
        /// API name: next_hardfork_time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("next_hardfork_time")]
        public DateTime NextHardforkTime {get; set;}
    }
}
