using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Golos.Models;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class FollowApiTest : BaseTest
    {
        [Test][Parallelizable]
        public async Task get_account_reputations()
        {
            var resp = await Api.GetAccountReputations(User.Login, 10, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_blog()
        {
            var resp = await Api.GetBlog(User.Login, 0, 10, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_blog_authors()
        {
            var resp = await Api.GetBlogAuthors(User.Login, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_blog_entries()
        {
            var resp = await Api.GetBlogEntries(User.Login, 0, 10, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_feed()
        {
            var resp = await Api.GetFeed(User.Login, 0, 10, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_feed_entries()
        {
            var resp = await Api.GetFeedEntries(User.Login, 0, 10, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_follow_count()
        {
            var resp = await Api.GetFollowCount(User.Login, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_followers()
        {
            ushort count = 3;
            var resp = await Api.GetFollowers(User.Login, string.Empty, FollowType.Blog, count, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
            Assert.IsTrue(resp.Result.Length <= count);

            var respNext = await Api.GetFollowers(User.Login, resp.Result.Last().Follower, FollowType.Blog, count, CancellationToken.None);
            WriteLine(respNext);
            Assert.IsFalse(respNext.IsError);
            Assert.IsTrue(respNext.Result.Length <= count);
            Assert.IsTrue(respNext.Result.First().Follower == resp.Result.Last().Follower);

            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_following()
        {
            ushort count = 3;
            var resp = await Api.GetFollowing(User.Login, string.Empty, FollowType.Blog, count, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
            Assert.IsTrue(resp.Result.Length <= count);

            var respNext = await Api.GetFollowing(User.Login, resp.Result.Last().Following, FollowType.Blog, count, CancellationToken.None);
            WriteLine(respNext);
            Assert.IsFalse(respNext.IsError);
            Assert.IsTrue(respNext.Result.Length <= count);
            Assert.IsTrue(respNext.Result.First().Following == resp.Result.Last().Following);

            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_reblogged_by()
        {
            var resp = await Api.GetRebloggedBy("korzunav", "ditch-zanyala-prizovoe-mesto-2017-12-10-22-48-17", CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }
    }
}
