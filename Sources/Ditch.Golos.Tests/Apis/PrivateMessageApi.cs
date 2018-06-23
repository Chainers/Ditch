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
            var resp = Api.GetInbox(User.Login, new DateTime(2017, 1, 1), 10, CancellationToken.None);
            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.PrivateMessage, "get_inbox", new object[] { User.Login, new DateTime(2017, 1, 1), 10 }, CancellationToken.None);
            TestPropetries(resp, obj);
        }

        [Test]
        public void get_outbox()
        {
            var resp = Api.GetOutbox(User.Login, new DateTime(2017, 1, 1), 10, CancellationToken.None);
            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.PrivateMessage, "get_outbox", new object[] { User.Login, new DateTime(2017, 1, 1), 10 }, CancellationToken.None);
            TestPropetries(resp, obj);
        }
    }
}
