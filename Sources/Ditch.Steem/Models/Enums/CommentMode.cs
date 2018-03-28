using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Enums
{
    [JsonConverter(typeof(EnumConverter))]
    public enum CommentMode
    {
        FirstPayout,
        SecondPayout,
        Archived
    };
}