using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Models.Args;
using Ditch.Steem.Objects;

namespace Ditch.Steem
{
    /// <summary>
    /// tags_api
    /// libraries\plugins\apis\tags_api\include\steem\plugins\tags_api\tags_api.hpp
    /// </summary>
    public partial class OperationManager
    {
        /// <summary>
        /// API name: get_trending_tags
        /// 
        /// </summary>
        /// <param name="args">API type: get_trending_tags_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_trending_tags_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetTrendingTagsReturn> GetTrendingTags(GetTrendingTagsArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetTrendingTagsReturn>(KnownApiNames.TagsApi, "get_trending_tags", args, token);
        }

        /// <summary>
        /// API name: get_tags_used_by_author
        /// 
        /// </summary>
        /// <param name="args">API type: get_tags_used_by_author_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_tags_used_by_author_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetTagsUsedByAuthorReturn> GetTagsUsedByAuthor(GetTagsUsedByAuthorArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetTagsUsedByAuthorReturn>(KnownApiNames.TagsApi, "get_tags_used_by_author", args, token);
        }

        /// <summary>
        /// API name: get_discussion
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussion_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussion_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetDiscussionReturn> GetDiscussion(GetDiscussionArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetDiscussionReturn>(KnownApiNames.TagsApi, "get_discussion", args, token);
        }

        /// <summary>
        /// API name: get_content_replies
        /// 
        /// </summary>
        /// <param name="args">API type: get_content_replies_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_content_replies_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetContentRepliesReturn> GetContentReplies(GetContentRepliesArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetContentRepliesReturn>(KnownApiNames.TagsApi, "get_content_replies", args, token);
        }

        /// <summary>
        /// API name: get_post_discussions_by_payout
        /// 
        /// </summary>
        /// <param name="args">API type: get_post_discussions_by_payout_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_post_discussions_by_payout_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetPostDiscussionsByPayoutReturn> GetPostDiscussionsByPayout(GetPostDiscussionsByPayoutArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetPostDiscussionsByPayoutReturn>(KnownApiNames.TagsApi, "get_post_discussions_by_payout", args, token);
        }

        /// <summary>
        /// API name: get_comment_discussions_by_payout
        /// 
        /// </summary>
        /// <param name="args">API type: get_comment_discussions_by_payout_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_comment_discussions_by_payout_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetCommentDiscussionsByPayoutReturn> GetCommentDiscussionsByPayout(GetCommentDiscussionsByPayoutArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetCommentDiscussionsByPayoutReturn>(KnownApiNames.TagsApi, "get_comment_discussions_by_payout", args, token);
        }

        /// <summary>
        /// API name: get_discussions_by_trending
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussions_by_trending_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussions_by_trending_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetDiscussionsByTrendingReturn> GetDiscussionsByTrending(GetDiscussionsByTrendingArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetDiscussionsByTrendingReturn>(KnownApiNames.TagsApi, "get_discussions_by_trending", args, token);
        }

        /// <summary>
        /// API name: get_discussions_by_created
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussions_by_created_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussions_by_created_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetDiscussionsByCreatedReturn> GetDiscussionsByCreated(GetDiscussionsByCreatedArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetDiscussionsByCreatedReturn>(KnownApiNames.TagsApi, "get_discussions_by_created", args, token);
        }

        /// <summary>
        /// API name: get_discussions_by_active
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussions_by_active_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussions_by_active_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetDiscussionsByActiveReturn> GetDiscussionsByActive(GetDiscussionsByActiveArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetDiscussionsByActiveReturn>(KnownApiNames.TagsApi, "get_discussions_by_active", args, token);
        }

        /// <summary>
        /// API name: get_discussions_by_cashout
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussions_by_cashout_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussions_by_cashout_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetDiscussionsByCashoutReturn> GetDiscussionsByCashout(GetDiscussionsByCashoutArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetDiscussionsByCashoutReturn>(KnownApiNames.TagsApi, "get_discussions_by_cashout", args, token);
        }

        /// <summary>
        /// API name: get_discussions_by_votes
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussions_by_votes_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussions_by_votes_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetDiscussionsByVotesReturn> GetDiscussionsByVotes(GetDiscussionsByVotesArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetDiscussionsByVotesReturn>(KnownApiNames.TagsApi, "get_discussions_by_votes", args, token);
        }

        /// <summary>
        /// API name: get_discussions_by_children
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussions_by_children_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussions_by_children_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetDiscussionsByChildrenReturn> GetDiscussionsByChildren(GetDiscussionsByChildrenArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetDiscussionsByChildrenReturn>(KnownApiNames.TagsApi, "get_discussions_by_children", args, token);
        }

        /// <summary>
        /// API name: get_discussions_by_hot
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussions_by_hot_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussions_by_hot_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetDiscussionsByHotReturn> GetDiscussionsByHot(GetDiscussionsByHotArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetDiscussionsByHotReturn>(KnownApiNames.TagsApi, "get_discussions_by_hot", args, token);
        }

        /// <summary>
        /// API name: get_discussions_by_feed
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussions_by_feed_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussions_by_feed_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetDiscussionsByFeedReturn> GetDiscussionsByFeed(GetDiscussionsByFeedArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetDiscussionsByFeedReturn>(KnownApiNames.TagsApi, "get_discussions_by_feed", args, token);
        }

        /// <summary>
        /// API name: get_discussions_by_blog
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussions_by_blog_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussions_by_blog_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetDiscussionsByBlogReturn> GetDiscussionsByBlog(GetDiscussionsByBlogArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetDiscussionsByBlogReturn>(KnownApiNames.TagsApi, "get_discussions_by_blog", args, token);
        }

        /// <summary>
        /// API name: get_discussions_by_comments
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussions_by_comments_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussions_by_comments_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetDiscussionsByCommentsReturn> GetDiscussionsByComments(GetDiscussionsByCommentsArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetDiscussionsByCommentsReturn>(KnownApiNames.TagsApi, "get_discussions_by_comments", args, token);
        }

        /// <summary>
        /// API name: get_discussions_by_promoted
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussions_by_promoted_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussions_by_promoted_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetDiscussionsByPromotedReturn> GetDiscussionsByPromoted(GetDiscussionsByPromotedArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetDiscussionsByPromotedReturn>(KnownApiNames.TagsApi, "get_discussions_by_promoted", args, token);
        }

        /// <summary>
        /// API name: get_replies_by_last_update
        /// 
        /// </summary>
        /// <param name="args">API type: get_replies_by_last_update_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_replies_by_last_update_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetRepliesByLastUpdateReturn> GetRepliesByLastUpdate(GetRepliesByLastUpdateArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetRepliesByLastUpdateReturn>(KnownApiNames.TagsApi, "get_replies_by_last_update", args, token);
        }

        /// <summary>
        /// API name: get_discussions_by_author_before_date
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussions_by_author_before_date_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussions_by_author_before_date_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetDiscussionsByAuthorBeforeDateReturn> GetDiscussionsByAuthorBeforeDate(GetDiscussionsByAuthorBeforeDateArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetDiscussionsByAuthorBeforeDateReturn>(KnownApiNames.TagsApi, "get_discussions_by_author_before_date", args, token);
        }

        /// <summary>
        /// API name: get_active_votes
        /// 
        /// </summary>
        /// <param name="args">API type: get_active_votes_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_active_votes_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetActiveVotesReturn> GetActiveVotes(GetActiveVotesArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetActiveVotesReturn>(KnownApiNames.TagsApi, "get_active_votes", args, token);
        }
    }
}
