using System;
using System.Threading;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class TagsTest : BaseTest
    {
        [Test]
        public void get_trending_tags()
        {
            var resp = Api.GetTrendingTags(User.Login, 3, CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JObject[]>(KnownApiNames.Tags, "get_trending_tags", new object[] { User.Login, 3 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_tags_used_by_author()
        {
            var resp = Api.GetTagsUsedByAuthor(User.Login, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.Tags, "get_tags_used_by_author", new object[] { User.Login }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(obj);
        }

        [Test]
        public void get_languages()
        {
            var resp = Api.GetLanguages(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);
        }
    }
}
