using System.Threading;
using Ditch.Steem.Models;
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
            var args = new GetBlockHeaderArgs
            {
                BlockNum = 1
            };
            var resp = Api.GetBlockHeader(args, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_block()
        {
            var args = new GetBlockArgs
            {
                BlockNum = 1
            };
            var resp = Api.GetBlock(args, CancellationToken.None);
            TestPropetries(resp);
        }
    }
}
