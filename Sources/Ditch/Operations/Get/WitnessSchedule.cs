using System;
using Newtonsoft.Json;

namespace Ditch.Operations.Get
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ChainProperties
    {
        /// <summary>
        /// This fee, paid in STEEM, is converted into VESTING SHARES for the new account.Accounts 
        /// without vesting shares cannot earn usage rations and therefore are powerless.This minimum 
        /// fee requires all accounts to have some kind of commitment to the network that includes the
        ///  ability to vote and make transactions.
        /// </summary>
        [JsonProperty("account_creation_fee")]
        public Money AccountCreationFee { get; set; }

        /// <summary>
        /// This witnesses vote for the maximum_block_size which is used by the network to tune rate limiting and capacity
        /// </summary>
        [JsonProperty("maximum_block_size")]
        public UInt32 MaximumBlockSize { get; set; }

        [JsonProperty("sbd_interest_rate")]
        public UInt16 SbdInterestRate { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class WitnessSchedule
    {
        [JsonProperty("id")]
        public UInt64 Id { get; set; }

        [JsonProperty("current_virtual_time")]
        public string CurrentVirtualTime { get; set; }

        [JsonProperty("next_shuffle_block_num")]
        public UInt32 NextShuffleBlockNum { get; set; }

        [JsonProperty("current_shuffled_witnesses")]
        public string CurrentShuffledWitnesses { get; set; }

        [JsonProperty("num_scheduled_witnesses")]
        public byte NumScheduledWitnesses { get; set; }

        [JsonProperty("top19_weight")]
        public byte Top19Weight { get; set; }

        [JsonProperty("timeshare_weight")]
        public byte TimeshareWeight { get; set; }

        [JsonProperty("miner_weight")]
        public byte MinerWeight { get; set; }

        [JsonProperty("witness_pay_normalization_factor")]
        public UInt32 WitnessPayNormalizationFactor { get; set; }

        [JsonProperty("median_props")]
        public ChainProperties MedianProps { get; set; }

        [JsonProperty("majority_version")]
        public string MajorityVersion { get; set; }

        [JsonProperty("max_voted_witnesses")]
        public byte MaxVotedWitnesses { get; set; }

        [JsonProperty("max_miner_witnesses")]
        public byte MaxMinerWitnesses { get; set; }

        [JsonProperty("max_runner_witnesses")]
        public byte MaxRunnerWitnesses { get; set; }

        [JsonProperty("hardfork_required_witnesses")]
        public byte HardforkRequiredWitnesses { get; set; }
    }
}