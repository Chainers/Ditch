using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Enums
{
    /// <summary>
    /// sort_order_type
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum SortOrderType
    {

        /// <summary>
        /// API name: by_name
        /// 
        /// </summary>
        ByName,

        /// <summary>
        /// API name: by_proxy
        /// 
        /// </summary>
        ByProxy,

        /// <summary>
        /// API name: by_next_vesting_withdrawal
        /// 
        /// </summary>
        ByNextVestingWithdrawal,

        /// <summary>
        /// API name: by_account
        /// 
        /// </summary>
        ByAccount,

        /// <summary>
        /// API name: by_expiration
        /// 
        /// </summary>
        ByExpiration,

        /// <summary>
        /// API name: by_effective_date
        /// 
        /// </summary>
        ByEffectiveDate,

        /// <summary>
        /// API name: by_vote_name
        /// 
        /// </summary>
        ByVoteName,

        /// <summary>
        /// API name: by_schedule_time
        /// 
        /// </summary>
        ByScheduleTime,

        /// <summary>
        /// API name: by_account_witness
        /// 
        /// </summary>
        ByAccountWitness,

        /// <summary>
        /// API name: by_witness_account
        /// 
        /// </summary>
        ByWitnessAccount,

        /// <summary>
        /// API name: by_from_id
        /// 
        /// </summary>
        ByFromId,

        /// <summary>
        /// API name: by_ratification_deadline
        /// 
        /// </summary>
        ByRatificationDeadline,

        /// <summary>
        /// API name: by_withdraw_route
        /// 
        /// </summary>
        ByWithdrawRoute,

        /// <summary>
        /// API name: by_destination
        /// 
        /// </summary>
        ByDestination,

        /// <summary>
        /// API name: by_complete_from_id
        /// 
        /// </summary>
        ByCompleteFromId,

        /// <summary>
        /// API name: by_to_complete
        /// 
        /// </summary>
        ByToComplete,

        /// <summary>
        /// API name: by_delegation
        /// 
        /// </summary>
        ByDelegation,

        /// <summary>
        /// API name: by_account_expiration
        /// 
        /// </summary>
        ByAccountExpiration,

        /// <summary>
        /// API name: by_conversion_date
        /// 
        /// </summary>
        ByConversionDate,

        /// <summary>
        /// API name: by_cashout_time
        /// 
        /// </summary>
        ByCashoutTime,

        /// <summary>
        /// API name: by_permlink
        /// 
        /// </summary>
        ByPermlink,

        /// <summary>
        /// API name: by_root
        /// 
        /// </summary>
        ByRoot,

        /// <summary>
        /// API name: by_parent
        /// 
        /// </summary>
        ByParent,

        /// <summary>
        /// API name: by_last_update
        /// 
        /// </summary>
        ByLastUpdate,

        /// <summary>
        /// API name: by_author_last_update
        /// 
        /// </summary>
        ByAuthorLastUpdate,

        /// <summary>
        /// API name: by_comment_voter
        /// 
        /// </summary>
        ByCommentVoter,

        /// <summary>
        /// API name: by_voter_comment
        /// 
        /// </summary>
        ByVoterComment,

        /// <summary>
        /// API name: by_voter_last_update
        /// 
        /// </summary>
        ByVoterLastUpdate,

        /// <summary>
        /// API name: by_comment_weight_voter
        /// 
        /// </summary>
        ByCommentWeightVoter,

        /// <summary>
        /// API name: by_price
        /// 
        /// </summary>
        ByPrice
    }
}
