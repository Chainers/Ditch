using Newtonsoft.Json;

namespace Ditch.Steem.Operations.Post
{
    /// <summary>
    /// Flag post (Opposite operation is DownVoteOperation or UpVoteOperation)
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FlagOperation : VoteOperation
    {
        public FlagOperation(string voter, string author, string permlink)
            : base(voter, author, permlink, -10000)
        {
        }
    }
}