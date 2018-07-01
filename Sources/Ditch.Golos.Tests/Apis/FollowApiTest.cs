using System.Linq;
using System.Threading;
using Ditch.Golos.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class FollowApiTest : BaseTest
    {
        [Test]
        public void get_account_reputations()
        {
            var resp = Api.GetAccountReputations(User.Login, 10, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_blog()
        {
            var resp = Api.GetBlog(User.Login, 0, 10, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_blog_authors()
        {
            var resp = Api.GetBlogAuthors(User.Login, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_blog_entries()
        {
            var resp = Api.GetBlogEntries(User.Login, 0, 10, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_feed()
        {
            var resp = Api.GetFeed(User.Login, 0, 10, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_feed_entries()
        {
            var resp = Api.GetFeedEntries(User.Login, 0, 10, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_follow_count()
        {
            var resp = Api.GetFollowCount(User.Login, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_followers()
        {
            ushort count = 3;
            var resp = Api.GetFollowers(User.Login, string.Empty, FollowType.Blog, count, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
            Assert.IsTrue(resp.Result.Length <= count);

            var respNext = Api.GetFollowers(User.Login, resp.Result.Last().Follower, FollowType.Blog, count, CancellationToken.None);
            WriteLine(respNext);
            Assert.IsFalse(respNext.IsError);
            Assert.IsTrue(respNext.Result.Length <= count);
            Assert.IsTrue(respNext.Result.First().Follower == resp.Result.Last().Follower);

            TestPropetries(resp);
        }

        [Test]
        public void get_following()
        {
            ushort count = 3;
            var resp = Api.GetFollowing(User.Login, string.Empty, FollowType.Blog, count, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
            Assert.IsTrue(resp.Result.Length <= count);

            var respNext = Api.GetFollowing(User.Login, resp.Result.Last().Following, FollowType.Blog, count, CancellationToken.None);
            WriteLine(respNext);
            Assert.IsFalse(respNext.IsError);
            Assert.IsTrue(respNext.Result.Length <= count);
            Assert.IsTrue(respNext.Result.First().Following == resp.Result.Last().Following);

            TestPropetries(resp);
        }

        [Test]
        public void get_reblogged_by()
        {
            var resp = Api.GetRebloggedBy("korzunav", "ditch-zanyala-prizovoe-mesto-2017-12-10-22-48-17", CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }
    }
}
