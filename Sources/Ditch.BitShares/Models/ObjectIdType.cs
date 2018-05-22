using Ditch.Core;
using System;
using System.Collections.Generic; 
using Ditch.BitShares.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// object_id_type
    /// libraries\db\include\graphene\db\object_id.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ObjectIdType
    {

        /// <summary>
        /// API name: number
        /// 
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("number")]
        public UInt64 Number {get; set;}
    }
}
