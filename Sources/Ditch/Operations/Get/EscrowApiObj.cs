﻿using Newtonsoft.Json;

namespace Ditch.Operations.Get
{
    /// <summary>
    /// escrow_api_obj
    /// steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp
    /// golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class EscrowApiObj : EscrowObject
    {
    }
}
