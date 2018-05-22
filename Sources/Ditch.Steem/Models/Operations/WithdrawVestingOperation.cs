using Ditch.Core.Attributes;
using Ditch.Steem.Models.Other;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Operations
{
    /// <summary>
    ///  At any given point in time an account can be withdrawing from their vesting shares. A user may change the number of shares they wish to cash out at any time between 0 and their total vesting stake. After applying this operation, vesting_shares will be withdrawn at a rate of vesting_shares/104 per week for two years starting one week after this operation is included in the blockchain. This operation is not valid if the user has no vesting shares.
    /// 
    /// withdraw_vesting_operation
    /// libraries\protocol\include\steem\protocol\steem_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class WithdrawVestingOperation : BaseOperation
    {
        public override OperationType Type => OperationType.WithdrawVesting;

        public override string TypeName => "withdraw_vesting";

        /// <summary>
        /// API name: account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(20)]
        [JsonProperty("account")]
        public string Account { get; set; }

        /// <summary>
        /// API name: vesting_shares
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(30)]
        [JsonProperty("vesting_shares")]
        public Asset VestingShares { get; set; }

        /// <summary>
        ///  At any given point in time an account can be withdrawing from their vesting shares. A user may change the number of shares they wish to cash out at any time between 0 and their total vesting stake. After applying this operation, vesting_shares will be withdrawn at a rate of vesting_shares/104 per week for two years starting one week after this operation is included in the blockchain. This operation is not valid if the user has no vesting shares.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="vestingShares"></param>
        public WithdrawVestingOperation(string account, Asset vestingShares)
        {
            Account = account;
            VestingShares = vestingShares;
        }
    }
}
