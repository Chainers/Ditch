using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ditch.EOS.Models;
using Ditch.EOS.Tests.Apis;
using NUnit.Framework;

namespace Ditch.EOS.Tests
{
    [TestFixture]
    public class ApiContractToModelGenerator : BaseTest
    {
        [Test]
        [TestCase("eosio", @"D:\Projects\Chainers\Ditch\Sources\Ditch.EOS.Tests\Contracts\")]
        public async Task Generate(string contractName, string outDir)
        {
            var generator = new ContractCodeGenerator();
            await generator.Generate(Api, contractName, "Ditch.EOS.Contracts", outDir, new HashSet<string> { "newaccount" }, CancellationToken.None);
        }

    }
}
