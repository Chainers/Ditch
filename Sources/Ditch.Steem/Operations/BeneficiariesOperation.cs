using System.IO;
using Ditch.Core.Attributes;
using Ditch.Core.Interfaces;
using Ditch.Steem.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Operations
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CommentPayoutBeneficiaries : ICustomSerializer
    {
        public const string OperationName = "comment_payout_beneficiaries";

        public Beneficiary[] Beneficiaries { get; set; }

        public CommentPayoutBeneficiaries(Beneficiary[] beneficiaries)
        {
            Beneficiaries = beneficiaries;
        }

        #region ICustomSerializer

        public void Serializer(Stream stream, IMessageSerializer serializeHelper)
        {
            stream.WriteByte(0);
            serializeHelper.AddToMessageStream(stream, Beneficiaries.GetType(), Beneficiaries);
        }

        #endregion
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Beneficiary
    {
        [MessageOrder(10)]
        [JsonProperty("account")]
        public string Account { get; set; }

        [MessageOrder(20)]
        [JsonProperty("weight")]
        public ushort Weight { get; set; }

        public Beneficiary(string account, ushort weight)
        {
            Account = account;
            Weight = weight;
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class BeneficiariesOperation : CommentOptionsOperation
    {
        public BeneficiariesOperation(string author, string permlink, params Beneficiary[] beneficiaries)
            : base(author, permlink, new Asset(1000000000, Config.SteemAssetNumSbd), 10000, true, true, SetExtensions(beneficiaries))
        {
        }

        public BeneficiariesOperation(string author, string permlink, Asset maxAcceptedPayout, params Beneficiary[] beneficiaries)
            : base(author, permlink, maxAcceptedPayout, 10000, true, true, SetExtensions(beneficiaries))
        {
        }

        public BeneficiariesOperation(string author, string permlink, Asset maxAcceptedPayout, ushort percentSteemDollars, bool allowVotes, bool allowCurationRewards, params Beneficiary[] beneficiaries)
            : base(author, permlink, maxAcceptedPayout, percentSteemDollars, allowVotes, allowCurationRewards, SetExtensions(beneficiaries))
        {
        }


        private static object[] SetExtensions(Beneficiary[] beneficiaries)
        {
            return new object[]
            {
                new CommentPayoutBeneficiaries(beneficiaries)
            };
        }
    }
}