using System;
using System.Threading;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class AccountByKeyApiTest : BaseTest
    {
        [Test]
        public void get_key_references()
        {
            var respTest = Api.GetAccounts(new[] { User.Login }, CancellationToken.None);
            var pKey = respTest.Result[0].Owner.KeyAuths;
            var resp = Api.GetKeyReferences(new[] { pKey[0].Key }, CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);
        }
    }
}
