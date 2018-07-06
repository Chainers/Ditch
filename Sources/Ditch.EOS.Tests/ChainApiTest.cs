using System.Collections.Generic;
using System.Threading.Tasks;
using Ditch.EOS.Models;
using Ditch.EOS.Tests.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.EOS.Tests
{
    [TestFixture]
    public class ChainApiTest : BaseTest
    {
        const string CreatePostActionName = "createpost";

        [Test]
        public async Task GetInfoTest()
        {
            var resp = await Api.GetInfo(CancellationToken);
            TestPropetries(resp);
        }

        [Test]
        public async Task GetBlockTest()
        {
            var infoResp = await Api.GetInfo(CancellationToken);
            var info = infoResp.Result;

            var args = new GetBlockParams
            {
                BlockNumOrId = info.LastIrreversibleBlockId
            };

            var resp = await Api.GetBlock(args, CancellationToken);
            TestPropetries(resp);
        }

        [Test]
        public async Task GetAccountTest()
        {
            var accountParams = new GetAccountParams
            {
                AccountName = User.Login
            };

            var resp = await Api.GetAccount(accountParams, CancellationToken);
            TestPropetries(resp);
        }

        [Test]
        public async Task GetCodeTest()
        {
            var codeParams = new GetCodeParams
            {
                AccountName = User.Login
            };

            var resp = await Api.GetCode(codeParams, CancellationToken);
            TestPropetries(resp);
        }

        [Test]
        public async Task GetTableRowsTest()
        {
            var tableRowsParams = new GetTableRowsParams()
            {
                Scope = "test",
                Code = "test",
                Table = "posts",
                //Json = true,
                //LowerBound = "0",
                //UpperBound = "-1",
                //Limit = 10
            };

            var resp = await Api.GetTableRows(tableRowsParams, CancellationToken);
            TestPropetries(resp);
        }

        [Test]
        public async Task AbiJsonToBinTest()
        {
            var abiJsonToBinArgs = new AbiJsonToBinParams
            {
                Code = ContractInfo.ContractName,
                Action = CreatePostActionName,
                Args = new CreatePostArgs
                {
                    UrlPhoto = "test_1_url",
                    AccountCreator = User.Login,
                    IpfsHashPhoto = "test_1_hash",
                    //ParentPost = 1
                }
            };

            var resp = await Api.AbiJsonToBin(abiJsonToBinArgs, CancellationToken);
            TestPropetries(resp);
        }

        [Test]
        public async Task AbiBinToJsonTest()
        {
            var abiBinToJsonParams = new AbiBinToJsonParams
            {
                Code = ContractInfo.ContractName,
                Action = CreatePostActionName,
                Binargs = "000000000090b1ca0a746573745f315f75726c0b746573745f315f68617368"
            };

            var resp = await Api.AbiBinToJson(abiBinToJsonParams, CancellationToken);
            TestPropetries(resp);
        }

        [Test]
        public async Task PushTransactionTest()
        {
            var abiJsonToBinArgs = new AbiJsonToBinParams
            {
                Code = ContractInfo.ContractName,
                Action = CreatePostActionName,
                Args = new CreatePostArgs
                {
                    UrlPhoto = "test_1_url",
                    AccountCreator = User.Login,
                    IpfsHashPhoto = "test_1_hash",
                    //ParentPost = 1
                }
            };
            var abiJsonToBin = await Api.AbiJsonToBin(abiJsonToBinArgs, CancellationToken);
            Assert.IsFalse(abiJsonToBin.IsError);

            var args = new CreateTransactionArgs
            {
                Actions = new[]
                {
                    new Action
                    {
                        Account = User.Login,
                        Name = CreatePostActionName,
                        Authorization = new[]
                        {
                            new PermissionLevel
                            {
                                Actor = User.Login,
                                Permission = "active"
                            }
                        },
                        Data =  abiJsonToBin.Result.Binargs
                    }
                },
                PrivateKeys = new List<byte[]> { User.PrivateActiveKey }
            };

            var packedTransaction = await Api.CreatePackedTransaction(args, CancellationToken);

            var resp = await Api.PushTransaction(packedTransaction, CancellationToken);
            WriteLine(resp);

            Assert.IsFalse(resp.IsError);
        }

        //[Ignore("you need to put your own data")]
        //[Test]
        //public async Task GetRequiredKeysTest()
        //{
        //    var infoResp = await Api.GetInfo(CancellationToken);
        //    var info = infoResp.Result;

        //    var getRequiredKeysParams = new GetRequiredKeysParams
        //    {
        //        Transaction = new Transaction
        //        {
        //            Expiration = info.HeadBlockTime.Value.AddSeconds(30),
        //            Region = 0,
        //            RefBlockNum = (ushort)(info.HeadBlockNum & 0xffff),
        //            RefBlockPrefix = (uint)BitConverter.ToInt32(Hex.HexToBytes(info.HeadBlockId), 4),
        //            MaxNetUsageWords = 0,
        //            MaxKcpuUsage = 0,
        //            DelaySec = 0,
        //            ContextFreeActions = new Action[0],
        //            Actions = new[]
        //            {
        //                new Action
        //                {
        //                    Account = "hackathon",
        //                    Name = "transfer",
        //                    Authorization = new[]
        //                    {
        //                        new PermissionLevel
        //                        {
        //                            Actor = "test1",
        //                            Permission = "active"
        //                        }
        //                    },
        //                    Data = "000000008090b1ca000000008090b1cae8030000000000000056494d00000000"
        //                }
        //            }
        //        },
        //        AvailableKeys = new[] { "EOS6MRyAjQq8ud7hVNYcfnVPJqcVpscN5So8BhtHuGYqET5GDW5CV", "EOS7drQWvc7Mn7NK2PivjbAqLXMyBpvSNnZWnZC3CS61g1dhVK57o", "EOS8KLWY5tcczw6tTkk4UhfeZJrES7ECiFZAkChcR2mwsFcArURn7" }
        //    };

        //    var resp = await Api.GetRequiredKeys(getRequiredKeysParams, CancellationToken);
        //    var obj = await Api.CustomPostRequest<JObject>($"{ChainUrl}/v1/chain/get_required_keys", getRequiredKeysParams, CancellationToken);
        //    TestPropetries(resp);
        //}
    }
}
