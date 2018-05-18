using Ditch.Steem.Models.Other;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Operations
{
    /// <summary>
    /// This operation converts STEEM into VFS(Vesting Fund Shares) at the current exchange rate.With this operation it is possible to give another account vesting shares so that faucets can pre-fund new accounts with vesting shares.
    ///
    /// transfer_to_vesting_operation
    /// libraries\protocol\include\steem\protocol\steem_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class TransferToVestingOperation : BaseOperation
    {
        public override OperationType Type => OperationType.TransferToVesting;

        public override string TypeName => "transfer_to_vesting";


        /// <summary>
        /// API name: from
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// API name: to
        /// if null, then same as from
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// API name: amount
        /// must be STEEM
        /// </summary>
        /// <returns>API type: asset</returns>
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
