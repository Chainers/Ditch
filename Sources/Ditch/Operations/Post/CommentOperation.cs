using Ditch.Helpers;
using Newtonsoft.Json;

namespace Ditch.Operations.Post
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CommentOperation : BaseOperation
    {
        public override string TypeName => "comment";

        public override OperationType Type => OperationType.Comment;

        [SerializeHelper.MessageOrder(20)]
        [JsonProperty("parent_author")]
        public string ParentAuthor { get; set; }

        [SerializeHelper.MessageOrder(30)]
        [JsonProperty("parent_permlink")]
        public string ParentPermlink { get; set; }

        [SerializeHelper.MessageOrder(40)]
        [JsonProperty("author")]
        public string Author { get; set; }

        [SerializeHelper.MessageOrder(50)]
        [JsonProperty("permlink")]
        public string Permlink { get; set; }

        [SerializeHelper.MessageOrder(60)]
        [JsonProperty("title")]
        public string Title { get; set; }

        [SerializeHelper.MessageOrder(70)]
        [JsonProperty("body")]
        public string Body { get; set; }

        [SerializeHelper.MessageOrder(80)]
        [JsonProperty("json_metadata")]
        public string JsonMetadata { get; set; }

        public CommentOperation(string parentAuthor, string parentPermlink, string author, string permlink, string title, string body, string jsonMetadata)
        {
            ParentAuthor = parentAuthor;
            ParentPermlink = ConvertHelper.StringToPermlink(parentPermlink);
            Author = author;
            Permlink = ConvertHelper.StringToPermlink(permlink);
            Title = title;
            Body = body;
            JsonMetadata = jsonMetadata;
        }
    }
}