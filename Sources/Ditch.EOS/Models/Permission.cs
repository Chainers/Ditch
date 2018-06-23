using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// permission
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Permission
    {

        /// <summary>
        /// API name: perm_name
        /// 
        /// </summary>
        /// <returns>API type: name</returns>
        [JsonProperty("perm_name")]
        public string PermName { get; set; }

        /// <summary>
        /// API name: parent
        /// 
        /// </summary>
        /// <returns>API type: name</returns>
        [JsonProperty("parent")]
        public string Parent { get; set; }

        /// <summary>
        /// API name: required_auth
        /// 
        /// </summary>
        /// <returns>API type: authority</returns>
        [JsonProperty("required_auth")]
        public Authority RequiredAuth { get; set; }
    }
}
