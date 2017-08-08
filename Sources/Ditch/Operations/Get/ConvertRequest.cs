using System;
using Newtonsoft.Json;

namespace Ditch.Operations.Get
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ConvertRequest
    {
        [JsonProperty("id")]
        public UInt64 Id { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("requestid")]
        public UInt32 Requestid { get; set; }

        [JsonProperty("amount")]
        public Money Amount { get; set; }

        [JsonProperty("conversion_date")]
        public DateTime ConversionDate { get; set; }
    }
}
