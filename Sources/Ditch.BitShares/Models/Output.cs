using Ditch.Core;
using System;
using System.Collections.Generic;
using Ditch.BitShares.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// output
    /// libraries\wallet\include\graphene\wallet\wallet.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Output
    {

        /// <summary>
        /// API name: label
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// API name: pub_key
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [JsonProperty("pub_key")]
        public object PubKey { get; set; }

        /// <summary>
        /// API name: decrypted_memo
        /// 
        /// </summary>
        /// <returns>API type: stealth_confirmation::memo_data</returns>
        [JsonProperty("decrypted_memo")]
        public object DecryptedMemo { get; set; }

        /// <summary>
        /// API name: confirmation
        /// 
        /// </summary>
        /// <returns>API type: stealth_confirmation</returns>
        [JsonProperty("confirmation")]
        public StealthConfirmation Confirmation { get; set; }

        /// <summary>
        /// API name: auth
        /// 
        /// </summary>
        /// <returns>API type: authority</returns>
        [JsonProperty("auth")]
        public Authority Auth { get; set; }

        /// <summary>
        /// API name: confirmation_receipt
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("confirmation_receipt")]
        public string ConfirmationReceipt { get; set; }
    }
}
