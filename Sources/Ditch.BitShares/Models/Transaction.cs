using System;
using Ditch.BitShares.Models.Operations;
using Ditch.Core.Attributes;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     * @defgroup transactions Transactions
     *
     * All transactions are sets of operations that must be applied atomically. Transactions must refer to a recent
     * block that defines the context of the operation so that they assert a known binding to the object id's referenced
     * in the transaction.
     *
     * Rather than specify a full block number, we only specify the lower 16 bits of the block number which means you
     * can reference any block within the last 65,536 blocks which is 3.5 days with a 5 second block interval or 18
     * hours with a 1 second interval.
     *
     * All transactions must expire so that the network does not have to maintain a permanent record of all transactions
     * ever published.  A transaction may not have an expiration date too far in the future because this would require
     * keeping too much transaction history in memory.
     *
     * The block prefix is the first 4 bytes of the block hash of the reference block number, which is the second 4
     * bytes of the @ref block_id_type (the first 4 bytes of the block ID are the block number)
     *
     * Note: A transaction which selects a reference block cannot be migrated between forks outside the period of
     * ref_block_num.time to (ref_block_num.time + rel_exp * interval). This fact can be used to protect market orders
     * which should specify a relatively short re-org window of perhaps less than 1 minute. Normal payments should
     * probably have a longer re-org window to ensure their transaction can still go through in the event of a momentary
     * disruption in service.
     *
     * @note It is not recommended to set the @ref ref_block_num, @ref ref_block_prefix, and @ref expiration
     * fields manually. Call the appropriate overload of @ref set_expiration instead.
     *
     * @{
     */
    /**
     *  @brief groups operations that should be applied atomically
     */

    /// <summary>
    /// transaction
    /// libraries\chain\include\graphene\chain\protocol\transaction.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Transaction
    {
        [MessageOrder(10)]
        public byte[] ChainId { get; set; } = new byte[0]; //64

        /**
         * Least significant 16 bits from the reference block number. If @ref relative_expiration is zero, this field
         * must be zero as well.
         */

        /// <summary>
        /// API name: ref_block_num
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [MessageOrder(20)]
        [JsonProperty("ref_block_num")]
        public UInt16 RefBlockNum { get; set; }

        /**
         * The first non-block-number 32-bits of the reference block ID. Recall that block IDs have 32 bits of block
         * number followed by the actual block hash, so this field should be set using the second 32 bits in the
         * @ref block_id_type
         */

        /// <summary>
        /// API name: ref_block_prefix
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [MessageOrder(20)]
        [JsonProperty("ref_block_prefix")]
        public UInt32 RefBlockPrefix { get; set; }


        /**
         * This field specifies the absolute expiration for this transaction.
         */

        /// <summary>
        /// API name: expiration
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [MessageOrder(30)]
        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }

        /// <summary>
        /// API name: operations
        /// 
        /// </summary>
        /// <returns>API type: operation</returns>
        [JsonProperty("operations")]
        [MessageOrder(40)]
        public BaseOperation[] BaseOperations { get; set; }

        /// <summary>
        /// API name: extensions
        /// 
        /// </summary>
        /// <returns>API type: extensions_type</returns>
        [MessageOrder(50)]
        [JsonProperty("extensions")]
        public object[] Extensions { get; set; } = new object[0];
    }
}
