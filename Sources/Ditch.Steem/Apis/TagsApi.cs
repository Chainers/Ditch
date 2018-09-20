using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Models;

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
        public Task<JsonRpcResponse<GetTrendingTagsReturn>> GetTrendingTagsAsync(GetTrendingTagsArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetTrendingTagsReturn>(KnownApiNames.TagsApi, "get_trending_tags", args, token);
        }

        /// <summary>
        /// API name: get_tags_used_by_author
        /// 
        /// </summary>
        /// <param name="args">API type: get_tags_used_by_author_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_tags_used_by_author_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetTagsUsedByAuthorReturn>> GetTagsUsedByAuthorAsync(GetTagsUsedByAuthorArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetTagsUsedByAuthorReturn>(KnownApiNames.TagsApi, "get_tags_used_by_author", args, token);
        }

        /// <summary>
        /// API name: get_discussion
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussion_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussion_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetDiscussionReturn>> GetDiscussionAsync(GetDiscussionArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetDiscussionReturn>(KnownApiNames.TagsApi, "get_discussion", args, token);
        }

        /// <summary>
        /// API name: get_content_replies
        /// 
        /// </summary>
        /// <param name="args">API type: get_content_replies_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_content_replies_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetContentRepliesReturn>> GetContentRepliesAsync(GetContentRepliesArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetContentRepliesReturn>(KnownApiNames.TagsApi, "get_content_replies", args, token);
        }

        /// <summary>
        /// API name: get_post_discussions_by_payout
        /// 
        /// </summary>
        /// <param name="args">API type: get_post_discussions_by_payout_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_post_discussions_by_payout_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetPostDiscussionsByPayoutReturn>> GetPostDiscussionsByPayoutAsync(GetPostDiscussionsByPayoutArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetPostDiscussionsByPayoutReturn>(KnownApiNames.TagsApi, "get_post_discussions_by_payout", args, token);
        }

        /// <summary>
        /// API name: get_comment_discussions_by_payout
        /// 
        /// </summary>
        /// <param name="args">API type: get_comment_discussions_by_payout_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_comment_discussions_by_payout_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetCommentDiscussionsByPayoutReturn>> GetCommentDiscussionsByPayoutAsync(GetCommentDiscussionsByPayoutArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetCommentDiscussionsByPayoutReturn>(KnownApiNames.TagsApi, "get_comment_discussions_by_payout", args, token);
        }

        /// <summary>
        /// API name: get_discussions_by_trending
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussions_by_trending_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussions_by_trending_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetDiscussionsByTrendingReturn>> GetDiscussionsByTrendingAsync(GetDiscussionsByTrendingArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetDiscussionsByTrendingReturn>(KnownApiNames.TagsApi, "get_discussions_by_trending", args, token);
        }

        /// <summary>
        /// API name: get_discussions_by_created
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussions_by_created_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussions_by_created_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetDiscussionsByCreatedReturn>> GetDiscussionsByCreatedAsync(GetDiscussionsByCreatedArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetDiscussionsByCreatedReturn>(KnownApiNames.TagsApi, "get_discussions_by_created", args, token);
        }

        /// <summary>
        /// API name: get_discussions_by_active
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussions_by_active_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussions_by_active_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetDiscussionsByActiveReturn>> GetDiscussionsByActiveAsync(GetDiscussionsByActiveArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetDiscussionsByActiveReturn>(KnownApiNames.TagsApi, "get_discussions_by_active", args, token);
        }

        /// <summary>
        /// API name: get_discussions_by_cashout
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussions_by_cashout_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussions_by_cashout_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetDiscussionsByCashoutReturn>> GetDiscussionsByCashoutAsync(GetDiscussionsByCashoutArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetDiscussionsByCashoutReturn>(KnownApiNames.TagsApi, "get_discussions_by_cashout", args, token);
        }

        /// <summary>
        /// API name: get_discussions_by_votes
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussions_by_votes_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussions_by_votes_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetDiscussionsByVotesReturn>> GetDiscussionsByVotesAsync(GetDiscussionsByVotesArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetDiscussionsByVotesReturn>(KnownApiNames.TagsApi, "get_discussions_by_votes", args, token);
        }

        /// <summary>
        /// API name: get_discussions_by_children
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussions_by_children_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussions_by_children_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetDiscussionsByChildrenReturn>> GetDiscussionsByChildrenAsync(GetDiscussionsByChildrenArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetDiscussionsByChildrenReturn>(KnownApiNames.TagsApi, "get_discussions_by_children", args, token);
        }

        /// <summary>
        /// API name: get_discussions_by_hot
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussions_by_hot_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussions_by_hot_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetDiscussionsByHotReturn>> GetDiscussionsByHotAsync(GetDiscussionsByHotArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetDiscussionsByHotReturn>(KnownApiNames.TagsApi, "get_discussions_by_hot", args, token);
        }

        /// <summary>
        /// API name: get_discussions_by_feed
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussions_by_feed_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussions_by_feed_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetDiscussionsByFeedReturn>> GetDiscussionsByFeedAsync(GetDiscussionsByFeedArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetDiscussionsByFeedReturn>(KnownApiNames.TagsApi, "get_discussions_by_feed", args, token);
        }

        /// <summary>
        /// API name: get_discussions_by_blog
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussions_by_blog_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussions_by_blog_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetDiscussionsByBlogReturn>> GetDiscussionsByBlogAsync(GetDiscussionsByBlogArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetDiscussionsByBlogReturn>(KnownApiNames.TagsApi, "get_discussions_by_blog", args, token);
        }

        /// <summary>
        /// API name: get_discussions_by_comments
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussions_by_comments_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussions_by_comments_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetDiscussionsByCommentsReturn>> GetDiscussionsByCommentsAsync(GetDiscussionsByCommentsArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetDiscussionsByCommentsReturn>(KnownApiNames.TagsApi, "get_discussions_by_comments", args, token);
        }

        /// <summary>
        /// API name: get_discussions_by_promoted
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussions_by_promoted_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussions_by_promoted_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetDiscussionsByPromotedReturn>> GetDiscussionsByPromotedAsync(GetDiscussionsByPromotedArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetDiscussionsByPromotedReturn>(KnownApiNames.TagsApi, "get_discussions_by_promoted", args, token);
        }

        /// <summary>
        /// API name: get_replies_by_last_update
        /// 
        /// </summary>
        /// <param name="args">API type: get_replies_by_last_update_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_replies_by_last_update_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetRepliesByLastUpdateReturn>> GetRepliesByLastUpdateAsync(GetRepliesByLastUpdateArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetRepliesByLastUpdateReturn>(KnownApiNames.TagsApi, "get_replies_by_last_update", args, token);
        }

        /// <summary>
        /// API name: get_discussions_by_author_before_date
        /// 
        /// </summary>
        /// <param name="args">API type: get_discussions_by_author_before_date_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_discussions_by_author_before_date_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetDiscussionsByAuthorBeforeDateReturn>> GetDiscussionsByAuthorBeforeDateAsync(GetDiscussionsByAuthorBeforeDateArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetDiscussionsByAuthorBeforeDateReturn>(KnownApiNames.TagsApi, "get_discussions_by_author_before_date", args, token);
        }

        /// <summary>
        /// API name: get_active_votes
        /// 
        /// </summary>
        /// <param name="args">API type: get_active_votes_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_active_votes_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetActiveVotesReturn>> GetActiveVotesAsync(GetActiveVotesArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetActiveVotesReturn>(KnownApiNames.TagsApi, "get_active_votes", args, token);
        }
    }
}
