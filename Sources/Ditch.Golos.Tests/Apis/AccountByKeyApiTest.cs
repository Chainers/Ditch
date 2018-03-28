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
            var pubKey = new PublicKeyType("GLS5hVWAKDvt9HzxvXSY2HoJKQ5S4Ka1ZT8qqFVQBnx2wJ6aguwmD");

            var resp = Api.GetKeyReferences(new[] { pubKey }, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }
    }
}
