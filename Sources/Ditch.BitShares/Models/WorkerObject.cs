using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     * @brief Worker object contains the details of a blockchain worker. See @ref workers for details.
     */

    /// <summary>
    /// worker_object
    /// libraries\chain\include\graphene\chain\worker_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class WorkerObject
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
        /// = worker_object_type;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("type_id")]
        public byte TypeId { get; set; }


        /// ID of the account which owns this worker

        /// <summary>
        /// API name: worker_account
        /// 
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [JsonProperty("worker_account")]
        public AccountIdType WorkerAccount { get; set; }

        /// Time at which this worker begins receiving pay, if elected

        /// <summary>
        /// API name: work_begin_date
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("work_begin_date")]
        public TimePointSec WorkBeginDate { get; set; }

        /// Time at which this worker will cease to receive pay. Worker will be deleted at this time

        /// <summary>
        /// API name: work_end_date
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("work_end_date")]
        public TimePointSec WorkEndDate { get; set; }

        /// Amount in CORE this worker will be paid each day

        /// <summary>
        /// API name: daily_pay
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("daily_pay")]
        public object DailyPay { get; set; }

        /// ID of this worker's pay balance

        /// <summary>
        /// API name: worker
        /// 
        /// </summary>
        /// <returns>API type: worker_type</returns>
        [JsonProperty("worker")]
        public object Worker { get; set; }

        /// Human-readable name for the worker

        /// <summary>
        /// API name: name
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// URL to a web page representing this worker

        /// <summary>
        /// API name: url
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("url")]
        public string Url { get; set; }


        /// Voting ID which represents approval of this worker

        /// <summary>
        /// API name: vote_for
        /// 
        /// </summary>
        /// <returns>API type: vote_id_type</returns>
        [JsonProperty("vote_for")]
        public object VoteFor { get; set; }

        /// Voting ID which represents disapproval of this worker

        /// <summary>
        /// API name: vote_against
        /// 
        /// </summary>
        /// <returns>API type: vote_id_type</returns>
        [JsonProperty("vote_against")]
        public object VoteAgainst { get; set; }

        /// <summary>
        /// API name: total_votes_for
        /// = 0;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("total_votes_for")]
        public ulong TotalVotesFor { get; set; }

        /// <summary>
        /// API name: total_votes_against
        /// = 0;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("total_votes_against")]
        public ulong TotalVotesAgainst { get; set; }
    }
}
