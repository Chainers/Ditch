using Ditch.Core;
using System;
using System.Collections.Generic; 
using Ditch.Steem.Objects;
using Newtonsoft.Json;

namespace Ditch.Steem.Objects
{
    /// <summary>
    /// get_replies_by_last_update_return
    /// libraries\plugins\apis\tags_api\include\steem\plugins\tags_api\tags_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GetRepliesByLastUpdateReturn : DiscussionQueryResult
    {
    }
}
