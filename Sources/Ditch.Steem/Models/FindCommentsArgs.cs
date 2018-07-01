using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// find_comments_args
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FindCommentsArgs
    {

        /// <summary>
        /// API name: comments
        /// 
        /// </summary>
        [JsonProperty("comments")]
        public string[][] Comments { get; set; }
    }
}
