using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Ditch.EOS.Tests
{
    [TestFixture]
    public class OperationManagerTest : BaseTest
    {

        [Test]
        public async Task GetInfoTest()
        {
            var resp = await Api.GetInfo(CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsTrue(resp.IsSuccess);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = await Api.CustomGetRequest<JObject>("v1/chain/get_info", CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public async Task GetBlockTest()
        {
            var block_num_or_id = "1";
            var resp = await Api.GetBlock(block_num_or_id, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsTrue(resp.IsSuccess);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var parameters = new Dictionary<string, object>()
            {
                {"block_num_or_id", block_num_or_id}
            };
            var obj = await Api.CustomPostRequest<JObject>("v1/chain/get_block", parameters, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }
    }
}
