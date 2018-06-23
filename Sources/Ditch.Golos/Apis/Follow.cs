using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Golos.Models;

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
        /// *Возвращает данные о репутации пользователей отфильтрованных по шаблону.
        /// 
        /// </summary>
        /// <param name="lowerBoundName">API type: std::string</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_reputation</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountReputation[]> GetAccountReputations(string lowerBoundName, uint limit, CancellationToken token)
        {
            return CustomGetRequest<AccountReputation[]>(KnownApiNames.Follow, "get_account_reputations", new object[] { lowerBoundName, limit }, token);
        }

        /// <summary>
        /// API name: get_blog
        /// *Возвращает полные данные о записях из блога указанного пользователя.
        /// 
        /// </summary>
        /// <param name="account">API type: std::string</param>
        /// <param name="entryId">API type: uint32_t</param>
        /// <param name="limit">API type: uint16_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: comment_blog_entry</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<CommentBlogEntry[]> GetBlog(string account, uint entryId, ushort limit, CancellationToken token)
        {
            return CustomGetRequest<CommentBlogEntry[]>(KnownApiNames.Follow, "get_blog", new object[] { account, entryId, limit }, token);
        }

        /// <summary>
        /// API name: get_blog_authors
        /// *Возвращает список авторов и количество репостов этого автора пользователем.
        /// 
        /// </summary>
        /// <param name="blogAccount">API type: account_name_type</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: std::vector&lt;std::pair&lt;std::string, uint32_t>>;</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ReblogCount[]> GetBlogAuthors(string blogAccount, CancellationToken token)
        {
            return CustomGetRequest<ReblogCount[]>(KnownApiNames.Follow, "get_blog_authors", new object[] { blogAccount }, token);
        }

        /// <summary>
        /// API name: get_blog_entries
        /// *Возвращает краткие данные о записях из блога указанного пользователя.
        /// 
        /// </summary>
        /// <param name="account">API type: std::string</param>
        /// <param name="entryId">API type: uint32_t</param>
        /// <param name="limit">API type: uint16_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: blog_entry</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<BlogEntry[]> GetBlogEntries(string account, uint entryId, ushort limit, CancellationToken token)
        {
            return CustomGetRequest<BlogEntry[]>(KnownApiNames.Follow, "get_blog_entries", new object[] { account, entryId, limit }, token);
        }

        /// <summary>
        /// API name: get_feed
        /// *Возвращает полные данные о записях из ленты указанного пользователя.
        /// 
        /// </summary>
        /// <param name="account">API type: std::string</param>
        /// <param name="entryId">API type: uint32_t</param>
        /// <param name="limit">API type: uint16_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: comment_feed_entry</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<CommentFeedEntry[]> GetFeed(string account, uint entryId, ushort limit, CancellationToken token)
        {
            return CustomGetRequest<CommentFeedEntry[]>(KnownApiNames.Follow, "get_feed", new object[] { account, entryId, limit }, token);
        }

        /// <summary>
        /// API name: get_feed_entries
        /// *Возвращает краткие данные о записях из ленты указанного пользователя
        /// 
        /// </summary>
        /// <param name="account">API type: std::string</param>
        /// <param name="entryId">API type: uint32_t</param>
        /// <param name="limit">API type: uint16_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: feed_entry</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FeedEntry[]> GetFeedEntries(string account, uint entryId, ushort limit, CancellationToken token)
        {
            return CustomGetRequest<FeedEntry[]>(KnownApiNames.Follow, "get_feed_entries", new object[] { account, entryId, limit }, token);
        }

        /// <summary>
        /// API name: get_follow_count
        /// *Возвращает данные о количестве подписчиков и подписок указанного пользователя.
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
        /// *Возвращает список: Либо всех подписчиков пользователя 'following'. Либо если указано имя пользователя в параметре 'startFollower' возвращается список совпадающих подписчиков.
        /// 
        /// </summary>
        /// <param name="to">API type: std::string</param>
        /// <param name="start">API type: std::string</param>
        /// <param name="type">API type: follow_type</param>
        /// <param name="limit">API type: uint16_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: follow_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FollowApiObject[]> GetFollowers(string to, string start, FollowType type, ushort limit, CancellationToken token)
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
        public JsonRpcResponse<FollowApiObject[]> GetFollowing(string from, string start, FollowType type, ushort limit, CancellationToken token)
        {
            return CustomGetRequest<FollowApiObject[]>(KnownApiNames.Follow, "get_following", new object[] { from, start, type, limit }, token);
        }

        /// <summary>
        /// API name: get_reblogged_by
        /// *Возвращает список пользователей которые либо создали запись либо сделали её репост.
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
