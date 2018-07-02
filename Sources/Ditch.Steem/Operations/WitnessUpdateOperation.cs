using Ditch.Core.Attributes;
using Ditch.Steem.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Operations
{


    /// <summary>
    /// witness_update_operation
    /// libraries\protocol\include\steem\protocol\steem_operations.hpp
    /// 
    /// Users who wish to become a witness must pay a fee acceptable to the current witnesses to apply for the position and allow voting to begin.
    /// 
    /// If the owner isn't a witness they will become a witness.  Witnesses are charged a fee equal to 1 weeks worth of witness pay which in turn is derived from the current share supply.  The fee is only applied if the owner is not already a witness.
    /// 
    /// If the block_signing_key is null then the witness is removed from contention.The network will pick the top 21 witnesses for producing blocks.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class WitnessUpdateOperation : BaseOperation
    {
        public const string OperationName = "witness_update_operation";
        public override string TypeName => OperationName;

        public override OperationType Type => OperationType.WitnessUpdate;

        /// <summary>
        /// API name: owner
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(20)]
        [JsonProperty("owner")]
        public string Owner { get; set; }

        /// <summary>
        /// API name: url
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [MessageOrder(30)]
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// API name: block_signing_key
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [MessageOrder(40)]
        [JsonProperty("block_signing_key")]
        public PublicKeyType BlockSigningKey { get; set; }

        /// <summary>
        /// API name: props
        /// 
        /// </summary>
        /// <returns>API type: legacy_chain_properties</returns>
        [MessageOrder(50)]
        [JsonProperty("props")]
        public LegacyChainProperties Props { get; set; }

        /// <summary>
        /// API name: fee
        /// the fee paid to register a new witness, should be 10x current block production pay
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(60)]
        [JsonProperty("fee")]
        public Asset Fee { get; set; }

        public WitnessUpdateOperation(string owner, string url, PublicKeyType blockSigningKey, LegacyChainProperties props, Asset fee)
        {
            Owner = owner;
            Url = url;
            BlockSigningKey = blockSigningKey;
            Props = props;
            Fee = fee;
        }
    }
}