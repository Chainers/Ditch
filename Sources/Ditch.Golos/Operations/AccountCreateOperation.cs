using Ditch.Core.Attributes;
using Ditch.Golos.Models;
using Newtonsoft.Json;

namespace Ditch.Golos.Operations
{
    /// <inheritdoc />
    /// <summary>
    /// account_create_operation
    /// libraries\protocol\include\golos\protocol\steem_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AccountCreateOperation : BaseOperation
    {
        public const string OperationName = "account_create";

        public override OperationType Type => OperationType.AccountCreate;

        public override string TypeName => OperationName;

        /// <summary>
        /// API name: fee
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(20)]
        [JsonProperty("fee")]
        public Asset Fee { get; set; }

        /// <summary>
        /// API name: creator
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(30)]
        [JsonProperty("creator")]
        public string Creator { get; set; }

        /// <summary>
        /// API name: new_account_name
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(40)]
        [JsonProperty("new_account_name")]
        public string NewAccountName { get; set; }

        /// <summary>
        /// API name: owner
        /// 
        /// </summary>
        /// <returns>API type: authority</returns>
        [MessageOrder(50)]
        [JsonProperty("owner")]
        public Authority Owner { get; set; }

        /// <summary>
        /// API name: active
        /// 
        /// </summary>
        /// <returns>API type: authority</returns>
        [MessageOrder(60)]
        [JsonProperty("active")]
        public Authority Active { get; set; }

        /// <summary>
        /// API name: posting
        /// 
        /// </summary>
        /// <returns>API type: authority</returns>
        [MessageOrder(70)]
        [JsonProperty("posting")]
        public Authority Posting { get; set; }

        /// <summary>
        /// API name: memo_key
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [MessageOrder(80)]
        [JsonProperty("memo_key")]
        public PublicKeyType MemoKey { get; set; }

        /// <summary>
        /// API name: json_metadata
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [MessageOrder(90)]
        [JsonProperty("json_metadata")]
        public string JsonMetadata { get; set; }


        public AccountCreateOperation()
        {
            Owner = new Authority();
            Active = new Authority();
            Posting = new Authority();
        }
    }
}
