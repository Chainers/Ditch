using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Ditch.Helpers;
using Ditch.Operations.Get;
using Ditch.Operations.Post;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Ditch.Tests {
   [TestFixture]
   public class OperationManagerTest: BaseTest {
      private readonly Dictionary<string, string> _login;
      private readonly Dictionary<string, List<byte[]>> _userPrivateKeys;
      private readonly Dictionary<string, ChainInfo> _chain;
      private readonly OperationManager _steem;
      private readonly OperationManager _golos;

      public OperationManagerTest() {
         _login = new Dictionary<string, string>()
         {
                { "Steem","Test Login" },
                { "Golos", Constants.GolosUser }
            };
         _userPrivateKeys = new Dictionary<string, List<byte[]>>()
         {
                { "Steem",new List<byte[]>{ Base58.GetBytes(Constants.SteemPostingKey) } },
                { "Golos",new List<byte[]>{ Base58.GetBytes(Constants.GolosPostingKey) } }
            };

<<<<<<< HEAD
         _chain = new Dictionary<string, ChainInfo>();

         var steemChainInfo = ChainManager.GetChainInfo(KnownChains.Steem);
         _chain.Add("Steem", steemChainInfo);
         _steem = new OperationManager(steemChainInfo.Url, steemChainInfo.ChainId);

         var golosChainInfo = ChainManager.GetChainInfo(KnownChains.Golos);
         _chain.Add("Golos", golosChainInfo);
         _golos = new OperationManager(golosChainInfo.Url, golosChainInfo.ChainId);
      }

      private OperationManager Manager(string name) {
         switch (name) {
            case "Steem":
               return _steem;
            case "Golos":
               return _golos;
            default:
               return null;
         }
      }


      [Test, Sequential]
      public void GetDynamicGlobalPropertiesTest([Values("Steem", "Golos")] string name) {
         var prop = Manager(name).GetDynamicGlobalProperties();
         Assert.IsTrue(prop != null);
         Assert.IsTrue(prop.Result != null);
         Assert.IsFalse(prop.IsError);
      }

      [Test]
      public virtual void GetContentTest(
          [Values("Steem", "Golos")] string name,
          [Values("steepshot", "golosmedia")] string author,
          [Values("c-lib-ditch-1-0-for-graphene-from-steepshot-team-under-the-mit-license", "psk38")] string permlink) {
         var prop = Manager(name).GetContent(author, permlink);
         Assert.IsTrue(prop != null);
         Assert.IsTrue(prop.Result != null);
         Assert.IsFalse(prop.IsError);
      }

      [Test]
      [TestCase("277.126 SBD")]
      public void ParseTestTest(string test) {
         var money = new Money(test, CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator, CultureInfo.InvariantCulture.NumberFormat.NumberGroupSeparator);
         Assert.IsTrue(money.Value == 277126);
         Assert.IsTrue(money.Precision == 3);
         Assert.IsTrue(money.Currency == "SBD");
      }

      [Test]
      public void GetHelp([Values("Steem", "Golos")] string name) {
         var rez = Manager(name).CustomGetRequest<object>("help");
         Console.WriteLine(rez.Error);
      }

      [Test]
      public void VerifyAuthoritySuccessTest([Values("Steem", "Golos")] string name) {
         var op = new FollowOperation(_login[name], "steepshot", FollowType.Blog, _login[name]);
         var rez = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
         Assert.IsFalse(rez.IsError, rez.GetErrorMessage());
         Assert.IsTrue(rez.Result);
      }

      [Test]
      public void VerifyAuthorityFallTest([Values("Steem", "Golos")] string name) {
         var op = new FollowOperation(_login[name], "steepshot", FollowType.Blog, "StubLogin");
         var rez = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
         Assert.IsTrue(rez.IsError);
      }

      [Test]
      public void GetAccountsTest([Values("Steem", "Golos")] string name) {
         var rez = Manager(name).GetAccounts(_login[name]);
         Assert.IsFalse(rez.IsError, rez.GetErrorMessage());
      }

      [Test]
      public void GetChainPropertiesHelp([Values("Steem", "Golos")] string name) {
         var rez = Manager(name).CustomGetRequest<object>("get_chain_properties");
         Console.WriteLine(rez.Error);
      }

      [Test]
      public void FollowTest([Values("Steem", "Golos")] string name) {
         var op = new FollowOperation(_login[name], "joseph.kalu", FollowType.Blog | FollowType.Posts, _login[name]);
         var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
         //var prop = Manager(name).BroadcastOperations(op);
         Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
      }

      /// <summary>
      /// "params": [
      ///     3,
      ///     "broadcast_transaction",
      ///     [
      ///         {
      ///             "ref_block_num": 7663,
      ///             "ref_block_prefix": 66978938,
      ///             "expiration": "2017-07-06T09:42:45",
      ///             "operations": [
      ///                 [
      ///                     "custom_json",
      ///                     {
      ///                         "required_auths": [],
      ///                         "required_posting_auths": [
      ///                             "joseph.kalu"
      ///                         ],
      ///                         "id": "follow",
      ///                         "json": "[\"follow\", {\"follower\": \"joseph.kalu\", \"following\": \"joseph.kalu\", \"what\": [\"\"]}]"
      ///                     }
      ///                 ]
      ///             ],
      ///             "extensions": [],
      ///             "signatures": ["**********************************************************************************************************************************"
      ///             ]
      ///         }
      ///     ]
      /// ],
      /// </summary>
      [Test]
      public void UnFollowTest([Values("Steem", "Golos")] string name) {
         var op = new UnfollowOperation(_login[name], "joseph.kalu", _login[name]);
         var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
         //var prop = Manager(name).BroadcastOperations(op);
         Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
      }

      [Test]
      public void UpVoteOperationTest([Values("Steem", "Golos")] string name) {
         var op = new UpVoteOperation(_login[name], "joseph.kalu", "fkkl");
         var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
         //var prop = Manager(name).BroadcastOperations(op);
         Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
      }

      [Test]
      public void DownVoteOperationTest([Values("Steem", "Golos")] string name) {
         var op = new DownVoteOperation(_login[name], "joseph.kalu", "fkkl");
         var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
         //var prop = Manager(name).BroadcastOperations(op);
         Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
      }

      [Test]
      public void FlagTest([Values("Steem", "Golos")] string name) {
         var op = new FlagOperation(_login[name], "joseph.kalu", "fkkl");
         var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
         //var prop = Manager(name).BroadcastOperations(op);
         Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
      }

      [Test]
      public virtual void PostTest([Values("Steem")] string name) {
         var op = new PostOperation("test", _login[name], "testpostwithbeneficiares", "test post with beneficiares", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg", "{\"app\": \"steepshot / 0.0.4\", \"tags\": []}");
         var popt = new BeneficiariesOperation(_login[name], "testpostwithbeneficiares", _chain[name].SbdSymbol, new Beneficiary("steepshot", 1000));
         var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op, popt);
         //var prop = Manager(name).BroadcastOperations(UserPrivateKeys[name], op, popt);
         Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
      }

      [Test]
      public virtual void RuPostTest([Values("Steem", "Golos")] string name) {
         var op = new PostOperation("test", _login[name], "Тест с русскими буквами", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", "{\"app\": \"steepshot / 0.0.4\", \"tags\": []}");

         var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
         //var prop = Manager(name).BroadcastOperations(op, popt);
         Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
      }

      [Test]
      public void ReplyTest([Values("Steem", "Golos")] string name) {
         var op = new ReplyOperation("steepshot", "Тест с русскими буквами", _login[name], "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", "{\"app\": \"steepshot / 0.0.4\", \"tags\": []}");
         var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
         //var prop = Manager(name).BroadcastOperations(op);
         Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
      }

      [Test]
      public void RepostTest([Values("Steem", "Golos")] string name) {
         var op = new RePostOperation(_login[name], "joseph.kalu", "fkkl", _login[name]);
         var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
         //var prop = Manager(name).BroadcastOperations(op);
         Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
      }

      [Test]
      public void DateSerializationTest([Values("Golos")] string name) {
         DateTime badDate = DateTime.Parse("2017-07-31T18:14:59.30232Z");
         var request = Manager(name).CustomGetRequest<object>("get_discussions_by_author_before_date", "golosloto", "", badDate, 1);
         Assert.IsFalse(request.IsError, request.GetErrorMessage());
      }
   }
=======
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

        [Test]
        [TestCase("277.126 SBD", 277126, 3, "SBD")]
        [TestCase("0 SBD", 0, 0, "SBD")]
        [TestCase("0", 0, 0, "")]
        [TestCase("123 SBD", 123, 0, "SBD")]
        [TestCase("0.12345 SBD", 12345, 5, "SBD")]
        public void ParseTestTest(string test, long value, byte precision, string currency)
        {
            var money = new Money(test, CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator, CultureInfo.InvariantCulture.NumberFormat.NumberGroupSeparator);
            Assert.IsTrue(money.Value == value);
            Assert.IsTrue(money.Precision == precision);
            Assert.IsTrue(money.Currency == currency);
            Assert.IsTrue(test.Equals(money.ToString()));
        }

        #region Post requests

        [Test]
        public void FollowTest([Values("Steem", "Golos")] string name)
        {
            var op = new FollowOperation(_login[name], "joseph.kalu", FollowType.Blog | FollowType.Posts, _login[name]);
            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(_userPrivateKeys[name], op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        /// <summary>
        /// "params": [
        ///     3,
        ///     "broadcast_transaction",
        ///     [
        ///         {
        ///             "ref_block_num": 7663,
        ///             "ref_block_prefix": 66978938,
        ///             "expiration": "2017-07-06T09:42:45",
        ///             "operations": [
        ///                 [
        ///                     "custom_json",
        ///                     {
        ///                         "required_auths": [],
        ///                         "required_posting_auths": [
        ///                             "joseph.kalu"
        ///                         ],
        ///                         "id": "follow",
        ///                         "json": "[\"follow\", {\"follower\": \"joseph.kalu\", \"following\": \"joseph.kalu\", \"what\": [\"\"]}]"
        ///                     }
        ///                 ]
        ///             ],
        ///             "extensions": [],
        ///             "signatures": ["**********************************************************************************************************************************"
        ///             ]
        ///         }
        ///     ]
        /// ],
        /// </summary>
        [Test]
        public void UnFollowTest([Values("Steem", "Golos")] string name)
        {
            var op = new UnfollowOperation(_login[name], "joseph.kalu", _login[name]);
            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(_userPrivateKeys[name], op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void UpVoteOperationTest([Values("Steem", "Golos")] string name)
        {
            var op = new UpVoteOperation(_login[name], "joseph.kalu", "fkkl");
            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(_userPrivateKeys[name], op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void DownVoteOperationTest([Values("Steem", "Golos")] string name)
        {
            var op = new DownVoteOperation(_login[name], "joseph.kalu", "fkkl");
            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(_userPrivateKeys[name], op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void FlagTest([Values("Steem", "Golos")] string name)
        {
            var op = new FlagOperation(_login[name], "joseph.kalu", "fkkl");
            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(_userPrivateKeys[name], op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public virtual void PostTest([Values("Steem")] string name)
        {
            var op = new PostOperation("test", _login[name], "test post with beneficiares", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg", "{\"app\": \"steepshot / 0.0.4\", \"tags\": []}");
            var popt = new BeneficiariesOperation(_login[name], op.Permlink, _chain[name].SbdSymbol, new Beneficiary("steepshot", 1000));
            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op, popt);
            //var prop = Manager(name).BroadcastOperations(UserPrivateKeys[name], op, popt);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public virtual void RuPostTest([Values("Steem", "Golos")] string name)
        {
            var op = new PostOperation("test", _login[name], "Тест с русскими буквами", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", "{\"app\": \"steepshot / 0.0.4\", \"tags\": []}");

            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(_userPrivateKeys[name], op, popt);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void ReplyTest([Values("Steem", "Golos")] string name)
        {
            var op = new ReplyOperation("steepshot", "Тест с русскими буквами", _login[name], "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", "{\"app\": \"steepshot / 0.0.4\", \"tags\": []}");
            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(_userPrivateKeys[name], op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        public void RepostTest([Values("Steem", "Golos")] string name)
        {
            var op = new RePostOperation(_login[name], "joseph.kalu", "fkkl", _login[name]);
            var prop = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            //var prop = Manager(name).BroadcastOperations(_userPrivateKeys[name], op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        #endregion Post requests

        #region Get requests

        [Test]
        public void VerifyAuthoritySuccessTest([Values("Steem", "Golos")] string name)
        {
            var op = new FollowOperation(_login[name], "steepshot", FollowType.Blog, _login[name]);
            var rez = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            Assert.IsFalse(rez.IsError, rez.GetErrorMessage());
            Assert.IsTrue(rez.Result);
        }

        [Test]
        public void VerifyAuthorityFallTest([Values("Steem", "Golos")] string name)
        {
            var op = new FollowOperation(_login[name], "steepshot", FollowType.Blog, "StubLogin");
            var rez = Manager(name).VerifyAuthority(_userPrivateKeys[name], op);
            Assert.IsTrue(rez.IsError);
        }

        [Test, Sequential]
        public void get_dynamic_global_properties([Values("Steem", "Golos")] string name)
        {
            var prop = Manager(name).GetDynamicGlobalProperties();
            Assert.IsFalse(prop.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(prop.Result));
        }

        [Test]
        public virtual void get_content(
            [Values("Steem", "Golos")] string name,
            [Values("steepshot", "golosmedia")] string author,
            [Values("c-lib-ditch-1-0-for-graphene-from-steepshot-team-under-the-mit-license", "psk38")] string permlink)
        {
            var prop = Manager(name).GetContent(author, permlink);
            Assert.IsTrue(prop != null);
            Assert.IsTrue(prop.Result != null);
            Assert.IsFalse(prop.IsError);
        }

        [Test]
        public void help([Values("Steem", "Golos")] string name)
        {
            var rez = Manager(name).CustomGetRequest<object>("help");
            Console.WriteLine(rez.Error);
            Console.WriteLine(rez.Result);
            Assert.IsFalse(rez.IsError);
        }

        [Test]
        public void get_followers([Values("Steem", "Golos")] string name)
        {
            ushort count = 3;
            var resp = Manager(name).GetFollowers(_login[name], string.Empty, FollowType.Blog, count);
            Assert.IsFalse(resp.IsError);
            Assert.IsTrue(resp.Result.Length <= count);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            var respNext = Manager(name).GetFollowers(_login[name], resp.Result.Last().Follower, FollowType.Blog, count);
            Assert.IsFalse(respNext.IsError);
            Assert.IsTrue(respNext.Result.Length <= count);
            Assert.IsTrue(respNext.Result.First().Follower == resp.Result.Last().Follower);
            Console.WriteLine(JsonConvert.SerializeObject(respNext.Result));
        }

        [Test]
        public void get_following([Values("Steem", "Golos")] string name)
        {
            ushort count = 3;
            var resp = Manager(name).GetFollowing(_login[name], string.Empty, FollowType.Blog, count);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(resp.Result));
            Assert.IsTrue(resp.Result.Length <= count);

            var respNext = Manager(name).GetFollowing(_login[name], resp.Result.Last().Following, FollowType.Blog, count);
            Assert.IsFalse(respNext.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(respNext.Result));
            Assert.IsTrue(respNext.Result.Length <= count);
            Assert.IsTrue(respNext.Result.First().Following == resp.Result.Last().Following);
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

            var respNext = Manager(name).GetDiscussionsByAuthorBeforeDate(_login[name], resp.Result[count - 1].Permlink, dt, count);
            Assert.IsFalse(respNext.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(respNext.Result));
            Assert.IsTrue(respNext.Result.Length <= count);
            Assert.IsTrue(respNext.Result[0].Permlink == resp.Result[count - 1].Permlink);
        }

        [Test]
        public void get_state([Values("Steem", "Golos")] string name)
        {
            var rez = Manager(name).GetState("path");
            Console.WriteLine(rez.Error);
            Assert.IsFalse(rez.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(rez.Result));
        }

        [Test]
        public void get_config([Values("Steem", "Golos")] string name)
        {
            var rez = Manager(name).GetConfig();
            Console.WriteLine(rez.Error);
            Assert.IsFalse(rez.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(rez.Result));
        }

        [Test]
        public void get_chain_properties([Values("Steem", "Golos")] string name)
        {
            var rez = Manager(name).GetChainProperties();
            Console.WriteLine(rez.Error);
            Assert.IsFalse(rez.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(rez.Result));
        }

        [Test]
        public void get_feed_history([Values("Steem", "Golos")] string name)
        {
            var rez = Manager(name).GetFeedHistory();
            Console.WriteLine(rez.Error);
            Assert.IsFalse(rez.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(rez.Result));
        }

        [Test]
        public void get_current_median_history_price([Values("Steem", "Golos")] string name)
        {
            var rez = Manager(name).GetCurrentMedianHistoryPrice();
            Console.WriteLine(rez.Error);
            Assert.IsFalse(rez.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(rez.Result));
        }

        [Test]
        public void get_witness_schedule([Values("Steem", "Golos")] string name)
        {
            var rez = Manager(name).GetWitnessSchedule();
            Console.WriteLine(rez.Error);
            Assert.IsFalse(rez.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(rez.Result));
        }

        [Test]
        public void get_hardfork_version([Values("Steem", "Golos")] string name)
        {
            var rez = Manager(name).GetHardforkVersion();
            Console.WriteLine(rez.Error);
            Assert.IsFalse(rez.IsError);
            Console.WriteLine(rez.Result);
        }

        [Test]
        public void get_next_scheduled_hardfork([Values("Steem", "Golos")] string name)
        {
            var rez = Manager(name).GetNextScheduledHardfork();
            Console.WriteLine(rez.Error);
            Assert.IsFalse(rez.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(rez.Result));
        }

        [Test]
        public void get_key_references([Values("Steem", "Golos")] string name)
        {
            var acResp = Manager(name).GetAccounts(_login[name]);
            Assert.IsFalse(acResp.IsError);
            var ac = acResp.Result;
            Assert.IsTrue(ac.Length == 1);

            var rez = Manager(name).GetKeyReferences(new string[1][] { new[] { ac[0].Active.Value } });
            Console.WriteLine(rez.Error);
            Assert.IsFalse(rez.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(rez.Result));
        }

        [Test]
        public void get_accounts([Values("Steem", "Golos")] string name)
        {
            var rez = Manager(name).GetAccounts(_login[name]);
            Assert.IsFalse(rez.IsError, rez.GetErrorMessage());
            Console.WriteLine(JsonConvert.SerializeObject(rez.Result));
        }

        [Test]
        public void get_account_references([Values("Steem", "Golos")] string name)
        {
            var ac = Manager(name).GetAccounts(_login[name]);
            Assert.IsFalse(ac.IsError);

            var rez = Manager(name).GetAccountReferences(ac.Result[0].Id);
            Console.WriteLine(rez.Error);
            Console.WriteLine(rez.Result);
            Assert.IsFalse(rez.IsError);
        }

        [Test]
        public void lookup_account_names([Values("Steem", "Golos")] string name)
        {
            var rez = Manager(name).LookupAccountNames(_login[name]);
            Console.WriteLine(rez.Error);
            Assert.IsFalse(rez.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(rez.Result));
        }

        [Test]
        public void lookup_accounts([Values("Steem", "Golos")] string name)
        {
            UInt32 limit = 3;
            var rez = Manager(name).LookupAccounts(_login[name], limit);
            Console.WriteLine(rez.Error);
            Assert.IsFalse(rez.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(rez.Result));
        }

        [Test]
        public void get_account_count([Values("Steem", "Golos")] string name)
        {
            var rez = Manager(name).GetAccountCount();
            Console.WriteLine(rez.Error);
            Console.WriteLine(rez.Result);
            Assert.IsFalse(rez.IsError);
            Console.WriteLine(rez.Result);
        }

        [Test]
        public void get_conversion_requests([Values("Steem", "Golos")] string name)
        {
            var rez = Manager(name).GetConversionRequests(_login[name]);
            Console.WriteLine(rez.Error);
            Assert.IsFalse(rez.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(rez.Result));
        }

        [Test]
        public void get_account_history([Values("Steem", "Golos")] string name)
        {
            UInt64 from = 3;
            UInt32 limit = 3;
            var rez = Manager(name).GetAccountHistory(_login[name], from, limit);
            Console.WriteLine(rez.Error);
            Assert.IsFalse(rez.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(rez.Result));
        }

        [Test]
        public void get_owner_history([Values("Steem", "Golos")] string name)
        {
            var rez = Manager(name).CustomGetRequest<object>("get_owner_history", _login[name]);
            Console.WriteLine(rez.Error);
            Console.WriteLine(rez.Result);
            Assert.IsFalse(rez.IsError);
        }

        [Test]
        public void get_recovery_request([Values("Steem", "Golos")] string name)
        {
            var rez = Manager(name).CustomGetRequest<object>("get_recovery_request", _login[name]);
            Console.WriteLine(rez.Error);
            Console.WriteLine(rez.Result);
            Assert.IsFalse(rez.IsError);
        }

        [Test]
        public void get_withdraw_routes([Values("Steem", "Golos")] string name)
        {
            var rez = Manager(name).CustomGetRequest<object>("get_withdraw_routes", _login[name], "incoming");
            Console.WriteLine(rez.Error);
            Console.WriteLine(rez.Result);
            Assert.IsFalse(rez.IsError);

            rez = Manager(name).CustomGetRequest<object>("get_withdraw_routes", _login[name], "outgoing");
            Console.WriteLine(rez.Error);
            Console.WriteLine(rez.Result);
            Assert.IsFalse(rez.IsError);

            rez = Manager(name).CustomGetRequest<object>("get_withdraw_routes", _login[name], "all");
            Console.WriteLine(rez.Error);
            Console.WriteLine(rez.Result);
            Assert.IsFalse(rez.IsError);
        }

        [Test]
        public void get_account_bandwidth([Values("Steem", "Golos")] string name)
        {
            var rez = Manager(name).GetAccountBandwidth(_login[name], BandwidthType.Post);
            Console.WriteLine(rez.Error);
            Assert.IsFalse(rez.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(rez.Result));

            rez = Manager(name).GetAccountBandwidth(_login[name], BandwidthType.Forum);
            Console.WriteLine(rez.Error);
            Assert.IsFalse(rez.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(rez.Result));

            rez = Manager(name).GetAccountBandwidth(_login[name], BandwidthType.Market);
            Console.WriteLine(rez.Error);
            Assert.IsFalse(rez.IsError);
            Console.WriteLine(JsonConvert.SerializeObject(rez.Result));
        }

        #endregion Get requests
    }
>>>>>>> d6ac9c99b169203d85ec0382b8640ffd5034e20a
}