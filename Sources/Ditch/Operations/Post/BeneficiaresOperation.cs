using System;
using Ditch.Helpers;
using Newtonsoft.Json;

namespace Ditch.Operations.Post
{
    [Obsolete("The class is still not ready to use. SetBeneficiaries is wrong - when validating the signature, an error will be returned")]
    [JsonObject(MemberSerialization.OptIn)]
    public class BeneficiaresOperation : CommentOptionsOperation
    {
        public class BeneficiaryContainer : INamedConteiner
        {
            [SerializeHelper.MessageOrder(10)]
            [JsonProperty("beneficiaries")]
            public Beneficiary[] Beneficiaries { get; set; }

            public BeneficiaryContainer(Beneficiary[] beneficiaries)
            {
                Beneficiaries = beneficiaries;
            }
        }

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


        public BeneficiaresOperation(string author, string permlink, string currency, params Beneficiary[] beneficiaries)
            : base(author, permlink, new Money(1000000000, 3, currency), 10000, true, true, SetBeneficiaries(beneficiaries))
        {
        }

        private static object[] SetBeneficiaries(Beneficiary[] beneficiaries)
        {
            return new object[]
            {
                new object[]
                {
                    (byte) 0,
                    new BeneficiaryContainer(beneficiaries)
                }
            };
        }
    }
}