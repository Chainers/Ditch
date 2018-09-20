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
            var resp = await Api.GetOpsInBlockAsync(id, false, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }

        [Test][Parallelizable]
        public async Task get_transaction()
        {
            uint id = 26;
            var ops = await Api.GetOpsInBlockAsync(id, false, CancellationToken.None).ConfigureAwait(false);
            var trxId = ops.Result[0].TrxId;

            var resp = await Api.GetTransactionAsync(trxId, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp);
        }
    }
}

