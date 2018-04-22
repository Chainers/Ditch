using System;
using System.Collections.Generic;
using Ditch.Core.Attributes;
using Ditch.Golos.Models.Other;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.Operations
{
    public class KeyContainer : List<object>
    {
        public KeyContainer(byte key, object value)
        {
            Add(key);
            Add(value);
        }
    }

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
        public BeneficiariesOperation(string author, string permlink, Asset asset, UInt16 percentSteemDollars, bool allowVotes, bool allowCurationRewards, params Beneficiary[] beneficiaries)
            : base(author, permlink, asset, percentSteemDollars, allowVotes, allowCurationRewards, SetBeneficiaries(beneficiaries))
        {
        }

        public BeneficiariesOperation(string author, string permlink, Asset asset, params Beneficiary[] beneficiaries)
            : this(author, permlink, asset, 10000, true, true, beneficiaries)
        {
        }

        public BeneficiariesOperation(string author, string permlink, string currency, params Beneficiary[] beneficiaries)
            : this(author, permlink, new Asset(1000000000, 3, currency), beneficiaries)
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