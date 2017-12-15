using System;
using Ditch.Core;
using Newtonsoft.Json;

namespace Ditch.Steem.Objects
{
    /// <summary>
    /// escrow_object
    /// steem-0.19.1\libraries\chain\include\steemit\chain\steem_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class EscrowObject
    {

        // bdType : id_type
        [JsonProperty("id")]
        public object Id { get; set; }

        // bdType : uint32_t | = 20;
        [JsonProperty("escrow_id")]
        public UInt32 EscrowId { get; set; }

        // bdType : account_name_type
        [JsonProperty("from")]
        public string From { get; set; }

        // bdType : account_name_type
        [JsonProperty("to")]
        public string To { get; set; }

        // bdType : account_name_type
        [JsonProperty("agent")]
        public string Agent { get; set; }

        // bdType : time_point_sec
        [JsonProperty("ratification_deadline")]
        public DateTime RatificationDeadline { get; set; }

        // bdType : time_point_sec
        [JsonProperty("escrow_expiration")]
        public DateTime EscrowExpiration { get; set; }

        // bdType : asset
        [JsonProperty("sbd_balance")]
        public Asset SbdBalance { get; set; }

        // bdType : asset
        [JsonProperty("steem_balance")]
        public Asset SteemBalance { get; set; }

        // bdType : asset
        [JsonProperty("pending_fee")]
        public Asset PendingFee { get; set; }

        // bdType : bool | = false;
        [JsonProperty("to_approved")]
        public bool ToApproved { get; set; }

        // bdType : bool | = false;
        [JsonProperty("agent_approved")]
        public bool AgentApproved { get; set; }

        // bdType : bool | = false;
        [JsonProperty("disputed")]
        public bool Disputed { get; set; }
    }

}