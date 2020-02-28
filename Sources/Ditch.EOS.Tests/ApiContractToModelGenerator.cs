using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ditch.EOS.Tests.Apis;
using NUnit.Framework;

namespace Ditch.EOS.Tests
{
    [TestFixture]
    public class ApiContractToModelGenerator : BaseTest
    {
        [Test]
        [TestCase("eosio", @"..\..\Contracts\", null)]
        [TestCase("eosio.token", @"..\..\Contracts\", null)]
        public async Task Generate(string contractName, string outDir, string[] set)
        {
            HashSet<string> actionFilter = null;
            if (set != null)
                actionFilter = new HashSet<string>(set);

            var currentDir = AppContext.BaseDirectory;
            outDir = $"{currentDir}{outDir}";

            var generator = new ContractCodeGenerator();
            await generator.GenerateAsync(Api, contractName, "Ditch.EOS.Contracts", outDir, actionFilter, CancellationToken.None).ConfigureAwait(false);
        }
    }
}
