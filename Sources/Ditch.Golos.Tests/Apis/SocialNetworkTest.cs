using System.Linq;
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
            TestPropetries(resp);
        }

        [Test]
        public void get_account_votes()
        {
            var resp = Api.GetAccountVotes(User.Login, 100, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_content()
        {
            var author = "steepshot";
            var permlink = "znakomtes-steepshot-io";

            var resp = Api.GetContent(author, permlink, 100, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_content_replies()
        {
            var parent = "korzunav";
            var parentPermink = "ditch-na-blokchein-khakatone";

            var resp = Api.GetContentReplies(parent, parentPermink, 100, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_replies_by_last_update()
        {
            var resp = Api.GetRepliesByLastUpdate(User.Login, string.Empty, 10, 100, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_all_content_replies()
        {
            var author = "korzunav";
            var post = "ditch-na-blokchein-khakatone";

            var resp = Api.GetAllContentReplies(author, post, 1, CancellationToken.None);
            TestPropetries(resp);
        }
    }
}
