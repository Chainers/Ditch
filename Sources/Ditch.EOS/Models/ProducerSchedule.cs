using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// producer_schedule
    /// contracts\eosiolib\privileged.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ProducerSchedule
    {

        /// <summary>
        /// API name: version
        /// = 0; ///&lt; sequentially incrementing version number
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("version")]
        public uint Version {get; set;}

        /// <summary>
        /// API name: producers
        /// 
        /// </summary>
        /// <returns>API type: producer_key</returns>
        [JsonProperty("producers")]
        public ProducerKey[] Producers {get; set;}
    }
}
