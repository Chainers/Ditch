using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Onerror
    {
        [JsonProperty("sender_id")]
        public UInt128 SenderId {get; set;}

        [JsonProperty("sent_trx")]
        public Bytes SentTrx {get; set;}

    }
}
