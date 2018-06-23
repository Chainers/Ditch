using Ditch.Core.Attributes;
using Ditch.Golos.Models;
using Newtonsoft.Json;

namespace Ditch.Golos.Operations
{
    [JsonObject(MemberSerialization.OptIn)]
    public class WitnessUpdateOperation : BaseOperation
    {
        public override OperationType Type => OperationType.WitnessUpdate;

        public override string TypeName => "witness_update";

        [MessageOrder(20)]
        [JsonProperty("owner")]
        public string Owner { get; set; }

        [MessageOrder(30)]
        [JsonProperty("url")]
        public string Url { get; set; }

        [MessageOrder(40)]
        [JsonProperty("block_signing_key")]
        public PublicKeyType BlockSigningKey { get; set; }

        [MessageOrder(50)]
        [JsonProperty("props")]
        public ChainApiProperties Props { get; set; }

        [MessageOrder(60)]
        [JsonProperty("fee")]
        public Asset Fee { get; set; }


        public WitnessUpdateOperation(string owner, string url, PublicKeyType blockSigningKey, ChainApiProperties props, Asset fee)
        {
            Owner = owner;
            Url = url;
            BlockSigningKey = blockSigningKey;
            Props = props;
            Fee = fee;
        }
    }
}