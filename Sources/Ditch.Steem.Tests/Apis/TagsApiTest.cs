using System;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Ditch.Steem.Models.Args;

namespace Ditch.Steem.Tests.Apis
{
    [TestFixture]
    public class TagsApiTest : BaseTest
    {

        [Test]
        public void get_trending_tags()
        {
            var args = new GetTrendingTagsArgs();
            var resp = Api.GetTrendingTags(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.TagsApi, "get_trending_tags", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_tags_used_by_author()
        {
            var args = new GetTagsUsedByAuthorArgs()
            {
                Author = User.Login
            };
            var resp = Api.GetTagsUsedByAuthor(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.TagsApi, "get_tags_used_by_author", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_discussion()
        {
            var args = new GetDiscussionArgs()
            {
                Author = "steepshot",
                Permlink = "let-s-make-steem-great-again-incentives-to-sponsors-announcement-from-steepshot",
            };
            var resp = Api.GetDiscussion(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.TagsApi, "get_discussion", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_content_replies()
        {
            var args = new GetContentRepliesArgs()
            {
                Author = "steepshot",
                Permlink = "let-s-make-steem-great-again-incentives-to-sponsors-announcement-from-steepshot",
            };
            var resp = Api.GetContentReplies(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.TagsApi, "get_content_replies", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_post_discussions_by_payout()
        {
            var args = new GetPostDiscussionsByPayoutArgs();
            var resp = Api.GetPostDiscussionsByPayout(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.TagsApi, "get_post_discussions_by_payout", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_comment_discussions_by_payout()
        {
            var args = new GetCommentDiscussionsByPayoutArgs();
            var resp = Api.GetCommentDiscussionsByPayout(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.TagsApi, "get_comment_discussions_by_payout", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_discussions_by_trending()
        {
            var args = new GetDiscussionsByTrendingArgs();
            var resp = Api.GetDiscussionsByTrending(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.TagsApi, "get_discussions_by_trending", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_discussions_by_created()
        {
            var args = new GetDiscussionsByCreatedArgs();
            var resp = Api.GetDiscussionsByCreated(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.TagsApi, "get_discussions_by_created", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_discussions_by_active()
        {
            var args = new GetDiscussionsByActiveArgs();
            var resp = Api.GetDiscussionsByActive(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.TagsApi, "get_discussions_by_active", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_discussions_by_cashout()
        {
            var args = new GetDiscussionsByCashoutArgs();
            var resp = Api.GetDiscussionsByCashout(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.TagsApi, "get_discussions_by_cashout", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_discussions_by_votes()
        {
            var args = new GetDiscussionsByVotesArgs();
            var resp = Api.GetDiscussionsByVotes(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.TagsApi, "get_discussions_by_votes", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_discussions_by_children()
        {
            var args = new GetDiscussionsByChildrenArgs();
            var resp = Api.GetDiscussionsByChildren(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.TagsApi, "get_discussions_by_children", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_discussions_by_hot()
        {
            var args = new GetDiscussionsByHotArgs();
            var resp = Api.GetDiscussionsByHot(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.TagsApi, "get_discussions_by_hot", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_discussions_by_feed()
        {
            var args = new GetDiscussionsByFeedArgs()
            {
                Tag = "photo",
                SelectAuthors = new[] {User.Login},
                FilterTags = new string[] {"steepshot"}
            };
            var resp = Api.GetDiscussionsByFeed(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.TagsApi, "get_discussions_by_feed", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_discussions_by_blog()
        {
            var args = new GetDiscussionsByBlogArgs()
            {
                Tag = "photo",
                SelectAuthors = new[] { User.Login },
                FilterTags = new string[] { "steepshot" }
            };
            var resp = Api.GetDiscussionsByBlog(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.TagsApi, "get_discussions_by_blog", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_discussions_by_comments()
        {
            var args = new GetDiscussionsByCommentsArgs()
            {
                StartAuthor = User.Login
            };
            var resp = Api.GetDiscussionsByComments(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.TagsApi, "get_discussions_by_comments", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_discussions_by_promoted()
        {
            var args = new GetDiscussionsByPromotedArgs()
            {
                ParentAuthor = "steepshot",
            };
            var resp = Api.GetDiscussionsByPromoted(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.TagsApi, "get_discussions_by_promoted", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_replies_by_last_update()
        {
            var args = new GetRepliesByLastUpdateArgs()
            {
                StartParentAuthor = "steepshot",
                StartPermlink = "let-s-make-steem-great-again-incentives-to-sponsors-announcement-from-steepshot",
                Limit = 3
            };
            var resp = Api.GetRepliesByLastUpdate(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.TagsApi, "get_replies_by_last_update", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_discussions_by_author_before_date()
        {
            var args = new GetDiscussionsByAuthorBeforeDateArgs()
            {
                Author = "steepshot",
                StartPermlink = "let-s-make-steem-great-again-incentives-to-sponsors-announcement-from-steepshot",
                BeforeDate = DateTime.Today,
                Limit = 3
            };
            var resp = Api.GetDiscussionsByAuthorBeforeDate(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.TagsApi, "get_discussions_by_author_before_date", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_active_votes()
        {
            var args = new GetActiveVotesArgs()
            {
                Permlink = "let-s-make-steem-great-again-incentives-to-sponsors-announcement-from-steepshot",
                Author = "steepshot"
            };
            var resp = Api.GetActiveVotes(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.TagsApi, "get_active_votes", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }
    }
}
