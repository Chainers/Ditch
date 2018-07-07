using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// follow_type
    /// plugins\follow\include\golos\plugins\follow\follow_forward.hpp
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum FollowType
    {

        /// <summary>
        /// API name: undefined
        /// 
        /// </summary>
        Undefined,

        /// <summary>
        /// API name: blog
        /// 
        /// </summary>
        Blog,

        /// <summary>
        /// API name: ignore
        /// 
        /// </summary>
        Ignore
    }
}