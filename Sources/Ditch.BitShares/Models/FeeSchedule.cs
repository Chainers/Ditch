using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     *  @brief contains all of the parameters necessary to calculate the fee for any operation
     */

    /// <summary>
    /// fee_schedule
    /// libraries\chain\include\graphene\chain\protocol\fee_schedule.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FeeSchedule
    {


        /**
         *  @note must be sorted by fee_parameters.which() and have no duplicates
         */

        /// <summary>
        /// API name: parameters
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("parameters")]
        public object[] Parameters { get; set; }

        /// <summary>
        /// API name: scale
        /// = GRAPHENE_100_PERCENT; ///&lt; fee * scale / GRAPHENE_100_PERCENT
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("scale")]
        public uint Scale { get; set; }
    }
}
