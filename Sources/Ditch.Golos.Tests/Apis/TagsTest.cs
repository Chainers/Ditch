using System;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Golos.Models;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class TagsTest : BaseTest
    {
        [Test][Parallelizable]
        public async Task get_discussions_by_trending()
        {
            var query = new DiscussionQuery
            {
                TruncateBody = 1024,
                Limit = 2
            };
            var resp = await Api.GetDiscussionsByTrendingAsync(query, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_discussions_by_created()
        {
            var query = new DiscussionQuery
            {
                TruncateBody = 100,
                Limit = 2
            };

            var resp = await Api.GetDiscussionsByCreatedAsync(query, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_discussions_by_active()
        {
            var query = new DiscussionQuery
            {
                TruncateBody = 100,
                Limit = 2
            };
            var resp = await Api.GetDiscussionsByActiveAsync(query, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_discussions_by_cashout()
        {
            var query = new DiscussionQuery
            {
                TruncateBody = 100,
                Limit = 2
            };
            var resp = await Api.GetDiscussionsByCashoutAsync(query, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_discussions_by_payout()
        {
            var query = new DiscussionQuery
            {
                TruncateBody = 100,
                Limit = 2
            };
            var resp = await Api.GetDiscussionsByPayoutAsync(query, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_discussions_by_votes()
        {
            var query = new DiscussionQuery
            {
                TruncateBody = 100,
                Limit = 2
            };
            var resp = await Api.GetDiscussionsByVotesAsync(query, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_discussions_by_hot()
        {
            var query = new DiscussionQuery
            {
                TruncateBody = 100,
                Limit = 2
            };
            var resp = await Api.GetDiscussionsByHotAsync(query, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_discussions_by_feed()
        {
            var query = new DiscussionQuery
            {
                TruncateBody = 100,
                Limit = 2,
                SelectAuthors = new[] { User.Login }
            };
            var resp = await Api.GetDiscussionsByFeedAsync(query, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_discussions_by_blog()
        {
            var query = new DiscussionQuery
            {
                TruncateBody = 100,
                Limit = 2,
                SelectAuthors = new[] { User.Login }
            };
            var resp = await Api.GetDiscussionsByBlogAsync(query, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_discussions_by_comments()
        {
            var query = new DiscussionQuery
            {
                TruncateBody = 100,
                Limit = 2,
                StartAuthor = User.Login
            };
            var resp = await Api.GetDiscussionsByCommentsAsync(query, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_discussions_by_promoted()
        {
            var query = new DiscussionQuery
            {
                TruncateBody = 100,
                Limit = 2
            };
            var resp = await Api.GetDiscussionsByPromotedAsync(query, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_discussions_by_author_before_date()
        {
            ushort count = 3;
            var dt = DateTime.Now;
            var resp = await Api.GetDiscussionsByAuthorBeforeDateAsync(User.Login, string.Empty, dt, count, 100, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
            Assert.IsTrue(resp.Result.Length <= count);
        }

        [Test][Parallelizable]
        public async Task get_discussions_by_children()
        {
            var query = new DiscussionQuery
            {
                TruncateBody = 100,
                Limit = 2
            };

            var resp = await Api.GetDiscussionsByChildrenAsync(query, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_trending_tags()
        {
            var resp = await Api.GetTrendingTagsAsync(User.Login, 3, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_tags_used_by_author()
        {
            var resp = await Api.GetTagsUsedByAuthorAsync(User.Login, CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test][Parallelizable]
        public async Task get_languages()
        {
            var resp = await Api.GetLanguagesAsync(CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }
    }
}
