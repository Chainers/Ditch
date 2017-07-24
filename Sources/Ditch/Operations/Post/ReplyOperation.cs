using Ditch.Helpers;
using Newtonsoft.Json;

namespace Ditch.Operations.Post
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ReplyOperation : CommentOperation
    {
        public ReplyOperation(string parentAuthor, string parentPermlink, string author, string body, string jsonMetadata)
            : base(parentAuthor, parentPermlink, author, ConvertHelper.PermlinkToParentPermlink(author, parentPermlink), string.Empty, body, jsonMetadata) { }
    }
}