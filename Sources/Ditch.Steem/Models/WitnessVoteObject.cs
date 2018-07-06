using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// witness_vote_object
    /// libraries\chain\include\steem\chain\witness_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class WitnessVoteObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: id_type</returns>
        [JsonProperty("id")]
        public object Id {get; set;}

        /// <summary>
        /// API name: witness
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("witness")]
        public string Witness {get; set;}

        /// <summary>
        /// API name: account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("account")]
        public string Account {get; set;}
    }
}
