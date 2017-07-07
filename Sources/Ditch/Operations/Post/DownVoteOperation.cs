using Newtonsoft.Json;

namespace Ditch.Operations.Post
{
    /// <summary>
    /// Vote down post
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class DownVoteOperation : VoteOperation
    {
        public DownVoteOperation(string voter, string author, string permlink)
            : base(voter, author, permlink, 0)
        {
        }
    }
}