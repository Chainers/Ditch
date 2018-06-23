using Ditch.Steem.Models.Objects;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// list_witnesses_return
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ListWitnessesReturn
    {

        /// <summary>
        /// API name: witnesses
        /// 
        /// </summary>
        /// <returns>API type: api_witness_object</returns>
        [JsonProperty("witnesses")]
        public ApiWitnessObject[] Witnesses {get; set;}
    }
}
