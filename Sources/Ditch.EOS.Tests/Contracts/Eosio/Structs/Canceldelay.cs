using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Canceldelay
    {
        [JsonProperty("canceling_auth")]
        public PermissionLevel CancelingAuth {get; set;}

        [JsonProperty("trx_id")]
        public string TrxId {get; set;}

    }
}
