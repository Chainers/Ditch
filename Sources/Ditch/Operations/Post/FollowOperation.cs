using Ditch.Operations.Enums;

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
        /// <param name="what">"blog","posts" or "blog" or "posts" or "" = (unfollow). (posts, comments, votes, ignore *https://github.com/steemit/steem/blob/master/libraries/wallet/include/steemit/wallet/wallet.hpp)</param>
        /// <param name="requiredPostingAuths"></param>
        /// <returns></returns>
        public FollowOperation(string login, string author, FollowType[] what, params string[] requiredPostingAuths)
            : base("follow", $"[\"follow\", {{\"follower\": \"{login}\", \"following\": \"{author}\", \"what\": [{ToString(what)}]}}]")
        {
            RequiredPostingAuths = requiredPostingAuths;
        }

        /// <param name="login"></param>
        /// <param name="author"></param>
        /// <param name="what">"blog","posts" or "blog" or "posts" or "" = (unfollow). (posts, comments, votes, ignore *https://github.com/steemit/steem/blob/master/libraries/wallet/include/steemit/wallet/wallet.hpp)</param>
        /// <param name="requiredPostingAuths"></param>
        /// <returns></returns>
        public FollowOperation(string login, string author, FollowType what, params string[] requiredPostingAuths)
            : base("follow", $"[\"follow\", {{\"follower\": \"{login}\", \"following\": \"{author}\", \"what\": [\"{what}\"]}}]")
        {
            RequiredPostingAuths = requiredPostingAuths;
        }

        private static string ToString(FollowType[] what)
        {
            if (what == null || what.Length == 0)
                return string.Empty;
            return $"\"{string.Join("\", \"", what)}\"";
        }
    }
}