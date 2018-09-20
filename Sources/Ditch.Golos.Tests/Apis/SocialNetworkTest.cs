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
            var resp = await Api.GetActiveVotesAsync(User.Login, permlink, 100, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_account_votes()
        {
            var resp = await Api.GetAccountVotesAsync(User.Login, 100, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_content()
        {
            var author = "steepshot";
            var permlink = "znakomtes-steepshot-io";

            var resp = await Api.GetContentAsync(author, permlink, 100, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_content_replies()
        {
            var parent = "korzunav";
            var parentPermink = "ditch-na-blokchein-khakatone";

            var resp = await Api.GetContentRepliesAsync(parent, parentPermink, 100, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_replies_by_last_update()
        {
            var resp = await Api.GetRepliesByLastUpdateAsync(User.Login, string.Empty, 10, 100, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_all_content_replies()
        {
            var author = "korzunav";
            var post = "ditch-na-blokchein-khakatone";

            var resp = await Api.GetAllContentRepliesAsync(author, post, 1, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }
    }
}
