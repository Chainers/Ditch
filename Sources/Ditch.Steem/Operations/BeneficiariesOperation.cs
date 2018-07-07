using System;
using System.IO;
using Ditch.Core.Attributes;
using Ditch.Core.Converters;
using Ditch.Core.Interfaces;
using Ditch.Steem.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Operations
{
    [JsonConverter(typeof(CustomConverter))]
    [JsonObject(MemberSerialization.OptIn)]
    public class CommentPayoutBeneficiaries : ICustomJson, ICustomSerializer
    {
        public const string OperationName = "comment_payout_beneficiaries";

        public Beneficiary[] Beneficiaries { get; set; }

        public CommentPayoutBeneficiaries(Beneficiary[] beneficiaries)
        {
            Beneficiaries = beneficiaries;
        }

        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            throw new NotImplementedException("Oops, it seems that Ditch doesn't support this functionality yet. Try adding it yourself or contact the developer.");
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("type");
            writer.WriteValue(OperationName);
            writer.WritePropertyName("value");

            writer.WriteStartObject();
            writer.WritePropertyName("beneficiaries");
            serializer.Serialize(writer, Beneficiaries);
            writer.WriteEndObject();

            writer.WriteEndObject();
        }

        #endregion

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