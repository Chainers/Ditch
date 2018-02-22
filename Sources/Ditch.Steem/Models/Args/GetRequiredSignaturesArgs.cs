using Ditch.Steem.Models.Objects;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Args
{
    /// <summary>
    /// get_required_signatures_args
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GetRequiredSignaturesArgs
    {

        /// <summary>
        /// API name: trx
        /// 
        /// </summary>
        /// <returns>API type: signed_transaction</returns>
        [JsonProperty("trx")]
        public SignedTransaction Trx {get; set;}

        /// <summary>
        /// API name: available_keys
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("available_keys")]
        public PublicKeyType[] AvailableKeys {get; set;}
    }
}
