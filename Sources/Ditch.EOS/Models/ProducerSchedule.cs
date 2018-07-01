using System;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /**
     *  Defines both the order, account name, and signing keys of the active set of producers.
     */

    /// <summary>
    /// producer_schedule
    /// contracts\eosiolib\producer_schedule.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ProducerSchedule
    {

        /// <summary>
        /// API name: version
        /// sequentially incrementing version number
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("version")]
        public UInt32 Version { get; set; }

        /// <summary>
        /// API name: producers
        /// 
        /// </summary>
        /// <returns>API type: producer_key</returns>
        [JsonProperty("producers")]
        public ProducerKey[] Producers { get; set; }
    }
}
