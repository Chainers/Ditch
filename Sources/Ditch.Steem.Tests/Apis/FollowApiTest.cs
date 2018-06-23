using System.Threading;
using Ditch.Steem.Models.Args;
using Ditch.Steem.Models.Enums;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Steem.Tests.Apis
{
    [TestFixture]
    public class FollowApiTest : BaseTest
    {
        [Test]
        public void get_followers()
        {
            var args = new GetFollowersArgs
            {
                Account = User.Login,
                Limit = 3,
                Start = string.Empty,
                Type = FollowType.Blog
            };
            var resp = Api.GetFollowers(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.FollowApi, "get_followers", args, CancellationToken.None);
            WriteLine(obj);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_following()
        {
            var args = new GetFollowingArgs
            {
                Account = User.Login,
                Limit = 3,
                Start = string.Empty,
                Type = FollowType.Blog
            };
            var resp = Api.GetFollowing(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.FollowApi, "get_following", args, CancellationToken.None);
            WriteLine(obj);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_follow_count()
        {
            var args = new GetFollowCountArgs
            {
                Account = User.Login
            };
            var resp = Api.GetFollowCount(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.FollowApi, "get_follow_count", args, CancellationToken.None);
            WriteLine(obj);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_feed_entries()
        {
            var args = new GetFeedEntriesArgs
            {
                Account = User.Login,
                StartEntryId = 0,
                Limit = 10
            };
            var resp = Api.GetFeedEntries(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.FollowApi, "get_feed_entries", args, CancellationToken.None);
            WriteLine(obj);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_feed()
        {
            var args = new GetFeedArgs
            {
                Account = User.Login,
                StartEntryId = 0,
                Limit = 10
            };
            var resp = Api.GetFeed(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.FollowApi, "get_feed", args, CancellationToken.None);
            WriteLine(obj);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_blog_entries()
        {
            var args = new GetBlogEntriesArgs
            {
                Account = User.Login,
                StartEntryId = 0,
                Limit = 10
            };
            var resp = Api.GetBlogEntries(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.FollowApi, "get_blog_entries", args, CancellationToken.None);
            WriteLine(obj);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_blog()
        {
            var args = new GetBlogArgs
            {
                Account = User.Login,
                StartEntryId = 0,
                Limit = 10
            };
            var resp = Api.GetBlog(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.FollowApi, "get_blog", args, CancellationToken.None);
            WriteLine(obj);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_account_reputations()
        {
            var args = new GetAccountReputationsArgs
            {
                AccountLowerBound = User.Login,
                Limit = 10
            };
            var resp = Api.GetAccountReputations(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.FollowApi, "get_account_reputations", args, CancellationToken.None);
            WriteLine(obj);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_reblogged_by()
        {
            var args = new GetRebloggedByArgs
            {
                Author = "steepshot",
                Permlink = "finally-arrived-steepshot-goes-to-beta-meet-the-updated-open-source-android-app"
            };
            var resp = Api.GetRebloggedBy(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.FollowApi, "get_reblogged_by", args, CancellationToken.None);
            WriteLine(obj);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_blog_authors()
        {
            var args = new GetBlogAuthorsArgs
            {
                BlogAccount = User.Login
            };
            var resp = Api.GetBlogAuthors(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.FollowApi, "get_blog_authors", args, CancellationToken.None);
            WriteLine(obj);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }
    }
}
