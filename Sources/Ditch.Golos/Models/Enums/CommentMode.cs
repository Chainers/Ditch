using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.Enums
{
    [JsonConverter(typeof(EnumConverter))]
    public enum CommentMode
    {
        FirstPayout,
        SecondPayout,
        Archived
    }
}