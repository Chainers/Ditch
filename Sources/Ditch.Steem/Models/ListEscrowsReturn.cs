using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// list_escrows_return
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ListEscrowsReturn
    {

        /// <summary>
        /// API name: escrows
        /// 
        /// </summary>
        /// <returns>API type: api_escrow_object</returns>
        [JsonProperty("escrows")]
        public ApiEscrowObject[] Escrows {get; set;}
    }
}
