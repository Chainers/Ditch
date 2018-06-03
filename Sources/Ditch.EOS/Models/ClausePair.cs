using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// clause_pair
    /// libraries\chain\include\eosio\chain\contracts\types.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ClausePair
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// API name: body
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
