using Ditch.Steem.Models.Other;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// get_volume_return
    /// libraries\plugins\apis\market_history_api\include\steem\plugins\market_history_api\market_history_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GetVolumeReturn
    {

        /// <summary>
        /// API name: steem_volume
        /// = asset( 0, STEEM_SYMBOL );
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("steem_volume")]
        public Asset SteemVolume {get; set;}

        /// <summary>
        /// API name: sbd_volume
        /// = asset( 0, SBD_SYMBOL );
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("sbd_volume")]
        public Asset SbdVolume {get; set;}
    }
}
