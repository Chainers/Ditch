using System.Threading;
using System.Threading.Tasks;
using Ditch.Steem.Models;
using NUnit.Framework;

namespace Ditch.Steem.Tests.Apis
{
    [TestFixture]
    public class CondenserApiTest : BaseTest
    {
        [OneTimeSetUp]
        protected override void OneTimeSetUp()
        {
            base.OneTimeSetUp();
            JsonSerializerSettings = Api.CondenserJsonSerializerSettings;
        }

        //  "condenser_api.broadcast_block",


        //  "condenser_api.broadcast_transaction",
        //  "condenser_api.broadcast_transaction_synchronous",


        [Test]
        [Parallelizable]
        public async Task get_account_bandwidth()
        {
            var args = new GetAccountBandwidthArgs
            {
                Account = User.Login,
                Type = BandwidthType.Forum
            };
            var resp = await Api.CondenserGetAccountBandwidthAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp, true);
        }

        [Test]
        [Parallelizable]
        public async Task get_account_count()
        {
            var resp = await Api.CondenserGetAccountCountAsync(CancellationToken.None).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }

        [Test]
        [Parallelizable]
        public async Task get_account_history()
        {
            var args = new GetAccountHistoryArgs
            {
                Account = User.Login,
                Limit = 1,
                Start = 1
            };
            var resp = await Api.CondenserGetAccountHistoryAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp, true);
        }

        //  "condenser_api.get_account_references",
        //  "condenser_api.get_account_reputations",
        //  "condenser_api.get_account_votes",
        //  "condenser_api.get_accounts",
        //  "condenser_api.get_active_votes",

        [Test]
        [Parallelizable]
        public async Task get_active_witnesses()
        {
            var resp = await Api.CondenserGetActiveWitnessesAsync(CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp, true);
        }

        [Test]
        [Parallelizable]
        public async Task get_block()
        {
            var args = new GetBlockArgs
            {
                BlockNum = 22054347
            };
            var resp = await Api.CondenserGetBlockAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp, true);
        }
        //  "condenser_api.get_block_header",
        //  "condenser_api.get_blog",
        //  "condenser_api.get_blog_authors",
        //  "condenser_api.get_blog_entries",
        //  "condenser_api.get_chain_properties",
        //  "condenser_api.get_comment_discussions_by_payout",
        //  "condenser_api.get_config",
        //  "condenser_api.get_content",
        //  "condenser_api.get_content_replies",
        //  "condenser_api.get_conversion_requests",
        //  "condenser_api.get_current_median_history_price",
        //  "condenser_api.get_discussions_by_active",
        //  "condenser_api.get_discussions_by_author_before_date",
        //  "condenser_api.get_discussions_by_blog",
        //  "condenser_api.get_discussions_by_cashout",
        //  "condenser_api.get_discussions_by_children",
        //  "condenser_api.get_discussions_by_comments",
        //  "condenser_api.get_discussions_by_created",
        //  "condenser_api.get_discussions_by_feed",
        //  "condenser_api.get_discussions_by_hot",
        //  "condenser_api.get_discussions_by_promoted",
        //  "condenser_api.get_discussions_by_trending",
        //  "condenser_api.get_discussions_by_votes",

        [Test]
        [Parallelizable]
        public async Task get_dynamic_global_properties()
        {
            var resp = await Api.CondenserGetDynamicGlobalPropertiesAsync(CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp, true);
        }

        //  "condenser_api.get_escrow",
        //  "condenser_api.get_expiring_vesting_delegations",
        //  "condenser_api.get_feed",
        //  "condenser_api.get_feed_entries",
        //  "condenser_api.get_feed_history",
        //  "condenser_api.get_follow_count",
        //  "condenser_api.get_followers",
        //  "condenser_api.get_following",
        //  "condenser_api.get_hardfork_version",
        //  "condenser_api.get_key_references",
        //  "condenser_api.get_market_history",
        //  "condenser_api.get_market_history_buckets",
        //  "condenser_api.get_next_scheduled_hardfork",
        //  "condenser_api.get_open_orders",
        //  "condenser_api.get_ops_in_block",
        //  "condenser_api.get_order_book",
        //  "condenser_api.get_owner_history",
        //  "condenser_api.get_post_discussions_by_payout",
        [Test]
        [Parallelizable]
        public async Task get_potential_signatures()
        {
            var args = new GetPotentialSignaturesArgs
            {
                Trx = await GetSignedTransaction().ConfigureAwait(false)
            };
            var resp = await Api.CondenserGetPotentialSignaturesAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp, true);
        }
        //  "condenser_api.get_reblogged_by",
        //  "condenser_api.get_recent_trades",
        //  "condenser_api.get_recovery_request",
        //  "condenser_api.get_replies_by_last_update",

        [Test]
        [Parallelizable]
        public async Task get_required_signatures()
        {
            var findAccountsArgs = new FindAccountsArgs
            {
                Accounts = new[] { User.Login }
            };
            var accounts = await Api.FindAccountsAsync(findAccountsArgs, CancellationToken.None).ConfigureAwait(false);
            if (accounts.IsError)
                WriteLine(accounts);
            Assert.IsFalse(accounts.IsError);
            var pKey = accounts.Result.Accounts[0].Posting.KeyAuths[0].Key;

            var args = new GetRequiredSignaturesArgs
            {
                Trx = await GetSignedTransaction().ConfigureAwait(false),
                AvailableKeys = new[] { pKey }
            };
            var resp = await Api.CondenserGetRequiredSignaturesAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp, true);
        }

        //  "condenser_api.get_reward_fund",
        //  "condenser_api.get_savings_withdraw_from",
        //  "condenser_api.get_savings_withdraw_to",
        //  "condenser_api.get_state",
        //  "condenser_api.get_tags_used_by_author",
        //  "condenser_api.get_ticker",
        //  "condenser_api.get_trade_history",
        //  "condenser_api.get_transaction",

        [Test]
        [Parallelizable]
        public async Task get_transaction_hex()
        {
            var args = new GetTransactionHexArgs
            {
                Trx = await GetSignedTransaction().ConfigureAwait(false)
            };
            var resp = await Api.CondenserGetTransactionHexAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp, true);
        }

        [Test]
        [Parallelizable]
        public async Task get_trending_tags()
        {
            var args = new GetTrendingTagsArgs
            {
                StartTag = string.Empty,
                Limit = 1
            };
            var resp = await Api.CondenserGetTrendingTagsAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestPropetries(resp, true);
        }
        //  "condenser_api.get_version",
        //  "condenser_api.get_vesting_delegations",
        //  "condenser_api.get_volume",
        //  "condenser_api.get_withdraw_routes",
        //  "condenser_api.get_witness_by_account",
        //  "condenser_api.get_witness_count",
        //  "condenser_api.get_witness_schedule",
        //  "condenser_api.get_witnesses",
        //  "condenser_api.get_witnesses_by_vote",
        //  "condenser_api.lookup_account_names",
        //  "condenser_api.lookup_accounts",
        //  "condenser_api.lookup_witness_accounts",
        //  "condenser_api.verify_account_authority",
        //  "condenser_api.verify_authority",
    }
}
