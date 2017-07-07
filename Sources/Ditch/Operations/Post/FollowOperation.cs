namespace Ditch.Operations.Post
{
    /// <summary>
    /// Follow / Unfollow some author
    /// </summary>
    public class FollowOperation : CustomJsonOperation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="author"></param>
        /// <param name="what">"blog","posts" or "blog" or "posts" or "" = (unfollow).</param>
        /// <param name="requiredPostingAuths"></param>
        /// <returns></returns>
        public FollowOperation(string login,string author, string what, params string[] requiredPostingAuths)
            : base("follow", $"[\"follow\", {{\"follower\": \"{login}\", \"following\": \"{author}\", \"what\": [\"{what}\"]}}]")
        {
            RequiredPostingAuths = requiredPostingAuths;
        }
    }
}