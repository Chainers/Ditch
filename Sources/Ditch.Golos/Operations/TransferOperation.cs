using Ditch.Core.Attributes;
using Ditch.Golos.Models;
using Newtonsoft.Json;

namespace Ditch.Golos.Operations
{
    /// <summary>
    /// Transfers STEEM from one account to another.
    /// 
    /// transfer_operation
    /// libraries\protocol\include\steemit\protocol\steem_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class TransferOperation : BaseOperation
    {
        public override OperationType Type => OperationType.Transfer;

        public override string TypeName => "transfer";


        /// <summary>
        /// API name: from
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(20)]
        [JsonProperty("from")]
        public string From { get; set; }

        /// Account to transfer asset to

        /// <summary>
        /// API name: to
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(30)]
        [JsonProperty("to")]
        public string To { get; set; }

        /// The amount of asset to transfer from @ref from to @ref to

        /// <summary>
        /// API name: amount
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(40)]
        [JsonProperty("amount")]
        public Asset Amount { get; set; }


        /// The memo is plain-text, any encryption on the memo is up to
        /// a higher level protocol.

        /// <summary>
        /// API name: memo
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [MessageOrder(50)]
        [JsonProperty("memo")]
        public string Memo { get; set; }


        /// <summary>
        /// Transfers STEEM from one account to another.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="amount"></param>
        /// <param name="memo"></param>
        public TransferOperation(string from, string to, Asset amount, string memo)
        {
            From = from;
            To = to;
            Amount = amount;
            Memo = memo;
        }
    }
}
