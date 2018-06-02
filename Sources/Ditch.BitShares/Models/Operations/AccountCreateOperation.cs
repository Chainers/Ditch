using System;
using Ditch.Core.Attributes;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models.Operations
{
    /**
     *  @ingroup operations
     */

    /// <summary>
    /// account_create_operation
    /// libraries\chain\include\graphene\chain\protocol\account.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class AccountCreateOperation : BaseOperation
    {
        public override OperationType Type => OperationType.AccountCreate;

        public override string TypeName => "account_create";

        /// <summary>
        /// API name: fee
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(20)]
        [JsonProperty("fee")]
        public Asset Fee { get; set; }

        /// <summary>
        /// API name: registrar
        /// 
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [MessageOrder(30)]
        [JsonProperty("registrar")]
        public AccountIdType Registrar { get; set; }


        /// This account receives a portion of the fee split between registrar and referrer. Must be a member.

        /// <summary>
        /// API name: referrer
        /// 
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [MessageOrder(40)]
        [JsonProperty("referrer")]
        public AccountIdType Referrer { get; set; }

        /// Of the fee split between registrar and referrer, this percentage goes to the referrer. The rest goes to the
        /// registrar.

        /// <summary>
        /// API name: referrer_percent
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [MessageOrder(50)]
        [JsonProperty("referrer_percent")]
        public UInt16 ReferrerPercent { get; set; }

        /// <summary>
        /// API name: name
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [MessageOrder(60)]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// API name: owner
        /// 
        /// </summary>
        /// <returns>API type: authority</returns>
        [MessageOrder(70)]
        [JsonProperty("owner")]
        public Authority Owner { get; set; }

        /// <summary>
        /// API name: active
        /// 
        /// </summary>
        /// <returns>API type: authority</returns>
        [MessageOrder(80)]
        [JsonProperty("active")]
        public Authority Active { get; set; }

        /// <summary>
        /// API name: options
        /// 
        /// </summary>
        /// <returns>API type: account_options</returns>
        [MessageOrder(90)]
        [JsonProperty("options")]
        public AccountOptions Options { get; set; }

        /// <summary>
        /// API name: extensions
        /// 
        /// </summary>
        /// <returns>API type: extension</returns>
        [MessageOrder(100)]
        [JsonProperty("extensions")]
        public object[] Extensions { get; set; } = new object[0];
    }
}
