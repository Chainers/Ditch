using Newtonsoft.Json;

namespace Ditch.Steem.Models.Args
{
    /// <summary>
    /// find_witnesses_args
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FindWitnessesArgs
    {

        /// <summary>
        /// API name: owners
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("owners")]
        public string[] Owners {get; set;}
    }
}
