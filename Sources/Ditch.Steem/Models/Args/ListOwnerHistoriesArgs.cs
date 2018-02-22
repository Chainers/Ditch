using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Args
{
    /* Owner Auth History */

    /// <summary>
    /// list_owner_histories_args
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ListOwnerHistoriesArgs
    {

        /// <summary>
        /// API name: start
        /// 
        /// </summary>
        /// <returns>API type: variant</returns>
        [JsonProperty("start")]
        public object Start {get; set;}

        /// <summary>
        /// API name: limit
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("limit")]
        public UInt32 Limit {get; set;}
    }
}
