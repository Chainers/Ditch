using System;
using System.Threading;
using Ditch.Steem.Models.Args;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Steem.Tests.Apis
{
    [TestFixture]
    public class BlockApiTest : BaseTest
    {
        [Test]
        public void get_block_header()
        {
            var args = new GetBlockHeaderArgs()
            {
                BlockNum = 1
            };
            var resp = Api.GetBlockHeader(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.BlockApi, "get_block_header", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_block()
        {
            var args = new GetBlockArgs()
            {
                BlockNum = 1
            };
            var resp = Api.GetBlock(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.BlockApi, "get_block", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }
    }
}
