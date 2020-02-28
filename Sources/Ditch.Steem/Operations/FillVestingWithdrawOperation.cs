using Ditch.Core.Attributes;
using Ditch.Steem.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Operations
{
    /// <inheritdoc />
    /// <summary>
    ///  ****
    /// fill_vesting_withdraw_operation
    /// libraries\protocol\include\steem\protocol\steem_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FillVestingWithdrawOperation : BaseOperation
    {
        public const string OperationName = "fill_vesting_withdraw_operation";
        public override string TypeName => OperationName;

        public override OperationType Type => OperationType.FillVestingWithdraw;

        /// <summary>
        /// API name: from_account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(20)]
        [JsonProperty("from_account")]
        public string FromAccount { get; set; }

        /// <summary>
        /// API name: to_account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(30)]
        [JsonProperty("to_account")]
        public string ToAccount { get; set; }

        /// <summary>
        /// API name: withdrawn
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(40)]
        [JsonProperty("withdrawn")]
        public Asset Withdrawn { get; set; }

        /// <summary>
        /// API name: deposited
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(50)]
        [JsonProperty("deposited")]
        public Asset Deposited { get; set; }
    }
}
