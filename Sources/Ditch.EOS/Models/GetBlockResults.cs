using System;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    public class GetBlockResults : SignedBlock
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("block_num")]
        public UInt32 BlockNum { get; set; }

        [JsonProperty("ref_block_prefix")]
        public UInt32 RefBlockPrefix { get; set; }
    }
}
