using Ditch.Core.Attributes;
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
    public class Action
    {
        /// <summary>
        /// API name: account
        /// 
        /// </summary>
        /// <returns>API type: account_name</returns>
        [MessageOrder(10)]
        [JsonProperty("account")]
        public AccountName Account { get; set; }

        /// <summary>
        /// API name: name
        /// 
        /// </summary>
        /// <returns>API type: action_name</returns>
        [MessageOrder(20)]
        [JsonProperty("name")]
        public ActionName Name { get; set; }

        /// <summary>
        /// API name: authorization
        /// 
        /// </summary>
        /// <returns>API type: permission_level</returns>
        [MessageOrder(30)]
        [JsonProperty("authorization")]
        public PermissionLevel[] Authorization { get; set; }

        /// <summary>
        /// API name: data
        /// 
        /// </summary>
        /// <returns>API type: bytes</returns>
        [MessageOrder(40)]
        [JsonProperty("data")]
        public Bytes Data { get; set; }


        public Action() { }

        public Action(AccountName accountName, ActionName actionName, PermissionLevel[] permissionLevels)
        {
            Account = accountName;
            Name = actionName;
            Authorization = permissionLevels;
        }

        public Action(AccountName accountName, ActionName actionName, PermissionLevel[] permissionLevels, Bytes data)
        : this(accountName, actionName, permissionLevels)
        {
            Data = data;
        }
    }
}
