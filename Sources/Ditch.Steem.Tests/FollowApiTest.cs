using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Ditch.Steem.Operations.Enums;
using System.Threading;
using System.Linq;

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

        //[Test]
        //public void get_followers()
        //{
        //    var resp = Api.GetFollowers();
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>("get_followers");
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //}
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
        //[Test]
        //public void get_following()
        //{
        //    var resp = Api.GetFollowing();
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>("get_following");
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //}

        //[Test]
        //public void get_follow_count()
        //{
        //    var resp = Api.GetFollowCount();
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>("get_follow_count");
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //}

        //[Test]
        //public void get_feed_entries()
        //{
        //    var resp = Api.GetFeedEntries();
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>("get_feed_entries");
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //}

        //[Test]
        //public void get_feed()
        //{
        //    var resp = Api.GetFeed();
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>("get_feed");
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //}

        //[Test]
        //public void get_blog_entries()
        //{
        //    var resp = Api.GetBlogEntries();
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>("get_blog_entries");
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //}

        //[Test]
        //public void get_blog()
        //{
        //    var resp = Api.GetBlog();
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>("get_blog");
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //}

        //[Test]
        //public void get_account_reputations()
        //{
        //    var resp = Api.GetAccountReputations();
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>("get_account_reputations");
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //}

        //[Test]
        //public void get_reblogged_by()
        //{
        //    var resp = Api.GetRebloggedBy();
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>("get_reblogged_by");
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //}

        //[Test]
        //public void get_blog_authors()
        //{
        //    var resp = Api.GetBlogAuthors();
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = Api.CustomGetRequest<JObject>("get_blog_authors");
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //}
    }
}
