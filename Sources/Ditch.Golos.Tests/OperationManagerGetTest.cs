using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ditch.Golos.Operations;
using Ditch.Golos.Operations.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Golos.Tests
{
    [TestFixture]
    public class OperationManagerGetTest : BaseTest
    {

        [Test]
        public async Task TryConnectToTest()
        {
            var golos = new List<string> { "wss://ws.testnet.golos.io" };

            var manager = new OperationManager();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{i} conect to golos.");
                var url = manager.TryConnectTo(golos);
                Console.WriteLine($"{i} conected to {url}");
                await Task.Delay(3000);
            }
        }


        [Test]
        public void get_followers()
        {
            ushort count = 3;
            var resp = Api.GetFollowers(User.Login, string.Empty, FollowType.Blog, count);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Assert.IsTrue(resp.Result.Length <= count);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            var respNext = Api.GetFollowers(User.Login, resp.Result.Last().Follower, FollowType.Blog, count);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(respNext.IsError);
            Assert.IsTrue(respNext.Result.Length <= count);
            Assert.IsTrue(respNext.Result.First().Follower == resp.Result.Last().Follower);
            Console.WriteLine(JsonConvert.SerializeObject(respNext.Result));

            var obj = Api.CustomGetRequest<JObject[]>("call", "follow_api", "get_followers", new object[] { User.Login, resp.Result.Last().Follower, FollowType.Blog.ToString().ToLower(), count });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_following()
        {
            ushort count = 3;
            var resp = Api.GetFollowing(User.Login, string.Empty, FollowType.Blog, count);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            Assert.IsTrue(resp.Result.Length <= count);

            var respNext = Api.GetFollowing(User.Login, resp.Result.Last().Following, FollowType.Blog, count);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(respNext.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(respNext.Result));
            Assert.IsTrue(respNext.Result.Length <= count);
            Assert.IsTrue(respNext.Result.First().Following == resp.Result.Last().Following);

            var obj = Api.CustomGetRequest<JObject[]>("call", "follow_api", "get_following", new object[] { User.Login, resp.Result.Last().Follower, FollowType.Blog.ToString().ToLower(), count });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_order_book()
        {
            var resp = Api.GetOrderBook(3);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>("get_order_book", 3);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }
    }
}
