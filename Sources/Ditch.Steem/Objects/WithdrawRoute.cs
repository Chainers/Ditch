using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Objects
{
    /// <summary>
    /// withdraw_route
    /// steem-0.19.1\libraries\app\include\steemit\app\database_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class WithdrawRoute
    {

        // bdType : string
        [JsonProperty("from_account")]
        public string FromAccount { get; set; }

        // bdType : string
        [JsonProperty("to_account")]
        public string ToAccount { get; set; }

        // bdType : uint16_t
        [JsonProperty("percent")]
        public UInt16 Percent { get; set; }

        // bdType : bool
        [JsonProperty("auto_vest")]
        public bool AutoVest { get; set; }
    }

}
