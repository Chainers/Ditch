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
    public class ChainApiTest : BaseTest
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
                Code = "hackathon",
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
        public async Task AbiBinToJsonTest()
        {
            var abiBinToJsonParams = new AbiBinToJsonParams()
            {
                Code = "hackathon",
                Action = "transfer",
                Binargs = "000000008090b1ca000000008090b1cae8030000000000000056494d00000000"
            };

            var resp = await Api.AbiBinToJson(abiBinToJsonParams, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsTrue(resp.IsSuccess);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = await Api.CustomPostRequest<JObject>("v1/chain/abi_bin_to_json", abiBinToJsonParams, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        //[Test]
        //public async Task PushTransactionTest()
        //{
        //    var infoResp = await Api.GetInfo(CancellationToken.None);
        //    var info = infoResp.Result;

        //    var pushTransactionParams = new SignedTransaction()
        //    {
        //        RefBlockNum = (ushort)(info.HeadBlockNum & 0xffff),
        //        RefBlockPrefix = (uint)BitConverter.ToInt32(Hex.HexToBytes(info.HeadBlockId), 4),
        //        Expiration = info.HeadBlockTime.AddSeconds(30),

        //        MaxNetUsageWords = 0,
        //        MaxKcpuUsage = 0,
        //        DelaySec = 0,
        //        ContextFreeActions = new EOS.Models.Action[0],
        //        Actions = new[]
        //        {
        //            new EOS.Models.Action()
        //            {
        //                Account = "hackathon",
        //                Name = "transfer",
        //                Authorization = new[]
        //                {
        //                    new PermissionLevel
        //                    {
        //                        Actor = "test1",
        //                        Permission = "active"
        //                    }
        //                },
        //                Data = "000000008090b1ca000000008090b1cae8030000000000000056494d00000000",
        //            }
        //        }
        //    };

        //    var resp = await Api.PushTransaction(pushTransactionParams, CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsTrue(resp.IsSuccess);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = await Api.CustomPostRequest<JObject>("v1/chain/push_transaction", pushTransactionParams, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

        //[Test]
        //public async Task PushTransactionsTest()
        //{
        //    var abiBinToJsonParams = new AbiBinToJsonParams()
        //    {
        //        Code = "hackathon",
        //        Action = "transfer",
        //        Binargs = "000000008090b1ca000000008090b1cae8030000000000000056494d00000000"
        //    };

        //    var resp = await Api.PushTransactions(null, CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsTrue(resp.IsSuccess);
        //    Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

        //    var obj = await Api.CustomPostRequest<JObject>("v1/chain/push_transactions", abiBinToJsonParams, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(JsonConvert.SerializeObject(obj));
        //}

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
                            Account = "hackathon",
                            Name = "transfer",
                            Authorization = new[]
                            {
                                new PermissionLevel
                                {
                                    Actor = "test1",
                                    Permission = "active"
                                }
                            },
                            Data = "000000008090b1ca000000008090b1cae8030000000000000056494d00000000",
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
