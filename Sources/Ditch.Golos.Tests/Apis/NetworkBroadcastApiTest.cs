using System;
using System.Threading;
using Ditch.Golos.Models.Enums;
using Ditch.Golos.Models.Operations;
using Ditch.Golos.Models.Other;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class NetworkBroadcastApiTest : BaseTest
    {
        [Test]
        [Ignore("Real transaction")]
        public void broadcast_transaction()
        {
            var user = User;
            var autor = "steepshot";

            var op = new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            var prop = Api.GetDynamicGlobalProperties(CancellationToken.None);
            var transaction = Api.CreateTransaction(prop.Result, user.PostingKeys, CancellationToken.None, op);

            var resp = Api.BroadcastTransaction(transaction, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        [Ignore("Real transaction")]
        public void broadcast_transaction_synchronous()
        {
            var user = User;
            var autor = "steepshot";

            var op = new FollowOperation(user.Login, autor, FollowType.Blog, user.Login);
            var prop = Api.GetDynamicGlobalProperties(CancellationToken.None);
            var transaction = Api.CreateTransaction(prop.Result, user.PostingKeys, CancellationToken.None, op);

            var resp = Api.BroadcastTransactionSynchronous(transaction, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        [Ignore("Real transaction")]
        public void broadcast_block()
        {
            var resp = Api.BroadcastBlock(new SignedBlock(), CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }
    }
}
