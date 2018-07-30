using Ditch.Core.Attributes;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// permission_level
    /// contracts\eosiolib\action.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class PermissionLevel
    {

        /// <summary>
        /// API name: actor
        /// 
        /// </summary>
        /// <returns>API type: account_name</returns>
        [MessageOrder(10)]
        [JsonProperty("actor")]
        public AccountName Actor { get; set; }

        /// <summary>
        /// API name: permission
        /// 
        /// </summary>
        /// <returns>API type: permission_name</returns>
        [MessageOrder(20)]
        [JsonProperty("permission")]
        public PermissionName Permission { get; set; }


        public PermissionLevel() { }

        public PermissionLevel(AccountName actor, PermissionName permissionName)
        {
            Actor = actor;
            Permission = permissionName;
        }
    }
}
