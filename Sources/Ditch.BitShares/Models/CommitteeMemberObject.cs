using System;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     *  @brief tracks information about a committee_member account.
     *  @ingroup object
     *
     *  A committee_member is responsible for setting blockchain parameters and has
     *  dynamic multi-sig control over the committee account.  The current set of
     *  active committee_members has control.
     *
     *  committee_members were separated into a separate object to make iterating over
     *  the set of committee_member easy.
     */

    /// <summary>
    /// committee_member_object
    /// libraries\chain\include\graphene\chain\committee_member_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class CommitteeMemberObject : AbstractObject<CommitteeMemberObject>
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
        /// = committee_member_object_type;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("type_id")]
        public byte TypeId { get; set; }

        /// <summary>
        /// API name: committee_member_account
        /// 
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [JsonProperty("committee_member_account")]
        public object CommitteeMemberAccount { get; set; }

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
    }
}
