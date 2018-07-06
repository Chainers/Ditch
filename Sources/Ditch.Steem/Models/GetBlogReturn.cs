using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// get_blog_return
    /// libraries\plugins\apis\follow_api\include\steem\plugins\follow_api\follow_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetBlogReturn
    {

        /// <summary>
        /// API name: blog
        /// 
        /// </summary>
        /// <returns>API type: comment_blog_entry</returns>
        [JsonProperty("blog")]
        public CommentBlogEntry[] Blog {get; set;}
    }
}
