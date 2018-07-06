using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Steem.Old.Models.Enums
{
    /// <summary>
    /// follow_type
    /// libraries\plugins\follow\include\steem\plugins\follow\follow_objects.hpp
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