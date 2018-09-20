using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class PrivateMessageApiTest : BaseTest
    {

        [Test][Parallelizable]
        public async Task get_inbox()
        {
            var resp = await Api.GetInboxAsync(User.Login, new DateTime(2017, 1, 1), 10, 0, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_outbox()
        {
            var resp = await Api.GetOutboxAsync(User.Login, new DateTime(2017, 1, 1), 10, 0, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }
    }
}
