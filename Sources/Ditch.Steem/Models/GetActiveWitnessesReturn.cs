using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// get_active_witnesses_return
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetActiveWitnessesReturn
    {

        /// <summary>
        /// API name: witnesses
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("witnesses")]
        public string[] Witnesses { get; set; }
    }
}
