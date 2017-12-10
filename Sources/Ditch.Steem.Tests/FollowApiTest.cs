using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Ditch.Steem.Operations.Enums;
using System.Threading;
using System.Linq;
using Ditch.Steem.Operations;

namespace Ditch.Steem.Tests
{
    [TestFixture]
    public class FollowApiTest : BaseTest
    {

        //[Test]
        //public void on_api_startup()
        //{
        //    var resp = Api.OnApiStartup();
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>("on_api_startup");
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //}

        [Test]
        public void get_followers()
        {
            ushort count = 3;
            var resp = Api.GetFollowers(User.Login, string.Empty, FollowType.Blog, count, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Assert.IsTrue(resp.Result.Length <= count);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            var respNext = Api.GetFollowers(User.Login, resp.Result.Last().Follower, FollowType.Blog, count, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(respNext.IsError);
            Assert.IsTrue(respNext.Result.Length <= count);
            Assert.IsTrue(respNext.Result.First().Follower == resp.Result.Last().Follower);
            Console.WriteLine(JsonConvert.SerializeObject(respNext.Result));

            var obj = Api.CustomGetRequest<JObject[]>("call", CancellationToken.None, "follow_api", "get_followers", new object[] { User.Login, resp.Result.Last().Follower, FollowType.Blog.ToString().ToLower(), count });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_following()
        {
            ushort count = 3;
            var resp = Api.GetFollowing(User.Login, string.Empty, FollowType.Blog, count, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            Assert.IsTrue(resp.Result.Length <= count);

            var respNext = Api.GetFollowing(User.Login, resp.Result.Last().Following, FollowType.Blog, count, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(respNext.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(respNext.Result));
            Assert.IsTrue(respNext.Result.Length <= count);
            Assert.IsTrue(respNext.Result.First().Following == resp.Result.Last().Following);

            var obj = Api.CustomGetRequest<JObject[]>("call", CancellationToken.None, "follow_api", "get_following", new object[] { User.Login, resp.Result.Last().Follower, FollowType.Blog.ToString().ToLower(), count });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_follow_count()
        {
            var resp = Api.GetFollowCount(User.Login, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("call", CancellationToken.None, KnownApiNames.FollowApi, "get_follow_count", new object[] { User.Login });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_feed_entries()
        {
            var resp = Api.GetFeedEntries(User.Login, 0, 10, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JArray>("call", CancellationToken.None, KnownApiNames.FollowApi, "get_feed_entries", new object[] { User.Login, 0, 10 });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_feed()
        {
            var resp = Api.GetFeed(User.Login, 0, 10, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JArray>("call", CancellationToken.None, KnownApiNames.FollowApi, "get_feed", new object[] { User.Login, 0, 10 });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_blog_entries()
        {
            var resp = Api.GetBlogEntries(User.Login, 0, 10, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JArray>("call", CancellationToken.None, KnownApiNames.FollowApi, "get_blog_entries", new object[] { User.Login, 0, 10 });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_blog()
        {
            var resp = Api.GetBlog(User.Login, 0, 10, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JArray>("call", CancellationToken.None, KnownApiNames.FollowApi, "get_blog", new object[] { User.Login, 0, 10 });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_account_reputations()
        {
            var resp = Api.GetAccountReputations(User.Login, 10, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JArray>("call", CancellationToken.None, KnownApiNames.FollowApi, "get_account_reputations", new object[] { User.Login, 10 });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_reblogged_by()
        {
            var resp = Api.GetRebloggedBy("steepshot", "finally-arrived-steepshot-goes-to-beta-meet-the-updated-open-source-android-app", CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_blog_authors()
        {
            var resp = Api.GetBlogAuthors(User.Login, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            Assert.IsFalse(string.IsNullOrEmpty(resp.Result[0].Key));
        }
    }
}
