using Newtonsoft.Json;

namespace Ditch.Golos.Models.Other
{
    /// <summary>
    /// database_info
    /// plugins\database_api\include\golos\plugins\database_api\plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class DatabaseInfo
    {

        /// <summary>
        /// API name: total_size
        /// 
        /// </summary>
        /// <returns>API type: size_t</returns>
        [JsonProperty("total_size")]
        public int TotalSize { get; set; }

        /// <summary>
        /// API name: free_size
        /// 
        /// </summary>
        /// <returns>API type: size_t</returns>
        [JsonProperty("free_size")]
        public int FreeSize { get; set; }

        /// <summary>
        /// API name: reserved_size
        /// 
        /// </summary>
        /// <returns>API type: size_t</returns>
        [JsonProperty("reserved_size")]
        public int ReservedSize { get; set; }

        /// <summary>
        /// API name: used_size
        /// 
        /// </summary>
        /// <returns>API type: size_t</returns>
        [JsonProperty("used_size")]
        public int UsedSize { get; set; }

        /// <summary>
        /// API name: index_list
        /// 
        /// </summary>
        /// <returns>API type: database_index_info</returns>
        [JsonProperty("index_list")]
        public DatabaseIndexInfo[] IndexList { get; set; }
    }
}
