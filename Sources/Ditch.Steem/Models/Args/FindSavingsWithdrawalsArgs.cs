using Newtonsoft.Json;

namespace Ditch.Steem.Models.Args
{
    /// <summary>
    /// find_savings_withdrawals_args
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FindSavingsWithdrawalsArgs
    {

        /// <summary>
        /// API name: account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("account")]
        public string Account {get; set;}
    }
}
