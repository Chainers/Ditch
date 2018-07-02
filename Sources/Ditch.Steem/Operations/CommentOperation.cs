using Ditch.Core.Attributes;
using Newtonsoft.Json;

namespace Ditch.Steem.Operations
{
    /// <summary>
    /// comment_operation
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CommentOperation : BaseOperation
    {
        public const string OperationName = "comment_operation";
        public override string TypeName => OperationName;

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