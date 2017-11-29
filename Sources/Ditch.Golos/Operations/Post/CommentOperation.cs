using Ditch.Golos.Helpers;
using Newtonsoft.Json;

namespace Ditch.Golos.Operations.Post
{
    /// <summary>
    /// comment_operation
    /// libraries\protocol\include\golos\protocol\operations\comment_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CommentOperation : BaseOperation
    {
        protected const int PermlinkCropCount = 40;
        public override string TypeName => "comment";

        public override OperationType Type => OperationType.Comment;

        /// <summary>
        /// API name: parent_author
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(20)]
        [JsonProperty("parent_author")]
        public string ParentAuthor { get; set; }

        /// <summary>
        /// API name: parent_permlink
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [MessageOrder(30)]
        [JsonProperty("parent_permlink")]
        public string ParentPermlink { get; set; }

        /// <summary>
        /// API name: author
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(40)]
        [JsonProperty("author")]
        public string Author { get; set; }

        /// <summary>
        /// API name: permlink
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [MessageOrder(50)]
        [JsonProperty("permlink")]
        public string Permlink { get; set; }

        /// <summary>
        /// API name: title
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [MessageOrder(60)]
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// API name: body
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [MessageOrder(70)]
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// API name: json_metadata
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [MessageOrder(80)]
        [JsonProperty("json_metadata")]
        public string JsonMetadata { get; set; }

        public CommentOperation(string parentAuthor, string parentPermlink, string author, string permlink, string title, string body, string jsonMetadata)
        {
            ParentAuthor = parentAuthor;
            ParentPermlink = parentPermlink;
            Author = author;
            Permlink = permlink;
            Title = title;
            Body = body;
            JsonMetadata = jsonMetadata;
        }
    }
}
