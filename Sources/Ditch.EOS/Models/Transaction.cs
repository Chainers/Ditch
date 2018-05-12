using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /**
    *  A transaction consits of a set of messages which must all be applied or
    *  all are rejected. These messages have access to data within the given
    *  read and write scopes.
    */

    /// <summary>
    /// transaction
    /// libraries\chain\include\eosio\chain\transaction.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Transaction : TransactionHeader
    {

        /// <summary>
        /// API name: context_free_actions
        /// 
        /// </summary>
        /// <returns>API type: action</returns>
        [JsonProperty("context_free_actions")]
        public Action[] ContextFreeActions { get; set; }

        /// <summary>
        /// API name: actions
        /// 
        /// </summary>
        /// <returns>API type: action</returns>
        [JsonProperty("actions")]
        public Action[] Actions { get; set; }
    }
}