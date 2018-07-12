using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class SocialNetworkTest : BaseTest
    {
        [Test][Parallelizable]
        public async Task get_active_votes()
        {
            var permlink = "test";
            var resp = await Api.GetActiveVotes(User.Login, permlink, 100, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_account_votes()
        {
            var resp = await Api.GetAccountVotes(User.Login, 100, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_content()
        {
            var author = "steepshot";
            var permlink = "znakomtes-steepshot-io";

            var resp = await Api.GetContent(author, permlink, 100, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_content_replies()
        {
            var parent = "korzunav";
            var parentPermink = "ditch-na-blokchein-khakatone";

            var resp = await Api.GetContentReplies(parent, parentPermink, 100, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_replies_by_last_update()
        {
            var resp = await Api.GetRepliesByLastUpdate(User.Login, string.Empty, 10, 100, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_all_content_replies()
        {
            var author = "korzunav";
            var post = "ditch-na-blokchein-khakatone";

            var resp = await Api.GetAllContentReplies(author, post, 1, CancellationToken.None);
            TestPropetries(resp);
        }
    }
}
