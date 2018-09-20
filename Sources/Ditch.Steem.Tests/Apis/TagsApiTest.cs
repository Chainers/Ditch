using System;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Steem.Models;
using NUnit.Framework;

namespace Ditch.Steem.Tests.Apis
{
    [TestFixture]
    public class TagsApiTest : BaseTest
    {

        [Test][Parallelizable]
        public async Task get_trending_tags()
        {
            var args = new GetTrendingTagsArgs();
            var resp = await Api.GetTrendingTagsAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_tags_used_by_author()
        {
            var args = new GetTagsUsedByAuthorArgs
            {
                Author = User.Login
            };
            var resp = await Api.GetTagsUsedByAuthorAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_discussion()
        {
            var args = new GetDiscussionArgs
            {
                Author = "steepshot",
                Permlink = "let-s-make-steem-great-again-incentives-to-sponsors-announcement-from-steepshot"
            };
            var resp = await Api.GetDiscussionAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_content_replies()
        {
            var args = new GetContentRepliesArgs
            {
                Author = "steepshot",
                Permlink = "let-s-make-steem-great-again-incentives-to-sponsors-announcement-from-steepshot"
            };
            var resp = await Api.GetContentRepliesAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_post_discussions_by_payout()
        {
            var args = new GetPostDiscussionsByPayoutArgs();
            var resp = await Api.GetPostDiscussionsByPayoutAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_comment_discussions_by_payout()
        {
            var args = new GetCommentDiscussionsByPayoutArgs();
            var resp = await Api.GetCommentDiscussionsByPayoutAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_discussions_by_trending()
        {
            var args = new GetDiscussionsByTrendingArgs();
            var resp = await Api.GetDiscussionsByTrendingAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_discussions_by_created()
        {
            var args = new GetDiscussionsByCreatedArgs();
            var resp = await Api.GetDiscussionsByCreatedAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_discussions_by_active()
        {
            var args = new GetDiscussionsByActiveArgs();
            var resp = await Api.GetDiscussionsByActiveAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_discussions_by_cashout()
        {
            var args = new GetDiscussionsByCashoutArgs();
            var resp = await Api.GetDiscussionsByCashoutAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_discussions_by_votes()
        {
            var args = new GetDiscussionsByVotesArgs();
            var resp = await Api.GetDiscussionsByVotesAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_discussions_by_children()
        {
            var args = new GetDiscussionsByChildrenArgs();
            var resp = await Api.GetDiscussionsByChildrenAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_discussions_by_hot()
        {
            var args = new GetDiscussionsByHotArgs();
            var resp = await Api.GetDiscussionsByHotAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_discussions_by_feed()
        {
            var args = new GetDiscussionsByFeedArgs
            {
                Tag = "photo",
                SelectAuthors = new[] {User.Login},
                FilterTags = new[] {"steepshot"}
            };
            var resp = await Api.GetDiscussionsByFeedAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_discussions_by_blog()
        {
            var args = new GetDiscussionsByBlogArgs
            {
                Tag = "photo",
                SelectAuthors = new[] { User.Login },
                FilterTags = new[] { "steepshot" }
            };
            var resp = await Api.GetDiscussionsByBlogAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_discussions_by_comments()
        {
            var args = new GetDiscussionsByCommentsArgs
            {
                StartAuthor = User.Login
            };
            var resp = await Api.GetDiscussionsByCommentsAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_discussions_by_promoted()
        {
            var args = new GetDiscussionsByPromotedArgs
            {
                ParentAuthor = "steepshot"
            };
            var resp = await Api.GetDiscussionsByPromotedAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_replies_by_last_update()
        {
            var args = new GetRepliesByLastUpdateArgs
            {
                StartParentAuthor = "steepshot",
                StartPermlink = "let-s-make-steem-great-again-incentives-to-sponsors-announcement-from-steepshot",
                Limit = 3
            };
            var resp = await Api.GetRepliesByLastUpdateAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_discussions_by_author_before_date()
        {
            var args = new GetDiscussionsByAuthorBeforeDateArgs
            {
                Author = "steepshot",
                StartPermlink = "let-s-make-steem-great-again-incentives-to-sponsors-announcement-from-steepshot",
                BeforeDate = DateTime.Today,
                Limit = 3
            };
            var resp = await Api.GetDiscussionsByAuthorBeforeDateAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_active_votes()
        {
            var args = new GetActiveVotesArgs
            {
                Permlink = "let-s-make-steem-great-again-incentives-to-sponsors-announcement-from-steepshot",
                Author = "steepshot"
            };
            var resp = await Api.GetActiveVotesAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }
    }
}
