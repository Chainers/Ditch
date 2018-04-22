using Ditch.Golos.Models.ApiObject;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.Other
{
    /// <summary>
    /// limit_order
    /// plugins\market_history\include\golos\plugins\market_history\market_history_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class LimitOrder : LimitOrderApiObject
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
