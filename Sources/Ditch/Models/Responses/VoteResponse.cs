namespace Ditch.Models.Responses
{
    /// {
    ///   "message": "Upvoted",
    ///   "new_total_payout_reward": "0.00"
    /// }
    public class VoteResponse : MessageField
    {
        public double NewTotalPayoutReward { get; set; }

        public bool IsVoted => Message.Equals("Upvoted");
    }
}