using System;
using System.Threading;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Ditch.Steem.Tests
{
    [TestFixture]
    public class AccountByKeyApiTest : BaseTest
    {

        [Test]
        public void get_key_references()
        {
            var pubKey = "STM6C8GjDBAHrfSqaNRn4FnLLUdCfw3WgjY3td1cC4T7CKpb32YM6";

            var resp = Api.GetKeyReferences(new[] { pubKey }, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }
    }
}
