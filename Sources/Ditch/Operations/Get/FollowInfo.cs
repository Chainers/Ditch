using System;
using Ditch.Operations.Post;
using Newtonsoft.Json;

namespace Ditch.Operations.Get
{
    [JsonObject(MemberSerialization.OptIn)]
    public class FollowInfo
    {
        public const string Api = "follow_api";

        [JsonProperty("follower")]
        public string Follower { get; set; }

        [JsonProperty("following")]
        public string Following { get; set; }

        [JsonProperty("what")]
        public string[] What { get; set; }

        public FollowType FollowType
        {
            get
            {
                var rez = FollowType.Undefined;
                for (var i = 0; i < What.Length; i++)
                {
                    var itm = What[i];
                    FollowType buf;
                    if (Enum.TryParse(itm, true, out buf))
                    {
                        rez |= buf;
                    }
                }
                return rez;
            }
        }
    }
}