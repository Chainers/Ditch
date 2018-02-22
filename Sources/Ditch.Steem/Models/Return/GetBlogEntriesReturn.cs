using Ditch.Steem.Models.Objects;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// get_blog_entries_return
    /// libraries\plugins\apis\follow_api\include\steem\plugins\follow_api\follow_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GetBlogEntriesReturn
    {

        /// <summary>
        /// API name: blog
        /// 
        /// </summary>
        /// <returns>API type: blog_entry</returns>
        [JsonProperty("blog")]
        public BlogEntry[] Blog {get; set;}
    }
}
