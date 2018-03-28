namespace Ditch.Golos.Models.Operations
{
    /// <summary>
    /// Repost some post by author and permlink (loads all additional parameters from the blockchain)
    /// </summary>
    public class RePostOperation : CustomJsonOperation
    {
        public RePostOperation(string login, string author, string permlink, params string[] requiredPostingAuths)
            : base("follow", $"[\"reblog\",{{\"account\":\"{login}\",\"author\":\"{author}\",\"permlink\":\"{permlink}\"}}]")
        {
            RequiredPostingAuths = requiredPostingAuths;
        }
    }
}