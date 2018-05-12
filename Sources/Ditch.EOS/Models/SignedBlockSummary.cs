using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /**
     *  The block_summary defines the set of transactions that were successfully applied as they
     *  are organized into cycles and shards. A shard contains the set of transactions IDs which
     *  are either user generated transactions or code-generated transactions.
     *
     *
     *  The primary purpose of a block is to define the order in which messages are processed.
     *
     *  The secodnary purpose of a block is certify that the messages are valid according to
     *  a group of 3rd party validators (producers).
     *
     *  The next purpose of a block is to enable light-weight proofs that a transaction occured
     *  and was considered valid.
     *
     *  The next purpose is to enable code to generate messages that are certified by the
     *  producers to be authorized.
     *
     *  A block is therefore defined by the ordered set of executed and generated transactions,
     *  and the merkle proof is over set of messages delivered as a result of executing the
     *  transactions.
     *
     *  A message is defined by { receiver, code, function, permission, data }, the merkle
     *  tree of a block should be generated over a set of message IDs rather than a set of
     *  transaction ids.
     */

    /// <summary>
    /// signed_block_summary
    /// libraries\chain\include\eosio\chain\block.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class SignedBlockSummary : SignedBlockHeader
    {

        /// <summary>
        /// API name: regions
        /// 
        /// </summary>
        /// <returns>API type: region_summary</returns>
        [JsonProperty("regions")]
        public RegionSummary[] Regions { get; set; }
    }
}
