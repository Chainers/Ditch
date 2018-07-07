using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// immutable_chain_parameters
    /// libraries\chain\include\graphene\chain\immutable_chain_parameters.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ImmutableChainParameters
    {

        /// <summary>
        /// API name: min_committee_member_count
        /// = GRAPHENE_DEFAULT_MIN_COMMITTEE_MEMBER_COUNT;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("min_committee_member_count")]
        public ushort MinCommitteeMemberCount { get; set; }

        /// <summary>
        /// API name: min_witness_count
        /// = GRAPHENE_DEFAULT_MIN_WITNESS_COUNT;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("min_witness_count")]
        public ushort MinWitnessCount { get; set; }

        /// <summary>
        /// API name: num_special_accounts
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("num_special_accounts")]
        public uint NumSpecialAccounts { get; set; }

        /// <summary>
        /// API name: num_special_assets
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("num_special_assets")]
        public uint NumSpecialAssets { get; set; }
    }
}
