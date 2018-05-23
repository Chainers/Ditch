using Ditch.Core;
using System;
using System.Collections.Generic;
using Ditch.BitShares.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     *  When sending a stealth tranfer we assume users are unable to scan
     *  the full blockchain; therefore, payments require confirmation data
     *  to be passed out of band.   We assume this out-of-band channel is
     *  not secure and therefore the contents of the confirmation must be
     *  encrypted. 
     */

    /// <summary>
    /// stealth_confirmation
    /// libraries\chain\include\graphene\chain\protocol\confidential.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class StealthConfirmation
    {

        /// <summary>
        /// API name: one_time_key
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [JsonProperty("one_time_key")]
        public object OneTimeKey { get; set; }

        /// <summary>
        /// API name: to
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [JsonProperty("to", NullValueHandling = NullValueHandling.Ignore)]
        public object To { get; set; }

        /// <summary>
        /// API name: encrypted_memo
        /// 
        /// </summary>
        /// <returns>API type: char</returns>
        [JsonProperty("encrypted_memo")]
        public char[] EncryptedMemo { get; set; }
    }
}
