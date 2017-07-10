using System.Collections.Generic;
using Ditch.Helpers;
using Newtonsoft.Json;

namespace Ditch.Operations.Post
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
    public class BeneficiaryContainer : INamedConteiner
    {
        public const byte Key = 0;

        [JsonProperty("beneficiaries")]
        [SerializeHelper.MessageOrder(10)]
        public Beneficiary[] BeneficiariesContainer { get; set; }
        
        public BeneficiaryContainer(Beneficiary[] beneficiaries)
        {
            BeneficiariesContainer = beneficiaries;
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Beneficiary : INamedConteiner
    {
        [SerializeHelper.MessageOrder(10)]
        [JsonProperty("account")]
        public string Account { get; set; }

        [SerializeHelper.MessageOrder(20)]
        [JsonProperty("weight")]
        public ushort Weight { get; set; }

        public Beneficiary(string account, ushort weight)
        {
            Account = account;
            Weight = weight;
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class BeneficiaresOperation : CommentOptionsOperation
    {
        public BeneficiaresOperation(string author, string permlink, string currency, params Beneficiary[] beneficiaries)
            : base(author, permlink, new Money(1000000000, 3, currency), 10000, true, true, SetBeneficiaries(beneficiaries))
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