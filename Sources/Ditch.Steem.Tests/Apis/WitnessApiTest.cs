using System;
using System.Threading;
using Ditch.Steem.Models.Args;
using Ditch.Steem.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Steem.Tests.Apis
{
    [TestFixture]
    public class WitnessApiTest : BaseTest
    {
        [Test]
        public void get_account_bandwidth()
        {
            var args = new GetAccountBandwidthArgs()
            {
                Account = User.Login,
                Type = BandwidthType.Forum
            };
            var resp = Api.GetAccountBandwidth(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WitnessApi, "get_account_bandwidth", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        [Test]
        public void get_reserve_ratio()
        {
            var args = new GetReserveRatioArgs();
            var resp = Api.GetReserveRatio(args, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.WitnessApi, "get_reserve_ratio", args, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }
    }
}
