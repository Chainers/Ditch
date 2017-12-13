using Newtonsoft.Json;

namespace Ditch.Golos.Objects
{
    /// <summary>
    /// signed_block
    /// golos-0.16.3\libraries\protocol\include\steemit\protocol\block.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SignedBlock : SignedBlockHeader
    {
        // bdType : vector<signed_transaction>
        [JsonProperty("transactions")]
        public object[] Transactions { get; set; }
    }
}