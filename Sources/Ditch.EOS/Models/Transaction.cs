using System;
using Ditch.Core.Attributes;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <inheritdoc />
    /// <summary>
    /// transaction
    /// contracts\eosiolib\transaction.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Transaction : TransactionHeader
    {
        /// <summary>
        /// API name: context_free_actions
        /// 
        /// </summary>
        /// <returns>API type: vector&lt;action></returns>
        [MessageOrder(70)]
        [JsonProperty("context_free_actions")]
        public BaseAction[] ContextFreeActions { get; set; } = new BaseAction[0];

        /// <summary>
        /// API name: actions
        /// 
        /// </summary>
        /// <returns>API type: vector&lt;action></returns>
        [MessageOrder(80)]
        [JsonProperty("actions")]
        public BaseAction[] Actions { get; set; } = new BaseAction[0];

        /// <summary>
        /// API name: transaction_extensions
        /// 
        /// </summary>
        /// <returns>API type: extensions_type</returns>
        [MessageOrder(90)]
        [JsonProperty("transaction_extensions")]
        public Tuple<ushort, char[]>[] TransactionExtensions { get; set; } = new Tuple<ushort, char[]>[0];
    }
}
