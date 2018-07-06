using System;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// escrow_object
    /// libraries\chain\include\golos\chain\steem_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class EscrowObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: id_type</returns>
        [JsonProperty("id")]
        public object Id { get; set; }

        /// <summary>
        /// API name: escrow_id
        /// = 20;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("escrow_id")]
        public UInt32 EscrowId {get; set;}

        /// <summary>
        /// API name: from
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// API name: to
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// API name: agent
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("agent")]
        public string Agent { get; set; }

        /// <summary>
        /// API name: ratification_deadline
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("ratification_deadline")]
        public TimePointSec RatificationDeadline { get; set; }

        /// <summary>
        /// API name: escrow_expiration
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("escrow_expiration")]
        public TimePointSec EscrowExpiration { get; set; }

        /// <summary>
        /// API name: sbd_balance
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("sbd_balance")]
        public Asset SbdBalance { get; set; }

        /// <summary>
        /// API name: steem_balance
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("steem_balance")]
        public Asset SteemBalance { get; set; }

        /// <summary>
        /// API name: pending_fee
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("pending_fee")]
        public Asset PendingFee { get; set; }

        /// <summary>
        /// API name: to_approved
        /// = false;
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("to_approved")]
        public bool ToApproved { get; set; }

        /// <summary>
        /// API name: agent_approved
        /// = false;
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("agent_approved")]
        public bool AgentApproved { get; set; }

        /// <summary>
        /// API name: disputed
        /// = false;
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("disputed")]
        public bool Disputed { get; set; }
    }
}