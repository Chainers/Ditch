using System;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// witness_object
    /// libraries\chain\include\graphene\chain\witness_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class WitnessObject : AbstractObject<WitnessObject>
    {

        /// <summary>
        /// API name: space_id
        /// = protocol_ids;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("space_id")]
        public byte SpaceId { get; set; }

        /// <summary>
        /// API name: type_id
        /// = witness_object_type;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("type_id")]
        public byte TypeId { get; set; }

        /// <summary>
        /// API name: witness_account
        /// 
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [JsonProperty("witness_account")]
        public AccountIdType WitnessAccount { get; set; }

        /// <summary>
        /// API name: last_aslot
        /// = 0;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("last_aslot")]
        public UInt64 LastAslot { get; set; }

        /// <summary>
        /// API name: signing_key
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [JsonProperty("signing_key")]
        public PublicKeyType SigningKey { get; set; }

        /// <summary>
        /// API name: pay_vb
        /// 
        /// </summary>
        /// <returns>API type: vesting_balance_id_type</returns>
        [JsonProperty("pay_vb", NullValueHandling = NullValueHandling.Ignore)]
        public object PayVb { get; set; }

        /// <summary>
        /// API name: vote_id
        /// 
        /// </summary>
        /// <returns>API type: vote_id_type</returns>
        [JsonProperty("vote_id")]
        public object VoteId { get; set; }

        /// <summary>
        /// API name: total_votes
        /// = 0;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("total_votes")]
        public UInt64 TotalVotes { get; set; }

        /// <summary>
        /// API name: url
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// API name: total_missed
        /// = 0;
        /// </summary>
        /// <returns>API type: int64_t</returns>
        [JsonProperty("total_missed")]
        public Int64 TotalMissed { get; set; }

        /// <summary>
        /// API name: last_confirmed_block_num
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("last_confirmed_block_num")]
        public UInt32 LastConfirmedBlockNum { get; set; }
    }
}
