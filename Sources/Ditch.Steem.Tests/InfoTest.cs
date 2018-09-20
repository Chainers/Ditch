using System;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.JsonRpc;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Ditch.Steem.Tests
{
    [TestFixture]
    public class InfoTest : BaseTest
    {
        [Test]
        public async Task get_methods()
        {
            var resp = await Api.CustomGetRequestAsync<string[]>(KnownApiNames.JsonrpcApi, "get_methods", CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public async Task get_signature()
        {
            var resp = await Api.CustomGetRequestAsync<VoidResponse>(KnownApiNames.JsonrpcApi, "get_signature", new Method(KnownApiNames.DatabaseApi, "list_witness_votes"), CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
            WriteLine(JsonConvert.SerializeObject(resp.Result).Replace("\",\"", $"\",{Environment.NewLine}\""));
        }

        private class Method
        {
            [JsonProperty("method")]
            public string Name { get; set; }

            public Method(string name)
            {
                Name = name;
            }

            public Method(string api, string name)
            {
                Name = $"{api}.{name}";
            }
        }
    }
}
