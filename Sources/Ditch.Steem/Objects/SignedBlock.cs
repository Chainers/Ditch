using Newtonsoft.Json;

namespace Ditch.Steem.Objects
{
    /// <summary>
    /// signed_block
    /// steem-0.19.1\libraries\protocol\include\steemit\protocol\block.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SignedBlock : SignedBlockHeader
    {
        // bdType : vector<signed_transaction>
        [JsonProperty("transactions")]
        public object[] Transactions { get; set; }
    }
}