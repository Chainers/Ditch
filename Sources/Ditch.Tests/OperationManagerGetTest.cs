using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ditch.Operations;
using Ditch.Operations.Enums;
using Ditch.Operations.Get;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Tests
{
    [TestFixture]
    public class OperationManagerGetTest : BaseTest
    {
        private readonly Dictionary<string, string> _login;
        private readonly Dictionary<string, ChainInfo> _chain;
        private readonly OperationManager _steem;
        private readonly OperationManager _golos;

        public OperationManagerGetTest()
        {
            _login = new Dictionary<string, string>()
            {
                {"Steem", "UserLogin"},
                {"Golos", "UserLogin"}
            };

            _chain = new Dictionary<string, ChainInfo>();

            var steemChainInfo = ChainManager.GetChainInfo(KnownChains.Steem);
            _chain.Add("Steem", steemChainInfo);
            _steem = new OperationManager(steemChainInfo.Url, steemChainInfo.ChainId);

            var golosChainInfo = ChainManager.GetChainInfo(KnownChains.Golos);
            _chain.Add("Golos", golosChainInfo);
            _golos = new OperationManager(golosChainInfo.Url, golosChainInfo.ChainId);
        }

        private OperationManager Manager(string name)
        {
            switch (name)
            {
                case "Steem":
                    return _steem;
                case "Golos":
                    return _golos;
                default:
                    return null;
            }
        }

        #region Get requests


        [Test, Sequential]
        public void get_dynamic_global_properties([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetDynamicGlobalProperties();
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject>("get_dynamic_global_properties");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public virtual void get_content(
            [Values("Steem", "Golos")] string name,
            [Values("steepshot", "golosmedia")] string author,
            [Values("c-lib-ditch-1-0-for-graphene-from-steepshot-team-under-the-mit-license", "psk38")] string permlink)
        {
            var resp = Manager(name).GetContent(author, permlink);
            Assert.IsTrue(resp != null);
            Assert.IsTrue(resp.Result != null);
            Assert.IsFalse(resp.IsError);

            var obj = Manager(name).CustomGetRequest<JObject>("call", (int)Api.DefaultApi, "get_content", new[] { author, permlink });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void help([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).CustomGetRequest<object>("help");
            Console.WriteLine(resp.Error);
            Console.WriteLine(resp.Result);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public void get_followers([Values("Steem", "Golos")] string name)
        {
            ushort count = 3;
            var resp = Manager(name).GetFollowers(_login[name], string.Empty, FollowType.blog, count);
            Assert.IsFalse(resp.IsError);
            Assert.IsTrue(resp.Result.Length <= count);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            var respNext = Manager(name).GetFollowers(_login[name], resp.Result.Last().Follower, FollowType.blog, count);
            Assert.IsFalse(respNext.IsError);
            Assert.IsTrue(respNext.Result.Length <= count);
            Assert.IsTrue(respNext.Result.First().Follower == resp.Result.Last().Follower);
            Console.WriteLine(JsonConvert.SerializeObject(respNext.Result));

            var obj = Manager(name).CustomGetRequest<JObject[]>("call", "follow_api", "get_followers", new object[] { _login[name], resp.Result.Last().Follower, FollowType.blog.ToString().ToLower(), count });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_following([Values("Steem", "Golos")] string name)
        {
            ushort count = 3;
            var resp = Manager(name).GetFollowing(_login[name], string.Empty, FollowType.blog, count);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            Assert.IsTrue(resp.Result.Length <= count);

            var respNext = Manager(name).GetFollowing(_login[name], resp.Result.Last().Following, FollowType.blog, count);
            Assert.IsFalse(respNext.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(respNext.Result));
            Assert.IsTrue(respNext.Result.Length <= count);
            Assert.IsTrue(respNext.Result.First().Following == resp.Result.Last().Following);

            var obj = Manager(name).CustomGetRequest<JObject[]>("call", "follow_api", "get_following", new object[] { _login[name], resp.Result.Last().Follower, FollowType.blog.ToString().ToLower(), count });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_discussions_by_author_before_date([Values("Steem", "Golos")] string name)
        {
            ushort count = 3;
            var dt = new DateTime(2017, 7, 1);
            var resp = Manager(name).GetDiscussionsByAuthorBeforeDate(_login[name], string.Empty, dt, count);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            Assert.IsTrue(resp.Result.Length <= count);

            var obj = Manager(name).CustomGetRequest<JObject[]>("get_discussions_by_author_before_date", _login[name], resp.Result[count - 1].Permlink, dt, count);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_state([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetState("path");
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject>("get_state", "[\"path\"]");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_config([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetConfig();
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_chain_properties([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetChainProperties();
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject>("get_chain_properties");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_feed_history([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetFeedHistory();
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject>("get_feed_history");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_current_median_history_price([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetCurrentMedianHistoryPrice();
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject>("get_current_median_history_price");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_witness_schedule([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetWitnessSchedule();
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject>("get_witness_schedule");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_hardfork_version([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetHardforkVersion();
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);
        }

        [Test]
        public void get_next_scheduled_hardfork([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetNextScheduledHardfork();
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject>("get_next_scheduled_hardfork");
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_key_references([Values("Steem", "Golos")] string name)
        {
            var acResp = Manager(name).GetAccounts(_login[name]);
            Assert.IsFalse(acResp.IsError);
            var ac = acResp.Result;
            Assert.IsTrue(ac.Length == 1);

            var resp = Manager(name).GetKeyReferences(new object[1][] { new[] { ac[0].Active } });
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_accounts([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetAccounts(_login[name]);

            Assert.IsFalse(resp.IsError, resp.GetErrorMessage());
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject[]>("get_accounts", new object[] { new[] { _login[name] } });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_account_references([Values("Steem", "Golos")] string name)
        {
            var ac = Manager(name).GetAccounts(_login[name]);
            Assert.IsFalse(ac.IsError);

            var resp = Manager(name).GetAccountReferences(ac.Result[0].Id);
            Console.WriteLine(resp.Error);
            Console.WriteLine(resp.Result);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public void lookup_account_names([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).LookupAccountNames(_login[name]);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject[]>("lookup_account_names", new object[] { new[] { _login[name] } });
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void lookup_accounts([Values("Steem", "Golos")] string name)
        {
            UInt32 limit = 3;
            var resp = Manager(name).LookupAccounts(_login[name], limit);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_account_count([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetAccountCount();
            Console.WriteLine(resp.Error);
            Console.WriteLine(resp.Result);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);
        }

        [Test]
        public void get_conversion_requests([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetConversionRequests(_login[name]);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject[]>("call", (int)Api.DefaultApi, "get_conversion_requests", _login[name]);
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        [Test]
        public void get_account_history([Values("Steem", "Golos")] string name)
        {
            UInt64 from = 3;
            UInt32 limit = 3;
            var resp = Manager(name).GetAccountHistory(_login[name], from, limit);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
        }

        [Test]
        public void get_owner_history([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).CustomGetRequest<object>("get_owner_history", _login[name]);
            Console.WriteLine(resp.Error);
            Console.WriteLine(resp.Result);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public void get_recovery_request([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).CustomGetRequest<object>("get_recovery_request", _login[name]);
            Console.WriteLine(resp.Error);
            Console.WriteLine(resp.Result);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public void get_withdraw_routes([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).CustomGetRequest<object>("get_withdraw_routes", _login[name], "incoming");
            Console.WriteLine(resp.Error);
            Console.WriteLine(resp.Result);
            Assert.IsFalse(resp.IsError);

            resp = Manager(name).CustomGetRequest<object>("get_withdraw_routes", _login[name], "outgoing");
            Console.WriteLine(resp.Error);
            Console.WriteLine(resp.Result);
            Assert.IsFalse(resp.IsError);

            resp = Manager(name).CustomGetRequest<object>("get_withdraw_routes", _login[name], "all");
            Console.WriteLine(resp.Error);
            Console.WriteLine(resp.Result);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        public void get_account_bandwidth([Values("Steem", "Golos")] string name)
        {
            var resp = Manager(name).GetAccountBandwidth(_login[name], BandwidthType.Post);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            resp = Manager(name).GetAccountBandwidth(_login[name], BandwidthType.Market);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            resp = Manager(name).GetAccountBandwidth(_login[name], BandwidthType.Forum);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));

            var obj = Manager(name).CustomGetRequest<JObject>("get_account_bandwidth", _login[name], BandwidthType.Forum.ToString().ToLower());
            TestPropetries(resp.Result.GetType(), obj.Result);
        }

        #endregion Get requests

        private void TestPropetries(Type type, JObject jObject)
        {
            var propNames = GetPropertyNames(type);

            var chSet = jObject.Children();

            List<string> msg = new List<string>();
            foreach (var jtoken in chSet)
            {
                if (!propNames.Contains(jtoken.Path))
                {
                    msg.Add($"Missing {jtoken}");
                }
            }

            if (msg.Any())
            {
                Assert.Fail($"Some properties ({msg.Count}) was missed! {Environment.NewLine} {string.Join(Environment.NewLine, msg)}");
            }
        }

        private void TestPropetries(Type type, JObject[] jObject)
        {
            if (jObject == null)
                throw new NullReferenceException("jObject");

            if (type.IsArray)
                TestPropetries(type.GetElementType(), jObject[0]);
            else
                throw new InvalidCastException();
        }

        private HashSet<string> GetPropertyNames(Type type)
        {
            var props = type.GetRuntimeProperties();
            var resp = new HashSet<string>();
            foreach (var prop in props)
            {
                var order = prop.GetCustomAttribute<JsonPropertyAttribute>();
                if (order != null)
                {
                    resp.Add(order.PropertyName);
                }
            }
            return resp;
        }
    }
}