using System;
using Ditch.Core.Attributes;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// These are the fields which can be updated by the active authority.

    /// <summary>
    /// account_options
    /// libraries\chain\include\graphene\chain\protocol\account.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class AccountOptions
    {

        /// The memo key is the key this account will typically use to encrypt/sign transaction memos and other non-
        /// validated account activities. This field is here to prevent confusion if the active authority has zero or
        /// multiple keys in it.

        /// <summary>
        /// API name: memo_key
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [MessageOrder(10)]
        [JsonProperty("memo_key")]
        public PublicKeyType MemoKey { get; set; }

        /// If this field is set to an account ID other than GRAPHENE_PROXY_TO_SELF_ACCOUNT,
        /// then this account's votes will be ignored; its stake
        /// will be counted as voting for the referenced account's selected votes instead.

        /// <summary>
        /// API name: voting_account
        /// = GRAPHENE_PROXY_TO_SELF_ACCOUNT;
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [MessageOrder(20)]
        [JsonProperty("voting_account")]
        public AccountIdType VotingAccount { get; set; }


        /// The number of active witnesses this account votes the blockchain should appoint
        /// Must not exceed the actual number of witnesses voted for in @ref votes

        /// <summary>
        /// API name: num_witness
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [MessageOrder(30)]
        [JsonProperty("num_witness")]
        public UInt16 NumWitness { get; set; }

        /// The number of active committee members this account votes the blockchain should appoint
        /// Must not exceed the actual number of committee members voted for in @ref votes

        /// <summary>
        /// API name: num_committee
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [MessageOrder(40)]
        [JsonProperty("num_committee")]
        public UInt16 NumCommittee { get; set; }

        /// This is the list of vote IDs this account votes for. The weight of these votes is determined by this
        /// account's balance of core asset.

        /// <summary>
        /// API name: votes
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [MessageOrder(50)]
        [JsonProperty("votes")]
        public object[] Votes { get; set; }

        /// <summary>
        /// API name: extensions
        /// 
        /// </summary>
        /// <returns>API type: extensions_type</returns>
        [MessageOrder(60)]
        [JsonProperty("extensions")]
        public object[] Extensions { get; set; }
    }
}
