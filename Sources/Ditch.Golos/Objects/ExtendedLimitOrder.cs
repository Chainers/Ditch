using Newtonsoft.Json;

namespace Ditch.Golos.Objects
{
    /// <summary>
    /// extended_limit_order
    /// libraries\app\include\steemit\app\state.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ExtendedLimitOrder
    {

        /// <summary>
        /// API name: real_price
        /// = 0;
        /// </summary>
        /// <returns>API type: double</returns>
        [JsonProperty("real_price")]
        public double RealPrice { get; set; }

        /// <summary>
        /// API name: rewarded
        /// = false;
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("rewarded")]
        public bool Rewarded { get; set; }
    }
}
