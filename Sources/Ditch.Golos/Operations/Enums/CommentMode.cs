using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ditch.Golos.Operations.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CommentMode
    {
        //[EnumMember(Value = "first_payout")]
        first_payout,
        //[EnumMember(Value = "second_payout")]
        second_payout,
        //[EnumMember(Value = "archived")]
        archived
    };
}