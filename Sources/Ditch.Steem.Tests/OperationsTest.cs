using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Operations;
using NUnit.Framework;

namespace Ditch.Steem.Tests
{
    [TestFixture]
    public class OperationsTest : CondenserOperationsTest
    {
        protected override async Task Post(IList<byte[]> postingKeys, bool isNeedBroadcast, params BaseOperation[] op)
        {
            JsonRpcResponse response;
            if (isNeedBroadcast)
                response = await Api.BroadcastOperations(postingKeys, op, CancellationToken.None);
            else
                response = await Api.VerifyAuthority(postingKeys, op, CancellationToken.None);

            WriteLine(response);
            Assert.IsFalse(response.IsError);
        }
    }
}