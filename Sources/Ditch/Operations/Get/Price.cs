﻿using Newtonsoft.Json;

namespace Ditch.Operations.Get
{
    /// <summary>
    /// price
    /// steem-0.19.1\libraries\protocol\include\steemit\protocol\asset.hpp
    /// golos-0.16.3\libraries\protocol\include\steemit\protocol\asset.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Price
    {

        // bdType : asset
        [JsonProperty("base")]
        public Money Base { get; set; }

        // bdType : asset
        [JsonProperty("quote")]
        public Money Quote { get; set; }
    }
}