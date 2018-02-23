using Ditch.Steem.Models.Objects;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// get_block_header_return
    /// libraries\plugins\apis\block_api\include\steem\plugins\block_api\block_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GetBlockHeaderReturn
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
