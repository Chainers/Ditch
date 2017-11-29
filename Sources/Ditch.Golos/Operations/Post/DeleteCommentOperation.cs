using Newtonsoft.Json;

namespace Ditch.Golos.Operations.Post
{
    /// <summary>
    /// delete_comment_operation
    /// libraries\protocol\include\golos\protocol\operations\comment_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class DeleteCommentOperation : BaseOperation
    {
        public override string TypeName => "delete_comment";
        public override OperationType Type => OperationType.DeleteComment;

        /// <summary>
        /// API name: author
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("author")]
        public string Author { get; set; }

        /// <summary>
        /// API name: permlink
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("permlink")]
        public string Permlink { get; set; }


        public DeleteCommentOperation(string author, string permlink)
        {
            Author = author;
            Permlink = permlink;
        }
    }
}
