using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// find_escrows_args
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FindEscrowsArgs
    {

        /// <summary>
        /// API name: from
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("from")]
        public string From {get; set;}
    }
}
