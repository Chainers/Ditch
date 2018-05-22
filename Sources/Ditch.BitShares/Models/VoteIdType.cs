using Ditch.Core;
using System;
using System.Collections.Generic;
using Ditch.BitShares.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     * @brief An ID for some votable object
     *
     * This class stores an ID for a votable object. The ID is comprised of two fields: a type, and an instance. The
     * type field stores which kind of object is being voted on, and the instance stores which specific object of that
     * type is being referenced by this ID.
     *
     * A value of vote_id_type is implicitly convertible to an unsigned 32-bit integer containing only the instance. It
     * may also be implicitly assigned from a uint32_t, which will update the instance. It may not, however, be
     * implicitly constructed from a uint32_t, as in this case, the type would be unknown.
     *
     * On the wire, a vote_id_type is represented as a 32-bit integer with the type in the lower 8 bits and the instance
     * in the upper 24 bits. This means that types may never exceed 8 bits, and instances may never exceed 24 bits.
     *
     * In JSON, a vote_id_type is represented as a string "type:instance", i.e. "1:5" would be type 1 and instance 5.
     *
     * @note In the Graphene protocol, vote_id_type instances are unique across types; that is to say, if an object of
     * type 1 has instance 4, an object of type 0 may not also have instance 4. In other words, the type is not a
     * namespace for instances; it is only an informational field.
     */

    /// <summary>
    /// vote_id_type
    /// libraries\chain\include\graphene\chain\protocol\vote.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class VoteIdType
    {

        /// Lower 8 bits are type; upper 24 bits are instance

        /// <summary>
        /// API name: content
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("content")]
        public UInt32 Content { get; set; }
    }
}
