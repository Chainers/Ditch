using System.Collections.Generic;
using System.Threading.Tasks;
using Ditch.EOS.Contracts.Eosio.Actions;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;
using Ditch.EOS.Tests.Apis;
using NUnit.Framework;

namespace Ditch.EOS.Tests.Examples
{
    [TestFixture]
    public class HowToRunCommandsFromContractTest : BaseTest
    {
        [Test]
        public async Task Buyram_SuccessTest()
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
        public async Task Delegatebw_SuccessTest()
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

        [Test]
        public async Task Undelegatebw_SuccessTest()
        {
            var op = new UndelegatebwAction
            {
                Account = UndelegatebwAction.ContractName,
                Args = new Undelegatebw
                {
                    From = User.Login,
                    Receiver = User.Login,
                    UnstakeCpuQuantity = new Asset("100.0000 EOS"),
                    UnstakeNetQuantity = new Asset("100.0000 EOS")
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

            var resp = await Api.BroadcastActionsAsync(new BaseAction[] { op }, new List<byte[]> { User.PrivateActiveKey }, CancellationToken).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }


        [Test]
        public async Task Transfer_SuccessTest()
        {
            var op = new Contracts.EosioToken.Actions.TransferAction
            {
                Account = "eosio.token",
                Args = new Contracts.EosioToken.Structs.Transfer
                {
                    From = User.Login,
                    To = "binancecleos",
                    Quantity = new Asset("100.0000 EOS"),
                    Memo = "000000000"
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
    }
}
