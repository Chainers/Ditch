using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Args
{
    /// <summary>
    /// find_comments_args
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class FindCommentsArgs
    {

        /// <summary>
        /// API name: comments
        /// 
        /// </summary>
        [JsonProperty("comments")]
        public string[][] Comments { get; set; }
    }
}
