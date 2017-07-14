using System;

namespace Ditch.Operations.Post
{
    [Flags]
    public enum FollowType : byte
    {
        Unfollow = 1,
        Blog = 2,
        Posts = 4,
    }


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
        public FollowOperation(string login, string author, FollowType what, params string[] requiredPostingAuths)
            : base("follow", $"[\"follow\", {{\"follower\": \"{login}\", \"following\": \"{author}\", \"what\": [\"{FollowTypeToString(what)}\"]}}]")
        {
            RequiredPostingAuths = requiredPostingAuths;
        }

        protected static string FollowTypeToString(FollowType what)
        {
            var result = string.Empty;
            if (what.HasFlag(FollowType.Unfollow))
            {
                return result;
            }
            if (what.HasFlag(FollowType.Blog))
            {
                result = "blog";
            }
            if (what.HasFlag(FollowType.Posts))
            {
                if (!string.IsNullOrEmpty(result))
                    result += "\", \"";
                result += "posts";
            }
            return result;
        }
    }
}