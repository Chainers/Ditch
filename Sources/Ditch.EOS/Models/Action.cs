using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /**
     * This is the packed representation of an action along with
     * meta-data about the authorization levels.
     */

    /// <summary>
    /// action
    /// contracts\eosiolib\action.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Action
    {

        /// <summary>
        /// API name: account
        /// 
        /// </summary>
        /// <returns>API type: account_name</returns>
        [JsonProperty("account")]
        public string Account { get; set; }

        /// <summary>
        /// API name: name
        /// 
        /// </summary>
        /// <returns>API type: action_name</returns>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// API name: authorization
        /// 
        /// </summary>
        /// <returns>API type: permission_level</returns>
        [JsonProperty("authorization")]
        public PermissionLevel[] Authorization { get; set; }

        /// <summary>
        /// API name: data
        /// 
        /// </summary>
        /// <returns>API type: bytes</returns>
        [JsonProperty("data")]
        public string Data { get; set; }
    }
}
