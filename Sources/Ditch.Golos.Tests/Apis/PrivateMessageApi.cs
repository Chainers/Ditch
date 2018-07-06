using System;
using System.Threading;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class PrivateMessageApiTest : BaseTest
    {

        [Test]
        public void get_inbox()
        {
            var resp = Api.GetInbox(User.Login, new DateTime(2017, 1, 1), 10, 0, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_outbox()
        {
            var resp = Api.GetOutbox(User.Login, new DateTime(2017, 1, 1), 10, 0, CancellationToken.None);
            TestPropetries(resp);
        }
    }
}
