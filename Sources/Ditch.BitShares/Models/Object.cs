using Ditch.Core;
using System;
using System.Collections.Generic;
using Ditch.BitShares.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     *  @brief base for all database objects
     *
     *  The object is the fundamental building block of the database and
     *  is the level upon which undo/redo operations are performed.  Objects
     *  are used to track data and their relationships and provide an effecient
     *  means to find and update information.
     *
     *  Objects are assigned a unique and sequential object ID by the database within
     *  the id_space defined in the object.
     *
     *  All objects must be serializable via FC_REFLECT() and their content must be
     *  faithfully restored.   Additionally all objects must be copy-constructable and
     *  assignable in a relatively efficient manner.  In general this means that objects
     *  should only refer to other objects by ID and avoid expensive operations when
     *  they are copied, especially if they are modified frequently.
     *
     *  Additionally all objects may be annotated by plugins which wish to maintain
     *  additional information to an object.  There can be at most one annotation
     *  per id_space for each object.   An example of an annotation would be tracking
     *  extra data not required by validation such as the name and description of
     *  a user asset.  By carefully organizing how information is organized and
     *  tracked systems can minimize the workload to only that which is necessary
     *  to perform their function.
     *
     *  @note Do not use multiple inheritance with object because the code assumes
     *  a static_cast will work between object and derived types.
     */

    /// <summary>
    /// object
    /// libraries\db\include\graphene\db\object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Object
    {

        /// <summary>
        /// API name: space_id
        /// = 0;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("space_id")]
        public byte SpaceId { get; set; }

        /// <summary>
        /// API name: type_id
        /// = 0;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("type_id")]
        public byte TypeId { get; set; }



        // serialized

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: object_id_type</returns>
        [JsonProperty("id")]
        public ObjectIdType Id { get; set; }
    }
}
