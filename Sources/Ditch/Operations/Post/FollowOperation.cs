using System;

namespace Ditch.Operations.Post
{
    /// <summary>
    /// This type is not a graphene type. (The numbers do not correspond to the numbers from the follow_type)
    /// </summary>
    [Flags]
    public enum FollowType : byte
    {
        Undefined = 0,
        Unfollow = 1,
        Blog = 2,
        Posts = 4,
        Ignore = 8,
        Comments = 16,
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
        /// <param name="what">"blog","posts" or "blog" or "posts" or "" = (unfollow). (posts, comments, votes, ignore *https://github.com/steemit/steem/blob/master/libraries/wallet/include/steemit/wallet/wallet.hpp)</param>
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