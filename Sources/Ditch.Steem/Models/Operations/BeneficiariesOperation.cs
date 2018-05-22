using System;
using Ditch.Core.Attributes;
using Ditch.Core.Models;
using Ditch.Steem.Models.Other;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Operations
{
    [JsonObject(MemberSerialization.OptIn)]
    public class BeneficiaryContainer : INamedContainer
    {
        public const byte Key = 0;

        [JsonProperty("beneficiaries")]
        [MessageOrder(10)]
        public Beneficiary[] BeneficiariesContainer { get; set; }

        public BeneficiaryContainer(Beneficiary[] beneficiaries)
        {
            BeneficiariesContainer = beneficiaries;
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Beneficiary : INamedContainer
    {
        [MessageOrder(10)]
        [JsonProperty("account")]
        public string Account { get; set; }

        [MessageOrder(20)]
        [JsonProperty("weight")]
        public UInt16 Weight { get; set; }

        public Beneficiary(string account, UInt16 weight)
        {
            Account = account;
            Weight = weight;
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class BeneficiariesOperation : CommentOptionsOperation
    {
        public BeneficiariesOperation(string author, string permlink, params Beneficiary[] beneficiaries)
            : base(author, permlink, new Asset(1000000000, Config.SteemAssetNumSbd), 10000, true, true, SetBeneficiaries(beneficiaries))
        {
        }

        public BeneficiariesOperation(string author, string permlink, Asset maxAcceptedPayout, params Beneficiary[] beneficiaries)
            : base(author, permlink, maxAcceptedPayout, 10000, true, true, SetBeneficiaries(beneficiaries))
        {
        }

        public BeneficiariesOperation(string author, string permlink, Asset maxAcceptedPayout, UInt16 percentSteemDollars, bool allowVotes, bool allowCurationRewards, params Beneficiary[] beneficiaries)
            : base(author, permlink, maxAcceptedPayout, percentSteemDollars, allowVotes, allowCurationRewards, SetBeneficiaries(beneficiaries))
        {
        }


        private static object[] SetBeneficiaries(Beneficiary[] beneficiaries)
        {
            return new object[]
            {
                new KeyContainer(BeneficiaryContainer.Key, new BeneficiaryContainer(beneficiaries))
            };
        }
    }
}