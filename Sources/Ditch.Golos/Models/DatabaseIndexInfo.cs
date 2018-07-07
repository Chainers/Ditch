using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// database_index_info
    /// plugins\database_api\include\golos\plugins\database_api\plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class DatabaseIndexInfo
    {

        /// <summary>
        /// API name: name
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("name")]
        public string Name {get; set;}

        /// <summary>
        /// API name: record_count
        /// 
        /// </summary>
        /// <returns>API type: size_t</returns>
        [JsonProperty("record_count")]
        public int RecordCount {get; set;}
    }
}
