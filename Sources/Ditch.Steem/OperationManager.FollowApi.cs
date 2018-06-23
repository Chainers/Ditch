using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Models.Args;
using Ditch.Steem.Models.Return;

namespace Ditch.Steem
{
    /// <summary>
    /// follow_api
    /// libraries\plugins\apis\follow_api\include\steem\plugins\follow_api\follow_api.hpp
    /// </summary>
    public partial class OperationManager
    {

        /// <summary>
        /// API name: get_followers
        /// 
        /// </summary>
        /// <param name="args">API type: get_followers_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_followers_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetFollowersReturn> GetFollowers(GetFollowersArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetFollowersReturn>(KnownApiNames.FollowApi, "get_followers", args, token);
        }

        /// <summary>
        /// API name: get_following
        /// 
        /// </summary>
        /// <param name="args">API type: get_following_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_following_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetFollowingReturn> GetFollowing(GetFollowingArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetFollowingReturn>(KnownApiNames.FollowApi, "get_following", args, token);
        }

        /// <summary>
        /// API name: get_follow_count
        /// 
        /// </summary>
        /// <param name="args">API type: get_follow_count_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_follow_count_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetFollowCountReturn> GetFollowCount(GetFollowCountArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetFollowCountReturn>(KnownApiNames.FollowApi, "get_follow_count", args, token);
        }

        /// <summary>
        /// API name: get_feed_entries
        /// 
        /// </summary>
        /// <param name="args">API type: get_feed_entries_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_feed_entries_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetFeedEntriesReturn> GetFeedEntries(GetFeedEntriesArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetFeedEntriesReturn>(KnownApiNames.FollowApi, "get_feed_entries", args, token);
        }

        /// <summary>
        /// API name: get_feed
        /// 
        /// </summary>
        /// <param name="args">API type: get_feed_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_feed_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetFeedReturn> GetFeed(GetFeedArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetFeedReturn>(KnownApiNames.FollowApi, "get_feed", args, token);
        }

        /// <summary>
        /// API name: get_blog_entries
        /// 
        /// </summary>
        /// <param name="args">API type: get_blog_entries_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_blog_entries_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetBlogEntriesReturn> GetBlogEntries(GetBlogEntriesArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetBlogEntriesReturn>(KnownApiNames.FollowApi, "get_blog_entries", args, token);
        }

        /// <summary>
        /// API name: get_blog
        /// 
        /// </summary>
        /// <param name="args">API type: get_blog_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_blog_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetBlogReturn> GetBlog(GetBlogArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetBlogReturn>(KnownApiNames.FollowApi, "get_blog", args, token);
        }

        /// <summary>
        /// API name: get_account_reputations
        /// 
        /// </summary>
        /// <param name="args">API type: get_account_reputations_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_account_reputations_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetAccountReputationsReturn> GetAccountReputations(GetAccountReputationsArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetAccountReputationsReturn>(KnownApiNames.FollowApi, "get_account_reputations", args, token);
        }


        /**
         * Gets list of accounts that have reblogged a particular post
         */

        /// <summary>
        /// API name: get_reblogged_by
        /// 
        /// </summary>
        /// <param name="args">API type: get_reblogged_by_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_reblogged_by_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetRebloggedByReturn> GetRebloggedBy(GetRebloggedByArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetRebloggedByReturn>(KnownApiNames.FollowApi, "get_reblogged_by", args, token);
        }


        /**
         * Gets a list of authors that have had their content reblogged on a given blog account
         */

        /// <summary>
        /// API name: get_blog_authors
        /// 
        /// </summary>
        /// <param name="args">API type: get_blog_authors_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_blog_authors_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetBlogAuthorsReturn> GetBlogAuthors(GetBlogAuthorsArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetBlogAuthorsReturn>(KnownApiNames.FollowApi, "get_blog_authors", args, token);
        }
    }
}
