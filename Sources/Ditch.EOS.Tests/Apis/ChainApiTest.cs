using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ditch.EOS.Contracts.Eosio.Actions;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.EOS.Tests.Apis
{
    [TestFixture]
    public class ChainApiTest : BaseTest
    {
        [Test]
        public async Task GetInfoTest()
        {
            var resp = await Api.GetInfoAsync(CancellationToken).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        public async Task GetBlockTest()
        {
            var args = new GetBlockParams
            {
                BlockNumOrId = "4"
            };

            var resp = await Api.GetBlockAsync(args, CancellationToken).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        public async Task GetBlockHeaderStateTest()
        {
            var infoResp = await Api.GetInfoAsync(CancellationToken).ConfigureAwait(false);
            var info = infoResp.Result;

            var args = new GetBlockHeaderStateParams
            {
                BlockNumOrId = info.LastIrreversibleBlockId
            };

            var resp = await Api.GetBlockHeaderStateAsync(args, CancellationToken).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        public async Task GetAccountTest()
        {
            var args = new GetAccountParams
            {
                AccountName = User.Login
            };

            var resp = await Api.GetAccountAsync(args, CancellationToken).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [TestCase("eosio.token")]
        public async Task GetAbiTest(string accountName)
        {
            var args = new GetAbiParams
            {
                AccountName = accountName
            };

            var resp = await Api.GetAbiAsync(args, CancellationToken).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [Ignore("Feature is currently unsupported. Use get_abi instead.")]
        [TestCase("eosio.token")]
        public async Task GetCodeTest(string accountName)
        {
            var args = new GetCodeParams
            {
                AccountName = accountName
            };

            var resp = await Api.GetCodeAsync(args, CancellationToken).ConfigureAwait(false);
            Assert.IsFalse(resp.IsError, resp.Exception.ToString());
            WriteLine(resp.Result.Abi);
        }

        [Test]
        [TestCase("eosio")]
        public async Task GetRawCodeAndAbiTest(string accName)
        {
            var args = new GetRawCodeAndAbiParams
            {
                AccountName = accName
            };

            var resp = await Api.GetRawCodeAndAbiAsync(args, CancellationToken).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [TestCase("eosio", "eosio", "producers")]
        [TestCase("eosio.token", "ditchtest", "accounts")]
        public async Task GetTableRowsTest(string code, string scope, string table)
        {
            var args = new GetTableRowsParams
            {
                Code = code,
                Scope = scope,
                Table = table,
                Json = true,
                //LowerBound = "0",
                //UpperBound = "-1",
                //Limit = 10
            };

            var resp = await Api.GetTableRowsAsync(args, CancellationToken).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [TestCase("eosio.token", "exchange", "EOS")]
        public async Task GetCurrencyBalanceTest(string code, string account, string symbol)
        {
            var args = new GetCurrencyBalanceParams()
            {
                Code = code,
                Account = account,
                Symbol = symbol,
            };

            var resp = await Api.GetCurrencyBalanceAsync(args, CancellationToken).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        public async Task AbiJsonToBinTest()
        {
            var args = new AbiJsonToBinParams
            {
                Code = NewaccountAction.ContractName,
                Action = NewaccountAction.ActionName,
                Args = new Newaccount
                {
                    Creator = "eosio",
                    Newact = "qwdfvbmfkrt",
                    Owner = new Ditch.EOS.Contracts.Eosio.Structs.Authority
                    {
                        Threshold = 1,
                        Keys = new[] { new Ditch.EOS.Contracts.Eosio.Structs.KeyWeight
                        {
                            Key = new PublicKey("EOS6JQaiy5wpCvwyBauN4odnyqcutboxMk2bYkC3e2nmUubBsBbZ8"),
                            Weight = 1
                        } },
                        Accounts = new[] { new Ditch.EOS.Contracts.Eosio.Structs.PermissionLevelWeight
                        {
                            Weight = 1,
                            Permission = new PermissionLevel()
                            {
                                Permission = "owner",
                                Actor = "qwdfvbmfkrt"
                            }
                        } },
                        Waits = new[]
                        {
                            new WaitWeight()
                            {
                                Weight = 1,
                                WaitSec = 0
                            }
                        }
                    },
                    Active = new Ditch.EOS.Contracts.Eosio.Structs.Authority
                    {
                        Threshold = 1,
                        Keys = new[] { new Ditch.EOS.Contracts.Eosio.Structs.KeyWeight
                        {
                            Weight = 1,
                            Key = new PublicKey("EOS7z5qpGxAKZRgDmVCc2p5VZocumssfDoFMi5BNEsSocFWu4dXB2")
                        } },
                        Accounts = new[] { new Ditch.EOS.Contracts.Eosio.Structs.PermissionLevelWeight
                        {
                            Weight = 1,
                            Permission = new PermissionLevel()
                            {
                                Permission = "active",
                                Actor = "qwdfvbmfkrt"
                            }
                        } },
                        Waits = new[]
                        {
                            new WaitWeight()
                            {
                                Weight = 1,
                                WaitSec = 0
                            }
                        }
                    }
                }
            };

            var resp = await Api.AbiJsonToBinAsync(args, CancellationToken).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        public async Task AbiBinToJsonTest()
        {
            var args = new AbiBinToJsonParams
            {
                Code = NewaccountAction.ContractName,
                Action = NewaccountAction.ActionName,
                Binargs = "0000000000ea305500f2854b9ebd12b701000000010002ba0115bf16dbe4bc5f8bf66ffbfd86f879aa729054f31176a80b98326ce5400001000100f2854b9ebd12b70000000080ab26a70100010000000001000100000001000397caa58c9aed5159cad3d2d5ce19e98d7308fe7fa2c0ad6071ab6244c8f3cc2401000100f2854b9ebd12b700000000a8ed3232010001000000000100"
            };

            var resp = await Api.AbiBinToJsonAsync(args, CancellationToken).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        [TestCase("eosio.token", "EOS")]
        public async Task GetCurrencyStatsTest(string contractName, string symbol)
        {
            var args = new GetCurrencyStatsParams()
            {
                Code = contractName,
                Symbol = symbol
            };

            var resp = await Api.GetCurrencyStatsAsync(args, CancellationToken).ConfigureAwait(false);
            //TestPropetries(resp);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public async Task GetProducersTest()
        {
            var args = new GetProducersParams()
            {
                Limit = 50,
                Json = true
            };

            var resp = await Api.GetProducersAsync(args, CancellationToken).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test]
        public async Task BroadcastBuyramActionTest()
        {
            var op = new BuyramAction
            {
                Account = BuyramAction.ContractName,

                Args = new Buyram
                {
                    Payer = User.Login,
                    Receiver = User.Login,
                    Quant = new Asset("100.0000 EOS")

                },
                Authorization = new[]
                {
                    new PermissionLevel
                    {
                        Actor = User.Login,
                        Permission = "active"
                    }
                }
            };

            var resp = await Api.BroadcastActionsAsync(new[] { op }, new List<byte[]> { User.PrivateActiveKey }, CancellationToken).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public async Task BroadcastDelegatebwActionTest()
        {
            var op = new DelegatebwAction
            {
                Account = DelegatebwAction.ContractName,

                Args = new Delegatebw
                {
                    From = User.Login,
                    Receiver = User.Login,
                    StakeCpuQuantity = new Asset("100.0000 EOS"),
                    StakeNetQuantity = new Asset("100.0000 EOS"),
                    Transfer = false
                },
                Authorization = new[]
                {
                    new PermissionLevel
                    {
                        Actor = User.Login,
                        Permission = "active"
                    }
                }
            };

            var resp = await Api.BroadcastActionsAsync(new[] { op }, new List<byte[]> { User.PrivateActiveKey }, CancellationToken).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        //[Ignore("you need to put your own data")]
        //[Test]
        //public async Task GetRequiredKeysTest()
        //{
        //    var infoResp = await Api.GetInfoAsync(CancellationToken).ConfigureAwait(false);
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

        //    var resp = await Api.GetRequiredKeysAsync(getRequiredKeysParams, CancellationToken).ConfigureAwait(false);
        //    var obj = await Api.CustomPostRequestAsync<JObject>($"{ChainUrl}/v1/chain/get_required_keys", getRequiredKeysParams, CancellationToken).ConfigureAwait(false);
        //    TestPropetries(resp);
        //}
    }
}
