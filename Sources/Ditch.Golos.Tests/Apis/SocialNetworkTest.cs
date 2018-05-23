using System;
using System.Threading;
using Ditch.Golos.Models.Other;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Golos.Tests.Apis
{
    [TestFixture]
    public class SocialNetworkTest : BaseTest
    {
        [Test]
        public void get_trending_categories()
        {
            var resp = Api.GetTrendingCategories(string.Empty, 3, CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JObject[]>(KnownApiNames.SocialNetworkApi, "get_trending_categories", new object[] { string.Empty, 3 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_best_categories()
        {
            var resp = Api.GetBestCategories(string.Empty, 3, CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JObject[]>(KnownApiNames.SocialNetworkApi, "get_best_categories", new object[] { string.Empty, 3 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_active_categories()
        {
            var resp = Api.GetActiveCategories(User.Login, 3, CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_active_categories", new object[] { User.Login, 3 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        [Test]
        public void get_recent_categories()
        {
            var resp = Api.GetRecentCategories(string.Empty, 3, CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_recent_categories", new object[] { string.Empty, 3 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            WriteLine(obj);
        }

        //[Test]
        //[Ignore("no method with name 'get_free_memory'")]
        //public void get_free_memory()
        //{
        //    var resp = Api.GetFreeMemory(CancellationToken.None);
        //    WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    WriteLine(resp.Result);
        //}

        //[Test]
        //public void get_reward_fund()
        //{
        //    if (VersionHelper.GetHardfork(Api.Version) > 16)
        //    {
        //        var resp = Api.GetRewardFund(User.Login, CancellationToken.None);
        //        WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        WriteLine(resp.Result);

        //        var obj = Api.CustomGetRequest<JObject>(KnownApiNames.SocialNetworkApi, "get_reward_fund", new object[] { User.Login }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        WriteLine("----------------------------------------------------------------------------");
        //        WriteLine(obj);
        //    }
        //    else
        //    {
        //        WriteLine("Added in hf 17");
        //    }
        //}

        //[Test]
        //public void get_name_cost()
        //{
        //    if (VersionHelper.GetHardfork(Api.Version) > 16)
        //    {
        //        var resp = Api.GetNameCost(User.Login, CancellationToken.None);
        //        WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        WriteLine(resp.Result);

        //        var obj = Api.CustomGetRequest<JObject>(KnownApiNames.SocialNetworkApi, "get_name_cost", new object[] { User.Login }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        WriteLine("----------------------------------------------------------------------------");
        //        WriteLine(obj);
        //    }
        //    else
        //    {
        //        WriteLine("Added in hf 17");
        //    }
        //}

        //[Test]
        //public void get_account_balances()
        //{
        //    if (VersionHelper.GetHardfork(Api.Version) > 16)
        //    {
        //        var resp = Api.GetAccountBalances(User.Login, new string[0], CancellationToken.None);
        //        WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        WriteLine(resp.Result);
        //    }
        //    else
        //    {
        //        WriteLine("Added in hf 17");
        //    }
        //}

        //[Test]
        //public void get_vesting_delegations()
        //{
        //    if (VersionHelper.GetHardfork(Api.Version) > 16)
        //    {
        //        var resp = Api.GetVestingDelegations(User.Login, string.Empty, 10, CancellationToken.None);
        //        WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        WriteLine(resp.Result);

        //        var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_vesting_delegations", new object[] { User.Login, string.Empty, 10 }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        WriteLine("----------------------------------------------------------------------------");
        //        WriteLine(obj);
        //    }
        //    else
        //    {
        //        WriteLine("Added in hf 17");
        //    }
        //}

        //[Test]
        //public void get_expiring_vesting_delegations()
        //{
        //    if (VersionHelper.GetHardfork(Api.Version) > 16)
        //    {
        //        var resp = Api.GetExpiringVestingDelegations(User.Login, new DateTime(2017, 01, 01), 100, CancellationToken.None);
        //        WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        WriteLine(resp.Result);

        //        var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_expiring_vesting_delegations", new object[] { User.Login, new DateTime(2017, 01, 01), 100 }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        WriteLine("----------------------------------------------------------------------------");
        //        WriteLine(obj);
        //    }
        //    else
        //    {
        //        WriteLine("Added in hf 17");
        //    }
        //}

        //[Test]
        //public void get_assets()
        //{
        //    if (VersionHelper.GetHardfork(Api.Version) > 16)
        //    {
        //        var resp = Api.GetAssets(new[] { "GBG", "GOLOS" }, CancellationToken.None);
        //        WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        WriteLine(resp.Result);

        //        var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_assets", new object[] { new[] { "GBG" } }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        WriteLine("----------------------------------------------------------------------------");
        //        WriteLine(obj);
        //    }
        //    else
        //    {
        //        WriteLine("Added in hf 17");
        //    }
        //}

        //[Test]
        //public void get_assets_by_issuer()
        //{
        //    if (VersionHelper.GetHardfork(Api.Version) > 16)
        //    {
        //        var resp = Api.GetAssetsByIssuer("b1acksun", CancellationToken.None);
        //        WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        WriteLine(resp.Result);

        //        var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_assets_by_issuer", new object[] { "b1acksun" }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        WriteLine("----------------------------------------------------------------------------");
        //        WriteLine(obj);
        //    }
        //    else
        //    {
        //        WriteLine("Added in hf 17");
        //    }
        //}

        //[Test]
        //public void get_assets_dynamic_data()
        //{
        //    if (VersionHelper.GetHardfork(Api.Version) > 16)
        //    {
        //        var resp = Api.GetAssetsDynamicData(new[] { "GBG" }, CancellationToken.None);
        //        WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        WriteLine(resp.Result);

        //        var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_assets_dynamic_data", new object[] { new[] { "GBG" } }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        WriteLine("----------------------------------------------------------------------------");
        //        WriteLine(obj);
        //    }
        //    else
        //    {
        //        WriteLine("Added in hf 17");
        //    }
        //}

        //[Test]
        //public void get_bitassets_data()
        //{
        //    if (VersionHelper.GetHardfork(Api.Version) > 16)
        //    {
        //        var resp = Api.GetBitassetsData(new[] { "GBG" }, CancellationToken.None);
        //        WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        WriteLine(resp.Result);

        //        var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_bitassets_data", new object[] { new[] { "GBG" } }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        WriteLine("----------------------------------------------------------------------------");
        //        WriteLine(obj);
        //    }
        //    else
        //    {
        //        WriteLine("Added in hf 17");
        //    }
        //}

        //[Test]
        //public void list_assets()
        //{
        //    if (VersionHelper.GetHardfork(Api.Version) > 16)
        //    {
        //        var resp = Api.ListAssets(string.Empty, 10, CancellationToken.None);
        //        WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        WriteLine(resp.Result);

        //        var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "list_assets", new object[] { string.Empty, 1 }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        WriteLine("----------------------------------------------------------------------------");
        //        WriteLine(obj);
        //    }
        //    else
        //    {
        //        WriteLine("Added in hf 17");
        //    }
        //}

        [Test]
        public void get_active_votes()
        {
            var permlink = "test";
            var resp = Api.GetActiveVotes(User.Login, permlink, 100, CancellationToken.None);
            WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_active_votes", new object[] { User.Login, permlink, 100 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(obj);
        }

        [Test]
        public void get_account_votes()
        {
            var resp = Api.GetAccountVotes(User.Login, 100, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_account_votes", new object[] { User.Login, 100 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(obj);
        }

        [Test]
        public void get_content()
        {
            var author = "steepshot";
            var permlink = "znakomtes-steepshot-io";

            var resp = Api.GetContent(author, permlink, 100, CancellationToken.None);
            Assert.IsTrue(resp != null);
            Assert.IsTrue(resp.Result != null);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JObject>(KnownApiNames.SocialNetworkApi, "get_content", new object[] { author, permlink, 100 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(obj);
        }

        [Test]
        public void get_content_replies()
        {
            var parent = "";
            var parentPermink = "";
            var resp = Api.GetContentReplies(parent, parentPermink, 100, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_content_replies", new object[] { parent, parentPermink, 100 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(obj);
        }

        [Test]
        public void get_discussions_by_trending()
        {
            var query = new DiscussionQuery()
            {
                TruncateBody = 1024,
                Limit = 2
            };
            var resp = Api.GetDiscussionsByTrending(query, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_discussions_by_trending", new object[] { query }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(obj);
        }

        [Test]
        public void get_discussions_by_created()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };

            var resp = Api.GetDiscussionsByCreated(query, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_discussions_by_created", new object[] { query }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(obj);
        }

        [Test]
        public void get_discussions_by_active()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByActive(query, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_discussions_by_active", new object[] { query }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(obj);
        }

        [Test]
        public void get_discussions_by_cashout()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByCashout(query, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_discussions_by_cashout", new object[] { query }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(obj);
        }

        [Test]
        public void get_discussions_by_payout()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByPayout(query, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_discussions_by_payout", new object[] { query }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(obj);
        }

        //[Test]
        //public void get_post_discussions_by_payout()
        //{
        //    if (VersionHelper.GetHardfork(Api.Version) > 16)
        //    {
        //        var query = new DiscussionQuery()
        //        {
        //            SelectAuthors = new[] { User.Login }
        //        };
        //        var resp = Api.GetPostDiscussionsByPayout(query, CancellationToken.None);
        //        Console.WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        Console.WriteLine(resp.Result);

        //        var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_post_discussions_by_payout", new object[] { query }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        Console.WriteLine("----------------------------------------------------------------------------");
        //        Console.WriteLine(obj);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Added in hf 17");
        //    }
        //}

        //[Test]
        //public void get_comment_discussions_by_payout()
        //{
        //    if (VersionHelper.GetHardfork(Api.Version) > 16)
        //    {
        //        var query = new DiscussionQuery()
        //        {
        //            SelectAuthors = new[] { User.Login }
        //        };
        //        var resp = Api.GetCommentDiscussionsByPayout(query, CancellationToken.None);
        //        Console.WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        Console.WriteLine(resp.Result);

        //        var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_comment_discussions_by_payout", new object[] { query }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        Console.WriteLine("----------------------------------------------------------------------------");
        //        Console.WriteLine(obj);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Added in hf 17");
        //    }
        //}

        [Test]
        public void get_discussions_by_votes()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByVotes(query, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_discussions_by_votes", new object[] { query }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(obj);
        }

        //[Test]
        //public void get_discussions_by_children()
        //{
        //    var query = new DiscussionQuery()
        //    {
        //        SelectAuthors = new[] { User.Login }
        //    };
        //    var resp = Api.GetDiscussionsByChildren(query, CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_discussions_by_children", new object[] { query }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(obj);
        //}

        [Test]
        public void get_discussions_by_hot()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByHot(query, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_discussions_by_hot", new object[] { query }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(obj);
        }

        [Test]
        public void get_discussions_by_feed()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByFeed(query, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_discussions_by_feed", new object[] { query }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(obj);
        }

        [Test]
        public void get_discussions_by_blog()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByBlog(query, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_discussions_by_blog", new object[] { query }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(obj);
        }

        [Test]
        public void get_discussions_by_comments()
        {
            var query = new DiscussionQuery()
            {
                StartAuthor = User.Login
            };
            var resp = Api.GetDiscussionsByComments(query, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_discussions_by_comments", new object[] { query }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(obj);
        }

        [Test]
        public void get_discussions_by_promoted()
        {
            var query = new DiscussionQuery()
            {
                SelectAuthors = new[] { User.Login }
            };
            var resp = Api.GetDiscussionsByPromoted(query, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_discussions_by_promoted", new object[] { query }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(obj);
        }

        [Test]
        public void get_replies_by_last_update()
        {
            var resp = Api.GetRepliesByLastUpdate(User.Login, string.Empty, 10, 100, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_replies_by_last_update", new object[] { User.Login, string.Empty, 10, 100 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(obj);
        }

        [Test]
        public void get_discussions_by_author_before_date()
        {
            ushort count = 3;
            var dt = DateTime.Now;
            var resp = Api.GetDiscussionsByAuthorBeforeDate(User.Login, string.Empty, dt, count, 100, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);
            Assert.IsTrue(resp.Result.Length <= count);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_discussions_by_author_before_date", new object[] { User.Login, string.Empty, dt, count, 100 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(obj);
        }

        [Test]
        public void get_all_content_replies()
        {
            var query = new DiscussionQuery()
            {
                TruncateBody = 100,
                Limit = 2
            };

            var trending = Api.GetDiscussionsByTrending(query, CancellationToken.None);
            var post = trending.Result[0];

            var resp = Api.GetAllContentReplies(post.Author, post.Url, 100, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_all_content_replies", new object[] { User.Login, "spasibo-golos", 100 }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(obj);
        }

        [Test]
        public void get_discussions_by_children()
        {
            var query = new DiscussionQuery()
            {
                TruncateBody = 100,
                Limit = 2
            };

            var resp = Api.GetDiscussionsByChildren(query, CancellationToken.None);
            Console.WriteLine(resp.Error);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Result);

            var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_discussions_by_children", new object[] { query }, CancellationToken.None);
            TestPropetries(resp.Result.GetType(), obj.Result);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(obj);
        }

        //[Test]
        //[Ignore("add data for test")]
        //public void get_payout_extension_cost()
        //{
        //    var parmlink = "";
        //    var resp = Api.GetPayoutExtensionCost(User.Login, parmlink, new DateTime(2017, 1, 1), CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.SocialNetworkApi, "get_payout_extension_cost", new object[] { User.Login, parmlink, new DateTime(2017, 1, 1) }, CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(obj);
        //}

        //[Test]
        //[Ignore("add data for test")]
        //public void get_payout_extension_time()
        //{
        //    var parmlink = "";
        //    var resp = Api.GetPayoutExtensionTime(User.Login, parmlink, new Asset(0, 3, "GBG"), CancellationToken.None);
        //    Console.WriteLine(resp.Error);
        //    Assert.IsFalse(resp.IsError);
        //    Console.WriteLine(resp.Result);

        //    var obj = Api.CustomGetRequest<JObject>(KnownApiNames.SocialNetworkApi, "get_payout_extension_time", new object[] { User.Login, parmlink, new Asset(0, 3, "GBG") },
        //        CancellationToken.None);
        //    TestPropetries(resp.Result.GetType(), obj.Result);
        //    Console.WriteLine("----------------------------------------------------------------------------");
        //    Console.WriteLine(obj);
        //}

        //[Test]
        //public void get_proposed_transactions()
        //{
        //    if (VersionHelper.GetHardfork(Api.Version) > 16)
        //    {
        //        var resp = Api.GetProposedTransactions(User.Login, CancellationToken.None);
        //        Console.WriteLine(resp.Error);
        //        Assert.IsFalse(resp.IsError);
        //        Console.WriteLine(resp.Result);

        //        var obj = Api.CustomGetRequest<JArray>(KnownApiNames.SocialNetworkApi, "get_proposed_transactions", new object[] { User.Login }, CancellationToken.None);
        //        TestPropetries(resp.Result.GetType(), obj.Result);
        //        Console.WriteLine("----------------------------------------------------------------------------");
        //        Console.WriteLine(obj);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Added in hf 17");
        //    }
        //}
    }
}

