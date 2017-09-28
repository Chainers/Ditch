
namespace Ditch.Operations.Post
{
    /// <summary>
    /// Unfollow some author
    /// </summary>
    public class UnfollowOperation : CustomJsonOperation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="author"></param>
        /// <param name="requiredPostingAuths"></param>
        /// <returns></returns>
        public UnfollowOperation(string login, string author, params string[] requiredPostingAuths)
            : base("follow", $"[\"follow\", {{\"follower\": \"{login}\", \"following\": \"{author}\", \"what\": []}}]")
        {
            RequiredPostingAuths = requiredPostingAuths;
        }
    }
}