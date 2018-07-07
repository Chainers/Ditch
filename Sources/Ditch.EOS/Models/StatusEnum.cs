using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// status_enum
    /// libraries\chain\include\eosio\chain\block.hpp
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum StatusEnum
    {

        /// <summary>
        /// API name: executed
        /// 0 ///&lt; succeed no error handler executed
        /// </summary>
        Executed,

        /// <summary>
        /// API name: soft_fail
        /// 1 ///&lt; objectively failed (not executed) error handler executed
        /// </summary>
        SoftFail,

        /// <summary>
        /// API name: hard_fail
        /// 2 ///&lt; objectively failed and error handler objectively failed thus no state change
        /// </summary>
        HardFail,

        /// <summary>
        /// API name: delayed
        /// 3 ///&lt; transaction delayed/deferred/scheduled for future execution
        /// </summary>
        Delayed,

        /// <summary>
        /// API name: expired
        /// 4 ///&lt; transaction expired and storage space refuned to user
        /// </summary>
        Expired
    }
}
