using System;
using System.Threading;
using Ditch.Golos.Models.Other;
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
            var pKey = respTest.Result[0].Owner.KeyAuths[0][0] as string;
            var resp = Api.GetKeyReferences(new[] { new PublicKeyType(pKey), }, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }
    }
}
