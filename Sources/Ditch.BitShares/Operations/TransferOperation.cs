using Ditch.BitShares.Models;
using Ditch.Core.Attributes;
using Newtonsoft.Json;

namespace Ditch.BitShares.Operations
{
    /**
     * @ingroup operations
     *
     * @brief Transfers an amount of one asset from one account to another
     *
     *  Fees are paid by the "from" account
     *
     *  @pre amount.amount > 0
     *  @pre fee.amount >= 0
     *  @pre from != to
     *  @post from account's balance will be reduced by fee and amount
     *  @post to account's balance will be increased by amount
     *  @return n/a
     */

    /// <summary>
    /// transfer_operation
    /// libraries\protocol\include\graphene\protocol\transfer.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class TransferOperation : BaseOperation
    {
        public override OperationType Type => OperationType.Transfer;

        public override string TypeName => "transfer";

        /// <summary>
        /// API name: fee
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(20)]
        [JsonProperty("fee")]
        public Asset Fee { get; set; }

        /// <summary>
        /// API name: from
        /// 
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [MessageOrder(30)]
        [JsonProperty("from")]
        public AccountIdType From { get; set; }

        /// <summary>
        /// API name: to
        /// 
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [MessageOrder(40)]
        [JsonProperty("to")]
        public AccountIdType To { get; set; }

        /// <summary>
        /// API name: amount
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(50)]
        [JsonProperty("amount")]
        public Asset Amount { get; set; }

        /// <summary>
        /// API name: memo
        /// 
        /// </summary>
        /// <returns>API type: memo_data</returns>
        [JsonProperty("memo", NullValueHandling = NullValueHandling.Ignore)]
        [MessageOrder(60)]
        public MemoData Memo { get; set; }

        /// <summary>
        /// API name: extensions
        /// 
        /// </summary>
        /// <returns>API type: extensions_type</returns>
        [MessageOrder(70)]
        [JsonProperty("extensions")]
        public object[] Extensions { get; set; }
    }
}
