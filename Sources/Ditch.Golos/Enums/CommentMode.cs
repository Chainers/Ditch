using Ditch.Core.Helpers;
using Newtonsoft.Json;

namespace Ditch.Golos.Enums
{
    [JsonConverter(typeof(EnumConverter))]
    public enum CommentMode
    {
        FirstPayout,
        SecondPayout,
        Archived
    }
}