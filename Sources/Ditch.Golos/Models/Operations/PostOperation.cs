using Ditch.Core;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.Operations
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PostOperation : CommentOperation
    {
        public PostOperation(string parentPermlink, string author, string permlink, string title, string body, string jsonMetadata)
            : base(string.Empty, parentPermlink, author, permlink, title, body, jsonMetadata)
        {
        }

        public PostOperation(string parentPermlink, string author, string title, string body, string jsonMetadata)
            : base(string.Empty, parentPermlink, author, OperationHelper.TitleToPermlink(title), title, body, jsonMetadata)
        {
        }
    }
}
