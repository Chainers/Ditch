using Newtonsoft.Json;

namespace Ditch.Steem.Models.Args
{
    /* get_block_header */

    /// <summary>
    /// get_block_header_args
    /// libraries\plugins\apis\block_api\include\steem\plugins\block_api\block_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetBlockHeaderArgs
    {

        /// <summary>
        /// API name: block_num
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("block_num")]
        public uint BlockNum {get; set;}
    }
}
