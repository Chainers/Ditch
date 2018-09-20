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
            var resp = await Api.GetFollowersAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.GetFollowingAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_follow_count()
        {
            var args = new GetFollowCountArgs
            {
                Account = User.Login
            };
            var resp = await Api.GetFollowCountAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.GetFeedEntriesAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.GetFeedAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.GetBlogEntriesAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.GetBlogAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.GetAccountReputationsAsync(args, CancellationToken.None).ConfigureAwait(false);
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
            var resp = await Api.GetRebloggedByAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_blog_authors()
        {
            var args = new GetBlogAuthorsArgs
            {
                BlogAccount = User.Login
            };
            var resp = await Api.GetBlogAuthorsAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }
    }
}
