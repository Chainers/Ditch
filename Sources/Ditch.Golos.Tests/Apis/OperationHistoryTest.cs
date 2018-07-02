using System.Threading;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class OperationHistoryTest : BaseTest
    {
        [Test]
        public void get_ops_in_block()
        {
            uint id = 26;
            var resp = Api.GetOpsInBlock(id, false, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test]
        public void get_transaction()
        {
            uint id = 26;
            var ops = Api.GetOpsInBlock(id, false, CancellationToken.None);
            var trxId = ops.Result[0].TrxId;

            var resp = Api.GetTransaction(trxId, CancellationToken.None);
            TestPropetries(resp);
        }
    }
}

