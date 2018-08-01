using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Setramrate
    {
        [JsonProperty("bytes_per_block")]
        public ushort BytesPerBlock {get; set;}

    }
}
