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
            uint id = 2;
            var resp = Api.GetOpsInBlock(id, false, CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.OperationHistory, "get_ops_in_block", new object[] { id, false }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_transaction()
        {
            uint id = 2;
            var ops = Api.GetOpsInBlock(id, false, CancellationToken.None);
            var trxId = ops.Result[0].TrxId;

            var resp = Api.GetTransaction(trxId, CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.OperationHistory, "get_transaction", new object[] { trxId }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }
    }
}

