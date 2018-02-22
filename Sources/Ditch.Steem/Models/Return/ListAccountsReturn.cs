using Ditch.Steem.Models.Objects;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// list_accounts_return
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ListAccountsReturn
    {

        /// <summary>
        /// API name: accounts
        /// 
        /// </summary>
        /// <returns>API type: api_account_object</returns>
        [JsonProperty("accounts")]
        public ApiAccountObject[] Accounts {get; set;}
    }
}
