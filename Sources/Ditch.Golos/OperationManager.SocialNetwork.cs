using System;
using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Core.Models;
using Ditch.Golos.Models.ApiObj;
using Ditch.Golos.Models.Objects;
using Ditch.Golos.Models.Other;
using Newtonsoft.Json.Linq;

namespace Ditch.Golos
{
    /**
    * @brief The database_api class implements the RPC API for the chain database.
    *
    * This API exposes accessors on the database which query state tracked by a blockchain validating node. This API is
    * read-only; all modifications to the database must be performed via transactions. Transactions are broadcast via
    * the @ref network_broadcast_api.
    */

    /// <summary>
    ///     database_api
    ///     libraries\application\include\golos\application\database_api.hpp
    /// </summary>
    public partial class OperationManager
    {

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
            return CustomGetRequest<TagApiObj[]>(KnownApiNames.SocialNetworkApi, "get_trending_tags", new object[] { afterTag, limit }, token);
        }

        /// <summary>
        /// API name: get_trending_categories
        /// *Returns sorted by value tags starting with a given or similar to it.
        /// 
        /// </summary>
        /// <param name="after">API type: std::string</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: category_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<CategoryApiObject[]> GetTrendingCategories(string after, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<CategoryApiObject[]>(KnownApiNames.SocialNetworkApi, "get_trending_categories", new object[] { after, limit }, token);
        }

        /// <summary>
        /// API name: get_best_categories
        /// 
        /// </summary>
        /// <param name="after">API type: std::string</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: category_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<CategoryApiObject[]> GetBestCategories(string after, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<CategoryApiObject[]>(KnownApiNames.SocialNetworkApi, "get_best_categories", new object[] { after, limit }, token);
        }

        /// <summary>
        /// API name: get_active_categories
        /// 
        /// </summary>
        /// <param name="after">API type: std::string</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: category_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<CategoryApiObject[]> GetActiveCategories(string after, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<CategoryApiObject[]>(KnownApiNames.SocialNetworkApi, "get_active_categories", new object[] { after, limit }, token);
        }

        /// <summary>
        /// API name: get_recent_categories
        /// 
        /// </summary>
        /// <param name="after">API type: std::string</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: category_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<CategoryApiObject[]> GetRecentCategories(string after, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<CategoryApiObject[]>(KnownApiNames.SocialNetworkApi, "get_recent_categories", new object[] { after, limit }, token);
        }

        /// <summary>
        /// API name: get_active_votes
        /// *Displays the list of users who voted for the specified entry
        /// 
        /// </summary>
        /// <param name="author">API type: std::string</param>
        /// <param name="permlink">API type: std::string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: vote_state if permlink is "" then it will return all votes for author</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<VoteState[]> GetActiveVotes(string author, string permlink, CancellationToken token)
        {
            return CustomGetRequest<VoteState[]>(KnownApiNames.SocialNetworkApi, "get_active_votes", new object[] { author, permlink }, token);
        }

        /// <summary>
        /// API name: get_account_votes
        /// *Displays all the voices that are displayed by the specified user
        /// 
        /// </summary>
        /// <param name="voter">API type: std::string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_vote</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountVote[]> GetAccountVotes(string voter, CancellationToken token)
        {
            return CustomGetRequest<AccountVote[]>(KnownApiNames.SocialNetworkApi, "get_account_votes", new object[] { voter }, token);
        }

        /// <summary>
        /// API name: get_content
        /// *Gets information about the publication, with the exception of comments
        /// 
        /// </summary>
        /// <param name="author">API type: std::string</param>
        /// <param name="permlink">API type: std::string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion> GetContent(string author, string permlink, CancellationToken token)
        {
            return CustomGetRequest<Discussion>(KnownApiNames.SocialNetworkApi, "get_content", new object[] { author, permlink }, token);
        }

        /// <summary>
        /// API name: get_content_replies
        /// *Displays a list of all comments for the selected publication
        /// 
        /// </summary>
        /// <param name="parent">API type: std::string</param>
        /// <param name="parentPermlink">API type: std::string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetContentReplies(string parent, string parentPermlink, CancellationToken token)
        {
            return CustomGetRequest<Discussion[]>(KnownApiNames.SocialNetworkApi, "get_content_replies", new object[] { parent, parentPermlink }, token);
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
            return CustomGetRequest<MapContainer<string, UInt32>>(KnownApiNames.SocialNetworkApi, "get_tags_used_by_author", new object[] { author }, token);
        }

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
            return CustomGetRequest<Discussion[]>(KnownApiNames.SocialNetworkApi, "get_discussions_by_trending", new object[] { query }, token);
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
            return CustomGetRequest<Discussion[]>(KnownApiNames.SocialNetworkApi, "get_discussions_by_created", new object[] { query }, token);
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
            return CustomGetRequest<Discussion[]>(KnownApiNames.SocialNetworkApi, "get_discussions_by_active", new object[] { query }, token);
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
            return CustomGetRequest<Discussion[]>(KnownApiNames.SocialNetworkApi, "get_discussions_by_cashout", new object[] { query }, token);
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
            return CustomGetRequest<Discussion[]>(KnownApiNames.SocialNetworkApi, "get_discussions_by_payout", new object[] { query }, token);
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
            return CustomGetRequest<Discussion[]>(KnownApiNames.SocialNetworkApi, "get_discussions_by_votes", new object[] { query }, token);
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
            return CustomGetRequest<Discussion[]>(KnownApiNames.SocialNetworkApi, "get_discussions_by_hot", new object[] { query }, token);
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
            return CustomGetRequest<Discussion[]>(KnownApiNames.SocialNetworkApi, "get_discussions_by_feed", new object[] { query }, token);
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
            return CustomGetRequest<Discussion[]>(KnownApiNames.SocialNetworkApi, "get_discussions_by_blog", new object[] { query }, token);
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
            return CustomGetRequest<Discussion[]>(KnownApiNames.SocialNetworkApi, "get_discussions_by_comments", new object[] { query }, token);
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
            return CustomGetRequest<Discussion[]>(KnownApiNames.SocialNetworkApi, "get_discussions_by_promoted", new object[] { query }, token);
        }



        /// <summary>
        /// API name: get_replies_by_last_update
        /// *Return the active discussions with the highest cumulative pending payouts without respect to category, total  pending payout means the pending payout of all children as well.
        /// 
        /// </summary>
        /// <param name="startAuthor">API type: account_name_type</param>
        /// <param name="startPermlink">API type: std::string</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion Return the active discussions with the highest cumulative pending payouts without respect to category, total
        /// pending payout means the pending payout of all children as well.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetRepliesByLastUpdate(string startAuthor, string startPermlink, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<Discussion[]>(KnownApiNames.SocialNetworkApi, "get_replies_by_last_update", new object[] { startAuthor, startPermlink, limit }, token);
        }

        /// <summary>
        /// API name: get_discussions_by_author_before_date
        /// This method is used to fetch all posts/comments by start_author that occur after before_date and start_permlink with up to limit being returned.
        /// 
        /// If start_permlink is empty then only before_date will be considered. If both are specified the eariler to the two metrics will be used. This
        /// should allow easy pagination.
        ///
        /// *Displays a limited number of user publications
        /// 
        /// </summary>
        /// <param name="author">API type: std::string</param>
        /// <param name="startPermlink">API type: std::string</param>
        /// <param name="beforeDate">API type: time_point_sec</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetDiscussionsByAuthorBeforeDate(string author, string startPermlink, DateTime beforeDate, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<Discussion[]>(KnownApiNames.SocialNetworkApi, "get_discussions_by_author_before_date", new object[] { author, startPermlink, beforeDate, limit }, token);
        }

        /// <summary>
        /// API name: get_all_content_replies
        /// 
        /// </summary>
        /// <param name="author">API type: std::string</param>
        /// <param name="permlink">API type: std::string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<Discussion[]> GetAllContentReplies(string author, string permlink, CancellationToken token)
        {
            return CustomGetRequest<Discussion[]>(KnownApiNames.SocialNetworkApi, "get_all_content_replies", new object[] { author, permlink }, token);
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
            return CustomGetRequest<Discussion[]>(KnownApiNames.SocialNetworkApi, "get_discussions_by_children", new object[] { query }, token);
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
            return CustomGetRequest<JObject>(KnownApiNames.SocialNetworkApi, "get_languages", token);
        }
    }
}