using System;
using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Core.Models;
using Ditch.Golos.Models;
using Newtonsoft.Json.Linq;

namespace Ditch.Golos
{

    public partial class OperationManager
    {
        /// <summary>
        /// API name: get_discussions_by_trending
        /// Used to retrieve the list of first payout discussions sorted by rshares^2 amount
        ///
        /// *Displays a limited number of publications beginning with the most expensive of the award.
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query @ref discussion_query</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion vector of first payout mode discussions sorted by rshares^2 amount</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByTrending(DiscussionQuery query, CancellationToken token)
        {
            return CustomGetRequest<Discussion[]>(KnownApiNames.Tags, "get_discussions_by_trending", new object[] { query }, token);
        }

        /// <summary>
        /// API name: get_discussions_by_created
        /// Used to retrieve the list of discussions sorted by created time
        ///
        /// *Displays a limited number of publications, starting with the newest one.
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query @ref discussion_query</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion vector of discussions sorted by created time</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByCreated(DiscussionQuery query, CancellationToken token)
        {
            return CustomGetRequest<Discussion[]>(KnownApiNames.Tags, "get_discussions_by_created", new object[] { query }, token);
        }

        /// <summary>
        /// API name: get_discussions_by_active
        /// Used to retrieve the list of discussions sorted by last activity time
        ///
        /// *Displays a limited number of entries in which there was activity since the newest.
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query @ref discussion_query</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion vector of discussions sorted by last activity time</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByActive(DiscussionQuery query, CancellationToken token)
        {
            return CustomGetRequest<Discussion[]>(KnownApiNames.Tags, "get_discussions_by_active", new object[] { query }, token);
        }

        /// <summary>
        /// API name: get_discussions_by_cashout
        /// Used to retrieve the list of discussions sorted by cashout time
        ///
        /// *Displays a limited number of publications, sorted by the time of payments
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query @ref discussion_query</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion vector of discussions sorted by last cashout time</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByCashout(DiscussionQuery query, CancellationToken token)
        {
            return CustomGetRequest<Discussion[]>(KnownApiNames.Tags, "get_discussions_by_cashout", new object[] { query }, token);
        }

        /// <summary>
        /// API name: get_discussions_by_payout
        /// Used to retrieve the list of discussions sorted by net rshares amount
        ///
        /// *Displays a limited number of publications sorted by payments
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query @ref discussion_query</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion vector of discussions sorted by net rshares amount</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByPayout(DiscussionQuery query, CancellationToken token)
        {
            return CustomGetRequest<Discussion[]>(KnownApiNames.Tags, "get_discussions_by_payout", new object[] { query }, token);
        }

        /// <summary>
        /// API name: get_discussions_by_votes
        /// Used to retrieve the list of discussions sorted by direct votes amount
        ///
        /// *Displays a limited number of publications, sorted by votes.
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query @ref discussion_query</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion vector of discussions sorted by direct votes amount</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByVotes(DiscussionQuery query, CancellationToken token)
        {
            return CustomGetRequest<Discussion[]>(KnownApiNames.Tags, "get_discussions_by_votes", new object[] { query }, token);
        }


        /// <summary>
        /// API name: get_discussions_by_hot
        /// Used to retrieve the list of discussions sorted by hot amount
        ///
        /// *Displays a limited number of publications, sorted by popularity.
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query @ref discussion_query</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion vector of discussions sorted by hot amount</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByHot(DiscussionQuery query, CancellationToken token)
        {
            return CustomGetRequest<Discussion[]>(KnownApiNames.Tags, "get_discussions_by_hot", new object[] { query }, token);
        }

        /// <summary>
        /// API name: get_discussions_by_feed
        /// Used to retrieve the list of discussions from the feed of a specific author
        ///
        /// *Displays a limited number of conversion records for a specific author
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query @ref discussion_query
        /// @attention @ref discussion_query#select_authors must be set and must contain the @ref discussion_query#start_author param if the last one is not null</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion vector of discussions from the feed of authors in @ref discussion_query#select_authors</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByFeed(DiscussionQuery query, CancellationToken token)
        {
            return CustomGetRequest<Discussion[]>(KnownApiNames.Tags, "get_discussions_by_feed", new object[] { query }, token);
        }

