using System;
using Ditch.Steem.Old.Models.Other;
using Newtonsoft.Json;

namespace Ditch.Steem.Old.Models.Objects
{
    /// <summary>
    /// Shows an overview of various information regarding the current state of the STEEM network.
    /// dynamic_global_property_object
    /// steem-0.19.1\libraries\chain\include\steemit\chain\global_property_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class DynamicGlobalPropertyObject
    {
        // bdType : id_type
        [JsonProperty("id")]
        public string Id { get; set; }

        // bdType : uint32_t | = 0;
        [JsonProperty("head_block_number")]
        public uint HeadBlockNumber { get; set; }

        //block_id_type
        [JsonProperty("head_block_id")]
        public string HeadBlockId { get; set; }

        // bdType : time_point_sec
        [JsonProperty("time")]
        public DateTime Time { get; set; }
    }
}