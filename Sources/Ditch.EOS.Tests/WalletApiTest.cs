using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;

namespace Ditch.EOS.Tests
{
    [TestFixture]
    public class WalletApiTest : BaseTest
    {
        [Test]
        public async Task CreateTest()
        {
            var name = $"testname{DateTime.Now.ToString("yyyyMMddhhmmss")}";
            Console.WriteLine(name);
            var resp = await Api.WalletCreate(name, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsTrue(resp.IsSuccess);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

    }
}
