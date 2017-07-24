using Ditch.Helpers;
using Newtonsoft.Json;

namespace Ditch.Operations.Post
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PostOperation : CommentOperation
    {
        public PostOperation(string parentPermlink, string author, string permlink, string title, string body, string jsonMetadata)
            : base(string.Empty, parentPermlink, author, permlink, title, body, jsonMetadata)
        {
        }

        public PostOperation(string parentPermlink, string author, string title, string body, string jsonMetadata)
            : base(string.Empty, parentPermlink, author, Transliteration.Convert(title), title, body, jsonMetadata)
        {
        }
    }
}