using Ditch.Core.Helpers;
using Newtonsoft.Json;

namespace Ditch.Steem.Enums
{
    [JsonConverter(typeof(EnumConverter))]
    public enum CommentMode
    {
        FirstPayout,
        SecondPayout,
        Archived
    };
}