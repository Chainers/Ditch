using Ditch.Helpers;
using Newtonsoft.Json;

namespace Ditch.Operations
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class CommentOperation : BaseOperation
    {
        [SerializeHelper.IgnoreForMessage]
        public override string TypeName => "comment";

        public override OperationType Type => OperationType.Comment;


        [JsonProperty("parent_author")]
        public string ParentAuthor { get; set; }

        [JsonProperty("parent_permlink")]
        public string ParentPermlink { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("permlink")]
        public string Permlink { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("json_metadata")]
        public string JsonMetadata { get; set; }
    }
}