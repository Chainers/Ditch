using System;
using System.Threading;
using Ditch.Golos.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class TagsTest : BaseTest
    {
        private string ApiName = KnownApiNames.Tags;

        [Test]
        public void get_discussions_by_trending()
        {
            var query = new DiscussionQuery()
            {
                TruncateBody = 1024,
                Limit = 2
            };
            var resp = Api.GetDiscussionsByTrending(query, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(ApiName, "get_discussions_by_trending", new object[] { query }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_discussions_by_created()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };

            var resp = Api.GetDiscussionsByCreated(query, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(ApiName, "get_discussions_by_created", new object[] { query }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_discussions_by_active()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByActive(query, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(ApiName, "get_discussions_by_active", new object[] { query }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_discussions_by_cashout()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByCashout(query, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(ApiName, "get_discussions_by_cashout", new object[] { query }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_discussions_by_payout()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByPayout(query, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(ApiName, "get_discussions_by_payout", new object[] { query }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_discussions_by_votes()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByVotes(query, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(ApiName, "get_discussions_by_votes", new object[] { query }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_discussions_by_hot()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByHot(query, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(ApiName, "get_discussions_by_hot", new object[] { query }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_discussions_by_feed()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByFeed(query, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(ApiName, "get_discussions_by_feed", new object[] { query }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_discussions_by_blog()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByBlog(query, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(ApiName, "get_discussions_by_blog", new object[] { query }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_discussions_by_comments()
        {
            var query = new DiscussionQuery()
            {
                StartAuthor = User.Login
            };
            var resp = Api.GetDiscussionsByComments(query, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(ApiName, "get_discussions_by_comments", new object[] { query }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_discussions_by_promoted()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByPromoted(query, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(ApiName, "get_discussions_by_promoted", new object[] { query }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_discussions_by_author_before_date()
        {
            ushort count = 3;
            var dt = DateTime.Now;
            var resp = Api.GetDiscussionsByAuthorBeforeDate(User.Login, string.Empty, dt, count, 100, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(ApiName, "get_discussions_by_author_before_date", new object[] { User.Login, string.Empty, dt, count, 100 }, CancellationToken.None);
            TestPropetries(resp, obj);
            Assert.IsTrue(resp.Result.Length <= count);
        }

        [Test]
        public void get_discussions_by_children()
        {
            var query = new DiscussionQuery()
            {
                TruncateBody = 100,
                Limit = 2
            };

            var resp = Api.GetDiscussionsByChildren(query, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(ApiName, "get_discussions_by_children", new object[] { query }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_trending_tags()
        {
            var resp = Api.GetTrendingTags(User.Login, 3, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(ApiName, "get_trending_tags", new object[] { User.Login, 3 }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_tags_used_by_author()
        {
            var resp = Api.GetTagsUsedByAuthor(User.Login, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(ApiName, "get_tags_used_by_author", new object[] { User.Login }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_languages()
        {
            var resp = Api.GetLanguages(CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }
    }
}
