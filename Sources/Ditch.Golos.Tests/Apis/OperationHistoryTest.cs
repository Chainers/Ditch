using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class OperationHistoryTest : BaseTest
    {
        [Test][Parallelizable]
        public async Task get_ops_in_block()
        {
            uint id = 26;
            var resp = await Api.GetOpsInBlock(id, false, CancellationToken.None);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_transaction()
        {
            uint id = 26;
            var ops = await Api.GetOpsInBlock(id, false, CancellationToken.None);
            var trxId = ops.Result[0].TrxId;

            var resp = await Api.GetTransaction(trxId, CancellationToken.None);
            TestPropetries(resp);
        }
    }
}

