using System.Threading.Tasks;
using Ditch.Core;
using Ditch.EOS.Models;
using Ditch.EOS.Tests.Apis;
using NUnit.Framework;

namespace Ditch.EOS.Tests
{

    [TestFixture()]
    public class ContractTest : BaseTest
    {
        [Test]
        public async Task CreateTest()
        {
            var op = new Operation
            {
                Account = User.Login,
                ContractName = User.Login,
                Name = "create",
                Authorization = new[]
                {
                    new PermissionLevel
                    {
                        Actor = User.Login,
                        Permission = "owner"
                    }
                },
                Args = new[] { User.Login, "1000000000.0000 TOM" }
            };
            var result = await Api.BroadcastOperations(new[] { op }, User.OwnerKeys, CancellationToken);
            WriteLine(result);
            Assert.IsFalse(result.IsError);
        }

        [Test]
        public async Task GetCurrency()
        {
            var args = new GetCurrencyStatsParams()
            {
                Code = User.Login,
                Symbol = "TOM"
            };

            var resp = await Api.GetCurrencyStats(args, CancellationToken);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public async Task IssueTestc()
        {
            var op = new Operation
            {
                Account = User.Login,
                ContractName = User.Login,
                Name = "issue",
                Authorization = new[]
                {
                    new PermissionLevel
                    {
                        Actor = User.Login,
                        Permission = "owner"
                    }
                },
                Args = new[] { "tez", "100.0000 TOM", "memo" }
            };
            var result = await Api.BroadcastOperations(new[] { op }, User.OwnerKeys, CancellationToken);
            WriteLine(result);
            Assert.IsFalse(result.IsError);
        }

        [Test]
        public async Task TransferTest()
        {
            var op = new Operation
            {
                Account = User.Login,
                ContractName = User.Login,
                Name = "transfer",
                Authorization = new[]
                {
                    new PermissionLevel
                    {
                        Actor = User.Login,
                        Permission = "owner"
                    }
                },
                Args = new[] { User.Login, "tez", "25.0000 TOM", "m" }
            };
            var result = await Api.BroadcastOperations(new[] { op }, User.OwnerKeys, CancellationToken);
            WriteLine(result);
            Assert.IsFalse(result.IsError);
        }
    }
}
