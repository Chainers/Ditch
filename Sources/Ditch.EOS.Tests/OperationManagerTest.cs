using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Ditch.EOS.Tests.Models;
using Ditch.EOS.Models;
using Ditch.Core.Helpers;

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


        [Test]
        public async Task GetAccountTest()
        {
            var accountParams = new GetAccountParams
            {
                AccountName = "test1"
            };
            var resp = await Api.GetAccount(accountParams, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsTrue(resp.IsSuccess);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));


            var obj = await Api.CustomPostRequest<JObject>("v1/chain/get_account", accountParams, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public async Task GetCodeTest()
        {
            var codeParams = new GetCodeParams
            {
                AccountName = "hackathon"
            };
            var resp = await Api.GetCode(codeParams, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsTrue(resp.IsSuccess);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = await Api.CustomPostRequest<JObject>("v1/chain/get_code", codeParams, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public async Task GetTableRowsTest()
        {
            var tableRowsParams = new GetTableRowsParams()
            {
                Scope = "inita",
                Code = "currency",
                Table = "account",
                Json = true,
                LowerBound = "0",
                UpperBound = "-1",
                Limit = 10,
            };
            var resp = await Api.GetTableRows(tableRowsParams, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsTrue(resp.IsSuccess);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = await Api.CustomPostRequest<JObject>("v1/chain/get_table_rows", tableRowsParams, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public async Task AbiJsonToBinTest()
        {
            var abiJsonToBinParams = new AbiJsonToBinParams
            {
                Code = "hackathon",
                Action = "transfer",
                Args = new Transfer
                {
                    From = "test1",
                    To = "test1",
                    Amount = "1000 VIM",
                }
            };

            var resp = await Api.AbiJsonToBin(abiJsonToBinParams, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsTrue(resp.IsSuccess);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = await Api.CustomPostRequest<JObject>("v1/chain/abi_json_to_bin", abiJsonToBinParams, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public async Task GetRequiredKeysTest()
        {
            var infoResp = await Api.GetInfo(CancellationToken.None);
            var info = infoResp.Result;

            var getRequiredKeysParams = new GetRequiredKeysParams
            {
                Transaction = new Transaction
                {
                    Expiration = info.HeadBlockTime.AddSeconds(30),
                    Region = 0,
                    RefBlockNum = (ushort)(info.HeadBlockNum & 0xffff),
                    RefBlockPrefix = (uint)BitConverter.ToInt32(Hex.HexToBytes(info.HeadBlockId), 4),
                    MaxNetUsageWords = 0,
                    MaxKcpuUsage = 0,
                    DelaySec = 0,
                    ContextFreeActions = new EOS.Models.Action[0],
                    Actions = new[]
                    {
                        new EOS.Models.Action()
                        {
                            Account = "currency",
                            Name = "transfer",
                            Authorization = new[]
                            {
                                new PermissionLevel
                                {
                                    Actor = "currency",
                                    Permission = "active"
                                }
                            },
                            Data = "0000001e4d75af46000000008090b1ca4015e73b000000000456494d00000000",
                        }
                    }
                },
                AvailableKeys = new[] { "EOS6MRyAjQq8ud7hVNYcfnVPJqcVpscN5So8BhtHuGYqET5GDW5CV", "EOS7drQWvc7Mn7NK2PivjbAqLXMyBpvSNnZWnZC3CS61g1dhVK57o", "EOS8KLWY5tcczw6tTkk4UhfeZJrES7ECiFZAkChcR2mwsFcArURn7" }
            };
            var resp = await Api.GetRequiredKeys(getRequiredKeysParams, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsTrue(resp.IsSuccess);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = await Api.CustomPostRequest<JObject>("v1/chain/get_required_keys", getRequiredKeysParams, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }
    }
}
