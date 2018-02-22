using Ditch.Steem.Models.Enums;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Args
{
    /// <summary>
    /// find_withdraw_vesting_routes_args
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class FindWithdrawVestingRoutesArgs
    {

        /// <summary>
        /// API name: account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("account")]
        public string Account {get; set;}

        /// <summary>
        /// API name: order
        /// 
        /// </summary>
        /// <returns>API type: sort_order_type</returns>
        [JsonProperty("order")]
        public SortOrderType Order {get; set;}
    }
}
