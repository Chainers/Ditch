using System;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.Objects
{
    /// <summary>
    /// bucket_object
    /// plugins\blockchain_statistics\include\golos\plugins\blockchain_statistics\bucket_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class BucketObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: id_type</returns>
        [JsonProperty("id")]
        public object Id {get; set;}

        /// <summary>
        /// API name: open
        /// Open time of the bucket
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("open")]
        public DateTime Open {get; set;}

        /// <summary>
        /// API name: seconds
        /// = 0; ///&lt; Seconds accounted for in the bucket
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("seconds")]
        public uint Seconds {get; set;}

        /// <summary>
        /// API name: blocks
        /// = 0; ///&lt; Blocks produced
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("blocks")]
        public uint Blocks {get; set;}

        /// <summary>
        /// API name: bandwidth
        /// = 0; ///&lt; Bandwidth in bytes
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("bandwidth")]
        public uint Bandwidth {get; set;}

        /// <summary>
        /// API name: operations
        /// = 0; ///&lt; Operations evaluated
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("operations")]
        public uint Operations {get; set;}

        /// <summary>
        /// API name: transactions
        /// = 0; ///&lt; Transactions processed
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("transactions")]
        public uint Transactions {get; set;}

        /// <summary>
        /// API name: transfers
        /// = 0; ///&lt; Account to account transfers
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("transfers")]
        public uint Transfers {get; set;}

        /// <summary>
        /// API name: steem_transferred
        /// = 0; ///&lt; STEEM transferred from account to account
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("steem_transferred")]
        public object SteemTransferred {get; set;}

        /// <summary>
        /// API name: sbd_transferred
        /// = 0; ///&lt; SBD transferred from account to account
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("sbd_transferred")]
        public object SbdTransferred {get; set;}

        /// <summary>
        /// API name: sbd_paid_as_interest
        /// = 0; ///&lt; SBD paid as interest
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("sbd_paid_as_interest")]
        public object SbdPaidAsInterest {get; set;}

        /// <summary>
        /// API name: paid_accounts_created
        /// = 0; ///&lt; Accounts created with fee
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("paid_accounts_created")]
        public uint PaidAccountsCreated {get; set;}

        /// <summary>
        /// API name: mined_accounts_created
        /// = 0; ///&lt; Accounts mined for free
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("mined_accounts_created")]
        public uint MinedAccountsCreated {get; set;}

        /// <summary>
        /// API name: root_comments
        /// = 0; ///&lt; Top level root comments
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("root_comments")]
        public uint RootComments {get; set;}

        /// <summary>
        /// API name: root_comment_edits
        /// = 0; ///&lt; Edits to root comments
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("root_comment_edits")]
        public uint RootCommentEdits {get; set;}

        /// <summary>
        /// API name: root_comments_deleted
        /// = 0; ///&lt; Root comments deleted
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("root_comments_deleted")]
        public uint RootCommentsDeleted {get; set;}

        /// <summary>
        /// API name: replies
        /// = 0; ///&lt; Replies to comments
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("replies")]
        public uint Replies {get; set;}

        /// <summary>
        /// API name: reply_edits
        /// = 0; ///&lt; Edits to replies
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("reply_edits")]
        public uint ReplyEdits {get; set;}

        /// <summary>
        /// API name: replies_deleted
        /// = 0; ///&lt; Replies deleted
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("replies_deleted")]
        public uint RepliesDeleted {get; set;}

        /// <summary>
        /// API name: new_root_votes
        /// = 0; ///&lt; New votes on root comments
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("new_root_votes")]
        public uint NewRootVotes {get; set;}

        /// <summary>
        /// API name: changed_root_votes
        /// = 0; ///&lt; Changed votes on root comments
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("changed_root_votes")]
        public uint ChangedRootVotes {get; set;}

        /// <summary>
        /// API name: new_reply_votes
        /// = 0; ///&lt; New votes on replies
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("new_reply_votes")]
        public uint NewReplyVotes {get; set;}

        /// <summary>
        /// API name: changed_reply_votes
        /// = 0; ///&lt; Changed votes on replies
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("changed_reply_votes")]
        public uint ChangedReplyVotes {get; set;}

        /// <summary>
        /// API name: payouts
        /// = 0; ///&lt; Number of comment payouts
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("payouts")]
        public uint Payouts {get; set;}

        /// <summary>
        /// API name: sbd_paid_to_authors
        /// = 0; ///&lt; Ammount of SBD paid to authors
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("sbd_paid_to_authors")]
        public object SbdPaidToAuthors {get; set;}

        /// <summary>
        /// API name: vests_paid_to_authors
        /// = 0; ///&lt; Ammount of VESS paid to authors
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("vests_paid_to_authors")]
        public object VestsPaidToAuthors {get; set;}

        /// <summary>
        /// API name: vests_paid_to_curators
        /// = 0; ///&lt; Ammount of VESTS paid to curators
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("vests_paid_to_curators")]
        public object VestsPaidToCurators {get; set;}

        /// <summary>
        /// API name: liquidity_rewards_paid
        /// = 0; ///&lt; Ammount of STEEM paid to market makers
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("liquidity_rewards_paid")]
        public object LiquidityRewardsPaid {get; set;}

        /// <summary>
        /// API name: transfers_to_vesting
        /// = 0; ///&lt; Transfers of STEEM into VESTS
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("transfers_to_vesting")]
        public uint TransfersToVesting {get; set;}

        /// <summary>
        /// API name: steem_vested
        /// = 0; ///&lt; Ammount of STEEM vested
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("steem_vested")]
        public object SteemVested {get; set;}

        /// <summary>
        /// API name: new_vesting_withdrawal_requests
        /// = 0; ///&lt; New vesting withdrawal requests
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("new_vesting_withdrawal_requests")]
        public uint NewVestingWithdrawalRequests {get; set;}

        /// <summary>
        /// API name: modified_vesting_withdrawal_requests
        /// = 0; ///&lt; Changes to vesting withdrawal requests
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("modified_vesting_withdrawal_requests")]
        public uint ModifiedVestingWithdrawalRequests {get; set;}

        /// <summary>
        /// API name: vesting_withdraw_rate_delta
        /// = 0;
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("vesting_withdraw_rate_delta")]
        public object VestingWithdrawRateDelta {get; set;}

        /// <summary>
        /// API name: vesting_withdrawals_processed
        /// = 0; ///&lt; Number of vesting withdrawals
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("vesting_withdrawals_processed")]
        public uint VestingWithdrawalsProcessed {get; set;}

        /// <summary>
        /// API name: finished_vesting_withdrawals
        /// = 0; ///&lt; Processed vesting withdrawals that are now finished
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("finished_vesting_withdrawals")]
        public uint FinishedVestingWithdrawals {get; set;}

        /// <summary>
        /// API name: vests_withdrawn
        /// = 0; ///&lt; Ammount of VESTS withdrawn to STEEM
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("vests_withdrawn")]
        public object VestsWithdrawn {get; set;}

        /// <summary>
        /// API name: vests_transferred
        /// = 0; ///&lt; Ammount of VESTS transferred to another account
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("vests_transferred")]
        public object VestsTransferred {get; set;}

        /// <summary>
        /// API name: sbd_conversion_requests_created
        /// = 0; ///&lt; SBD conversion requests created
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("sbd_conversion_requests_created")]
        public uint SbdConversionRequestsCreated {get; set;}

        /// <summary>
        /// API name: sbd_to_be_converted
        /// = 0; ///&lt; Amount of SBD to be converted
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("sbd_to_be_converted")]
        public object SbdToBeConverted {get; set;}

        /// <summary>
        /// API name: sbd_conversion_requests_filled
        /// = 0; ///&lt; SBD conversion requests filled
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("sbd_conversion_requests_filled")]
        public uint SbdConversionRequestsFilled {get; set;}

        /// <summary>
        /// API name: steem_converted
        /// = 0; ///&lt; Amount of STEEM that was converted
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("steem_converted")]
        public object SteemConverted {get; set;}

        /// <summary>
        /// API name: limit_orders_created
        /// = 0; ///&lt; Limit orders created
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("limit_orders_created")]
        public uint LimitOrdersCreated {get; set;}

        /// <summary>
        /// API name: limit_orders_filled
        /// = 0; ///&lt; Limit orders filled
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("limit_orders_filled")]
        public uint LimitOrdersFilled {get; set;}

        /// <summary>
        /// API name: limit_orders_cancelled
        /// = 0; ///&lt; Limit orders cancelled
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("limit_orders_cancelled")]
        public uint LimitOrdersCancelled {get; set;}

        /// <summary>
        /// API name: total_pow
        /// = 0; ///&lt; POW submitted
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("total_pow")]
        public uint TotalPow {get; set;}

        /// <summary>
        /// API name: estimated_hashpower
        /// = 0; ///&lt; Estimated average hashpower over interval
        /// </summary>
        /// <returns>API type: uint128_t</returns>
        [JsonProperty("estimated_hashpower")]
        public string EstimatedHashpower {get; set;}
    }
}
