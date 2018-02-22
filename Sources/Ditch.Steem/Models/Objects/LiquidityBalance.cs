using Newtonsoft.Json;

namespace Ditch.Steem.Models.Objects
{

    [JsonObject(MemberSerialization.OptIn)]
    public partial class LiquidityBalance
    {
        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }
    }
}