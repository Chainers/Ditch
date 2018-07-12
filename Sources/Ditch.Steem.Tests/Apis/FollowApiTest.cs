using System.Threading;
using System.Threading.Tasks;
using Ditch.Steem.Models;
using NUnit.Framework;

namespace Ditch.Steem.Tests.Apis
{
    [TestFixture]
    public class FollowApiTest : BaseTest
    {
        [Test][Parallelizable]
        public async Task get_followers()
        {
            var args = new GetFollowersArgs
            {
                Account = User.Login,
                Limit = 3,
                Start = string.Empty,
                Type = FollowType.Blog
            };
            var resp = await Api.GetFollowers(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_following()
        {
            var args = new GetFollowingArgs
            {
                Account = User.Login,
                Limit = 3,
                Start = string.Empty,
                Type = FollowType.Blog
            };
            var resp = await Api.GetFollowing(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_follow_count()
        {
            var args = new GetFollowCountArgs
            {
                Account = User.Login
            };
            var resp = await Api.GetFollowCount(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_feed_entries()
        {
            var args = new GetFeedEntriesArgs
            {
                Account = User.Login,
                StartEntryId = 0,
                Limit = 10
            };
            var resp = await Api.GetFeedEntries(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_feed()
        {
            var args = new GetFeedArgs
            {
                Account = User.Login,
                StartEntryId = 0,
                Limit = 10
            };
            var resp = await Api.GetFeed(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_blog_entries()
        {
            var args = new GetBlogEntriesArgs
            {
                Account = User.Login,
                StartEntryId = 0,
                Limit = 10
            };
            var resp = await Api.GetBlogEntries(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_blog()
        {
            var args = new GetBlogArgs
            {
                Account = User.Login,
                StartEntryId = 0,
                Limit = 10
            };
            var resp = await Api.GetBlog(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_account_reputations()
        {
            var args = new GetAccountReputationsArgs
            {
                AccountLowerBound = User.Login,
                Limit = 10
            };
            var resp = await Api.GetAccountReputations(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_reblogged_by()
        {
            var args = new GetRebloggedByArgs
            {
                Author = "steepshot",
                Permlink = "finally-arrived-steepshot-goes-to-beta-meet-the-updated-open-source-android-app"
            };
            var resp = await Api.GetRebloggedBy(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_blog_authors()
        {
            var args = new GetBlogAuthorsArgs
            {
                BlogAccount = User.Login
            };
            var resp = await Api.GetBlogAuthors(args, CancellationToken.None);
            TestPropetries(resp);
        }
    }
}
