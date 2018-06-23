using System.Threading;
using Ditch.Golos.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class SocialNetworkTest : BaseTest
    {
        [Test]
        public void get_active_votes()
        {
            var permlink = "test";
            var resp = Api.GetActiveVotes(User.Login, permlink, 100, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_active_votes", new object[] { User.Login, permlink, 100 }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_account_votes()
        {
            var resp = Api.GetAccountVotes(User.Login, 100, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_account_votes", new object[] { User.Login, 100 }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_content()
        {
            var author = "steepshot";
            var permlink = "znakomtes-steepshot-io";

            var resp = Api.GetContent(author, permlink, 100, CancellationToken.None);
            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.SocialNetworkApi, "get_content", new object[] { author, permlink, 100 }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_content_replies()
        {
            var parent = "";
            var parentPermink = "";
            var resp = Api.GetContentReplies(parent, parentPermink, 100, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_content_replies", new object[] { parent, parentPermink, 100 }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_replies_by_last_update()
        {
            var resp = Api.GetRepliesByLastUpdate(User.Login, string.Empty, 10, 100, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_replies_by_last_update", new object[] { User.Login, string.Empty, 10, 100 }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_all_content_replies()
        {
            var query = new DiscussionQuery()
            {
                TruncateBody = 100,
                Limit = 2
            };

            var trending = Api.GetDiscussionsByTrending(query, CancellationToken.None);
            var post = trending.Result[0];

            var resp = Api.GetAllContentReplies(post.Author, post.Url, 100, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_all_content_replies", new object[] { User.Login, "spasibo-golos", 100 }, CancellationToken.None);
            TestPropetries(resp, obj);
        }
    }
}
