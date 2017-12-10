using System;
using System.Collections.Generic;
using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Operations;
using Ditch.Steem.Operations.Enums;
using Ditch.Steem.Operations.Get;

namespace Ditch.Steem
{

    /// <summary>
    /// follow_api
    /// \libraries\plugins\follow\include\steemit\follow\follow_api.hpp
    /// </summary>
    public partial class OperationManager
    {

        /// <summary>
        /// 
        /// Возвращает список: Либо всех подписчиков пользователя 'following'. 
        /// Либо если указано имя пользователя в параметре 'startFollower' возвращается список совпадающих подписчиков.
        /// </summary>
        /// <param name="following"></param>
        /// <param name="startFollower"></param>
        /// <param name="followType"></param>
        /// <param name="limit"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FollowApiObj[]> GetFollowers(string following, string startFollower, FollowType followType, UInt16 limit, CancellationToken token)
        {
            return CustomGetRequest<FollowApiObj[]>("call", token, KnownApiNames.FollowApi, "get_followers", new object[] { following, startFollower, followType.ToString().ToLower(), limit });
        }

        /// <summary>
        /// 
        /// Aналогично GetFollowers только для подписок
        /// </summary>
        /// <param name="follower"></param>
        /// <param name="startFollowing"></param>
        /// <param name="followType"></param>
        /// <param name="limit"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FollowApiObj[]> GetFollowing(string follower, string startFollowing, FollowType followType, UInt16 limit, CancellationToken token)
        {
            return CustomGetRequest<FollowApiObj[]>("call", token, KnownApiNames.FollowApi, "get_following", new object[] { follower, startFollowing, followType.ToString().ToLower(), limit });
        }

        /// <summary>
        /// API name: get_follow_count
        /// 
        /// </summary>
        /// <param name="account">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: follow_count_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FollowCountApiObj> GetFollowCount(string account, CancellationToken token)
        {
            return CustomGetRequest<FollowCountApiObj>("call", token, KnownApiNames.FollowApi, "get_follow_count", new object[] { account });
        }

        /// <summary>
        /// API name: get_feed_entries
        /// 
        /// </summary>
        /// <param name="account">API type: string</param>
        /// <param name="entryId">API type: uint32_t</param>
        /// <param name="limit">API type: uint16_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: feed_entry</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FeedEntry[]> GetFeedEntries(string account, UInt32 entryId, UInt16 limit, CancellationToken token)
        {
            return CustomGetRequest<FeedEntry[]>("call", token, KnownApiNames.FollowApi, "get_feed_entries", account, entryId, limit);
        }

        /// <summary>
        /// API name: get_feed
        /// 
        /// </summary>
        /// <param name="account">API type: string</param>
        /// <param name="entryId">API type: uint32_t</param>
        /// <param name="limit">API type: uint16_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: comment_feed_entry</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<CommentFeedEntry[]> GetFeed(string account, UInt32 entryId, UInt16 limit, CancellationToken token)
        {
            return CustomGetRequest<CommentFeedEntry[]>("call", token, KnownApiNames.FollowApi, "get_feed", account, entryId, limit);
        }

        /// <summary>
        /// API name: get_blog_entries
        /// 
        /// </summary>
        /// <param name="account">API type: string</param>
        /// <param name="entryId">API type: uint32_t</param>
        /// <param name="limit">API type: uint16_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: blog_entry</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<BlogEntry[]> GetBlogEntries(string account, UInt32 entryId, UInt16 limit, CancellationToken token)
        {
            return CustomGetRequest<BlogEntry[]>("call", token, KnownApiNames.FollowApi, "get_blog_entries", account, entryId, limit);
        }

        /// <summary>
        /// API name: get_blog
        /// 
        /// </summary>
        /// <param name="account">API type: string</param>
        /// <param name="entryId">API type: uint32_t</param>
        /// <param name="limit">API type: uint16_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: comment_blog_entry</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<CommentBlogEntry[]> GetBlog(string account, UInt32 entryId, UInt16 limit, CancellationToken token)
        {
            return CustomGetRequest<CommentBlogEntry[]>("call", token, KnownApiNames.FollowApi, "get_blog", account, entryId, limit);
        }

        /// <summary>
        /// API name: get_account_reputations
        /// 
        /// </summary>
        /// <param name="lowerBoundName">API type: string</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_reputation</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountReputation[]> GetAccountReputations(string lowerBoundName, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<AccountReputation[]>("call", token, KnownApiNames.FollowApi, "get_account_reputations", lowerBoundName, limit);
        }


        /**
         * Gets list of accounts that have reblogged a particular post
         */
        /// <summary>
        /// API name: get_reblogged_by
        /// 
        /// </summary>
        /// <param name="author">API type: string</param>
        /// <param name="permlink">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_name_type</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string[]> GetRebloggedBy(string author, string permlink, CancellationToken token)
        {
            return CustomGetRequest<string[]>("call", token, KnownApiNames.FollowApi, "get_reblogged_by", author, permlink);
        }


        /**
         * Gets a list of authors that have had their content reblogged on a given blog account
         */
        /// <summary>
        /// API name: get_blog_authors
        /// 
        /// </summary>
        /// <param name="blogAccount">API type: account_name_type</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<KeyValuePair<string, UInt32>[]> GetBlogAuthors(string blogAccount, CancellationToken token)
        {
            return CustomGetRequest<KeyValuePair<string, UInt32>[]>("call", token, KnownApiNames.FollowApi, "get_blog_authors", blogAccount);
        }
    }
}