        /// <summary>
        /// API name: get_discussions_by_blog
        /// Used to retrieve the list of discussions from the blog of a specific author
        ///
        /// *Displays a limited number of publications, from a blog of a specific author.
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query @ref discussion_query
        /// @attention @ref discussion_query#select_authors must be set and must contain the @ref discussion_query#start_author param if the last one is not null</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion vector of discussions from the blog of authors in @ref discussion_query#select_authors</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByBlog(DiscussionQuery query, CancellationToken token)
        {
            return CustomGetRequest<Discussion[]>(KnownApiNames.Tags, "get_discussions_by_blog", new object[] { query }, token);
        }

        /// <summary>
        /// API name: get_discussions_by_comments
        /// *Displays a limited number of publications, from the comments of a particular author.
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByComments(DiscussionQuery query, CancellationToken token)
        {
            return CustomGetRequest<Discussion[]>(KnownApiNames.Tags, "get_discussions_by_comments", new object[] { query }, token);
        }

        /// <summary>
        /// API name: get_discussions_by_promoted
        /// Used to retrieve the list of discussions sorted by promoted balance amount
        ///
        /// *Displays a limited number of publications sorted by an increased balance amount
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query @ref discussion_query</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion vector of discussions sorted by promoted balance amount</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByPromoted(DiscussionQuery query, CancellationToken token)
        {
            return CustomGetRequest<Discussion[]>(KnownApiNames.Tags, "get_discussions_by_promoted", new object[] { query }, token);
        }


        ///  <summary>
        ///  API name: get_discussions_by_author_before_date
        ///  This method is used to fetch all posts/comments by start_author that occur after before_date and start_permlink with up to limit being returned.
        ///  
        ///  If start_permlink is empty then only before_date will be considered. If both are specified the eariler to the two metrics will be used. This
        ///  should allow easy pagination.
        /// 
        ///  *Displays a limited number of user publications
        ///  
        ///  </summary>
        ///  <param name="author">API type: std::string</param>
        ///  <param name="startPermlink">API type: std::string</param>
        ///  <param name="beforeDate">API type: time_point_sec</param>
        ///  <param name="limit">API type: uint32_t</param>
        /// <param name="voteLimit"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///  <returns>API type: discussion</returns>
        ///  <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByAuthorBeforeDate(string author, string startPermlink, DateTime beforeDate, UInt32 limit, UInt16 voteLimit, CancellationToken token)
        {
            return CustomGetRequest<Discussion[]>(KnownApiNames.Tags, "get_discussions_by_author_before_date", new object[] { author, startPermlink, beforeDate, limit, voteLimit }, token);
        }

        /// <summary>
        /// API name: get_discussions_by_children
        /// Used to retrieve the list of discussions sorted by children posts amount
        /// 
        /// </summary>
        /// <param name="query">API type: discussion_query</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion  Vector of discussions sorted by children posts amount</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByChildren(DiscussionQuery query, CancellationToken token)
        {
            return CustomGetRequest<Discussion[]>(KnownApiNames.Tags, "get_discussions_by_children", new object[] { query }, token);
        }

        /// <summary>
        ///     API name: get_trending_tags
        ///     *Returns a list of tags (tags) that include word combinations
        /// </summary>
        /// <param name="afterTag">API type: std::string</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: tag_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<TagApiObj[]> GetTrendingTags(string afterTag, uint limit, CancellationToken token)
        {
            return CustomGetRequest<TagApiObj[]>(KnownApiNames.Tags, "get_trending_tags", new object[] { afterTag, limit }, token);
        }

        /// <summary>
        /// API name: get_tags_used_by_author
        /// Used to retrieve top 1000 tags list used by an author sorted by most frequently used
        ///
        /// 
        /// </summary>
        /// <param name="author">API type: std::string select tags of this author</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>vector of top 1000 tags used by an author sorted by most frequently used</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<MapContainer<string, UInt32>> GetTagsUsedByAuthor(string author, CancellationToken token)
        {
            return CustomGetRequest<MapContainer<string, UInt32>>(KnownApiNames.Tags, "get_tags_used_by_author", new object[] { author }, token);
        }

        /// <summary>
        /// API name: get_languages
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion  Vector of discussions sorted by children posts amount</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<JObject> GetLanguages(CancellationToken token)
        {
            return CustomGetRequest<JObject>(KnownApiNames.Tags, "get_languages", token);
        }
    }
}