using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// get_transaction_hex_return
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetTransactionHexReturn
    {

        /// <summary>
        /// API name: hex
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("hex")]
        public string Hex {get; set;}
    }
}
