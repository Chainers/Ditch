﻿using System;
using Newtonsoft.Json;

namespace Ditch.Operations.Get
{
    /// <summary>
    /// Shows an overview of various information regarding the current state of the STEEM network.
    /// dynamic_global_property_api_obj
    /// steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class DynamicGlobalPropertyApiObj : DynamicGlobalPropertyObject
    {
        public static readonly DynamicGlobalPropertyApiObj Default = new DynamicGlobalPropertyApiObj { HeadBlockId = "0000000000000000000000000000000000000000", Time = DateTime.Now, HeadBlockNumber = 0 };

        // bdType : uint32_t | = 0;
        [JsonProperty("current_reserve_ratio")]
        public new UInt32 CurrentReserveRatio { get; set; }

        // bdType : uint64_t | = 0;
        [JsonProperty("average_block_size")]
        public new UInt64 AverageBlockSize { get; set; }

        // bdType : uint128_t | = 0;
        [JsonProperty("max_virtual_bandwidth")]
        public new string MaxVirtualBandwidth { get; set; }
    }
}