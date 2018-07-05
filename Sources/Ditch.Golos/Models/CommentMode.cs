using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// comment_mode
    /// libraries\chain\include\golos\chain\comment_object.hpp
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum CommentMode
    {
        /// <summary>
        /// API name: not_set
        /// 
        /// </summary>
        NotSet,

        /// <summary>
        /// API name: first_payout
        /// 
        /// </summary>
        FirstPayout,

        /// <summary>
        /// API name: second_payout
        /// 
        /// </summary>
        SecondPayout,

        /// <summary>
        /// API name: archived
        /// 
        /// </summary>
        Archived,
    }
}