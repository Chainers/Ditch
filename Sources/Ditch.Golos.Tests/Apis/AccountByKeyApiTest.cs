using System.Threading;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class AccountByKeyApiTest : BaseTest
    {
        [Test]
        public void get_key_references()
        {
            var respTest = Api.GetAccounts(new[] { User.Login }, CancellationToken.None);
            var pKey = respTest.Result[0].Owner.KeyAuths;
            var resp = Api.GetKeyReferences(new[] { pKey[0].Key }, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }
    }
}
