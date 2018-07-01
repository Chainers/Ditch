using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// get_block_return
    /// libraries\plugins\apis\block_api\include\steem\plugins\block_api\block_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetBlockReturn
    {

        /// <summary>
        /// API name: block
        /// 
        /// </summary>
        /// <returns>API type: api_signed_block_object</returns>
        [JsonProperty("block", NullValueHandling = NullValueHandling.Ignore)]
        public ApiSignedBlockObject Block {get; set;}
    }
}
