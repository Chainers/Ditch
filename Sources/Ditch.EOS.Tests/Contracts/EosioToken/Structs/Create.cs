using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.EosioToken.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Create
    {
        [JsonProperty("issuer")]
        public BaseName Issuer {get; set;}

        [JsonProperty("maximum_supply")]
        public Asset MaximumSupply {get; set;}

    }
}
