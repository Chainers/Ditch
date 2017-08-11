﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ditch.Operations.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FollowType
    {
        //[EnumMember(Value = "undefined")]
        undefined,
        //[EnumMember(Value = "blog")]
        blog,
        //[EnumMember(Value = "ignore")]
        ignore
    };
}