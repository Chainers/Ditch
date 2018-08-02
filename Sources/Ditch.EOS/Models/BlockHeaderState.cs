using Ditch.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// block_header_state
    /// libraries\chain\include\eosio\chain\block_header_state.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class BlockHeaderState
    {
        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: block_id_type</returns>
        [JsonProperty("id")]
        public object Id { get; set; }

        /// <summary>
        /// API name: block_num
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("block_num")]
        public uint BlockNum { get; set; }

        /// <summary>
        /// API name: header
        /// 
        /// </summary>
        /// <returns>API type: signed_block_header</returns>
        [JsonProperty("header")]
        public SignedBlockHeader Header { get; set; }

        /// <summary>
        /// API name: dpos_proposed_irreversible_blocknum
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("dpos_proposed_irreversible_blocknum")]
        public uint DposProposedIrreversibleBlocknum { get; set; }

        /// <summary>
        /// API name: dpos_irreversible_blocknum
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("dpos_irreversible_blocknum")]
        public uint DposIrreversibleBlocknum { get; set; }

        /// <summary>
        /// API name: bft_irreversible_blocknum
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("bft_irreversible_blocknum")]
        public uint BftIrreversibleBlocknum { get; set; }

        /// <summary>
        /// API name: pending_schedule_lib_num
        /// = 0; /// last irr block num
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("pending_schedule_lib_num")]
        public uint PendingScheduleLibNum { get; set; }

        /// <summary>
        /// API name: pending_schedule_hash
        /// 
        /// </summary>
        /// <returns>API type: digest_type</returns>
        [JsonProperty("pending_schedule_hash")]
        public object PendingScheduleHash { get; set; }

        /// <summary>
        /// API name: pending_schedule
        /// 
        /// </summary>
        /// <returns>API type: producer_schedule_type</returns>
        [JsonProperty("pending_schedule")]
        public object PendingSchedule { get; set; }

        /// <summary>
        /// API name: active_schedule
        /// 
        /// </summary>
        /// <returns>API type: producer_schedule_type</returns>
        [JsonProperty("active_schedule")]
        public object ActiveSchedule { get; set; }

        /// <summary>
        /// API name: blockroot_merkle
        /// 
        /// </summary>
        /// <returns>API type: incremental_merkle</returns>
        [JsonProperty("blockroot_merkle")]
        public object BlockrootMerkle { get; set; }

        /// <summary>
        /// API name: producer_to_last_produced
        /// 
        /// </summary>
        /// <returns>API type: flat_map</returns>
        [JsonProperty("producer_to_last_produced")]
        public MapContainer<AccountName, uint> ProducerToLastProduced { get; set; }

        /// <summary>
        /// API name: producer_to_last_implied_irb
        /// 
        /// </summary>
        /// <returns>API type: flat_map</returns>
        [JsonProperty("producer_to_last_implied_irb")]
        public MapContainer<AccountName, uint> ProducerToLastImpliedIrb { get; set; }

        /// <summary>
        /// API name: block_signing_key
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [JsonProperty("block_signing_key")]
        public PublicKeyType BlockSigningKey { get; set; }

        /// <summary>
        /// API name: confirm_count
        /// 
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("confirm_count")]
        public byte[] ConfirmCount { get; set; }

        /// <summary>
        /// API name: confirmations
        /// 
        /// </summary>
        /// <returns>API type: header_confirmation</returns>
        [JsonProperty("confirmations")]
        public HeaderConfirmation[] Confirmations { get; set; }
    }
}