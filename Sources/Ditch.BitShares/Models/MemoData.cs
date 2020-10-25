using System;
using System.IO;
using System.Security.Cryptography;
using Ditch.Core.Attributes;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     *  @brief defines the keys used to derive the shared secret
     *
     *  Because account authorities and keys can change at any time, each memo must
     *  capture the specific keys used to derive the shared secret.  In order to read
     *  the cipher message you will need one of the two private keys.
     *
     *  If @ref from == @ref to and @ref from == 0 then no encryption is used, the memo is public.
     *  If @ref from == @ref to and @ref from != 0 then invalid memo data
     *
     */

    /// <summary>
    /// memo_data
    /// libraries\protocol\include\graphene\protocol\memo.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class MemoData
    {

        /// <summary>
        /// API name: from
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [MessageOrder(10)]
        [JsonProperty("from")]
        public PublicKeyType From { get; set; }

        /// <summary>
        /// API name: to
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [MessageOrder(20)]
        [JsonProperty("to")]
        public PublicKeyType To { get; set; }

        /// <summary>
        /// API name: nonce
        /// = 0;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [MessageOrder(30)]
        [JsonProperty("nonce")]
        public ulong Nonce { get; set; }

        /// <summary>
        /// API name: message
        /// 
        /// </summary>
        /// <returns>API type: char</returns>
        [MessageOrder(40)]
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
