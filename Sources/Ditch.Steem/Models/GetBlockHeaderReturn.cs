using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// get_block_header_return
    /// libraries\plugins\apis\block_api\include\steem\plugins\block_api\block_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetBlockHeaderReturn
    {

        /// <summary>
        /// API name: header
        /// 
        /// </summary>
        /// <returns>API type: block_header</returns>
        [JsonProperty("header", NullValueHandling = NullValueHandling.Ignore)]
        public BlockHeader Header {get; set;}
    }
}
