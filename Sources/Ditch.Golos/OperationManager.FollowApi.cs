using System;
using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Golos.Models.ApiObj;
using Ditch.Golos.Models.Enums;
using Ditch.Golos.Models.Objects;
using Ditch.Golos.Models.Other;

namespace Ditch.Golos
{

    /// <summary>
    /// follow
    /// plugins\follow\include\golos\plugins\follow\plugin.hpp
    /// </summary>
    public partial class OperationManager
    {

        /// <summary>
        /// API name: get_account_reputations
        /// *Returns data about the reputation of users filtered by template.
        /// 
        /// </summary>
        /// <param name="lowerBoundName">API type: std::string</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_reputation</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountReputation[]> GetAccountReputations(string lowerBoundName, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<AccountReputation[]>(KnownApiNames.Follow, "get_account_reputations", new object[] { lowerBoundName, limit }, token);
        }

        /// <summary>
        /// API name: get_blog
        /// *Returns the complete record data from the blog of the specified user.
        /// 
        /// </summary>
        /// <param name="account">API type: std::string</param>
        /// <param name="entryId">API type: uint32_t</param>
        /// <param name="limit">API type: uint16_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: comment_blog_entry</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<CommentBlogEntry[]> GetBlog(string account, UInt32 entryId, UInt16 limit, CancellationToken token)
        {
            return CustomGetRequest<CommentBlogEntry[]>(KnownApiNames.Follow, "get_blog", new object[] { account, entryId, limit }, token);
        }

        /// <summary>
        /// API name: get_blog_authors
        /// Gets a list of authors that have had their content reblogged on a given blog account
        ///
        /// *Returns the list of authors and the number of reposts of this author by the user.
        /// 
        /// </summary>
        /// <param name="blogAccount">API type: account_name_type</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: std::vector<std::pair<std::string, uint32_t>>;</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ReblogCount[]> GetBlogAuthors(string blogAccount, CancellationToken token)
        {
            return CustomGetRequest<ReblogCount[]>(KnownApiNames.Follow, "get_blog_authors", new object[] { blogAccount }, token);
        }

        /// <summary>
        /// API name: get_blog_entries
        /// *Returns brief information about records from the blog of the specified user.
        /// 
        /// </summary>
        /// <param name="account">API type: std::string</param>
        /// <param name="entryId">API type: uint32_t</param>
        /// <param name="limit">API type: uint16_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: blog_entry</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<BlogEntry[]> GetBlogEntries(string account, UInt32 entryId, UInt16 limit, CancellationToken token)
        {
            return CustomGetRequest<BlogEntry[]>(KnownApiNames.Follow, "get_blog_entries", new object[] { account, entryId, limit }, token);
        }

        /// <summary>
        /// API name: get_feed
        /// *Returns the complete record data from the specified user's tape.
        /// 
        /// </summary>
        /// <param name="account">API type: std::string</param>
        /// <param name="entryId">API type: uint32_t</param>
        /// <param name="limit">API type: uint16_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: comment_feed_entry</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<CommentFeedEntry[]> GetFeed(string account, UInt32 entryId, UInt16 limit, CancellationToken token)
        {
            return CustomGetRequest<CommentFeedEntry[]>(KnownApiNames.Follow, "get_feed", new object[] { account, entryId, limit }, token);
        }

        /// <summary>
        /// API name: get_feed_entries
        /// *Returns brief information about records from the specified user's tape
        /// 
        /// </summary>
        /// <param name="account">API type: std::string</param>
        /// <param name="entryId">API type: uint32_t</param>
        /// <param name="limit">API type: uint16_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: feed_entry</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FeedEntry[]> GetFeedEntries(string account, UInt32 entryId, UInt16 limit, CancellationToken token)
        {
            return CustomGetRequest<FeedEntry[]>(KnownApiNames.Follow, "get_feed_entries", new object[] { account, entryId, limit }, token);
        }

        /// <summary>
        /// API name: get_follow_count
        /// *Returns information about the number of subscribers and subscriptions of the specified user.
        /// 
        /// </summary>
        /// <param name="account">API type: std::string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: follow_count_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FollowCountApiObj> GetFollowCount(string account, CancellationToken token)
        {
            return CustomGetRequest<FollowCountApiObj>(KnownApiNames.Follow, "get_follow_count", new object[] { account }, token);
        }

        /// <summary>
        /// API name: get_followers
        /// *Returns the list: Either all of the subscribers of the user are 'following'. Or, if the user name is specified, the list of matching subscribers is returned in the parameter 'startFollower'.
        /// 
        /// </summary>
        /// <param name="to">API type: std::string</param>
        /// <param name="start">API type: std::string</param>
        /// <param name="type">API type: follow_type</param>
        /// <param name="limit">API type: uint16_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: follow_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FollowApiObject[]> GetFollowers(string to, string start, FollowType type, UInt16 limit, CancellationToken token)
        {
            return CustomGetRequest<FollowApiObject[]>(KnownApiNames.Follow, "get_followers", new object[] { to, start, type, limit }, token);
        }

        /// <summary>
        /// API name: get_following
        /// 
        /// </summary>
        /// <param name="from">API type: std::string</param>
        /// <param name="start">API type: std::string</param>
        /// <param name="type">API type: follow_type</param>
        /// <param name="limit">API type: uint16_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: follow_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FollowApiObject[]> GetFollowing(string from, string start, FollowType type, UInt16 limit, CancellationToken token)
        {
            return CustomGetRequest<FollowApiObject[]>(KnownApiNames.Follow, "get_following", new object[] { from, start, type, limit }, token);
        }
       
        /// <summary>
        /// API name: get_reblogged_by
        /// Gets list of accounts that have reblogged a particular post
        ///
        /// *Returns the list of users who either created the record or made it a repost.
        /// 
        /// </summary>
        /// <param name="author">API type: std::string</param>
        /// <param name="permlink">API type: std::string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_name_type</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string[]> GetRebloggedBy(string author, string permlink, CancellationToken token)
        {
            return CustomGetRequest<string[]>(KnownApiNames.Follow, "get_reblogged_by", new object[] { author, permlink }, token);
        }

    }
}
