using Ditch.Core.Attributes;
using Ditch.Golos.Models;
using Newtonsoft.Json;

namespace Ditch.Golos.Operations
{
    /// <summary>
    /// This operation converts STEEM into VFS(Vesting Fund Shares) at the current exchange rate.With this operation it is possible to give another account vesting shares so that faucets can pre-fund new accounts with vesting shares.
    ///
    /// transfer_to_vesting_operation
    /// libraries\protocol\include\golos\protocol\steem_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class TransferToVestingOperation : BaseOperation
    {
        public const string OperationName = "transfer_to_vesting";

        public override OperationType Type => OperationType.TransferToVesting;

        public override string TypeName => OperationName;


        /// <summary>
        /// API name: from
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(20)]
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// API name: to
        /// if null, then same as from
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(30)]
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// API name: amount
        /// must be STEEM
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(40)]
        [JsonProperty("amount")]
        public Asset Amount { get; set; }


        public TransferToVestingOperation(string from, string to, Asset amount)
        {
            From = from;
            To = to;
            Amount = amount;
        }
    }
}
