using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// permission_level
    /// contracts\eosiolib\action.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class PermissionLevel
    {

        /// <summary>
        /// API name: actor
        /// 
        /// </summary>
        /// <returns>API type: account_name</returns>
        [JsonProperty("actor")]
        public string Actor {get; set;}

        /// <summary>
        /// API name: permission
        /// 
        /// </summary>
        /// <returns>API type: permission_name</returns>
        [JsonProperty("permission")]
        public string Permission {get; set;}
    }
}
